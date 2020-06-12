using System;
using BepInEx;
using HarmonyLib;

namespace FullClanMod
{
    [BepInPlugin("FullClanMod", "Full Clan Mod", "0.0.1")]
    [BepInProcess("MonsterTrain.exe")]
    [BepInProcess("MtLinkHandler.exe")]
    public class FullClanMod : BaseUnityPlugin
    {
        void Awake()
        {
            var harmony = new Harmony("FullClanMod");
            harmony.PatchAll();
            Console.WriteLine("FullClanMod 0.0.1");
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
    public class LetRandomToHitTheSameClassesPatch
    {
        public static void Prefix(ref ClassData avoidClass)
        {
            avoidClass = null;
        }
    }
}
