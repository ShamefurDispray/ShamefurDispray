using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

static class SigCheck
{
    static readonly HashSet<string> Specials = new HashSet<string>
    {
        "__instance", "__result", "__state", "__originalMethod", "__args", "__runOriginal",
        "__resultRef", "___" 
    };

    public static int Run(Assembly game, Assembly mod)
    {
        int problems = 0;
        foreach (var t in mod.GetTypes())
        {
            var cad = t.GetCustomAttributesData().FirstOrDefault(c => c.AttributeType.FullName == "HarmonyLib.HarmonyPatch");
            if (cad == null) continue;
            Type decl = null; string mname = null;
            foreach (var a in cad.ConstructorArguments)
            {
                if (a.ArgumentType == typeof(Type)) decl = a.Value as Type;
                else if (a.ArgumentType == typeof(string) && mname == null) mname = a.Value as string;
            }
            if (decl == null) continue;
            var targets = decl.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(m => mname == null || m.Name == mname).ToList();
            foreach (var tm in targets)
            {
                var tparams = tm.GetParameters();
                foreach (var pm in t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly))
                {
                    if (pm.Name != "Prefix" && pm.Name != "Postfix" && pm.Name != "Finalizer") continue;
                    foreach (var p in pm.GetParameters())
                    {
                        if (Specials.Contains(p.Name) || p.Name.StartsWith("___")) continue;
                        var tp = tparams.FirstOrDefault(x => x.Name == p.Name);
                        if (tp == null)
                        {
                            Console.WriteLine($"BAD PARAM {t.Name}.{pm.Name}: '{p.Name}' is not a parameter of {decl.Name}.{tm.Name}({string.Join(", ", tparams.Select(x => x.Name))})");
                            problems++;
                            continue;
                        }
                        if (tp.ParameterType != p.ParameterType && tp.ParameterType.MakeByRefType() != p.ParameterType)
                        {
                            Console.WriteLine($"BAD TYPE {t.Name}.{pm.Name}: param '{p.Name}' is {p.ParameterType.Name}, target has {tp.ParameterType.Name}");
                            problems++;
                        }
                    }
                }
            }
        }
        Console.WriteLine("signature problems: " + problems);
        return problems;
    }
}
