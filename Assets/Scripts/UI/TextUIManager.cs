using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.U2D.Animation;
using Unity.VisualScripting;
using Unity.Collections;
public class TextUIManager : MonoBehaviour
{


    [SerializeField]
    TextMeshProUGUI poopCount;  
    [SerializeField]
    TextMeshProUGUI dayCount;
    [SerializeField]
    TextMeshProUGUI moneyCount;
    [SerializeField]
    //Картофель
    TextMeshProUGUI poopInPotato;
    [SerializeField]
    TextMeshProUGUI potatolevel;
    [SerializeField]
    TextMeshProUGUI potatoCount;
    [SerializeField]
    TextMeshProUGUI potatoUpgradeCost;
    [SerializeField]
    TextMeshProUGUI potatoPrice;
    //Лук
    [SerializeField]
    TextMeshProUGUI poopInOnion;
    [SerializeField]
    TextMeshProUGUI onionlevel;
    [SerializeField]
    TextMeshProUGUI onionCount;
    [SerializeField]
    TextMeshProUGUI onionUpgradeCost;
    [SerializeField]
    TextMeshProUGUI onionPrice;
    


    
    private DataManager dataManager;

    void Awake()
    {
        dataManager = DataManager.GetInstance();
    }

    void Update()
    {
    if(dataManager != null)
        {
            poopCount.text = "Poop: " + dataManager.Poop;
            dayCount.text = "Day: " + dataManager.Day;
            moneyCount.text = "Money: " + dataManager.money;
            //Картофель
            potatoCount.text = "Potato: " + dataManager.potatoCount;
            potatolevel.text = "LVL " + dataManager.farmPotatoLevel;
            poopInPotato.text = "" + dataManager.poopInPotato + "/" + dataManager.maxPoopInPotato;
            potatoUpgradeCost.text = "$" + dataManager.potatoNextUpgradeCost;
            potatoPrice.text = "" + dataManager.potatoPrice + "$";
            //Лук
            onionCount.text = "Onion: " + dataManager.onionCount;
            onionlevel.text = "LVL " + dataManager.farmOnionLevel;
            poopInOnion.text = "" + dataManager.poopInOnion + "/" + dataManager.maxPoopInOnion;
            onionUpgradeCost.text = "$" + dataManager.onionNextUpgradeCost;
            onionPrice.text = "" + dataManager.onionPrice + "$";
            
        }
        
    else
    {
        Debug.Log("ItsNull");
    }
    }
}
