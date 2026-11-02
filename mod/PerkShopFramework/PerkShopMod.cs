using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Object = UnityEngine.Object;
using UnityEngine.UI;

namespace PerkShopFramework;

public sealed class PerkShopMod
{
	private sealed class TalentCardUi
	{
		public GameObject Root;

		public TextMeshProUGUI Name;

		public TextMeshProUGUI Description;

		public TextMeshProUGUI Price;

		public TextMeshProUGUI Stock;

		public Button Buy;
	}

	private sealed class ClickTarget
	{
		public Rect ScreenRect;

		public Action Action;
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Action _003C_003E9__68_1;

		public static Action _003C_003E9__77_0;

		public static Comparison<StartingPerk> _003C_003E9__179_0;

		public static Func<System.Type, bool> _003C_003E9__235_0;

		public static Func<System.Type, bool> _003C_003E9__240_0;

		internal void _003CBuildMentorDialogue_003Eb__68_1()
		{
		}

		internal void _003CCreateTalentCard_003Eb__77_0()
		{
		}

		internal int _003CBuildCatalog_003Eb__179_0(StartingPerk a, StartingPerk b)
		{
			return string.Compare(GetPerkId(a), GetPerkId(b), (StringComparison)4);
		}

		internal bool _003CFindLoadedType_003Eb__235_0(System.Type type)
		{
			return type != (System.Type)null;
		}

		internal bool _003CEnumerateInventoryGrantTargets_003Eb__240_0(System.Type type)
		{
			return type != (System.Type)null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CBuildNativeTalentPanelNextFrame_003Ed__87 : System.Collections.Generic.IEnumerator<object>, System.IDisposable, System.Collections.IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PerkShopMod _003C_003E4__this;

		public CommissaryUIManager manager;

		object System.Collections.Generic.IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CBuildNativeTalentPanelNextFrame_003Ed__87(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void System.IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0284: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02af: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_031d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0343: Unknown result type (might be due to invalid IL or missing references)
			//IL_0352: Unknown result type (might be due to invalid IL or missing references)
			//IL_036b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0384: Unknown result type (might be due to invalid IL or missing references)
			//IL_0390: Unknown result type (might be due to invalid IL or missing references)
			//IL_039a: Expected O, but got Unknown
			//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_041b: Unknown result type (might be due to invalid IL or missing references)
			//IL_042a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0443: Unknown result type (might be due to invalid IL or missing references)
			//IL_045c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0468: Unknown result type (might be due to invalid IL or missing references)
			//IL_0472: Expected O, but got Unknown
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_0200: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Unknown result type (might be due to invalid IL or missing references)
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0247: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PerkShopMod perkShopMod = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				try
				{
					if (!perkShopMod._talentMode || (Object)(object)manager == (Object)null || (Object)(object)manager.panel == (Object)null)
					{
						return false;
					}
					perkShopMod._catalogBuilt = false;
					perkShopMod.EnsureCatalog();
					perkShopMod.DestroyNativeTalentPanel();
					RectTransform component = manager.panel.GetComponent<RectTransform>();
					Transform parent = manager.panel.transform.parent;
					if ((Object)(object)component == (Object)null || (Object)(object)parent == (Object)null)
					{
						return false;
					}
					perkShopMod._nativeTalentFont = (((Object)(object)manager.redeemedCredit != (Object)null) ? ((TMP_Text)manager.redeemedCredit).font : null);
					if ((Object)(object)perkShopMod._nativeTalentFont == (Object)null)
					{
						TextMeshProUGUI componentInChildren = manager.panel.GetComponentInChildren<TextMeshProUGUI>(true);
						if ((Object)(object)componentInChildren != (Object)null)
						{
							perkShopMod._nativeTalentFont = ((TMP_Text)componentInChildren).font;
						}
					}
					Canvas componentInParent = manager.panel.GetComponentInParent<Canvas>();
					Transform parent2 = (((Object)(object)componentInParent != (Object)null) ? ((Component)componentInParent).transform : parent);
					RectTransform val = CreateFullScreenRect("NativePerkTalentPanel", parent2);
					perkShopMod._nativeTalentPanel = ((Component)val).gameObject;
					perkShopMod.AddImage(val, new Color(0.04f, 0.07f, 0.12f, 0.96f), null, 0f);
					((Transform)val).SetAsLastSibling();
					RectTransform val2 = CreateRect((Transform)(object)val, "Content", Vector2.zero, new Vector2(1200f, 700f));
					float num2 = 1f;
					try
					{
						RectTransform val3 = (((Object)(object)componentInParent != (Object)null) ? ((Component)componentInParent).GetComponent<RectTransform>() : null);
						Vector2 val4;
						if (!((Object)(object)val3 != (Object)null))
						{
							val4 = Vector2.zero;
						}
						else
						{
							Rect rect = val3.rect;
							val4 = rect.size;
						}
						Vector2 val5 = val4;
						if (val5.x > 1f && val5.y > 1f)
						{
							num2 = Mathf.Min(1f, Mathf.Min(val5.x / 1200f, val5.y / 700f));
						}
					}
					catch
					{
						num2 = 1f;
					}
					((Transform)val2).localScale = Vector3.one * Mathf.Clamp(num2, 0.65f, 2.5f);
					perkShopMod.CreateText(val2, "体悟", new Vector2(-430f, 255f), new Vector2(200f, 48f), 30f, new Color(0.82f, 0.94f, 0.97f, 1f), (TextAlignmentOptions)513);
					perkShopMod._nativeTalentPointsText = perkShopMod.CreateText(val2, string.Empty, new Vector2(80f, 250f), new Vector2(620f, 42f), 25f, new Color(0.82f, 0.94f, 0.97f, 1f), (TextAlignmentOptions)514);
					perkShopMod.CreateButton(val2, "×", new Vector2(575f, 250f), new Vector2(54f, 48f), new Color(0.18f, 0.28f, 0.36f, 1f), new Color(0.72f, 0.92f, 0.97f, 1f), new Action(perkShopMod.CloseNativeTalentPanel));
					float num3 = 150f;
					float num4 = 250f;
					float num5 = 14f;
					for (int i = 0; i < 7; i++)
					{
						float num6 = (0f - 6f * (num3 + num5)) / 2f + (float)i * (num3 + num5);
						perkShopMod._nativeTalentCards.Add(perkShopMod.CreateTalentCard(val2, new Vector2(num6, 10f), new Vector2(num3, num4), i));
					}
					perkShopMod._nativeTalentPageButton = perkShopMod.CreateButton(val2, "下一页", new Vector2(0f, -235f), new Vector2(300f, 48f), new Color(0.16f, 0.25f, 0.33f, 1f), new Color(0.72f, 0.92f, 0.97f, 1f), new Action(perkShopMod.NextNativeTalentPage));
					manager.panel.SetActive(false);
					perkShopMod.RefreshNativeTalentPanel();
					PerkShopLog.Msg("Native talent panel opened.");
				}
				catch (System.Exception ex)
				{
					PerkShopLog.Error("BuildNativeTalentPanelNextFrame failed: " + (object)ex);
				}
				return false;
			}
		}

		bool System.Collections.IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void System.Collections.IEnumerator.Reset()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private sealed class _003CBuildTalentPanelCloneNextFrame_003Ed__252 : System.Collections.Generic.IEnumerator<object>, System.IDisposable, System.Collections.IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PerkShopMod _003C_003E4__this;

		public CommissaryUIManager manager;

		object System.Collections.Generic.IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CBuildTalentPanelCloneNextFrame_003Ed__252(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void System.IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PerkShopMod perkShopMod = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				try
				{
					if (!perkShopMod._talentMode || (Object)(object)manager == (Object)null || (Object)(object)manager.panel == (Object)null)
					{
						return false;
					}
					perkShopMod.DestroyTalentPanelClone();
					Transform parent = manager.panel.transform.parent;
					if ((Object)(object)parent == (Object)null)
					{
						return false;
					}
					perkShopMod._talentPanelClone = Object.Instantiate<GameObject>(manager.panel, parent);
					((Object)perkShopMod._talentPanelClone).name = "PerkTalentPanel";
					perkShopMod._talentPanelClone.transform.SetAsLastSibling();
					RectTransform component = manager.panel.GetComponent<RectTransform>();
					RectTransform component2 = perkShopMod._talentPanelClone.GetComponent<RectTransform>();
					if ((Object)(object)component != (Object)null && (Object)(object)component2 != (Object)null)
					{
						component2.anchorMin = component.anchorMin;
						component2.anchorMax = component.anchorMax;
						component2.pivot = component.pivot;
						component2.anchoredPosition = component.anchoredPosition;
						component2.sizeDelta = component.sizeDelta;
					}
					CommissaryUIManager component3 = perkShopMod._talentPanelClone.GetComponent<CommissaryUIManager>();
					if ((Object)(object)component3 != (Object)null)
					{
						((Behaviour)component3).enabled = false;
					}
					perkShopMod._talentPanelClone.SetActive(true);
					manager.panel.SetActive(false);
					perkShopMod._talentCards = new List<CommissaryElement>((System.Collections.Generic.IEnumerable<CommissaryElement>)perkShopMod._talentPanelClone.GetComponentsInChildren<CommissaryElement>(true));
					perkShopMod._talentPage = 0;
					perkShopMod.PrepareClonedPanelTexts();
					perkShopMod.PrepareClonedPanelButtons();
					perkShopMod.RefreshClonedTalentPanel();
					PerkShopLog.Msg("Talent panel clone opened. cards=" + ((perkShopMod._talentCards != null) ? perkShopMod._talentCards.Count : 0));
				}
				catch (System.Exception ex)
				{
					PerkShopLog.Error("BuildTalentPanelCloneNextFrame failed: " + (object)ex);
				}
				return false;
			}
		}

		bool System.Collections.IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void System.Collections.IEnumerator.Reset()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private sealed class _003CDismissMentorNextFrame_003Ed__70 : System.Collections.Generic.IEnumerator<object>, System.IDisposable, System.Collections.IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerStore store;

