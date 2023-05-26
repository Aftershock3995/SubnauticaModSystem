using System.Collections;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace seamothHealthModule
{
    public class SeamothHealthUpgrade : Equipable
    {
        public static TechType SeamothHealthModule { get; private set; }

        public SeamothHealthUpgrade() : base(
            classId: "SeamothHealthUpgrade",
            friendlyName: "Seamoth health upgrade",
            description: "Increases Seamoth health.")
        {
            SeamothHealthModule = this.TechType;
        }

        public override EquipmentType EquipmentType => EquipmentType.SeamothModule;

        public override TechType RequiredForUnlock => TechType.BaseUpgradeConsole;

        public override TechGroup GroupForPDA => TechGroup.Workbench;

        public override TechCategory CategoryForPDA => TechCategory.Workbench;

        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;

        public override QuickSlotType QuickSlotType => QuickSlotType.Passive;

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            var taskResult = new TaskResult<GameObject>();
            yield return CraftData.InstantiateFromPrefabAsync(TechType.SeamothElectricalDefense, taskResult);
            var obj = taskResult.Get();

            var techTag = obj.GetComponent<TechTag>();
            var prefabIdentifier = obj.GetComponent<PrefabIdentifier>();

            techTag.type = TechType;
            prefabIdentifier.ClassId = ClassID;
            gameObject.Set(obj);
        }

        public static void OnUpgradeModuleChange(SeaMoth seamoth, int slotID, TechType techType, bool added)
        {
            if (techType == SeamothHealthModule)
            {
                LiveMixinData liveMixinData = seamoth.liveMixin.data;

                if (added)
                {
                    float healthIncrease = 50f;
                    liveMixinData.maxHealth = 200f + healthIncrease;
                    Debug.Log("Seamoth health increased with the module!");
                }
                else
                {
                    float healthDecrease = 50f;
                    liveMixinData.maxHealth = 200f - healthDecrease;
                    Debug.Log("Seamoth health decreased with the module!");
                }

                seamoth.liveMixin.data = liveMixinData;
                UpdateHUD(seamoth);
            }
        }

        private static void UpdateHUD(SeaMoth seamoth)
        {
            uGUI_SeamothHUD hud = GameObject.FindObjectOfType<uGUI_SeamothHUD>();
            if (hud != null)
            {
                float maxHealth = seamoth.liveMixin.data.maxHealth;
                hud.textHealth.text = Mathf.CeilToInt(maxHealth).ToString();
            }
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                Ingredients = new List<Ingredient>()
                {
                    new Ingredient(TechType.VehicleHullModule3, 1),
                    new Ingredient(TechType.PlasteelIngot, 1),
                    new Ingredient(TechType.Nickel, 2),
                    new Ingredient(TechType.AluminumOxide, 3)
                },
                craftAmount = 1
            };
        }

        protected override Atlas.Sprite GetItemSprite()
        {
            return SpriteManager.Get(TechType.VehicleHullModule3);
        }
    }
}
