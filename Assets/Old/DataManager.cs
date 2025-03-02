using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviour
{
private static DataManager DataManagerInstance;   //Единственная копия данных

internal double money;
internal double Poop;
internal double Day;
//Hippo stuff
internal double FoodInTheBelly;
internal double BellySize = 6;
//Potato stuff
internal double farmPotatoLevel = 1;
internal double poopInPotato;
internal double potatoCount;
internal double poopPerPotatoCycle = 1;
internal double maxPoopInPotato = 1;
internal double potatoPerCycle = 1;
internal double potatoBaseUpgradeCost = 5;
internal double potatoNextUpgradeCost = 5;
internal double potatoBasicPrice = 8;
internal double potatoPrice = 8;
internal float potatoCostRateExponent = 1.07f;
internal double potatoUpgradeCost10;
internal double potatoUpgradeCost25;
internal double potatoUpgradeCostMax;
internal double potatoUpgradeNumberMax;
//Onion stuff
internal double farmOnionLevel = 0;
internal double poopInOnion;
internal double onionCount;
internal double poopPerOnionCycle = 4;
internal double maxPoopInOnion = 0;
internal double onionPerCycle = 1;
internal double onionBaseUpgradeCost = 200;
internal double onionNextUpgradeCost = 200;
internal double onionBasicPrice = 150;
internal double onionPrice = 150;
internal float onionCostRateExponent = 1.13f;
internal double onionUpgradeCost10;
internal double onionUpgradeCost25;
internal double onionUpgradeCostMax;
internal double onionUpgradeNumberMax;
 






  public List<bool> toggleValues; // Список значений для всех тогглеров

    public void SetToggleValue(int index, bool value)
    {
        if (index >= 0 && index < toggleValues.Count)
        {
            toggleValues[index] = value;
        }
    }
private void Awake()
{
    if(DataManagerInstance == null)
    {
        DataManagerInstance = this;
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        Destroy(gameObject);
    }


    Debug.Log("dataManager: " + DataManagerInstance);
}

    public static DataManager GetInstance()
    {
        return DataManagerInstance;
    }


}
