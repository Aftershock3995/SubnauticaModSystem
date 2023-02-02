namespace Higherpowah
{
    using HarmonyLib;
    using SMLHelper.V2.Handlers;
    using System;
    using System.Reflection;
    using BepInEx;
    using System.Runtime.InteropServices;

    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class Main : BaseUnityPlugin
    {
        #region[Declarations]
        public const string
            MODNAME = "ElecticalMK2",
            AUTHOR = "Aftershock",
            GUID = AUTHOR + "_" + MODNAME,
            VERSION = "1.0.0.1";
        internal static Modules.SeamothElectricalModule2 moduleMK2 = new();
        
        #endregion

        private void Awake()
        {
            try
            {
                Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), GUID);
                LanguageHandler.SetLanguageLine("Tooltip_VehicleElectricalMK2", "Higher powah. Does not stack");
                moduleMK2.Patch();
     
                Logger.LogInfo("Succesfully patched yippe!");
            }
            catch (Exception e)
            {
                Logger.LogError(e.InnerException.Message);
                Logger.LogError(e.InnerException.StackTrace);
            }
        }
    }
}