using System;
using UnityEngine;

namespace FarmStats
{
    [CreateAssetMenu(menuName = "ScriptableObjects/FarmStats", fileName = nameof(FarmStats))]
    public class FarmStatsScriptableObject : ScriptableObject
    {
        [field: SerializeField] private double FarmLevel { get; set; }
        [field: SerializeField] private double MaxPoopIn { get; set; }



        public event Action OnFarmLevelChanged ;
        public event Action OnMaxPoopInChanged ;

        
        private void IncreaseFarmLevel(double increaseAmount)
        {
            FarmLevel += (increaseAmount);
            OnFarmLevelChanged?.Invoke();
        }
        
        private void IncreaseMaxPoopIn(double increaseAmount)
        {
            MaxPoopIn += (increaseAmount);
            OnMaxPoopInChanged?.Invoke();
        }
        
    }

}
