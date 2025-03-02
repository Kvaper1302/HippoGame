using System;
using UnityEngine;

namespace Storage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Storage/PoopStorage", fileName = "PoopStorage")]
    public class PoopStorageScriptableObject : ScriptableObject
    {
        [field: SerializeField] private double Poop { get; set; }


        public event Action OnPoopAmountChanged ;

        
        private void IncreasePoop(double increaseAmount)
        {
            Poop += (increaseAmount);
            OnPoopAmountChanged?.Invoke();
        }
        
        private void DecreasePoop(double decreaseAmount)
        {
            Poop += (decreaseAmount);
            OnPoopAmountChanged?.Invoke();
        }
        
    }

}