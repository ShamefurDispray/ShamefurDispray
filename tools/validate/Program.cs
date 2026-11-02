using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

class Program
{
    static string Managed = Environment.GetEnvironmentVariable("MANAGED_DIR") ?? "/workspace/managed/Managed";

    static int Main(string[] args)
    {
        AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
        {
            var name = new AssemblyName(e.Name).Name + ".dll";
            var p = Path.Combine(Managed, name);
            return File.Exists(p) ? Assembly.LoadFrom(p) : null;
        };
        var game = Assembly.LoadFrom(Path.Combine(Managed, "Assembly-CSharp.dll"));
        var mod = Assembly.LoadFrom(args[0]);
        int bad = 0, ok = 0;
        foreach (var t in mod.GetTypes())
        {
            foreach (var cad in t.GetCustomAttributesData())
            {
                if (cad.AttributeType.FullName != "HarmonyLib.HarmonyPatch") continue;
                Type decl = null; string mname = null;
                var cargs = cad.ConstructorArguments;
                foreach (var a in cargs)
                {
                    if (a.ArgumentType == typeof(Type)) decl = a.Value as Type;
                    else if (a.ArgumentType == typeof(string) && mname == null) mname = a.Value as string;
                }
                if (decl == null && mname != null && cargs.Count > 0 && cargs[0].ArgumentType == typeof(string))
                    decl = game.GetType(mname);
                var nameArg = cargs.Where(a => a.ArgumentType == typeof(string)).Select(a => a.Value as string).FirstOrDefault();
                string target = nameArg ?? mname;
                if (decl == null)
                {
                    Console.WriteLine($"MISSING TYPE  {t.Name} -> {target}");
                    bad++;
                    continue;
                }
                var methods = decl.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)
                    .Where(m => target == null || m.Name == target).ToList();
                if (methods.Count == 0)
                {
                    Console.WriteLine($"MISSING METHOD {t.Name} -> {decl.Name}.{target}");
                    bad++;
                }
                else ok++;
            }
        }
        Console.WriteLine($"patched targets ok={ok} bad={bad}");
        Console.WriteLine("references: " + string.Join(", ", mod.GetReferencedAssemblies().Select(a => a.Name)));
        var imods = mod.GetTypes().Where(t => t.GetInterfaces().Any(i => i.FullName == "IMod")).Select(t => t.FullName);
        Console.WriteLine("IMod implementations: " + string.Join(", ", imods));
        var nlg = game.GetType("NewGameData");
        var him = nlg?.GetMethod("HandleInitialItem", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static, null, Type.EmptyTypes, null);
        Console.WriteLine("NewGameData.HandleInitialItem(): " + (him != null));
        bad += SigCheck.Run(game, mod);
        if (args.Length > 1 && args[1] == "patchall")
        {
            try
            {
                var h = new HarmonyLib.Harmony("mod.PerkShopFramework");
                h.PatchAll(mod);
                Console.WriteLine("PatchAll: OK, patched " + h.GetPatchedMethods().Count() + " method(s)");
                h.UnpatchAll(h.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("PatchAll: FAILED " + ex);
                bad++;
            }
        }
        return bad == 0 ? 0 : 1;
    }
}
