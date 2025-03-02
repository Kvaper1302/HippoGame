using System;
using System.Collections.Generic;
using UnityEngine;

namespace Storage
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Storage/GoodsStorage/Vegetables", fileName = nameof(Storage))]
    public class VegetableStorageScriptableObject : ScriptableObject
    {

        [field: SerializeField]
        public List<VegetablesStored> Vegetables {get; private set;}

        private SellHandler _sellHandler;

        private void OnEnable()
        {
            _sellHandler.OnVegetableSold += PrintDebug;
        }


        private void PrintDebug(string vegetableType)
        {
            Debug.Log("The type of vegetable passed is" + vegetableType);
        }

        public event Action OnVegetablesAmountChanged ;
        
        
        private void ChangeStoredVegetablesAmount(string type, double addAmount)
        {
        int index = 0;
        foreach (var item in Vegetables)
        {
            if(item.vegetableType == type)
            {
                break;
            }
            index++;
        }
        Debug.Log("ListIndex " + index);
            
            Vegetables[index].count += addAmount;
            OnVegetablesAmountChanged?.Invoke();
        }


    }

    [System.Serializable]
    public class VegetablesStored
    {
        public string vegetableType;
        public double count;

    }

}
