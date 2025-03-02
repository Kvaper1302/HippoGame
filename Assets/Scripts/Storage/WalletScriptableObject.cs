using System;
using UnityEngine;

namespace Storage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Storage/Wallet", fileName = "Wallet")]
    public class WalletScriptableObject : ScriptableObject
    {
        [field: SerializeField] private double Money { get; set; }


        public event Action OnMoneyAmountChanged ;

        
        private void ChangeMoneyAmount(double changeAmount)
        {
            Money += (changeAmount);
            OnMoneyAmountChanged?.Invoke();
        }

        private void OnEnable()
        {
            
        }
    }

}