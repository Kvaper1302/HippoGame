using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/Vegetable", fileName = nameof(Vegetable))]

    public class Vegetable : ScriptableObject
    {
        [field: SerializeField] private string Name { get; set; }
        [field: SerializeField] private float BasePrice { get; set; }
        [field: SerializeField] private float BaseUpgradePrice { get; set; }
        [field: SerializeField] private float BaseProductionPerCycle { get; set; }
        [field: SerializeField] private float NeededPoopPerCycle { get; set; }
        [field: SerializeField] private float UpgradeCostGrowthModifier { get; set; }
        [field: SerializeField] private float BaseGrowthTime { get; set; }
    }


}