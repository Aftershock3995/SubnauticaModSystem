using System.Collections;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using System.Collections.Generic;
using UnityEngine;



namespace Higherpowah.Modules
{

    internal class SeamothElectricalModule2 : Equipable


    {
          public static TechType thisTechType;
        public SeamothElectricalModule2() : base(
            classId: "SeamothElectricalModule2",
            friendlyName: "Seamoth Electrical Module MK2",
            description: "Higher powah. Does not stack.")
        {
        }

        public override EquipmentType EquipmentType => EquipmentType.SeamothModule;

        public override TechType RequiredForUnlock => TechType.BaseUpgradeConsole;

        public override TechGroup GroupForPDA => TechGroup.Workbench;

        public override TechCategory CategoryForPDA => TechCategory.Workbench;

        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;

        public override QuickSlotType QuickSlotType => QuickSlotType.Selectable;


        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            var taskResult = new TaskResult<GameObject>();
            yield return CraftData.InstantiateFromPrefabAsync(TechType.VehicleHullModule3, taskResult);
            var obj = taskResult.Get();


            var techTag = obj.GetComponent<TechTag>();
            var prefabIdentifier = obj.GetComponent<PrefabIdentifier>();

            techTag.type = TechType;
            prefabIdentifier.ClassId = ClassID;
            gameObject.Set(obj);
        }


        protected override TechData GetBlueprintRecipe()
        {
            return new()
            {
                Ingredients = new List<Ingredient>()
                {
                    new(TechType.SeamothElectricalDefense, 1),
                    new(TechType.Diamond, 2),
                    new(TechType.Battery, 1)
                },
                craftAmount = 1
            };
        }

        protected override Atlas.Sprite GetItemSprite()
        {
            return SpriteManager.Get(TechType.SeamothElectricalDefense);


        }
    }
}