		object System.Collections.Generic.IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CDismissMentorNextFrame_003Ed__70(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void System.IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				try
				{
					if (store == null || !CanUseInRun(store) || !IsPerkShopMentorCurrent(store))
					{
						return false;
					}
					store.DismissCurrentClient(false, true, true);
				}
				catch (System.Exception ex)
				{
					PerkShopLog.Error("Deferred mentor dismissal failed: " + (object)ex);
				}
				return false;
			}
		}

		bool System.Collections.IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void System.Collections.IEnumerator.Reset()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private sealed class _003CEnumerateInventoryGrantTargets_003Ed__240 : System.Collections.Generic.IEnumerable<MethodInfo>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<MethodInfo>, System.IDisposable, System.Collections.IEnumerator
	{
		private int _003C_003E1__state;

		private MethodInfo _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Assembly[] _003C_003E7__wrap1;

		private int _003C_003E7__wrap2;

		private System.Type[] _003Ctypes_003E5__4;

		private int _003Ci_003E5__5;

		MethodInfo System.Collections.Generic.IEnumerator<MethodInfo>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CEnumerateInventoryGrantTargets_003Ed__240(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void System.IDisposable.Dispose()
		{
			_003C_003E7__wrap1 = null;
			_003Ctypes_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0053: Expected O, but got Unknown
			int num = _003C_003E1__state;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				goto IL_012a;
			}
			_003C_003E1__state = -1;
			_003C_003E7__wrap1 = AppDomain.CurrentDomain.GetAssemblies();
			_003C_003E7__wrap2 = 0;
			goto IL_0164;
			IL_0156:
			_003C_003E7__wrap2++;
			goto IL_0164;
			IL_013c:
			if (_003Ci_003E5__5 < _003Ctypes_003E5__4.Length)
			{
				System.Type type2 = _003Ctypes_003E5__4[_003Ci_003E5__5];
				if (!(type2 == (System.Type)null) && string.Equals(((MemberInfo)type2).Name, "InventoryGrant", (StringComparison)4))
				{
					MethodInfo method;
					try
					{
						method = type2.GetMethod("TryGrant", (BindingFlags)56, (Binder)null, new System.Type[1] { typeof(string) }, (ParameterModifier[])null);
					}
					catch
					{
						goto IL_012a;
					}
					if (method != (MethodInfo)null && method.ReturnType == typeof(bool))
					{
						_003C_003E2__current = method;
						_003C_003E1__state = 1;
						return true;
					}
				}
				goto IL_012a;
			}
			_003Ctypes_003E5__4 = null;
			goto IL_0156;
			IL_0164:
			if (_003C_003E7__wrap2 < _003C_003E7__wrap1.Length)
			{
				Assembly val = _003C_003E7__wrap1[_003C_003E7__wrap2];
				try
				{
					_003Ctypes_003E5__4 = val.GetTypes();
				}
				catch (ReflectionTypeLoadException val2)
				{
					ReflectionTypeLoadException val3 = val2;
					_003Ctypes_003E5__4 = Enumerable.ToArray<System.Type>(Enumerable.Where<System.Type>((System.Collections.Generic.IEnumerable<System.Type>)val3.Types, (Func<System.Type, bool>)((System.Type type) => type != (System.Type)null)));
				}
				catch
				{
					goto IL_0156;
				}
				_003Ci_003E5__5 = 0;
				goto IL_013c;
			}
			_003C_003E7__wrap1 = null;
			return false;
			IL_012a:
			_003Ci_003E5__5++;
			goto IL_013c;
		}

		bool System.Collections.IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void System.Collections.IEnumerator.Reset()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		System.Collections.Generic.IEnumerator<MethodInfo> System.Collections.Generic.IEnumerable<MethodInfo>.GetEnumerator()
		{
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				return this;
			}
			return new _003CEnumerateInventoryGrantTargets_003Ed__240(0);
		}

		[DebuggerHidden]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return (System.Collections.IEnumerator)((System.Collections.Generic.IEnumerable<MethodInfo>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CRefreshButtonLabelRoutine_003Ed__16 : System.Collections.Generic.IEnumerator<object>, System.IDisposable, System.Collections.IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Transform root;

		public string label;

		private int _003Ci_003E5__2;

		object System.Collections.Generic.IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CRefreshButtonLabelRoutine_003Ed__16(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void System.IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Ci_003E5__2 = 0;
				break;
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__2++;
				break;
			}
			if (_003Ci_003E5__2 < 30)
			{
				SetButtonLabel(root, label);
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			return false;
		}

		bool System.Collections.IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void System.Collections.IEnumerator.Reset()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private sealed class _003CSetupExchangeButtonNextFrame_003Ed__35 : System.Collections.Generic.IEnumerator<object>, System.IDisposable, System.Collections.IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ExchangeUIManager manager;

		public PerkShopMod _003C_003E4__this;

		object System.Collections.Generic.IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CSetupExchangeButtonNextFrame_003Ed__35(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void System.IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0225: Expected O, but got Unknown
			int num = _003C_003E1__state;
			PerkShopMod CS_0024_003C_003E8__locals0 = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				try
				{
					if ((Object)(object)manager == (Object)null || (Object)(object)manager.panel == (Object)null)
					{
						return false;
					}
					Button val = CS_0024_003C_003E8__locals0.FindExchangeTradeButton(manager);
					if ((Object)(object)val == (Object)null)
					{
						PerkShopLog.Warning("Exchange trade button not found.");
						return false;
					}
					if ((Object)(object)CS_0024_003C_003E8__locals0._exchangeEnlightenmentButton == (Object)null)
					{
						Transform parent = ((Component)val).transform.parent;
						if ((Object)(object)parent == (Object)null)
						{
							return false;
						}
						CS_0024_003C_003E8__locals0._exchangeEnlightenmentButton = Object.Instantiate<GameObject>(((Component)val).gameObject, parent);
						((Object)CS_0024_003C_003E8__locals0._exchangeEnlightenmentButton).name = "PerkShopEnlightenmentButton";
						LayoutElement val2 = CS_0024_003C_003E8__locals0._exchangeEnlightenmentButton.GetComponent<LayoutElement>();
						if ((Object)(object)val2 == (Object)null)
						{
							val2 = CS_0024_003C_003E8__locals0._exchangeEnlightenmentButton.AddComponent<LayoutElement>();
						}
						val2.ignoreLayout = true;
						RectTransform component = CS_0024_003C_003E8__locals0._exchangeEnlightenmentButton.GetComponent<RectTransform>();
						RectTransform component2 = ((Component)val).GetComponent<RectTransform>();
						if ((Object)(object)component != (Object)null && (Object)(object)component2 != (Object)null)
						{
							component.anchorMin = component2.anchorMin;
							component.anchorMax = component2.anchorMax;
							component.pivot = component2.pivot;
							component.sizeDelta = component2.sizeDelta;
							component.anchoredPosition = component2.anchoredPosition + new Vector2(0f, Math.Abs(component2.sizeDelta.y) + 12f);
						}
						Button val3 = CS_0024_003C_003E8__locals0._exchangeEnlightenmentButton.GetComponent<Button>();
						if ((Object)(object)val3 == (Object)null)
						{
							val3 = CS_0024_003C_003E8__locals0._exchangeEnlightenmentButton.GetComponentInChildren<Button>(true);
						}
						if ((Object)(object)val3 == (Object)null)
						{
							Object.Destroy((Object)(object)CS_0024_003C_003E8__locals0._exchangeEnlightenmentButton);
							CS_0024_003C_003E8__locals0._exchangeEnlightenmentButton = null;
							return false;
						}
						((UnityEventBase)val3.onClick).RemoveAllListeners();
						((UnityEvent)val3.onClick).AddListener(new UnityAction(([CompilerGenerated] () =>
						{
							CS_0024_003C_003E8__locals0.OpenTalentShopFromExchange();
						})));
						((Selectable)val3).interactable = true;
						CS_0024_003C_003E8__locals0._exchangeEnlightenmentButton.transform.SetAsLastSibling();
						CS_0024_003C_003E8__locals0._exchangeEnlightenmentButton.SetActive(true);
						CS_0024_003C_003E8__locals0.StartButtonLabelRefresh(CS_0024_003C_003E8__locals0._exchangeEnlightenmentButton.transform, "体悟");
					}
					else
					{
						CS_0024_003C_003E8__locals0._exchangeEnlightenmentButton.SetActive(true);
						SetButtonLabel(CS_0024_003C_003E8__locals0._exchangeEnlightenmentButton.transform, "体悟");
					}
					PerkShopLog.Msg("Exchange enlightenment button added.");
				}
				catch (System.Exception ex)
				{
					PerkShopLog.Error("SetupExchangeButtonNextFrame failed: " + (object)ex);
				}
				return false;
			}
		}

		bool System.Collections.IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void System.Collections.IEnumerator.Reset()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private sealed class _003CTryAdvanceMentorAfterFrame_003Ed__66 : System.Collections.Generic.IEnumerator<object>, System.IDisposable, System.Collections.IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PerkShopMod _003C_003E4__this;

		public DialogUIManager dialogUi;

		object System.Collections.Generic.IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CTryAdvanceMentorAfterFrame_003Ed__66(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void System.IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			int num = _003C_003E1__state;
			PerkShopMod perkShopMod = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				try
				{
					PlayerStore store = perkShopMod.GetStore();
					if ((Object)(object)dialogUi == (Object)null || !CanUseInRun(store) || !IsPerkShopMentorCurrent(store))
					{
						return false;
					}
					if (!dialogUi.isWaitingForManualAdvance)
					{
						PerkShopLog.Msg("Mentor advance fallback skipped: native input path already advanced.");
						return false;
					}
					Dialogue currentDialog = dialogUi.currentDialog;
					PerkShopLog.Msg("Mentor advance fallback invoked. next=" + (currentDialog != null && currentDialog.nextDialogue != null) + " waiting=" + dialogUi.isWaitingForManualAdvance);
					dialogUi.ContinueConversation();
				}
				catch (System.Exception ex)
				{
					PerkShopLog.Error("TryAdvanceMentorAfterFrame failed: " + (object)ex);
				}
				return false;
			}
		}

		bool System.Collections.IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void System.Collections.IEnumerator.Reset()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			throw new NotSupportedException();
		}
	}

	private const string BeginDayPendingKey = "BeginDayPending";

	private bool _deferredRepairsPending;

	private const string PendingSawyerCrewDayKey = "PendingSawyerCrewDay";

	private const string SawyerCrewHandledKey = "SawyerCrewHandled";

	private int _pendingSawyerCrewDay;

	private ExchangeUIManager _exchangeManager;

	private GameObject _exchangeEnlightenmentButton;

	private Button? _foodStationTradeButton;

	private GameObject? _foodStationEnlightenmentButton;

	private Transform? _foodStationRoot;

	private float _nextFoodStationScanTime;

	private const string MentorIntroSeenKey = "MentorIntroSeen";

	private const string MentorPromptedLevelKey = "MentorPromptedLevel";

	private const string MentorNextVisitDayKey = "MentorNextVisitDay";

	private const string MentorVisitCountKey = "MentorVisitCount";

	private const string MentorNativeTutorialDoneKey = "MentorNativeTutorialDone";

	private const string PerkShopMentorClientId = "perkshop_mentor";

	private bool _mentorIntroSeen;

	private int _mentorPromptedLevel;

	private int _mentorNextVisitDay = -1;

	private int _mentorVisitCount;

	private bool _mentorNativeTutorialDone;

	private bool _mentorVisitQueued;

	private float _nextMentorAttemptTime;

	private int _mentorAdvanceQueuedFrame = -1;

	private GameObject _nativeTalentPanel;

	private TMP_FontAsset _nativeTalentFont;

	private readonly List<TalentCardUi> _nativeTalentCards = new List<TalentCardUi>();

	private Button _nativeTalentPageButton;

	private TextMeshProUGUI _nativeTalentPointsText;

	private int _nativeTalentPage;

	private Sprite _nativeWhiteSprite;

	private const string VolumeKey = "TradeVolume";

	private const string PointsKey = "Points";

	private const string VolumeAtLastPointKey = "VolumeAtLastPoint";

	private const string PointsEarnedKey = "PointsEarned";

	private const string StateRunIdKey = "StateRunId";

	private const string StateVersionKey = "StateVersion";

	private const string AppliedContentPrefix = "AppliedContent.";

	private ConfigEntry<int> _creditsPerPoint;

	private ConfigEntry<float> _pointCostGrowth;

	private ConfigEntry<float> _latePointCostGrowth;

	private ConfigEntry<int> _costCurveVersion;

	private ConfigEntry<bool> _includeNegativePerks;

	private ModConfig _config;

	private Harmony _harmony;

	private readonly List<StartingPerk> _catalog = new List<StartingPerk>();

	private readonly List<StartingPerk> _registryPerks = new List<StartingPerk>();

	private bool _catalogBuilt;

	private bool _menuOpen;

	private bool _savePending;

	private Vector2 _scroll;

	private Rect _windowRect = new Rect(100f, 60f, 720f, 560f);

	private int _page;

	private const int PageSize = 7;

	private Font _uiFont;

	private GUIStyle _labelStyle;

	private GUIStyle _buttonStyle;

	private GUIStyle _boxStyle;

	private GUIStyle _windowStyle;

	private bool _stylesReady;

	private readonly List<ClickTarget> _clickTargets = new List<ClickTarget>();

	private int _lastClickFrame = -1;

	private string _loadedRunId;

	private long _tradeVolume;

	private long _volumeAtLastPoint;

	private int _points;

	private int _pointsEarned;

	private bool _nativeLocationRegistered;

	internal const string PerkShopLocationId = "perkshop";

	private CommissaryUIManager _commissaryManager;

	private GameObject _commissaryEnlightenmentButton;

	private Button _commissaryTradeButton;

	private bool _talentMode;

	private Texture2D _frameTexture;

	private Texture2D _panelTexture;

	private Texture2D _borderTexture;

	private Texture2D _buttonTexture;

	private Texture2D _buttonHoverTexture;

	private const string FutureTechRepairKey = "Repair.FutureTechStarterItems";

	private const string ScavengersReignRepairKey = "Repair.ScavengersReignToken";

	private static readonly string[] TapeheadCassetteIds = new string[7] { "cassette1d", "cassette2d", "cassette3d", "cassette4d", "cassette5d", "cassette6d", "cassette7d" };

	private const string TapeheadRepairKey = "Repair.TapeheadCassettes";

	private const string WagesPerksRepairPrefix = "Repair.WagesPerks.";

	private const string DestinyDicePerkId = "命运之骰";

	private const string FrogPowerPerkId = "蛙哥牛逼";

	private static bool _inventoryGrantRedirectInstalled;

	private static bool _vainPersonCompatibilityInstalled;

	private GameObject _talentPanelClone;

	private List<CommissaryElement> _talentCards;

	private Button _talentPageButton;

	private int _talentPage;

	[field: CompilerGenerated]
	private static Harmony? HarmonyInstance
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public static PerkShopMod Instance
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	public bool IsApplyingPurchasedContent
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	internal void HandleEndNight()
	{
		try
		{
			PlayerStore store = GetStore();
			if (CanUseInRun(store))
			{
				EnsureLoaded(store);
				WriteInt(store, "BeginDayPending", 1);
				_savePending = true;
				PerkShopLog.Debug("已登记下一次 BeginDay 处理。");
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("EndNight 登记失败：" + (object)ex);
		}
	}

	internal void HandleBeginDay()
	{
		try
		{
			PlayerStore store = GetStore();
			if (CanUseInRun(store))
			{
				EnsureLoaded(store);
				if (_deferredRepairsPending)
				{
					RunDeferredRepairs(store);
					_deferredRepairsPending = false;
				}
				UpdateDeferredPerkEvents(store);
				UpdateMentorEvents(store, includeDeferredVisits: true);
				WriteInt(store, "BeginDayPending", 0);
				_savePending = true;
				PerkShopLog.Debug("BeginDay 阶段处理完成。day=" + GetCurrentDaySafe());
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("BeginDay 执行失败：" + (object)ex);
		}
	}

	private void RunDeferredRepairs(PlayerStore store)
	{
		TryRepairLegacyExtraPerksItems(store);
		TryRepairLegacyDeferredEvents(store);
		TryRepairLegacyFutureTechItems(store);
		TryRepairLegacyTapeheadCassettes(store);
		TryRepairLegacyWagesPerksItems(store);
	}

	public void EnsureCommissaryButton(CommissaryUIManager manager)
	{
		if ((Object)(object)manager != (Object)null)
		{
			_commissaryManager = manager;
			_nextFoodStationScanTime = 0f;
			ScanFoodStationButton();
		}
	}

	public void QueueTalentMode()
	{
		_talentMode = true;
		CommissaryUIManager val = _commissaryManager ?? CommissaryUIManager.Instance;
		if ((Object)(object)val == (Object)null || (Object)(object)val.panel == (Object)null)
		{
			PerkShopLog.Warning("CommissaryUIManager or panel is null.");
			return;
		}
		if (!val.panel.activeInHierarchy)
		{
			val.OpenUI();
		}
		val.panel.SetActive(false);
		PerkShopRunner.Start(BuildNativeTalentPanelNextFrame(val));
	}

	public void OnCommissaryRefreshed()
	{
	}

	public void OnCommissaryClosed()
	{
		ClearCommissaryButton();
		_talentMode = false;
		DestroyNativeTalentPanel();
		DestroyTalentPanelClone();
	}

	private void EnterTalentMode()
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		try
		{
			CommissaryUIManager manager = _commissaryManager;
			PlayerStore store = GetStore();
			if ((Object)(object)manager == (Object)null || !CanUseInRun(store))
			{
				return;
			}
			_catalogBuilt = false;
			EnsureCatalog();
			_talentMode = true;
			Button val = FindCommissaryTradeButton(manager);
			if ((Object)(object)val != (Object)null)
			{
				_commissaryTradeButton = val;
				RebindButton(((Component)val).gameObject, "返回交易", (Action)delegate
				{
					try
					{
						manager.CloseUI();
					}
					catch
					{
					}
				});
			}
			SetTalentTitle(manager, "体悟");
			RefreshTalentCards(manager, store);
			PerkShopLog.Msg("Talent mode opened.");
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("EnterTalentMode failed: " + (object)ex);
		}
	}

	private Button FindCommissaryTradeButton(CommissaryUIManager manager)
	{
		try
		{
			Button[] componentsInChildren = ((Component)manager).gameObject.GetComponentsInChildren<Button>(true);
			if (componentsInChildren != null)
			{
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					Button val = componentsInChildren[i];
					if (!((Object)(object)val == (Object)null))
					{
						string buttonText = GetButtonText(((Component)val).transform);
						if (!string.IsNullOrEmpty(buttonText) && (buttonText.Contains("兑换") || buttonText.Contains("交易")))
						{
							return val;
						}
					}
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private void RefreshTalentCards(CommissaryUIManager manager, PlayerStore store)
	{
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		CommissaryUIManager manager2 = manager;
		List<CommissaryElement> commissaryElements = GameApi.CommissaryElements(manager2);
		if ((Object)(object)manager2 == (Object)null || commissaryElements == null)
		{
			return;
		}
		for (int i = 0; i < commissaryElements.Count; i++)
		{
			CommissaryElement val = commissaryElements[i];
			if ((Object)(object)val == (Object)null)
			{
				continue;
			}
			if (i >= _catalog.Count)
			{
				((Component)val).gameObject.SetActive(false);
				continue;
			}
			StartingPerk val2 = _catalog[i];
			string perkId = GetPerkId(val2);
			bool flag = IsOwned(store, perkId);
			bool flag2 = !flag && IsIncompatible(store, val2);
			int num = Math.Max(0, val2.cost);
			bool interactable = !flag && !flag2 && _points >= num;
			((Component)val).gameObject.SetActive(true);
			val.id = perkId;
			if ((Object)(object)val.productName != (Object)null)
			{
				((TMP_Text)val.productName).text = GetDisplayName(val2);
			}
			if ((Object)(object)val.price != (Object)null)
			{
				((TMP_Text)val.price).text = num + " 天赋点";
			}
			if ((Object)(object)val.stock != (Object)null)
			{
				((TMP_Text)val.stock).text = (flag ? "已拥有" : (flag2 ? "不可体悟" : "可体悟"));
			}
			if ((Object)(object)val.buyButton != (Object)null)
			{
				StartingPerk captured = val2;
				((UnityEventBase)val.buyButton.onClick).RemoveAllListeners();
				((UnityEvent)val.buyButton.onClick).AddListener(new UnityAction(delegate
				{
					TryPurchase(captured);
					RefreshTalentCards(manager2, GetStore());
				}));
				((Selectable)val.buyButton).interactable = interactable;
				SetButtonLabel(((Component)val.buyButton).transform, "购买");
			}
		}
		if ((Object)(object)manager2.redeemedCredit != (Object)null)
		{
			((TMP_Text)manager2.redeemedCredit).text = "剩余天赋点：" + _points + "   累计交易额：" + _tradeVolume;
		}
	}

	private void RebindButton(GameObject gameObject, string label, Action action)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		Action action2 = action;
		if ((Object)(object)gameObject == (Object)null)
		{
			return;
		}
		Button val = gameObject.GetComponent<Button>();
		if ((Object)(object)val == (Object)null)
		{
			val = gameObject.GetComponentInChildren<Button>(true);
		}
		if ((Object)(object)val != (Object)null)
		{
			((UnityEventBase)val.onClick).RemoveAllListeners();
			((UnityEvent)val.onClick).AddListener(new UnityAction(delegate
			{
				action2.Invoke();
			}));
			((Selectable)val).interactable = true;
		}
		StartButtonLabelRefresh(gameObject.transform, label);
	}

	private static string GetButtonText(Transform transform)
	{
		if ((Object)(object)transform == (Object)null)
		{
			return string.Empty;
		}
		try
		{
			TextMeshProUGUI componentInChildren = ((Component)transform).GetComponentInChildren<TextMeshProUGUI>(true);
			if ((Object)(object)componentInChildren != (Object)null)
			{
				return ((TMP_Text)componentInChildren).text ?? string.Empty;
			}
			Text componentInChildren2 = ((Component)transform).GetComponentInChildren<Text>(true);
			if ((Object)(object)componentInChildren2 != (Object)null)
			{
				return componentInChildren2.text ?? string.Empty;
			}
		}
		catch
		{
		}
		return string.Empty;
	}

	private static void SetButtonLabel(Transform root, string label)
	{
		if ((Object)(object)root == (Object)null)
		{
			return;
		}
		try
		{
			System.Collections.Generic.IEnumerator<TextMeshProUGUI> enumerator = ((System.Collections.Generic.IEnumerable<TextMeshProUGUI>)((Component)root).GetComponentsInChildren<TextMeshProUGUI>(true)).GetEnumerator();
			try
			{
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					((TMP_Text)enumerator.Current).text = label;
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			System.Collections.Generic.IEnumerator<Text> enumerator2 = ((System.Collections.Generic.IEnumerable<Text>)((Component)root).GetComponentsInChildren<Text>(true)).GetEnumerator();
			try
			{
				while (((System.Collections.IEnumerator)enumerator2).MoveNext())
				{
					enumerator2.Current.text = label;
				}
			}
			finally
			{
				((System.IDisposable)enumerator2)?.Dispose();
			}
		}
		catch
		{
		}
	}

	private void StartButtonLabelRefresh(Transform root, string label)
	{
		PerkShopRunner.Start(RefreshButtonLabelRoutine(root, label));
	}

	[IteratorStateMachine(typeof(_003CRefreshButtonLabelRoutine_003Ed__16))]
	private static System.Collections.IEnumerator RefreshButtonLabelRoutine(Transform root, string label)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CRefreshButtonLabelRoutine_003Ed__16(0)
		{
			root = root,
			label = label
		};
	}

	private static void SetTalentTitle(CommissaryUIManager manager, string title)
	{
		try
		{
			if ((Object)(object)manager == (Object)null || (Object)(object)manager.panel == (Object)null)
			{
				return;
			}
			System.Collections.Generic.IEnumerator<TextMeshProUGUI> enumerator = ((System.Collections.Generic.IEnumerable<TextMeshProUGUI>)manager.panel.GetComponentsInChildren<TextMeshProUGUI>(true)).GetEnumerator();
			try
			{
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					TextMeshProUGUI current = enumerator.Current;
					if (!string.IsNullOrEmpty(((TMP_Text)current).text) && (((TMP_Text)current).text.Contains("配给站") || ((TMP_Text)current).text.Contains("体悟")))
					{
						((TMP_Text)current).text = title;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
		}
		catch
		{
		}
	}

	private void UpdateDeferredPerkEvents(PlayerStore store)
	{
		if (!CanUseInRun(store) || store.storeClientManager == null || _pendingSawyerCrewDay <= 0 || GetCurrentDaySafe() < _pendingSawyerCrewDay)
		{
			return;
		}
		try
		{
			StoreClientManager storeClientManager = store.storeClientManager;
			StoreClient val = StoreClientListStory.CreateJanitorUndergroundExchangeIntroductionFence();
			if (val == null)
			{
				return;
			}
			List<StoreClient> clientStack = storeClientManager.clientStack;
			if (clientStack != null)
			{
				for (int i = 0; i < clientStack.Count; i++)
				{
					StoreClient val2 = clientStack[i];
					if (val2 != null && string.Equals(val2.identifier, val.identifier, (StringComparison)4))
					{
						CompletePendingSawyerCrewVisit(store);
						return;
					}
				}
			}
			storeClientManager.AddNextClient(val);
			CompletePendingSawyerCrewVisit(store);
			PerkShopLog.Msg("Queued deferred Sawyer Crew visit for day " + GetCurrentDaySafe() + ".");
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("UpdateDeferredPerkEvents failed: " + (object)ex);
		}
	}

	public void TryRepairLegacyDeferredEvents(PlayerStore store)
	{
		if (CanUseInRun(store) && ReadInt(store, "SawyerCrewHandled", 0) == 0 && ReadInt(store, "AppliedContent.sawyer_crew", 0) != 0 && _pendingSawyerCrewDay <= 0)
		{
			ScheduleSawyerCrewNextDay(store);
			PerkShopLog.Msg("Legacy Sawyer Crew purchase detected; deferred visit scheduled.");
		}
	}

	private void ScheduleSawyerCrewNextDay(PlayerStore store)
	{
		if (ReadInt(store, "SawyerCrewHandled", 0) == 0)
		{
			int num = GetCurrentDaySafe() + 1;
			if (num <= 1)
			{
				num = 2;
			}
			_pendingSawyerCrewDay = Math.Max(_pendingSawyerCrewDay, num);
			WriteInt(store, "PendingSawyerCrewDay", _pendingSawyerCrewDay);
			_savePending = true;
			PerkShopLog.Msg("Deferred Sawyer Crew visit scheduled for day " + _pendingSawyerCrewDay + ".");
		}
	}

	private void CompletePendingSawyerCrewVisit(PlayerStore store)
	{
		_pendingSawyerCrewDay = 0;
		WriteInt(store, "PendingSawyerCrewDay", 0);
		WriteInt(store, "SawyerCrewHandled", 1);
		_savePending = true;
	}

	internal static void Initialize(Harmony harmony)
	{
		HarmonyInstance = harmony;
		(Instance = new PerkShopMod()).InitializeInternal();
	}

	internal static void Update()
	{
		Instance?.UpdateInternal();
	}

	internal static void Shutdown()
	{
		Instance?.ShutdownInternal();
	}

	internal static void DrawGuiRoot()
	{
		Instance?.DrawGui();
	}

	public void EnsureExchangeEnlightenmentButton(ExchangeUIManager manager)
	{
		if (!((Object)(object)manager == (Object)null))
		{
			_exchangeManager = manager;
			PerkShopRunner.Start(SetupExchangeButtonNextFrame(manager));
		}
	}

	[IteratorStateMachine(typeof(_003CSetupExchangeButtonNextFrame_003Ed__35))]
	private System.Collections.IEnumerator SetupExchangeButtonNextFrame(ExchangeUIManager manager)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSetupExchangeButtonNextFrame_003Ed__35(0)
		{
			_003C_003E4__this = this,
			manager = manager
		};
	}

	private Button FindExchangeTradeButton(ExchangeUIManager manager)
	{
		try
		{
			Button[] componentsInChildren = ((Component)manager).gameObject.GetComponentsInChildren<Button>(true);
			if (componentsInChildren != null)
			{
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					Button val = componentsInChildren[i];
					if (!((Object)(object)val == (Object)null))
					{
						string buttonText = GetButtonText(((Component)val).transform);
						if (!string.IsNullOrEmpty(buttonText) && buttonText.Contains("交易"))
						{
							return val;
						}
					}
				}
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("FindExchangeTradeButton failed: " + ex.Message);
		}
		return null;
	}

	private void OpenTalentShopFromExchange()
	{
		try
		{
			try
			{
				ExchangeUIManager exchangeManager = _exchangeManager;
				if (exchangeManager != null)
				{
					exchangeManager.ClosePanel();
				}
			}
			catch
			{
			}
			QueueTalentMode();
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("OpenTalentShopFromExchange failed: " + (object)ex);
		}
	}

	private void ScanFoodStationButton()
	{
		if ((Object)(object)_foodStationEnlightenmentButton != (Object)null)
		{
			if (_foodStationEnlightenmentButton.activeInHierarchy)
			{
				return;
			}
			DestroyInjectedButtons(_foodStationRoot);
			_foodStationEnlightenmentButton = null;
		}
		if (Time.unscaledTime < _nextFoodStationScanTime)
		{
			return;
		}
		_nextFoodStationScanTime = Time.unscaledTime + 1f;
		try
		{
			CommissaryUIManager val = _commissaryManager ?? CommissaryUIManager.Instance;
			if ((Object)(object)val == (Object)null)
			{
				return;
			}
			_commissaryManager = val;
			Transform val2 = ResolveCommissaryRoot(val);
			if (!((Object)(object)val2 == (Object)null) && ((Component)val2).gameObject.activeInHierarchy)
			{
				DestroyInjectedButtons(val2);
				Button val3 = FindCommissaryTradeButton(val2);
				if (!((Object)(object)val3 == (Object)null) && !((Object)(object)((Component)val3).transform.parent == (Object)null))
				{
					CreateFoodStationButton(val2, val3, ((Component)val3).transform.parent);
				}
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("ScanFoodStationButton failed: " + ex.Message);
		}
	}

	private static Transform? ResolveCommissaryRoot(CommissaryUIManager manager)
	{
		try
		{
			MapUIManager instance = MapUIManager.Instance;
			if ((Object)(object)instance != (Object)null && (Object)(object)instance.UICommissaryPanel != (Object)null && instance.UICommissaryPanel.activeInHierarchy)
			{
				return instance.UICommissaryPanel.transform;
			}
		}
		catch
		{
		}
		if ((Object)(object)((manager != null) ? manager.panel : null) == (Object)null || !manager.panel.activeInHierarchy)
		{
			return null;
		}
		Transform parent = manager.panel.transform.parent;
		if ((Object)(object)parent == (Object)null)
		{
			return null;
		}
		string text = ((Object)parent).name ?? string.Empty;
		if (text.IndexOf("Commissary", (StringComparison)5) < 0 && text.IndexOf("_UICommissary", (StringComparison)5) < 0)
		{
			return null;
		}
		return parent;
	}

	private Button? FindCommissaryTradeButton(Transform root)
	{
		if ((Object)(object)root == (Object)null)
		{
			return null;
		}
		Button[] componentsInChildren = ((Component)root).GetComponentsInChildren<Button>(true);
		if (componentsInChildren == null)
		{
			return null;
		}
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Button val = componentsInChildren[i];
			if (!((Object)(object)val == (Object)null) && ((Component)val).gameObject.activeInHierarchy)
			{
				string text = GetButtonText(((Component)val).transform).Trim();
				if (string.Equals(((Object)val).name, "TradeButton", (StringComparison)4) || string.Equals(text, "交易", (StringComparison)4) || text.Contains("交易"))
				{
					return val;
				}
			}
		}
		return null;
	}

	private static bool HasReturnSibling(Transform parent)
	{
		try
		{
			Button[] componentsInChildren = ((Component)parent).GetComponentsInChildren<Button>(true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if ((Object)(object)componentsInChildren[i] != (Object)null && string.Equals(GetButtonText(((Component)componentsInChildren[i]).transform).Trim(), "返回", (StringComparison)4))
				{
					return true;
				}
			}
		}
		catch
		{
		}
		return false;
	}

	private void CreateFoodStationButton(Transform root, Button trade, Transform parent)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		try
		{
			_foodStationRoot = root;
			_foodStationTradeButton = trade;
			DestroyInjectedButtons(root);
			_foodStationEnlightenmentButton = Object.Instantiate<GameObject>(((Component)trade).gameObject, parent);
			((Object)_foodStationEnlightenmentButton).name = "PerkShopEnlightenmentButton";
			LayoutElement val = _foodStationEnlightenmentButton.GetComponent<LayoutElement>();
			if ((Object)(object)val == (Object)null)
			{
				val = _foodStationEnlightenmentButton.AddComponent<LayoutElement>();
			}
			val.ignoreLayout = true;
			RectTransform component = _foodStationEnlightenmentButton.GetComponent<RectTransform>();
			RectTransform component2 = ((Component)trade).GetComponent<RectTransform>();
			if ((Object)(object)component != (Object)null && (Object)(object)component2 != (Object)null)
			{
				component.anchorMin = component2.anchorMin;
				component.anchorMax = component2.anchorMax;
				component.pivot = component2.pivot;
				component.sizeDelta = component2.sizeDelta;
				component.anchoredPosition = component2.anchoredPosition + new Vector2(0f, Math.Abs(component2.sizeDelta.y) + 12f);
			}
			Button val2 = _foodStationEnlightenmentButton.GetComponent<Button>();
			if ((Object)(object)val2 == (Object)null)
			{
				val2 = _foodStationEnlightenmentButton.GetComponentInChildren<Button>(true);
			}
			if ((Object)(object)val2 == (Object)null)
			{
				Object.Destroy((Object)(object)_foodStationEnlightenmentButton);
				_foodStationEnlightenmentButton = null;
				return;
			}
			for (int i = 0; i < ((UnityEventBase)val2.onClick).GetPersistentEventCount(); i++)
			{
				((UnityEventBase)val2.onClick).SetPersistentListenerState(i, (UnityEventCallState)0);
			}
			val2.onClick = new Button.ButtonClickedEvent();
			((UnityEvent)val2.onClick).AddListener(new UnityAction(([CompilerGenerated] () =>
			{
				OpenTalentShopFromExchange();
			})));
			((Selectable)val2).interactable = true;
			_foodStationEnlightenmentButton.transform.SetAsLastSibling();
			_foodStationEnlightenmentButton.SetActive(true);
			StartButtonLabelRefresh(_foodStationEnlightenmentButton.transform, "体悟");
			PerkShopLog.Msg("Food station enlightenment button added. root=" + ((Object)parent).name);
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("CreateFoodStationButton failed: " + (object)ex);
		}
	}

	private void DestroyInjectedButtons(Transform? root)
	{
		try
		{
			if ((Object)(object)root == (Object)null)
			{
				return;
			}
			Button[] componentsInChildren = ((Component)root).GetComponentsInChildren<Button>(true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Button val = componentsInChildren[i];
				if (!((Object)(object)val == (Object)null) && string.Equals(((Object)val).name, "PerkShopEnlightenmentButton", (StringComparison)4))
				{
					GameObject gameObject = ((Component)val).gameObject;
					gameObject.SetActive(false);
					Object.Destroy((Object)(object)gameObject);
				}
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("DestroyInjectedButtons failed: " + ex.Message);
		}
	}

	public void ClearCommissaryButton()
	{
		if ((Object)(object)_foodStationRoot != (Object)null)
		{
			DestroyInjectedButtons(_foodStationRoot);
		}
		if ((Object)(object)_foodStationEnlightenmentButton != (Object)null)
		{
			_foodStationEnlightenmentButton.SetActive(false);
			Object.Destroy((Object)(object)_foodStationEnlightenmentButton);
		}
		_foodStationEnlightenmentButton = null;
		_foodStationTradeButton = null;
		_foodStationRoot = null;
		_commissaryTradeButton = null;
	}

	private void UpdateMentorEvents(PlayerStore store, bool includeDeferredVisits)
	{
		if (!CanUseInRun(store) || store.storeClientManager == null || (Object)(object)StoreUIManager.Instance == (Object)null || Time.unscaledTime < _nextMentorAttemptTime || _mentorVisitQueued)
		{
			return;
		}
		int currentDaySafe = GetCurrentDaySafe();
		if (currentDaySafe <= 0)
		{
			return;
		}
		if (!_mentorIntroSeen && (_mentorNativeTutorialDone || !store.tutorialEnable || !store.enableStoryClient))
		{
			if (QueueMentorVisit(store, intro: true, 1))
			{
				_mentorIntroSeen = true;
				WriteInt(store, "MentorIntroSeen", 1);
				_savePending = true;
			}
		}
		else if (includeDeferredVisits && _mentorNextVisitDay > 0 && currentDaySafe >= _mentorNextVisitDay && _pointsEarned > _mentorPromptedLevel)
		{
			QueueMentorVisit(store, intro: false, _mentorVisitCount + 1);
		}
	}

	public void OnNativeTutorialMentorDone()
	{
		try
		{
			_mentorNativeTutorialDone = true;
			_nextMentorAttemptTime = 0f;
			PlayerStore store = GetStore();
			if (CanUseInRun(store))
			{
				WriteInt(store, "MentorNativeTutorialDone", 1);
				_savePending = true;
			}
			PerkShopLog.Msg("Native tutorial mentor completed; perk shop mentor intro unlocked.");
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("OnNativeTutorialMentorDone failed: " + (object)ex);
		}
	}

	private static bool IsPerkShopMentorCurrent(PlayerStore store)
	{
		try
		{
			StoreClientInstance val = ((store != null) ? store.currentClientInstance : null);
			StoreClient val2 = ((val != null) ? val.GetClientBlueprint() : null);
			return val2 != null && string.Equals(val2.identifier, "perkshop_mentor", (StringComparison)4);
		}
		catch
		{
			return false;
		}
	}

	[IteratorStateMachine(typeof(_003CTryAdvanceMentorAfterFrame_003Ed__66))]
	private System.Collections.IEnumerator TryAdvanceMentorAfterFrame(DialogUIManager dialogUi)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CTryAdvanceMentorAfterFrame_003Ed__66(0)
		{
			_003C_003E4__this = this,
			dialogUi = dialogUi
		};
	}

	private bool QueueMentorVisit(PlayerStore store, bool intro, int visitNumber)
	{
		try
		{
			StoreClientManager storeClientManager = store.storeClientManager;
			if (storeClientManager == null)
			{
				return false;
			}
			StoreClient val = StoreClientListStory.CreateMentorClient();
			if (val == null)
			{
				PerkShopLog.Warning("Mentor event failed: CreateMentorClient returned null.");
				return false;
			}
			val.identifier = "perkshop_mentor";
			val.cooldown = 0;
			val.mainDialogue = BuildMentorDialogue(store, intro, visitNumber);
			storeClientManager.AddNextClient(val);
			_mentorVisitQueued = true;
			_nextMentorAttemptTime = Time.unscaledTime + 2f;
			PerkShopLog.Msg(string.Concat(new string[6]
			{
				"Queued perk mentor visit #",
				visitNumber.ToString(),
				" (",
				intro ? "intro" : "point",
				"). day=",
				GetCurrentDaySafe().ToString()
			}));
			return true;
		}
		catch (System.Exception ex)
		{
			_mentorVisitQueued = false;
			_nextMentorAttemptTime = Time.unscaledTime + 5f;
			PerkShopLog.Error("QueueMentorVisit failed: " + (object)ex);
			return false;
		}
	}

	private Dialogue BuildMentorDialogue(PlayerStore store, bool intro, int visitNumber)
	{
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		PlayerStore store2 = store;
		string text = LocHelper.GetLocalizedClientName("name_mentor");
		if (string.IsNullOrEmpty(text))
		{
			text = "导师";
		}
		string[] array = (intro ? new string[6] { "你看账本了吗？", "我做这行时，可没人会停下来教你这些。买卖能赚信用点，也能磨出眼力。", "眼力攒够了，就去配给站，交易台旁那块【体悟】。那里能把眼力换成本事。", "换到手的，会一直留在你这份档里。不是今天有、明天没的玩意儿。", "*他从夹克口袋里掏出一张便签，放在了柜台上。*", "这是你要先记住的一件事。等你做够第一笔流水，就会知道自己看懂了什么。" } : ((visitNumber <= 2) ? new string[5] { "我以前也想过，流水漂亮，本事自然就会跟着长。", "后来才发现不是这么回事。做过的买卖要回头看，才知道自己哪儿看走了眼。", "你这段生意，已经够你再看出一层门道了。去配给站，交易台旁那个【体悟】，别把这点眼力留在脑子里。", "我年轻时攒下过不少这样的东西，最后全被日子磨没了。换进手里的，才是真的。", "再做够下一阶的买卖流水，你还会更进一步。差多少，账本比我清楚。" } : ((visitNumber == 3) ? new string[5] { "我以前在下层区跑货，见过不少人今天替治安部递话，明天又替革命军传信。最后两边都嫌他知道得太多。", "在这种地方，站队不难，难的是站了队还活着。真想长久做生意，得让每一方都觉得你有用，又都别觉得你能被随手拿走。", "你这段时间的买卖，已经让你看出点门道了。配给站，交易台旁的【体悟】，把这层眼力换进手里。", "写规矩的人希望你只认一边。你别急着认，先学会怎么活。", "再做够下一阶的流水，我还来。" } : ((visitNumber == 4) ? new string[5] { "我曾替黑市带过一批不能见光的货。买家是革命军，路上放行的是治安部的人，最后收货的却坐着上层区的车。", "那笔生意教会我一件事：别问谁干净，先看谁能让你活到下一单。", "你又攒出一层经验了。配给站，老地方。趁还看得清，换成本事。", "别让任何一边摸清你的底。你越像一个有用、但不好拿的人，越没人愿意先动你。", "下一阶的流水做够了，我还来。" } : ((visitNumber != 5) ? new string[6] { "说实话，我以前不太看好你。", "这地方的人不是急着找靠山，就是急着把谁踩下去。你在几拨人之间来回周旋，到现在居然还没把自己做成谁的刀。", "能活下来的未必最聪明，但知道自己什么时候该装聋、什么时候该把牌摊开的人，通常活得最久。", "配给站，老地方。该换成本事的东西，别搁着。", "写规矩的人大概不喜欢你这种不听话、又不给他添乱的店主。挺好。", "再做够下一阶的流水，我还来。" } : new string[5] { "我看过站队的人倒在地上，也看过两边都不得罪的人被当成软柿子。中立从来不是缩着脖子做人。", "治安部给你路，不一定是保护你；革命军给你面子，也不一定是信你。黑市更简单，只认你手上有没有他们要的东西。", "你这点眼力已经熟了。配给站，交易台旁那块牌子，换进手里。", "别急着靠哪一边。先让他们都需要你，再谈信谁。", "再做够下一阶的流水，我还会来。" })))));
		Dialogue val = StoreClientDialogList.MentorIntroDialog();
		if (val == null)
		{
			PerkShopLog.Warning("Native mentor dialogue template returned null.");
			return null;
		}
		Dialogue val2 = null;
		Dialogue val3 = val;
		for (int i = 0; i < array.Length; i++)
		{
			if (val3 == null)
			{
				val3 = new Dialogue();
				if (val2 != null)
				{
					val2.nextDialogue = val3;
				}
			}
			val3.SetText(text, array[i]);
			Dialogue obj = val3;
			object obj2 = _003C_003Ec._003C_003E9__68_1;
			if (obj2 == null)
			{
				Action val4 = delegate
				{
				};
				_003C_003Ec._003C_003E9__68_1 = val4;
				obj2 = (object)val4;
			}
			obj.SetEndAction(((Action)obj2));
			val2 = val3;
			val3 = val3.nextDialogue;
		}
		if (val2 == null)
		{
			PerkShopLog.Warning("Native mentor dialogue template had no usable nodes.");
			return null;
		}
		val2.nextDialogue = null;
		Dialogue obj3 = val2.NextDialogue();
		obj3.SetText("PLAYER", "谢谢。");
		obj3.SetEndAction(delegate
		{
			CompleteMentorVisit(store2, intro, visitNumber);
		});
		return val;
	}

	private void CompleteMentorVisit(PlayerStore store, bool intro, int visitNumber)
	{
		try
		{
			PerkShopLog.Msg("Mentor visit completed. intro=" + intro + " visit=" + visitNumber);
			if (intro)
			{
				GrantMentorNote(store);
				_mentorIntroSeen = true;
				_mentorVisitCount = Math.Max(_mentorVisitCount, visitNumber);
				WriteInt(store, "MentorIntroSeen", 1);
				WriteInt(store, "MentorVisitCount", _mentorVisitCount);
				if (store.tutorialEnable && !_mentorNativeTutorialDone)
				{
					try
					{
						TutorialUIManager instance = TutorialUIManager.Instance;
						if (instance != null)
						{
							instance.OnMentorDone();
						}
					}
					catch (System.Exception ex)
					{
						PerkShopLog.Warning("Calling TutorialUIManager.OnMentorDone after mod mentor failed: " + ex.Message);
					}
				}
				if (_pointsEarned > _mentorPromptedLevel)
				{
					ScheduleMentorOnNextDay(store);
				}
			}
			else
			{
				_mentorPromptedLevel = _pointsEarned;
				_mentorNextVisitDay = -1;
				_mentorVisitCount = Math.Max(_mentorVisitCount, visitNumber);
				WriteInt(store, "MentorPromptedLevel", _mentorPromptedLevel);
				WriteInt(store, "MentorNextVisitDay", _mentorNextVisitDay);
				WriteInt(store, "MentorVisitCount", _mentorVisitCount);
			}
			ShowNextPointNotification();
			_mentorVisitQueued = false;
			_savePending = true;
		}
		catch (System.Exception ex2)
		{
			PerkShopLog.Error("CompleteMentorVisit failed: " + (object)ex2);
		}
		finally
		{
			try
			{
				PerkShopRunner.Start(DismissMentorNextFrame(store));
			}
			catch (System.Exception ex3)
			{
				PerkShopLog.Error("Scheduling mentor dismissal failed: " + (object)ex3);
			}
		}
	}

	[IteratorStateMachine(typeof(_003CDismissMentorNextFrame_003Ed__70))]
	private System.Collections.IEnumerator DismissMentorNextFrame(PlayerStore store)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDismissMentorNextFrame_003Ed__70(0)
		{
			store = store
		};
	}

	private void GrantMentorNote(PlayerStore store)
	{
		try
		{
			GameItem val = IntelHelper.CreateMentorNoteBasicTrading();
			if (val == null)
			{
				PerkShopLog.Warning("Mentor note creation returned null.");
				return;
			}
			IntelHelper.InitTutorialPage(val, "导师笔记：体悟", BuildMentorNoteBody(), "——导师");
			store.AddDirectSellingItemToTable(val, true, false, false, 0);
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("GrantMentorNote failed: " + (object)ex);
		}
	}

	private string BuildMentorNoteBody()
	{
		long pointCost = GetPointCost(0);
		long pointCost2 = GetPointCost(Math.Max(1, _pointsEarned));
		long progressToNextPoint = GetProgressToNextPoint();
		return string.Concat(new string[9]
		{
			"你在买卖中磨出的眼力，会沉淀为“体悟”。\n\n每当新增交易额达到 ",
			pointCost.ToString("N0", (IFormatProvider)(object)CultureInfo.InvariantCulture),
			" 信用点，你就会获得 1 点天赋点。\n\n前往配给站，点击“交易”上方的【体悟】，即可用天赋点购买天赋。\n\n手中天赋点：",
			_points.ToString(),
			"\n\n下一阶还需新增 ",
			pointCost2.ToString("N0", (IFormatProvider)(object)CultureInfo.InvariantCulture),
			" 信用点；当前已累积 ",
			progressToNextPoint.ToString("N0", (IFormatProvider)(object)CultureInfo.InvariantCulture),
			"。"
		});
	}

	private void ShowNextPointNotification()
	{
		try
		{
			StoreUIManager instance = StoreUIManager.Instance;
			if (!((Object)(object)instance == (Object)null))
			{
				instance.Notify("下一级需要交易额：" + GetPointCost(_pointsEarned).ToString("N0", (IFormatProvider)(object)CultureInfo.InvariantCulture) + " 信用点", "default");
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("ShowNextPointNotification failed: " + (object)ex);
		}
	}

	private void ScheduleMentorForPoint(PlayerStore store)
	{
		if (CanUseInRun(store) && _pointsEarned > _mentorPromptedLevel && _mentorNextVisitDay <= 0)
		{
			ScheduleMentorOnNextDay(store);
		}
	}

	private void ScheduleMentorOnNextDay(PlayerStore store)
	{
		int currentDaySafe = GetCurrentDaySafe();
		int num = ((currentDaySafe <= 1) ? 2 : (currentDaySafe + 1));
		if (_mentorNextVisitDay < 0 || num < _mentorNextVisitDay)
		{
			_mentorNextVisitDay = num;
			WriteInt(store, "MentorNextVisitDay", _mentorNextVisitDay);
			_savePending = true;
			PerkShopLog.Msg("Scheduled perk mentor visit for day " + _mentorNextVisitDay + ".");
		}
	}

	private static int GetCurrentDaySafe()
	{
		try
		{
			return StoreStation.GetDayCounter();
		}
		catch
		{
			return 0;
		}
	}

	private TalentCardUi CreateTalentCard(RectTransform parent, Vector2 position, Vector2 size, int index)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected O, but got Unknown
		RectTransform val = CreateRect((Transform)(object)parent, "TalentCard_" + index, position, size);
		AddImage(val, new Color(0.14f, 0.17f, 0.22f, 1f), (Color?)new Color(0.45f, 0.78f, 0.88f, 1f), 2f);
		TalentCardUi obj = new TalentCardUi
		{
			Root = ((Component)val).gameObject,
			Name = CreateText(val, string.Empty, new Vector2(0f, 82f), new Vector2(138f, 46f), 18f, new Color(0.84f, 0.95f, 0.97f, 1f), (TextAlignmentOptions)514),
			Description = CreateText(val, string.Empty, new Vector2(0f, 20f), new Vector2(132f, 70f), 13f, new Color(0.55f, 0.85f, 0.9f, 1f), (TextAlignmentOptions)514)
		};
		((TMP_Text)obj.Description).enableWordWrapping = true;
		((TMP_Text)obj.Description).enableAutoSizing = true;
		((TMP_Text)obj.Description).fontSizeMin = 8f;
		((TMP_Text)obj.Description).fontSizeMax = 14f;
		((TMP_Text)obj.Description).overflowMode = (TextOverflowModes)1;
		obj.Price = CreateText(val, string.Empty, new Vector2(0f, -38f), new Vector2(138f, 26f), 18f, new Color(0.9f, 0.88f, 0.74f, 1f), (TextAlignmentOptions)514);
		obj.Stock = CreateText(val, string.Empty, new Vector2(0f, -63f), new Vector2(138f, 24f), 16f, new Color(0.62f, 0.75f, 0.79f, 1f), (TextAlignmentOptions)514);
		Vector2 position2 = new Vector2(0f, -100f);
		Vector2 size2 = new Vector2(120f, 34f);
		Color background = new Color(0.18f, 0.28f, 0.36f, 1f);
		Color textColor = new Color(0.82f, 0.94f, 0.97f, 1f);
		object obj2 = _003C_003Ec._003C_003E9__77_0;
		if (obj2 == null)
		{
			Action val2 = delegate
			{
			};
			_003C_003Ec._003C_003E9__77_0 = val2;
			obj2 = (object)val2;
		}
		obj.Buy = CreateButton(val, "体悟", position2, size2, background, textColor, (Action)obj2);
		return obj;
	}

	private void RefreshNativeTalentPanel()
	{
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Expected O, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		try
		{
			PlayerStore store = GetStore();
			if ((Object)(object)_nativeTalentPanel == (Object)null || _nativeTalentCards.Count == 0 || !CanUseInRun(store))
			{
				return;
			}
			int count = _nativeTalentCards.Count;
			int num = Math.Max(1, (_catalog.Count + count - 1) / count);
			if (_nativeTalentPage >= num)
			{
				_nativeTalentPage = num - 1;
			}
			if (_nativeTalentPage < 0)
			{
				_nativeTalentPage = 0;
			}
			if ((Object)(object)_nativeTalentPointsText != (Object)null)
			{
				((TMP_Text)_nativeTalentPointsText).text = string.Concat(new string[8]
				{
					"剩余天赋点：",
					_points.ToString(),
					"   累计交易额：",
					_tradeVolume.ToString(),
					"   下一阶：",
					GetProgressToNextPoint().ToString(),
					"/",
					GetNextPointCost().ToString()
				});
			}
			for (int i = 0; i < _nativeTalentCards.Count; i++)
			{
				TalentCardUi talentCardUi = _nativeTalentCards[i];
				int num2 = _nativeTalentPage * count + i;
				if (num2 >= _catalog.Count)
				{
					talentCardUi.Root.SetActive(false);
					continue;
				}
				StartingPerk val = _catalog[num2];
				string perkId = GetPerkId(val);
				bool flag = IsOwned(store, perkId);
				bool flag2 = !flag && IsIncompatible(store, val);
				int num3 = Math.Max(0, val.cost);
				bool interactable = !flag && !flag2 && _points >= num3;
				talentCardUi.Root.SetActive(true);
				((TMP_Text)talentCardUi.Name).text = GetDisplayName(val);
				string text = GetDescription(val);
				if (text.Length > 120)
				{
					text = text.Substring(0, 120) + "...";
				}
				((TMP_Text)talentCardUi.Description).text = text;
				((TMP_Text)talentCardUi.Price).text = num3 + " 天赋点";
				((TMP_Text)talentCardUi.Stock).text = (flag ? "已拥有" : (flag2 ? "不可体悟" : "可体悟"));
				((UnityEventBase)talentCardUi.Buy.onClick).RemoveAllListeners();
				StartingPerk captured = val;
				((UnityEvent)talentCardUi.Buy.onClick).AddListener(new UnityAction(delegate
				{
					TryPurchase(captured);
					RefreshNativeTalentPanel();
				}));
				((Selectable)talentCardUi.Buy).interactable = interactable;
				SetButtonLabel(((Component)talentCardUi.Buy).transform, "体悟");
			}
			if (!((Object)(object)_nativeTalentPageButton != (Object)null))
			{
				return;
			}
			((UnityEventBase)_nativeTalentPageButton.onClick).RemoveAllListeners();
			if (_nativeTalentPage < num - 1)
			{
				((UnityEvent)_nativeTalentPageButton.onClick).AddListener(new UnityAction(([CompilerGenerated] () =>
				{
					NextNativeTalentPage();
				})));
				SetButtonLabel(((Component)_nativeTalentPageButton).transform, "下一页 " + (_nativeTalentPage + 1) + "/" + num);
			}
			else
			{
				((UnityEvent)_nativeTalentPageButton.onClick).AddListener(new UnityAction(([CompilerGenerated] () =>
				{
					CloseNativeTalentPanel();
				})));
				SetButtonLabel(((Component)_nativeTalentPageButton).transform, "返回交易");
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("RefreshNativeTalentPanel failed: " + (object)ex);
		}
	}

	private void NextNativeTalentPage()
	{
		int num = Math.Max(1, _nativeTalentCards.Count);
		int num2 = Math.Max(1, (_catalog.Count + num - 1) / num);
		if (_nativeTalentPage < num2 - 1)
		{
			_nativeTalentPage++;
			RefreshNativeTalentPanel();
		}
		else
		{
			CloseNativeTalentPanel();
		}
	}

	[IteratorStateMachine(typeof(_003CBuildNativeTalentPanelNextFrame_003Ed__87))]
	private System.Collections.IEnumerator BuildNativeTalentPanelNextFrame(CommissaryUIManager manager)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CBuildNativeTalentPanelNextFrame_003Ed__87(0)
		{
			_003C_003E4__this = this,
			manager = manager
		};
	}

	private RectTransform CreateRectObject(string name, Transform parent, RectTransform source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject(name);
		val.AddComponent<RectTransform>();
		RectTransform component = val.GetComponent<RectTransform>();
		((Transform)component).SetParent(parent, false);
		component.anchorMin = source.anchorMin;
		component.anchorMax = source.anchorMax;
		component.pivot = source.pivot;
		component.anchoredPosition = source.anchoredPosition;
		component.sizeDelta = source.sizeDelta;
		((Transform)component).localScale = Vector3.one;
		return component;
	}

	private static RectTransform CreateFullScreenRect(string name, Transform parent)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject(name);
		val.AddComponent<RectTransform>();
		RectTransform component = val.GetComponent<RectTransform>();
		((Transform)component).SetParent(parent, false);
		component.anchorMin = Vector2.zero;
		component.anchorMax = Vector2.one;
		component.pivot = new Vector2(0.5f, 0.5f);
		component.anchoredPosition = Vector2.zero;
		component.sizeDelta = Vector2.zero;
		((Transform)component).localScale = Vector3.one;
		return component;
	}

	private static RectTransform CreateRect(Transform parent, string name, Vector2 position, Vector2 size)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject(name);
		val.AddComponent<RectTransform>();
		RectTransform component = val.GetComponent<RectTransform>();
		((Transform)component).SetParent(parent, false);
		component.anchorMin = new Vector2(0.5f, 0.5f);
		component.anchorMax = new Vector2(0.5f, 0.5f);
		component.pivot = new Vector2(0.5f, 0.5f);
		component.anchoredPosition = position;
		component.sizeDelta = size;
		((Transform)component).localScale = Vector3.one;
		return component;
	}

	private Sprite GetNativeWhiteSprite()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)_nativeWhiteSprite == (Object)null)
		{
			_nativeWhiteSprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0f, 0f, 1f, 1f), new Vector2(0.5f, 0.5f));
		}
		return _nativeWhiteSprite;
	}

	private Image AddImage(RectTransform rect, Color color, Color? outline, float outlineDistance)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		Image obj = ((Component)rect).gameObject.AddComponent<Image>();
		obj.sprite = GetNativeWhiteSprite();
		obj.type = Image.Type.Sliced;
		((Graphic)obj).color = color;
		((Graphic)obj).raycastTarget = true;
		if (outline.HasValue && outlineDistance > 0f)
		{
			Outline obj2 = ((Component)rect).gameObject.AddComponent<Outline>();
			((Shadow)obj2).effectColor = outline.Value;
			((Shadow)obj2).effectDistance = new Vector2(outlineDistance, 0f - outlineDistance);
		}
		return obj;
	}

	private TextMeshProUGUI CreateText(RectTransform parent, string text, Vector2 position, Vector2 size, float fontSize, Color color, TextAlignmentOptions alignment)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		TextMeshProUGUI obj = ((Component)CreateRect((Transform)(object)parent, "Text", position, size)).gameObject.AddComponent<TextMeshProUGUI>();
		((TMP_Text)obj).font = _nativeTalentFont;
		((TMP_Text)obj).text = text;
		((TMP_Text)obj).fontSize = fontSize;
		((Graphic)obj).color = color;
		((TMP_Text)obj).alignment = alignment;
		((TMP_Text)obj).enableWordWrapping = false;
		((Graphic)obj).raycastTarget = false;
		return obj;
	}

	private Button CreateButton(RectTransform parent, string text, Vector2 position, Vector2 size, Color background, Color textColor, Action action)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		Action action2 = action;
		RectTransform val = CreateRect((Transform)(object)parent, "Button", position, size);
		Image targetGraphic = AddImage(val, background, (Color?)new Color(0.45f, 0.78f, 0.88f, 1f), 2f);
		Button obj = ((Component)val).gameObject.AddComponent<Button>();
		((Selectable)obj).targetGraphic = (Graphic)(object)targetGraphic;
		((UnityEvent)obj.onClick).AddListener(new UnityAction(delegate
		{
			action2.Invoke();
		}));
		TextMeshProUGUI obj2 = CreateText(val, text, Vector2.zero, size, 20f, textColor, (TextAlignmentOptions)514);
		((TMP_Text)obj2).rectTransform.anchorMin = Vector2.zero;
		((TMP_Text)obj2).rectTransform.anchorMax = Vector2.one;
		((TMP_Text)obj2).rectTransform.offsetMin = Vector2.zero;
		((TMP_Text)obj2).rectTransform.offsetMax = Vector2.zero;
		return obj;
	}

	private void CloseNativeTalentPanel()
	{
		_talentMode = false;
		DestroyNativeTalentPanel();
		try
		{
			CommissaryUIManager commissaryManager = _commissaryManager;
			if (commissaryManager != null)
			{
				commissaryManager.CloseUI();
			}
		}
		catch
		{
		}
	}

	private void DestroyNativeTalentPanel()
	{
		if ((Object)(object)_nativeTalentPanel != (Object)null)
		{
			Object.Destroy((Object)(object)_nativeTalentPanel);
		}
		_nativeTalentPanel = null;
		_nativeTalentCards.Clear();
		_nativeTalentPageButton = null;
		_nativeTalentPointsText = null;
		_nativeTalentPage = 0;
	}

	public void CaptureRegistrySnapshot()
	{
		try
		{
			List<StartingPerk> perks = StartingPerkList.Perks;
			if (perks == null)
			{
				PerkShopLog.Warning("Registry snapshot skipped because StartingPerkList.Perks is null.");
				return;
			}
			List<StartingPerk> val = new List<StartingPerk>(perks.Count);
			for (int i = 0; i < perks.Count; i++)
			{
				StartingPerk val2 = perks[i];
				if (val2 != null)
				{
					val.Add(val2);
				}
			}
			if (val.Count == 0)
			{
				PerkShopLog.Warning("Registry snapshot skipped because StartingPerkList.Perks is empty.");
				return;
			}
			_registryPerks.Clear();
			_registryPerks.AddRange((System.Collections.Generic.IEnumerable<StartingPerk>)val);
			_catalogBuilt = false;
			_catalog.Clear();
			PerkShopLog.Msg("Registry snapshot captured: " + _registryPerks.Count);
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("CaptureRegistrySnapshot failed: " + ex.Message);
		}
	}

	public void InvalidateCatalogOnly()
	{
		CaptureRegistrySnapshot();
	}

	internal void InitializeInternal()
	{
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		Instance = this;
		_config = ModConfig.For(PerkShopModEntry.ModId);
		_creditsPerPoint = _config.Define("CreditsPerPoint", 250, "天赋商店 / PerkShop", () => "Base credits per point", 1, 1000000, () => "First perk point cost.");
		_pointCostGrowth = _config.Define("PointCostGrowth", 1.5f, "天赋商店 / PerkShop", () => "Point cost growth", 1.01f, 100f, () => "Growth for the first four perk point costs.");
		_latePointCostGrowth = _config.Define("LatePointCostGrowth", 1.5f, "天赋商店 / PerkShop", () => "Late point cost growth", 1.01f, 100f, () => "Growth after the fourth perk point.");
		_costCurveVersion = _config.Define("CostCurveVersion", 0, "天赋商店 / PerkShop", () => "Cost curve version", 0, 1000, () => "Internal migration marker.");
		if (_costCurveVersion.Value < 3)
		{
			_creditsPerPoint.Set(777);
			_pointCostGrowth.Set(3.75f);
			_latePointCostGrowth.Set(1.5f);
			_costCurveVersion.Set(3);
		}
		_includeNegativePerks = _config.Define("IncludeNegativePerks", false, "天赋商店 / PerkShop", () => "Include negative perks", () => "Allow negative starting perks in the shop.");
		_config.Save();
		_harmony = HarmonyInstance;
		PerkShopLog.Msg("初始化阶段：兼容补丁。");
		TryInstallOptionalCompatibilityPatches(_harmony);
		PerkShopLog.Msg("初始化阶段：注册地图地点。");
		EnsureNativeButton(MapUIManager.Instance);
		PerkShopLog.Msg("初始化阶段：挂接 OnGUI。");
		PerkShopLog.Msg("PerkShopFramework loaded. Native map button enabled.");
	}

	internal void UpdateInternal()
	{
		PlayerStore store = GetStore();
		if (!CanUseInRun(store) || !IsStoreUiReady(store))
		{
			return;
		}
		try
		{
			EnsureLoaded(store);
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("状态加载失败：" + (object)ex);
			return;
		}
		try
		{
			UpdateMentorEvents(store, includeDeferredVisits: false);
			if (IsPerkShopMentorCurrent(store) && Time.frameCount != _mentorAdvanceQueuedFrame && (Input.GetMouseButtonDown(0) || Input.GetKeyDown((KeyCode)32) || Input.GetKeyDown((KeyCode)13)))
			{
				DialogUIManager instance = DialogUIManager.Instance;
				if ((Object)(object)instance != (Object)null && instance.isWaitingForManualAdvance)
				{
					_mentorAdvanceQueuedFrame = Time.frameCount;
					PerkShopRunner.Start(TryAdvanceMentorAfterFrame(instance));
				}
			}
		}
		catch (System.Exception ex2)
		{
			PerkShopLog.Error("导师对话推进失败：" + (object)ex2);
		}
		try
		{
			if (_menuOpen && Input.GetMouseButtonDown(0) && Time.frameCount != _lastClickFrame)
			{
				_lastClickFrame = Time.frameCount;
				ProcessClicksFromInput();
			}
		}
		catch (System.Exception ex3)
		{
			PerkShopLog.Error("菜单点击处理失败：" + (object)ex3);
		}
		try
		{
			ScanFoodStationButton();
		}
		catch (System.Exception ex4)
		{
			PerkShopLog.Error("配给站按钮扫描失败：" + (object)ex4);
		}
		try
		{
			PurchasedPerkContentDispatcher.Tick();
		}
		catch (System.Exception ex5)
		{
			PerkShopLog.Error("购买天赋内容调度失败：" + (object)ex5);
		}
		try
		{
			if (_savePending && CanSaveNow(store))
			{
				SaveNow(store, "pending");
			}
		}
		catch (System.Exception ex6)
		{
			PerkShopLog.Error("延迟保存失败：" + (object)ex6);
		}
	}

	internal void ShutdownInternal()
	{
		try
		{
			_harmony?.UnpatchAll(_harmony.Id);
			HarmonyInstance?.UnpatchAll(HarmonyInstance.Id);
		}
		catch
		{
		}
	}

	internal static bool IsTrackableTrade(GameItem item, int cost)
	{
		if (item != null && cost > 0)
		{
			return Instance != null;
		}
		return false;
	}

	internal static void AddPurchaseVolume(GameItem item, int cost)
	{
		if (IsTrackableTrade(item, cost))
		{
			Instance?.AddTradeVolume(Math.Abs(cost), "buy");
		}
	}

	internal static void AddSaleVolume(GameItem item, int cost)
	{
		if (IsTrackableTrade(item, cost))
		{
			Instance?.AddTradeVolume(Math.Abs(cost), "sell");
		}
	}

	private static bool CanSaveNow(PlayerStore store)
	{
		try
		{
			if (store == null)
			{
				return false;
			}
			if (store.currentClientInstance != null || store.isClientArrived || store.currentNegociatedItem != null || store.isClientBeingArrested || store.isHandlingShootout)
			{
				return false;
			}
		}
		catch
		{
			return false;
		}
		return true;
	}

	private static bool IsStoreUiReady(PlayerStore store)
	{
		try
		{
			return store != null && store.storeClientManager != null && (Object)(object)StoreUIManager.Instance != (Object)null;
		}
		catch
		{
			return false;
		}
	}

	private PlayerStore GetStore()
	{
		try
		{
			return PlayerStore.Instance;
		}
		catch
		{
			return null;
		}
	}

	private static bool CanUseInRun(PlayerStore store)
	{
		if (store != null && store.saveSlotId >= 0)
		{
			return !string.IsNullOrEmpty(store.runID);
		}
		return false;
	}

	private void EnsureLoaded(PlayerStore store)
	{
		if (!CanUseInRun(store) || store.runID == _loadedRunId)
		{
			return;
		}
		string loadedRunId = _loadedRunId;
		_loadedRunId = store.runID;
		int num = ReadInt(store, "StateVersion", 0);
		string text = ReadString(store, "StateRunId", string.Empty);
		int num2;
		if (num >= 2)
		{
			num2 = (string.Equals(text, store.runID, (StringComparison)4) ? 1 : 0);
			if (num2 != 0)
			{
				goto IL_0082;
			}
		}
		else
		{
			num2 = 0;
		}
		if (num < 2 || string.IsNullOrEmpty(loadedRunId) || !string.Equals(text, loadedRunId, (StringComparison)4))
		{
			goto IL_0082;
		}
		int num3 = (HasMeaningfulPersistedState(store) ? 1 : 0);
		goto IL_0083;
		IL_0083:
		bool flag = (byte)num3 != 0;
		if (num2 == 0 && !flag)
		{
			ClearPerkShopState(store);
			_tradeVolume = 0L;
			_volumeAtLastPoint = 0L;
			_points = 0;
			_pointsEarned = 0;
			_mentorIntroSeen = false;
			_mentorPromptedLevel = 0;
			_mentorNextVisitDay = -1;
			_mentorVisitCount = 0;
			_mentorNativeTutorialDone = false;
			_mentorVisitQueued = false;
			_pendingSawyerCrewDay = 0;
			PerkShopLog.Warning("PerkShop state was reset because run/save identity did not match. run=" + store.runID + " slot=" + store.saveSlotId);
		}
		else
		{
			if (flag)
			{
				PerkShopLog.Msg(string.Concat(new string[6]
				{
					"Adopted PerkShop state into forked run (save-snapshot mod compat). from=",
					text,
					" to=",
					store.runID,
					" slot=",
					store.saveSlotId.ToString()
				}));
			}
			_tradeVolume = ReadLong(store, "TradeVolume", 0L);
			_points = ReadInt(store, "Points", 0);
			_pointsEarned = ReadInt(store, "PointsEarned", -1);
			_volumeAtLastPoint = ReadLong(store, "VolumeAtLastPoint", -1L);
			int num4 = EstimatePointsEarned(_tradeVolume);
			if (_pointsEarned < 0)
			{
				_pointsEarned = num4;
			}
			else if (num4 > _pointsEarned)
			{
				int num5 = num4 - _pointsEarned;
				_points += num5;
				_pointsEarned = num4;
				PerkShopLog.Warning("Restored previously missed perk points: " + num5);
			}
			_volumeAtLastPoint = GetTotalCostForLevels(_pointsEarned);
			_mentorIntroSeen = ReadInt(store, "MentorIntroSeen", 0) != 0;
			_mentorPromptedLevel = ReadInt(store, "MentorPromptedLevel", _pointsEarned);
			_mentorNextVisitDay = ReadInt(store, "MentorNextVisitDay", -1);
			_mentorVisitCount = ReadInt(store, "MentorVisitCount", _mentorIntroSeen ? (1 + Math.Max(0, _mentorPromptedLevel)) : 0);
			_mentorNativeTutorialDone = ReadInt(store, "MentorNativeTutorialDone", 0) != 0;
			_pendingSawyerCrewDay = ReadInt(store, "PendingSawyerCrewDay", 0);
		}
		WriteString(store, "StateRunId", store.runID);
		WriteInt(store, "StateVersion", 2);
		_volumeAtLastPoint = GetTotalCostForLevels(_pointsEarned);
		WriteLong(store, "TradeVolume", _tradeVolume);
		WriteLong(store, "VolumeAtLastPoint", _volumeAtLastPoint);
		WriteInt(store, "PointsEarned", _pointsEarned);
		WriteInt(store, "Points", _points);
		WriteInt(store, "MentorIntroSeen", _mentorIntroSeen ? 1 : 0);
		WriteInt(store, "MentorPromptedLevel", _mentorPromptedLevel);
		WriteInt(store, "MentorNextVisitDay", _mentorNextVisitDay);
		WriteInt(store, "MentorVisitCount", _mentorVisitCount);
		WriteInt(store, "MentorNativeTutorialDone", _mentorNativeTutorialDone ? 1 : 0);
		WriteInt(store, "PendingSawyerCrewDay", _pendingSawyerCrewDay);
		_catalogBuilt = false;
		_deferredRepairsPending = true;
		PerkShopLog.Msg(string.Concat(new string[12]
		{
			"State loaded. run=",
			store.runID,
			" slot=",
			store.saveSlotId.ToString(),
			" volume=",
			_tradeVolume.ToString(),
			" points=",
			_points.ToString(),
			" pointLevel=",
			_pointsEarned.ToString(),
			" nextCost=",
			GetPointCost(_pointsEarned).ToString()
		}));
		return;
		IL_0082:
		num3 = 0;
		goto IL_0083;
	}

	private static bool HasMeaningfulPersistedState(PlayerStore store)
	{
		if (ReadLong(store, "TradeVolume", 0L) <= 0 && ReadInt(store, "Points", 0) <= 0 && ReadInt(store, "PointsEarned", 0) <= 0 && ReadInt(store, "MentorIntroSeen", 0) == 0)
		{
			return ReadInt(store, "MentorVisitCount", 0) > 0;
		}
		return true;
	}

	private void AddTradeVolume(int amount, string source)
	{
		if (amount <= 0)
		{
			return;
		}
		PlayerStore store = GetStore();
		try
		{
			EnsureLoaded(store);
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("状态加载失败（交易计量）：" + (object)ex);
			return;
		}
		if (!CanUseInRun(store))
		{
			return;
		}
		_tradeVolume += amount;
		int num = 0;
		while (_pointsEarned < 10000)
		{
			long pointCost = GetPointCost(_pointsEarned);
			if (_tradeVolume - _volumeAtLastPoint < pointCost)
			{
				break;
			}
			_pointsEarned++;
			_points++;
			num++;
		}
		_volumeAtLastPoint = GetTotalCostForLevels(_pointsEarned);
		WriteLong(store, "TradeVolume", _tradeVolume);
		WriteLong(store, "VolumeAtLastPoint", _volumeAtLastPoint);
		WriteInt(store, "PointsEarned", _pointsEarned);
		WriteInt(store, "Points", _points);
		if (num > 0)
		{
			ScheduleMentorForPoint(store);
			_savePending = true;
		}
		PerkShopLog.Msg(string.Concat(new string[12]
		{
			source,
			" volume+",
			amount.ToString(),
			" total=",
			_tradeVolume.ToString(),
			" points=",
			_points.ToString(),
			" level=",
			_pointsEarned.ToString(),
			" nextCost=",
			GetPointCost(_pointsEarned).ToString(),
			(num > 0) ? (" gained=" + num) : ""
		}));
	}

	private long GetPointCost(int level)
	{
		if (level < 0)
		{
			level = 0;
		}
		int num = Math.Max(1, (_creditsPerPoint != null) ? _creditsPerPoint.Value : 777);
		float num2 = Math.Max(1.01f, (_pointCostGrowth != null) ? _pointCostGrowth.Value : 3.75f);
		float num3 = Math.Max(1.01f, (_latePointCostGrowth != null) ? _latePointCostGrowth.Value : 1.5f);
		double num4 = ((level > 3) ? ((double)num * Math.Pow((double)num2, 3.0) * Math.Pow((double)num3, (double)(level - 3))) : ((double)num * Math.Pow((double)num2, (double)level)));
		if (num4 >= 9.223372036854776E+18)
		{
			return 9223372036854775807L;
		}
		return Math.Max(1L, (long)Math.Floor(num4));
	}

	private long GetTotalCostForLevels(int levels)
	{
		long num = 0L;
		for (int i = 0; i < levels && i < 10000; i++)
		{
			long pointCost = GetPointCost(i);
			if (pointCost > 9223372036854775807L - num)
			{
				return 9223372036854775807L;
			}
			num += pointCost;
		}
		return num;
	}

	private int EstimatePointsEarned(long volume)
	{
		int i = 0;
		long num = 0L;
		for (; i < 10000; i++)
		{
			long pointCost = GetPointCost(i);
			if (num > volume - pointCost)
			{
				break;
			}
			num += pointCost;
		}
		return i;
	}

	private long GetNextPointCost()
	{
		return GetPointCost(_pointsEarned);
	}

	private long GetProgressToNextPoint()
	{
		return Math.Max(0L, _tradeVolume - _volumeAtLastPoint);
	}

	private void SaveNow(PlayerStore store, string reason)
	{
		_savePending = false;
		PerkShopLog.Debug(string.Concat(new string[6]
		{
			"skipped self-save（P41）：",
			reason,
			". volume=",
			_tradeVolume.ToString(),
			" points=",
			_points.ToString()
		}));
	}

	private static long ReadLong(PlayerStore store, string key, long fallback)
	{
		return PerSaveState.GetLong(store, key, fallback);
	}

	private static int ReadInt(PlayerStore store, string key, int fallback)
	{
		long num = ReadLong(store, key, fallback);
		if (num > 2147483647)
		{
			return 2147483647;
		}
		if (num < -2147483648)
		{
			return -2147483648;
		}
		return (int)num;
	}

	private static void WriteLong(PlayerStore store, string key, long value)
	{
		PerSaveState.SetLong(store, key, value);
	}

	private static string ReadString(PlayerStore store, string key, string fallback)
	{
		return PerSaveState.GetString(store, key) ?? fallback;
	}

	private static void WriteString(PlayerStore store, string key, string value)
	{
		PerSaveState.SetString(store, key, value);
	}

	private static void ClearPerkShopState(PlayerStore store)
	{
		string[] array = new string[14]
		{
			"TradeVolume", "Points", "VolumeAtLastPoint", "PointsEarned", "StateRunId", "StateVersion", "MentorIntroSeen", "MentorPromptedLevel", "MentorNextVisitDay", "MentorVisitCount",
			"MentorNativeTutorialDone", "PendingSawyerCrewDay", "SawyerCrewHandled", "BeginDayPending"
		};
		foreach (string key in array)
		{
			PerSaveState.Remove(store, key);
		}
		PerSaveState.RemoveByPrefix(store, "AppliedContent.");
		PerSaveState.RemoveByPrefix(store, "PendingContent.");
		PerSaveState.RemoveByPrefix(store, "Repair.");
	}

	public void InvalidateLoadedState()
	{
		_loadedRunId = null;
		_tradeVolume = 0L;
		_volumeAtLastPoint = 0L;
		_points = 0;
		_pointsEarned = 0;
		_mentorIntroSeen = false;
		_mentorPromptedLevel = 0;
		_mentorNextVisitDay = -1;
		_mentorVisitCount = 0;
		_mentorNativeTutorialDone = false;
		_pendingSawyerCrewDay = 0;
		_mentorVisitQueued = false;
		_savePending = false;
		_nextMentorAttemptTime = 0f;
		_mentorAdvanceQueuedFrame = -1;
		_catalogBuilt = false;
		PurchasedPerkContentDispatcher.ResetStateForLoad();
	}

	public void ResetForNewRun()
	{
		InvalidateLoadedState();
		PlayerStore store = GetStore();
		if (CanUseInRun(store))
		{
			ClearPerkShopState(store);
			WriteString(store, "StateRunId", store.runID);
			WriteInt(store, "StateVersion", 2);
			WriteLong(store, "TradeVolume", 0L);
			WriteLong(store, "VolumeAtLastPoint", 0L);
			WriteInt(store, "PointsEarned", 0);
			WriteInt(store, "Points", 0);
			WriteInt(store, "MentorIntroSeen", 0);
			WriteInt(store, "MentorPromptedLevel", 0);
			WriteInt(store, "MentorNextVisitDay", -1);
			WriteInt(store, "MentorVisitCount", 0);
			WriteInt(store, "MentorNativeTutorialDone", 0);
			WriteInt(store, "PendingSawyerCrewDay", 0);
			WriteInt(store, "SawyerCrewHandled", 0);
		}
	}

	private static void WriteInt(PlayerStore store, string key, int value)
	{
		WriteLong(store, key, value);
	}

	private void EnsureCatalog()
	{
		if ((!_catalogBuilt || _catalog.Count <= 0) && CanUseInRun(GetStore()))
		{
			if (_registryPerks.Count == 0)
			{
				CaptureRegistrySnapshot();
			}
			BuildCatalog();
		}
	}

	private void BuildCatalog()
	{
		_catalog.Clear();
		HashSet<string> seen = new HashSet<string>((IEqualityComparer<string>)(object)StringComparer.Ordinal);
		int num = 0;
		int num2 = 0;
		try
		{
			for (int i = 0; i < _registryPerks.Count; i++)
			{
				num++;
				AddCatalogPerk(_registryPerks[i], seen);
			}
			List<StartingPerk> perks = StartingPerkList.Perks;
			if (perks != null)
			{
				for (int j = 0; j < perks.Count; j++)
				{
					num2++;
					AddCatalogPerk(perks[j], seen);
				}
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("StartingPerkList.Perks scan failed: " + ex.Message);
		}
		if (_catalog.Count == 0)
		{
			PerkShopLog.Warning("StartingPerkList.Perks is empty; catalog will wait for the native registry snapshot.");
		}
		_catalog.Sort((Comparison<StartingPerk>)((StartingPerk a, StartingPerk b) => string.Compare(GetPerkId(a), GetPerkId(b), (StringComparison)4)));
		_catalogBuilt = true;
		PerkShopLog.Msg(string.Concat(new string[6]
		{
			"Catalog built: snapshot=",
			num.ToString(),
			" list=",
			num2.ToString(),
			" usable=",
			_catalog.Count.ToString()
		}));
	}

	private void AddCatalogPerk(StartingPerk perk, HashSet<string> seen)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Invalid comparison between Unknown and I4
		if (perk == null)
		{
			return;
		}
		string perkId = GetPerkId(perk);
		if (string.IsNullOrEmpty(perkId) || !seen.Add(perkId))
		{
			return;
		}
		try
		{
			if (!_includeNegativePerks.Value && (int)perk.type == 1)
			{
				return;
			}
		}
		catch
		{
		}
		_catalog.Add(perk);
	}

	private static string GetPerkId(StartingPerk perk)
	{
		try
		{
			return ((perk != null) ? perk.id : null)?.TrimEnd('\0') ?? string.Empty;
		}
		catch
		{
			return string.Empty;
		}
	}

	private bool IsOwned(PlayerStore store, string id)
	{
		try
		{
			List<StartingPerk> startingPerks = store.startingPerks;
			if (startingPerks == null)
			{
				return false;
			}
			for (int i = 0; i < startingPerks.Count; i++)
			{
				if (string.Equals(GetPerkId(startingPerks[i]), id, (StringComparison)4))
				{
					return true;
				}
			}
		}
		catch
		{
		}
		return false;
	}

	private bool IsIncompatible(PlayerStore store, StartingPerk candidate)
	{
		string perkId = GetPerkId(candidate);
		try
		{
			List<StartingPerk> startingPerks = store.startingPerks;
			if (startingPerks == null)
			{
				return false;
			}
			for (int i = 0; i < startingPerks.Count; i++)
			{
				StartingPerk val = startingPerks[i];
				if (val != null && (IncompatibleContains(val, perkId) || IncompatibleContains(candidate, GetPerkId(val))))
				{
					return true;
				}
			}
		}
		catch
		{
		}
		return false;
	}

	private static bool IncompatibleContains(StartingPerk perk, string id)
	{
		if (perk == null || string.IsNullOrEmpty(id))
		{
			return false;
		}
		try
		{
			List<string> incompatiblePerks = perk.incompatiblePerks;
			if (incompatiblePerks == null)
			{
				return false;
			}
			for (int i = 0; i < incompatiblePerks.Count; i++)
			{
				if (string.Equals((incompatiblePerks[i] ?? string.Empty).TrimEnd('\0'), id, (StringComparison)4))
				{
					return true;
				}
			}
		}
		catch
		{
		}
		return false;
	}

	private bool ApplyPerkContentOnPurchase(PlayerStore store, StartingPerk perk)
	{
		TryInstallOptionalCompatibilityPatches(_harmony);
		string perkId = GetPerkId(perk);
		if (string.IsNullOrEmpty(perkId))
		{
			return false;
		}
		if (ReadInt(store, "AppliedContent." + perkId, 0) != 0)
		{
			return true;
		}
		PurchasedPerkContentDispatcher.Queue(store, perk);
		return true;
	}

	private void TryPurchase(StartingPerk perk)
	{
		try
		{
			if (perk == null)
			{
				return;
			}
			PlayerStore store = GetStore();
			if (!CanUseInRun(store))
			{
				return;
			}
			string perkId = GetPerkId(perk);
			if (IsOwned(store, perkId))
			{
				PerkShopLog.Warning("Perk already owned: " + perkId);
				return;
			}
			if (IsIncompatible(store, perk))
			{
				PerkShopLog.Warning("Perk is incompatible: " + perkId);
				return;
			}
			int num = Math.Max(0, perk.cost);
			if (_points < num)
			{
				return;
			}
			if (store.startingPerks == null)
			{
				PerkShopLog.Error("startingPerks list is null.");
				return;
			}
			bool flag = ApplyPerkContentOnPurchase(store, perk);
			if (!flag)
			{
				PerkShopLog.Warning("Purchase content did not apply; purchase was not committed. perk=" + perkId);
				return;
			}
			store.startingPerks.Add(perk);
			_points -= num;
			WriteInt(store, "Points", _points);
			SaveNow(store, "perk_purchase:" + perkId);
			string text = (string.IsNullOrEmpty(perk.id) ? perkId : perk.id);
			PerkShopLog.Msg(string.Concat(new string[10]
			{
				"Purchased perk=",
				perkId,
				" cost=",
				num.ToString(),
				" remainingPoints=",
				_points.ToString(),
				" contentApplied=",
				flag.ToString(),
				" active=",
				StartingPerk.IsPerkActive(text).ToString()
			}));
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("TryPurchase failed: " + (object)ex);
		}
	}

	private string GetDisplayName(StartingPerk perk)
	{
		try
		{
			string localizedDisplayName = perk.GetLocalizedDisplayName();
			if (!string.IsNullOrEmpty(localizedDisplayName))
			{
				return localizedDisplayName.TrimEnd('\0');
			}
		}
		catch
		{
		}
		return GetPerkId(perk);
	}

	private string GetDescription(StartingPerk perk)
	{
		try
		{
			return (perk.GetLocalizedDescription() ?? string.Empty).TrimEnd('\0');
		}
		catch
		{
			return string.Empty;
		}
	}

	public void EnsureNativeButton(MapUIManager manager)
	{
		EnsureNativeLocation();
	}

	private void EnsureNativeLocation()
	{
		if (_nativeLocationRegistered)
		{
			return;
		}
		_nativeLocationRegistered = true;
		try
		{
			DelegateAfterhourLocation location = ModHelper.AddAfterhourLocation(PerkShopModEntry.ModId, PerkShopLocationId, () => "天赋商店 / PerkShop", onArrive: OpenShopFromNativeButton, buildPanel: delegate(CustomUIBuilder builder)
			{
				builder.AddLabel("在这里花费天赋点解锁新的开局天赋。");
				builder.AddButton("打开天赋商店", OpenShopFromNativeButton);
			}, imageKey: "commissary", backgroundKey: "commissary", isDiscovered: () => true, isAvailable: () => true);
			if (location == null)
			{
				_nativeLocationRegistered = false;
				PerkShopLog.Warning("Native map location could not be registered.");
				return;
			}
			PerkShopLog.Msg("Native map location registered.");
		}
		catch (System.Exception ex)
		{
			_nativeLocationRegistered = false;
			PerkShopLog.Error("EnsureNativeLocation failed: " + (object)ex);
		}
	}

	private void OpenShopFromNativeButton()
	{
		try
		{
			_catalogBuilt = false;
			_page = 0;
			EnsureCatalog();
			_menuOpen = true;
			try
			{
				MapUIManager map = MapUIManager.Instance;
				if (map != null)
				{
					map.CloseUI();
				}
			}
			catch
			{
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("OpenShopFromNativeButton failed: " + (object)ex);
		}
	}

	public void RefreshCatalogFromUi()
	{
		try
		{
			_catalogBuilt = false;
			EnsureCatalog();
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("RefreshCatalogFromUi failed: " + ex.Message);
		}
	}

	private void EnsureStyles()
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		if (!_stylesReady)
		{
			try
			{
				_uiFont = Font.CreateDynamicFontFromOSFont(new string[4] { "Microsoft YaHei UI", "Microsoft YaHei", "SimHei", "Arial" }, 16);
			}
			catch
			{
				_uiFont = null;
			}
			_labelStyle = new GUIStyle(GUI.skin.label);
			_buttonStyle = new GUIStyle(GUI.skin.button);
			_boxStyle = new GUIStyle(GUI.skin.box);
			_windowStyle = new GUIStyle(GUI.skin.window);
			if ((Object)(object)_uiFont != (Object)null)
			{
				_labelStyle.font = _uiFont;
				_buttonStyle.font = _uiFont;
				_boxStyle.font = _uiFont;
				_windowStyle.font = _uiFont;
			}
			_labelStyle.fontSize = 16;
			_buttonStyle.fontSize = 15;
			_windowStyle.fontSize = 16;
			_labelStyle.wordWrap = false;
			_windowStyle.normal.textColor = new Color(0.96f, 0.91f, 0.75f, 1f);
			_stylesReady = true;
		}
	}

	private void DrawGui()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		if (!_menuOpen)
		{
			return;
		}
		Event current = Event.current;
		int depth = GUI.depth;
		GUI.depth = 33000;
		try
		{
			EnsureStyles();
			if (current != null && (int)current.type == 7)
			{
				_clickTargets.Clear();
				_windowRect = GUI.Window(73031, _windowRect, new GUI.WindowFunction(DrawWindow), "天赋升级", _windowStyle);
			}
			ConsumePointerEvents(current);
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("GUI failed: " + (object)ex);
		}
		finally
		{
			GUI.depth = depth;
		}
	}

	private void DrawWindow(int windowId)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected O, but got Unknown
		PlayerStore store = GetStore();
		if (!CanUseInRun(store))
		{
			DrawLabel(new Rect(14f, 32f, 520f, 24f), "请先进入一个已激活的存档。");
			DrawButton(new Rect(620f, 28f, 80f, 28f), "关闭", enabled: true, (Action)([CompilerGenerated] () =>
			{
				_menuOpen = false;
			}));
			return;
		}
		long nextPointCost = GetNextPointCost();
		long progressToNextPoint = GetProgressToNextPoint();
		DrawLabel(new Rect(14f, 26f, 430f, 24f), string.Concat(new string[6]
		{
			"累计交易额：",
			_tradeVolume.ToString(),
			"  天赋点：",
			_points.ToString(),
			"  下一阶：",
			nextPointCost.ToString()
		}));
		DrawButton(new Rect(430f, 24f, 70f, 28f), "刷新", enabled: true, (Action)([CompilerGenerated] () =>
		{
			_catalogBuilt = false;
			_page = 0;
			EnsureCatalog();
		}));
		DrawButton(new Rect(508f, 24f, 70f, 28f), "关闭", enabled: true, (Action)([CompilerGenerated] () =>
		{
			_menuOpen = false;
		}));
		DrawLabel(new Rect(14f, 54f, 500f, 24f), "当前阶进度：" + progressToNextPoint + " / " + nextPointCost);
		List<StartingPerk> val = new List<StartingPerk>();
		for (int i = 0; i < _catalog.Count; i++)
		{
			StartingPerk val2 = _catalog[i];
			if (val2 != null && !IsOwned(store, GetPerkId(val2)))
			{
				val.Add(val2);
			}
		}
		if (val.Count == 0)
		{
			DrawLabel(new Rect(14f, 100f, 600f, 28f), "没有可购买天赋。");
			return;
		}
		int num = Math.Max(1, (val.Count + 7 - 1) / 7);
		if (_page >= num)
		{
			_page = num - 1;
		}
		if (_page < 0)
		{
			_page = 0;
		}
		int num2 = _page * 7;
		int num3 = Math.Min(7, val.Count - num2);
		for (int j = 0; j < num3; j++)
		{
			DrawPerkRow(store, val[num2 + j], new Rect(6f, 84f + (float)j * 62f, 690f, 58f));
		}
		DrawLabel(new Rect(14f, 524f, 180f, 24f), string.Concat(new string[5]
		{
			"第 ",
			(_page + 1).ToString(),
			" / ",
			num.ToString(),
			" 页"
		}));
		DrawButton(new Rect(500f, 518f, 90f, 28f), "上一页", _page > 0, (Action)([CompilerGenerated] () =>
		{
			_page--;
		}));
		DrawButton(new Rect(600f, 518f, 90f, 28f), "下一页", _page < num - 1, (Action)([CompilerGenerated] () =>
		{
			_page++;
		}));
	}

	private void DrawPerkRow(PlayerStore store, StartingPerk perk, Rect row)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		StartingPerk perk2 = perk;
		if (perk2 != null)
		{
			string perkId = GetPerkId(perk2);
			bool flag = IsIncompatible(store, perk2);
			int num = Math.Max(0, perk2.cost);
			bool enabled = !flag && _points >= num;
			DrawBox(row);
			DrawLabel(new Rect(row.x + 8f, row.y + 4f, 420f, 22f), GetDisplayName(perk2) + "  [" + num + " 天赋点]");
			DrawLabel(new Rect(row.x + 428f, row.y + 4f, 105f, 22f), flag ? "互斥" : string.Empty);
			DrawButton(new Rect(row.x + 576f, row.y + 15f, 96f, 28f), "购买", enabled, (Action)delegate
			{
				TryPurchase(perk2);
			});
			string text = GetDescription(perk2);
			if (text.Length > 72)
			{
				text = text.Substring(0, 72) + "...";
			}
			DrawLabel(new Rect(row.x + 8f, row.y + 26f, 650f, 20f), text);
			DrawLabel(new Rect(row.x + 8f, row.y + 43f, 650f, 18f), "ID：" + perkId);
		}
	}

	private void DrawLabel(Rect rect, string text)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		Color contentColor = GUI.contentColor;
		GUI.contentColor = new Color(0.61f, 0.25f, 0.2f, 1f);
		_labelStyle.Draw(rect, new GUIContent(text), false, false, false, false);
		GUI.contentColor = contentColor;
	}

	private void DrawBox(Rect rect)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		DrawRect(rect, new Color(0.91f, 0.84f, 0.64f, 1f));
		DrawBorder(rect, new Color(0.82f, 0.4f, 0.28f, 1f), 2f);
	}

	private void DrawButton(Rect rect, string text, bool enabled, Action action)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		bool flag = enabled && rect.Contains(GuiMouse());
		DrawRect(rect, flag ? new Color(0.92f, 0.5f, 0.34f, 1f) : new Color(0.82f, 0.4f, 0.28f, 1f));
		DrawBorder(rect, new Color(0.62f, 0.28f, 0.23f, 1f), 2f);
		Color contentColor = GUI.contentColor;
		GUI.contentColor = (enabled ? new Color(0.97f, 0.91f, 0.75f, 1f) : new Color(0.55f, 0.5f, 0.43f, 1f));
		_buttonStyle.Draw(rect, new GUIContent(text), flag, flag && Input.GetMouseButton(0), false, false);
		GUI.contentColor = contentColor;
		if (enabled)
		{
			RegisterClick(rect, action);
		}
	}

	private static void DrawRect(Rect rect, Color color)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		Color color2 = GUI.color;
		GUI.color = color;
		GUI.DrawTexture(rect, (Texture)(object)Texture2D.whiteTexture);
		GUI.color = color2;
	}

	private static void DrawBorder(Rect rect, Color color, float thickness)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		DrawRect(new Rect(rect.x, rect.y, rect.width, thickness), color);
		DrawRect(new Rect(rect.x, rect.yMax - thickness, rect.width, thickness), color);
		DrawRect(new Rect(rect.x, rect.y, thickness, rect.height), color);
		DrawRect(new Rect(rect.xMax - thickness, rect.y, thickness, rect.height), color);
	}

	private void RegisterClick(Rect localRect, Action action)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		_clickTargets.Add(new ClickTarget
		{
			ScreenRect = new Rect(_windowRect.x + localRect.x, _windowRect.y + localRect.y, localRect.width, localRect.height),
			Action = action
		});
	}

	private void ProcessClicksFromInput()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = GuiMouse();
		for (int num = _clickTargets.Count - 1; num >= 0; num--)
		{
			ClickTarget clickTarget = _clickTargets[num];
			if (clickTarget.ScreenRect.Contains(val))
			{
				clickTarget.Action.Invoke();
				break;
			}
		}
	}

	private static Vector2 GuiMouse()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		Vector3 mousePosition = Input.mousePosition;
		return new Vector2(mousePosition.x, (float)Screen.height - mousePosition.y);
	}

	private static void ConsumePointerEvents(Event evt)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Invalid comparison between Unknown and I4
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Invalid comparison between Unknown and I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Invalid comparison between Unknown and I4
		if (evt != null && ((int)evt.type == 0 || (int)evt.type == 1 || (int)evt.type == 3 || (int)evt.type == 6))
		{
			Vector2 mousePosition = evt.mousePosition;
			mousePosition.y = (float)Screen.height - mousePosition.y;
			Rect val = new Rect(0f, 0f, (float)Screen.width, (float)Screen.height);
			if (val.Contains(mousePosition))
			{
				evt.Use();
			}
		}
	}

	public bool TryGrantFutureTechStarterItems()
	{
		string[] array = ResolveFutureTechStarterItemIds();
		if (array == null || array.Length == 0)
		{
			PerkShopLog.Warning("FutureTech starter item list was unavailable.");
			return false;
		}
		bool result = true;
		HashSet<string> val = new HashSet<string>((IEqualityComparer<string>)(object)StringComparer.Ordinal);
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (string.IsNullOrEmpty(text) || !val.Add(text))
			{
				continue;
			}
			try
			{
				if (HasOwnedItem(text))
				{
					continue;
				}
				GameItem val2 = DirectoryMaster.Item(text, true);
				if (val2 == null)
				{
					result = false;
					continue;
				}
				val2.DisableTag("TAG_NOT_PURCHASED", true);
				val2.DisableTag("not_purchased", true);
				if (!RoutePurchasedItemToPlayerOrCounter(val2))
				{
					result = false;
				}
			}
			catch (System.Exception ex)
			{
				result = false;
				PerkShopLog.Warning("FutureTech item grant failed for " + text + ": " + ex.Message);
			}
		}
		return result;
	}

	private static string[] ResolveFutureTechStarterItemIds()
	{
		try
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				System.Type type = assemblies[i].GetType("DeepSpacePawnshop.FutureTech.FutureEdition", false);
				if (!(type == (System.Type)null))
				{
					FieldInfo field = type.GetField("StarterItems", (BindingFlags)56);
					string[] array = ((field != (FieldInfo)null) ? (field.GetValue((object)null) as string[]) : null);
					if (array != null && array.Length != 0)
					{
						return array;
					}
				}
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("FutureTech starter item discovery failed: " + ex.Message);
		}
		return new string[2] { "dspf_future_purifier", "dspf_future_nuclear_battery" };
	}

	private static bool HasOwnedItem(string identifier)
	{
		try
		{
			EmporiumEntry instance = EmporiumEntry.Instance;
			List<GameItem> val = (((Object)(object)instance != (Object)null) ? instance.GetAllOwnedItems(false, true) : null);
			if (val != null)
			{
				for (int i = 0; i < val.Count; i++)
				{
					GameItem val2 = val[i];
					if (val2 != null && string.Equals(val2.identifier, identifier, (StringComparison)4))
					{
						return true;
					}
				}
			}
		}
		catch
		{
		}
		return false;
	}

	public void TryRepairLegacyFutureTechItems(PlayerStore store)
	{
		if (CanUseInRun(store) && ReadInt(store, "Repair.FutureTechStarterItems", 0) == 0 && ReadInt(store, "AppliedContent.dspf_future_tech", 0) != 0 && TryGrantFutureTechStarterItems())
		{
			WriteInt(store, "Repair.FutureTechStarterItems", 1);
			_savePending = true;
			PerkShopLog.Msg("Repaired legacy Future Tech starter items.");
		}
	}

	public void TryRepairLegacyExtraPerksItems(PlayerStore store)
	{
		if (!CanUseInRun(store) || ReadInt(store, "Repair.ScavengersReignToken", 0) != 0)
		{
			return;
		}
		bool flag = false;
		try
		{
			List<StartingPerk> startingPerks = store.startingPerks;
			if (startingPerks != null)
			{
				for (int i = 0; i < startingPerks.Count; i++)
				{
					string text = GetPerkId(startingPerks[i]).TrimEnd('\0');
					if (string.Equals(text, "拾荒者之王", (StringComparison)4) || string.Equals(text, "ScavengersReign", (StringComparison)4))
					{
						flag = true;
						break;
					}
				}
			}
		}
		catch
		{
		}
		if (!flag)
		{
			return;
		}
		try
		{
			EmporiumEntry instance = EmporiumEntry.Instance;
			List<GameItem> val = (((Object)(object)instance != (Object)null) ? instance.GetInvItems() : null);
			if (val != null)
			{
				for (int j = 0; j < val.Count; j++)
				{
					GameItem val2 = val[j];
					if (val2 != null && string.Equals(val2.identifier, "scav_token", (StringComparison)4))
					{
						WriteInt(store, "Repair.ScavengersReignToken", 1);
						return;
					}
				}
			}
			GameItem val3 = DirectoryMaster.Item("scav_token", true);
			if (val3 != null)
			{
				val3.DisableTag("TAG_NOT_PURCHASED", true);
				val3.DisableTag("not_purchased", true);
				if (RoutePurchasedItemToPlayerOrCounter(val3))
				{
					WriteInt(store, "Repair.ScavengersReignToken", 1);
					PerkShopLog.Msg("Repaired missing ExtraPerks item: scav_token");
				}
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("TryRepairLegacyExtraPerksItems failed: " + ex.Message);
		}
	}

	private bool TryGrantKnownItems(params string[] identifiers)
	{
		bool result = true;
		HashSet<string> val = new HashSet<string>((IEqualityComparer<string>)(object)StringComparer.Ordinal);
		foreach (string text in identifiers)
		{
			if (string.IsNullOrEmpty(text) || !val.Add(text))
			{
				continue;
			}
			try
			{
				if (HasOwnedItem(text))
				{
					continue;
				}
				GameItem val2 = DirectoryMaster.Item(text, true);
				if (val2 == null)
				{
					result = false;
					PerkShopLog.Warning("已知天赋物品不存在：" + text);
					continue;
				}
				val2.DisableTag("TAG_NOT_PURCHASED", true);
				val2.DisableTag("not_purchased", true);
				if (!RoutePurchasedItemToPlayerOrCounter(val2))
				{
					result = false;
					PerkShopLog.Warning("已知天赋物品发放失败：" + text);
				}
			}
			catch (System.Exception ex)
			{
				result = false;
				PerkShopLog.Warning("已知天赋物品发放异常：" + text + "，" + ex.Message);
			}
		}
		return result;
	}

	public bool RoutePurchasedItemToPlayerOrCounter(GameItem item)
	{
		if (item == null)
		{
			return false;
		}
		try
		{
			EmporiumEntry instance = EmporiumEntry.Instance;
			if ((Object)(object)instance == (Object)null || instance.invElement == null)
			{
				PerkShopLog.Warning("玩家背包入口尚未就绪，跳过主背包发放：" + item.identifier);
			}
			else
			{
				instance.TryAddToPlayerInv(item);
				if (item.parentInventory != null)
				{
					PerkShopLog.Msg("Purchased item routed to player inventory: " + item.identifier);
					return true;
				}
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("TryAddToPlayerInv failed for purchased item: " + ex.Message);
		}
		try
		{
			PlayerStore store = GetStore();
			if (CanUseInRun(store))
			{
				store.AddDirectSellingItemToTable(item, true, false, false, 0);
				if (item.parentInventory != null)
				{
					PerkShopLog.Msg("Purchased item routed to counter: " + item.identifier);
					return true;
				}
				PerkShopLog.Warning("柜台接收后未检测到物品归属：" + item.identifier);
			}
		}
		catch (System.Exception ex2)
		{
			PerkShopLog.Error("Counter fallback failed for purchased item: " + (object)ex2);
		}
		return false;
	}

	public bool TryGrantTapeheadCassettes()
	{
		try
		{
			int num = 0;
			for (int i = 0; i < TapeheadCassetteIds.Length; i++)
			{
				string text = TapeheadCassetteIds[i];
				if (!HasOwnedItem(text))
				{
					GameItem val = DirectoryMaster.Item(text, true);
					if (val == null)
					{
						PerkShopLog.Warning("Tapehead cassette item is unavailable: " + text);
						return false;
					}
					val.DisableTag("TAG_NOT_PURCHASED", true);
					val.DisableTag("not_purchased", true);
					if (!RoutePurchasedItemToPlayerOrCounter(val))
					{
						PerkShopLog.Warning("Tapehead cassette could not be placed: " + text);
						return false;
					}
					num++;
				}
			}
			PerkShopLog.Msg("Tapehead cassette set granted directly; new=" + num + ".");
			return true;
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("Tapehead cassette grant failed: " + ex.Message);
			return false;
		}
	}

	public void TryRepairLegacyTapeheadCassettes(PlayerStore store)
	{
		if (!CanUseInRun(store) || ReadInt(store, "AppliedContent.tapehead", 0) == 0 || ReadInt(store, "Repair.TapeheadCassettes", 0) != 0)
		{
			return;
		}
		try
		{
			if (!HasAllTapeheadCassettes() && !TryGrantTapeheadCassettes())
			{
				PerkShopLog.Warning("Tapehead repair could not grant all cassette items.");
				return;
			}
			if (!HasAllTapeheadCassettes())
			{
				PerkShopLog.Warning("Tapehead repair is waiting for all cassette items to appear.");
				return;
			}
			WriteInt(store, "Repair.TapeheadCassettes", 1);
			_savePending = true;
			PerkShopLog.Msg("Repaired legacy Tapehead cassettes.");
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("TryRepairLegacyTapeheadCassettes failed: " + ex.Message);
		}
	}

	private static bool HasAllTapeheadCassettes()
	{
		for (int i = 0; i < TapeheadCassetteIds.Length; i++)
		{
			if (!HasOwnedItem(TapeheadCassetteIds[i]))
			{
				return false;
			}
		}
		return true;
	}

	public bool TryGrantWagesPerksDestinyDice()
	{
		try
		{
			if (!TryInvokeWagesPerksItemGrant(FindLoadedType("DestinyDicePerk"), "_diceGiven", "GiveIfActive"))
			{
				PerkShopLog.Warning("WagesPerks DestinyDicePerk grant method was unavailable.");
				return false;
			}
			if (!HasOwnedItem("destiny_dice"))
			{
				GameItem val = InvokeGameItemFactory(FindLoadedType("DestinyDice"), "CreateDestinyDice");
				if (val == null)
				{
					PerkShopLog.Warning("WagesPerks DestinyDice factory returned null.");
					return false;
				}
				val.DisableTag("TAG_NOT_PURCHASED", true);
				val.DisableTag("not_purchased", true);
				if (!RoutePurchasedItemToPlayerOrCounter(val))
				{
					return false;
				}
			}
			PerkShopLog.Msg("WagesPerks item grant invoked: destiny_dice");
			return true;
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("WagesPerks DestinyDice grant failed: " + ex.Message);
			return false;
		}
	}

	public bool TryGrantWagesPerksFrogBox()
	{
		try
		{
			if (!TryInvokeWagesPerksItemGrant(FindLoadedType("FrogPowerPerk"), "_storageBoxGiven", "TryGiveStorageBox"))
			{
				PerkShopLog.Warning("WagesPerks FrogPowerPerk grant method was unavailable.");
				return false;
			}
			if (!HasOwnedItem("custom_storage_box"))
			{
				System.Type type = FindLoadedType("CustomStorageContainer");
				GameItem val = InvokeGameItemFactory(type, "CreateContainer");
				if (val == null)
				{
					PerkShopLog.Warning("WagesPerks CustomStorageContainer factory returned null.");
					return false;
				}
				TryFillFrogStorageBox(type, val);
				val.DisableTag("TAG_NOT_PURCHASED", true);
				val.DisableTag("not_purchased", true);
				if (!RoutePurchasedItemToPlayerOrCounter(val))
				{
					return false;
				}
			}
			PerkShopLog.Msg("WagesPerks item grant invoked: custom_storage_box");
			return true;
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("WagesPerks FrogPowerPerk grant failed: " + ex.Message);
			return false;
		}
	}

	public void TryRepairLegacyWagesPerksItems(PlayerStore store)
	{
		if (CanUseInRun(store))
		{
			TryRepairLegacyWagesPerksItem(store, "命运之骰", "destiny_dice", TryGrantWagesPerksDestinyDice);
			TryRepairLegacyWagesPerksItem(store, "蛙哥牛逼", "custom_storage_box", TryGrantWagesPerksFrogBox);
		}
	}

	private void TryRepairLegacyWagesPerksItem(PlayerStore store, string perkId, string itemId, Func<bool> grant)
	{
		if (ReadInt(store, "AppliedContent." + perkId, 0) != 0 && ReadInt(store, "Repair.WagesPerks." + perkId, 0) == 0 && !HasOwnedItem(itemId) && grant.Invoke())
		{
			WriteInt(store, "Repair.WagesPerks." + perkId, 1);
			_savePending = true;
			PerkShopLog.Msg("Repaired legacy WagesPerks item: " + itemId);
		}
	}

	private static bool TryInvokeWagesPerksItemGrant(System.Type perkType, string flagName, string methodName)
	{
		if (perkType == (System.Type)null)
		{
			return false;
		}
		FieldInfo field = perkType.GetField(flagName, (BindingFlags)56);
		if (field != (FieldInfo)null && field.FieldType == typeof(bool))
		{
			field.SetValue((object)null, (object)false);
		}
		MethodInfo val = FindStaticMethod(perkType, methodName, 0);
		if (val == (MethodInfo)null)
		{
			return false;
		}
		((MethodBase)val).Invoke((object)null, (object[])null);
		return true;
	}

	private static MethodInfo? FindStaticMethod(System.Type type, string name, int parameterCount)
	{
		if (type == (System.Type)null || string.IsNullOrEmpty(name))
		{
			return null;
		}
		MethodInfo[] methods = type.GetMethods((BindingFlags)56);
		foreach (MethodInfo val in methods)
		{
			if (((MemberInfo)val).Name == name && ((MethodBase)val).GetParameters().Length == parameterCount)
			{
				return val;
			}
		}
		return null;
	}

	private static GameItem InvokeGameItemFactory(System.Type type, string methodName)
	{
		if (type == (System.Type)null)
		{
			return null;
		}
		try
		{
			MethodInfo val = FindStaticMethod(type, methodName, 0);
			return (GameItem)((val != (MethodInfo)null) ? (object)val.Invoke(null, null) : null);
		}
		catch
		{
			return null;
		}
	}

	private static void TryFillFrogStorageBox(System.Type factoryType, GameItem item)
	{
		try
		{
			MethodInfo val = ((factoryType == (System.Type)null) ? null : FindStaticMethod(factoryType, "FillWithRandomLockedBoxes", 2));
			if (val != (MethodInfo)null)
			{
				((MethodBase)val).Invoke((object)null, new object[2] { item, 1 });
			}
		}
		catch
		{
		}
	}

	private static System.Type? FindLoadedType(string typeName)
	{
		if (string.IsNullOrEmpty(typeName))
		{
			return null;
		}
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly val in assemblies)
		{
			try
			{
				System.Type type2 = val.GetType(typeName, false);
				if (type2 != (System.Type)null)
				{
					return type2;
				}
			}
			catch
			{
			}
		}
		if (typeName.IndexOf('.') >= 0)
		{
			return null;
		}
		assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly val2 in assemblies)
		{
			System.Type[] array;
			try
			{
				array = val2.GetTypes();
			}
			catch (ReflectionTypeLoadException val3)
			{
				array = Enumerable.ToArray<System.Type>(Enumerable.Where<System.Type>((System.Collections.Generic.IEnumerable<System.Type>)val3.Types, (Func<System.Type, bool>)((System.Type type) => type != (System.Type)null)));
			}
			catch
			{
				continue;
			}
			foreach (System.Type type3 in array)
			{
				if (type3 != (System.Type)null && string.Equals(((MemberInfo)type3).Name, typeName, (StringComparison)4))
				{
					return type3;
				}
			}
		}
		return null;
	}

	public static void TryInstallOptionalCompatibilityPatches(Harmony harmony)
	{
		if (harmony != null)
		{
			PerkShopLog.Msg("兼容补丁：开始挂 InventoryGrant 重定向。");
			TryInstallInventoryGrantRedirect(harmony);
			PerkShopLog.Msg("兼容补丁：InventoryGrant 重定向阶段结束。");
			TryInstallVainPersonCompatibility(harmony);
			PerkShopLog.Msg("兼容补丁：VainPerson 阶段结束。");
		}
	}

	private static void TryInstallInventoryGrantRedirect(Harmony harmony)
	{
		if (_inventoryGrantRedirectInstalled)
		{
			return;
		}
		try
		{
			MethodInfo val = AccessTools.Method(typeof(PurchasedContentInventoryGrantRedirectPatch), "Prefix", new System.Type[1] { typeof(string) });
			if (val == (MethodInfo)null)
			{
				return;
			}
			int num = 0;
			System.Collections.Generic.IEnumerator<MethodInfo> enumerator = EnumerateInventoryGrantTargets().GetEnumerator();
			try
			{
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					MethodInfo current = enumerator.Current;
					harmony.Patch((MethodBase)(object)current, new HarmonyMethod(val), (HarmonyMethod)null);
					num++;
					PerkShopLog.Msg("特性 mod 开局发放重定向已挂载：" + ((MemberInfo)current).DeclaringType?.FullName);
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			if (num > 0)
			{
				_inventoryGrantRedirectInstalled = true;
			}
			else
			{
				PerkShopLog.Debug("未发现 InventoryGrant 型发放入口，本次跳过（下次购买重试）。");
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("InventoryGrant 重定向挂载失败：" + ex.Message);
		}
	}

	[IteratorStateMachine(typeof(_003CEnumerateInventoryGrantTargets_003Ed__240))]
	private static System.Collections.Generic.IEnumerable<MethodInfo> EnumerateInventoryGrantTargets()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CEnumerateInventoryGrantTargets_003Ed__240(-2);
	}

	private static void TryInstallVainPersonCompatibility(Harmony harmony)
	{
		if (_vainPersonCompatibilityInstalled)
		{
			return;
		}
		try
		{
			System.Type type = FindLoadedType("VainPerson.PerkClickDiagPatch");
			MethodInfo val = ((type == (System.Type)null) ? null : AccessTools.Method(type, "ClickPrefix", new System.Type[1] { typeof(StartingPerkElement) }));
			MethodInfo val2 = AccessTools.Method(typeof(VainPersonClickDiagSuppressor), "Prefix", System.Type.EmptyTypes);
			if (!(val == (MethodInfo)null) && !(val2 == (MethodInfo)null))
			{
				harmony.Patch((MethodBase)(object)val, new HarmonyMethod(val2), (HarmonyMethod)null);
				_vainPersonCompatibilityInstalled = true;
				PerkShopLog.Msg("VainPerson picker click diagnostics suppressed.");
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Warning("VainPerson compatibility patch failed: " + ex.Message);
		}
	}

	internal static bool CanApplyPurchasedContent()
	{
		try
		{
			return Instance != null && !Instance.IsApplyingPurchasedContent;
		}
		catch
		{
			return false;
		}
	}

	internal static PlayerStore? GetCurrentStoreForDispatcher()
	{
		try
		{
			return Instance?.GetStore();
		}
		catch
		{
			return null;
		}
	}

	internal void SetApplyingPurchasedContent(bool value)
	{
		IsApplyingPurchasedContent = value;
	}

	internal void MarkSavePending()
	{
		_savePending = true;
	}

	internal void ScheduleSawyerAfterPurchase(PlayerStore store)
	{
		ScheduleSawyerCrewNextDay(store);
	}

	private void RefreshClonedTalentPanel()
	{
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Expected O, but got Unknown
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Expected O, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		try
		{
			PlayerStore store = GetStore();
			if ((Object)(object)_talentPanelClone == (Object)null || _talentCards == null || _talentCards.Count == 0 || !CanUseInRun(store))
			{
				return;
			}
			int count = _talentCards.Count;
			int num = Math.Max(1, (_catalog.Count + count - 1) / count);
			if (_talentPage >= num)
			{
				_talentPage = num - 1;
			}
			if (_talentPage < 0)
			{
				_talentPage = 0;
			}
			for (int i = 0; i < _talentCards.Count; i++)
			{
				CommissaryElement val = _talentCards[i];
				if ((Object)(object)val == (Object)null)
				{
					continue;
				}
				int num2 = _talentPage * count + i;
				if (num2 >= _catalog.Count)
				{
					((Component)val).gameObject.SetActive(false);
					continue;
				}
				StartingPerk val2 = _catalog[num2];
				string perkId = GetPerkId(val2);
				bool flag = IsOwned(store, perkId);
				bool flag2 = !flag && IsIncompatible(store, val2);
				int num3 = Math.Max(0, val2.cost);
				bool interactable = !flag && !flag2 && _points >= num3;
				((Component)val).gameObject.SetActive(true);
				string text = (((Object)(object)val.productName != (Object)null) ? ((TMP_Text)val.productName).text : null);
				string text2 = (((Object)(object)val.price != (Object)null) ? ((TMP_Text)val.price).text : null);
				string text3 = (((Object)(object)val.stock != (Object)null) ? ((TMP_Text)val.stock).text : null);
				TextMeshProUGUI[] componentsInChildren = ((Component)val).gameObject.GetComponentsInChildren<TextMeshProUGUI>(true);
				TextMeshProUGUI val3 = null;
				TextMeshProUGUI val4 = null;
				TextMeshProUGUI val5 = null;
				if (componentsInChildren != null)
				{
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						if ((Object)(object)val3 == (Object)null && !string.IsNullOrEmpty(text) && ((TMP_Text)componentsInChildren[j]).text == text)
						{
							val3 = componentsInChildren[j];
						}
						else if ((Object)(object)val4 == (Object)null && !string.IsNullOrEmpty(text2) && ((TMP_Text)componentsInChildren[j]).text == text2)
						{
							val4 = componentsInChildren[j];
						}
						else if ((Object)(object)val5 == (Object)null && !string.IsNullOrEmpty(text3) && ((TMP_Text)componentsInChildren[j]).text == text3)
						{
							val5 = componentsInChildren[j];
						}
					}
					if ((Object)(object)val3 == (Object)null && componentsInChildren.Length > 0)
					{
						val3 = componentsInChildren[0];
					}
					if ((Object)(object)val4 == (Object)null && componentsInChildren.Length > 1)
					{
						val4 = componentsInChildren[1];
					}
					if ((Object)(object)val5 == (Object)null && componentsInChildren.Length > 2)
					{
						val5 = componentsInChildren[2];
					}
				}
				if ((Object)(object)val3 != (Object)null)
				{
					((TMP_Text)val3).text = GetDisplayName(val2);
				}
				if ((Object)(object)val4 != (Object)null)
				{
					((TMP_Text)val4).text = num3 + " 天赋点";
				}
				if ((Object)(object)val5 != (Object)null)
				{
					((TMP_Text)val5).text = (flag ? "已拥有" : (flag2 ? "不可体悟" : "可体悟"));
				}
				Button componentInChildren = ((Component)val).gameObject.GetComponentInChildren<Button>(true);
				if ((Object)(object)componentInChildren != (Object)null)
				{
					StartingPerk captured = val2;
					((UnityEventBase)componentInChildren.onClick).RemoveAllListeners();
					((UnityEvent)componentInChildren.onClick).AddListener(new UnityAction(delegate
					{
						TryPurchase(captured);
						RefreshClonedTalentPanel();
					}));
					((Selectable)componentInChildren).interactable = interactable;
					SetButtonLabel(((Component)componentInChildren).transform, "购买");
				}
			}
			if ((Object)(object)_talentPageButton != (Object)null)
			{
				if (_talentPage < num - 1)
				{
					RebindButton(((Component)_talentPageButton).gameObject, "下一页 " + (_talentPage + 1) + "/" + num, new Action(NextTalentPage));
				}
				else
				{
					RebindButton(((Component)_talentPageButton).gameObject, "返回交易", new Action(CloseClonedTalentPanel));
				}
			}
		}
		catch (System.Exception ex)
		{
			PerkShopLog.Error("RefreshClonedTalentPanel failed: " + (object)ex);
		}
	}

	[IteratorStateMachine(typeof(_003CBuildTalentPanelCloneNextFrame_003Ed__252))]
	private System.Collections.IEnumerator BuildTalentPanelCloneNextFrame(CommissaryUIManager manager)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CBuildTalentPanelCloneNextFrame_003Ed__252(0)
		{
			_003C_003E4__this = this,
			manager = manager
		};
	}

	private void PrepareClonedPanelTexts()
	{
		if ((Object)(object)_talentPanelClone == (Object)null)
		{
			return;
		}
		System.Collections.Generic.IEnumerator<TextMeshProUGUI> enumerator = ((System.Collections.Generic.IEnumerable<TextMeshProUGUI>)_talentPanelClone.GetComponentsInChildren<TextMeshProUGUI>(true)).GetEnumerator();
		try
		{
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				TextMeshProUGUI current = enumerator.Current;
				if (!string.IsNullOrEmpty(((TMP_Text)current).text))
				{
					if (((TMP_Text)current).text.Contains("配给站"))
					{
						((TMP_Text)current).text = "体悟";
					}
					else if (((TMP_Text)current).text.Contains("已兑换") || ((TMP_Text)current).text.Contains("票券"))
					{
						((TMP_Text)current).text = "剩余天赋点：" + _points + "   累计交易额：" + _tradeVolume;
					}
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
	}

	private void PrepareClonedPanelButtons()
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		_talentPageButton = null;
		if ((Object)(object)_talentPanelClone == (Object)null)
		{
			return;
		}
		Button[] componentsInChildren = _talentPanelClone.GetComponentsInChildren<Button>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Button val = componentsInChildren[i];
			if (!((Object)(object)val == (Object)null))
			{
				string buttonText = GetButtonText(((Component)val).transform);
				string text = ((((Object)val).name != null) ? ((Object)val).name.ToLowerInvariant() : string.Empty);
				if (!string.IsNullOrEmpty(buttonText) && (buttonText.Contains("兑换") || buttonText.Contains("交易")))
				{
					_talentPageButton = val;
					RebindButton(((Component)val).gameObject, "下一页", new Action(NextTalentPage));
				}
				else if ((!string.IsNullOrEmpty(buttonText) && (buttonText.Contains("返回") || buttonText.Contains("关闭") || buttonText == "×" || buttonText == "X")) || text.Contains("close"))
				{
					RebindButton(((Component)val).gameObject, "返回", new Action(CloseClonedTalentPanel));
				}
			}
		}
	}

	private void NextTalentPage()
	{
		int num = ((_talentCards == null) ? 1 : Math.Max(1, _talentCards.Count));
		int num2 = Math.Max(1, (_catalog.Count + num - 1) / num);
		if (_talentPage < num2 - 1)
		{
			_talentPage++;
			RefreshClonedTalentPanel();
		}
		else
		{
			CloseClonedTalentPanel();
		}
	}

	private void CloseClonedTalentPanel()
	{
		_talentMode = false;
		DestroyTalentPanelClone();
		try
		{
			CommissaryUIManager commissaryManager = _commissaryManager;
			if (commissaryManager != null)
			{
				commissaryManager.CloseUI();
			}
		}
		catch
		{
		}
	}

	private void DestroyTalentPanelClone()
	{
		if ((Object)(object)_talentPanelClone != (Object)null)
		{
			Object.Destroy((Object)(object)_talentPanelClone);
		}
		_talentPanelClone = null;
		_talentCards = null;
		_talentPageButton = null;
		_talentPage = 0;
	}
}
