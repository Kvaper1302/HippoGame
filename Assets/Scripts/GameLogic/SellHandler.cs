    using Storage;
    using UnityEngine;
    using System;

    public class SellHandler : MonoBehaviour
    {
        [SerializeField] private WalletScriptableObject wallet;

        [SerializeField] private VegetableStorageScriptableObject vegetableStorage;

            public event Action<string> OnVegetableSold;

            private SellPotatoButton _sellPotatoButton;
        private void Start()
        {
            _sellPotatoButton.OnPotatoSellButtonPressed += SellAllVegetablesOfType;
        }

            private void SellAllVegetablesOfType(string vegetableType)
        {
            OnVegetableSold?.Invoke(vegetableType);
        }

    }
