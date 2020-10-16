using BepInEx;
using HarmonyLib;

namespace FullClanMod
{
    [BepInPlugin("FullClanMod", "Full Clan Mod", "0.0.1")]
    public class FullClanMod : BaseUnityPlugin
    {
        void Awake()
        {
            var harmony = new Harmony("FullClanMod");
            harmony.PatchAll();
        }

    }

    [HarmonyPatch(typeof(ClassSelectionIconUI), "SwapClassIfNecessary")]
    public class DoNotSwapClassPatch
    {
        public static bool Prefix(ClassSelectionUI.ClassOptionData disabledClass, ClassSelectionUI.ClassOptionData replacementClass)
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(SaveManager), "GetRandomUnlockedClass")]
    public class LetRandomHitTheSameClassesPatch
    {
        public static void Prefix(ref ClassData avoidClass)
        {
            avoidClass = null;
        }
    }

}
