using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    private DataManager dataManager;  //ссылка на дата менеджер
    double potatoPoopDifference;  //разница между макс количеством какашек
                                     // и текущим количеством какашек в ферме картошки
    double onionPoopDifference;  //разница между макс количеством какашек
                                     // и текущим количеством какашек в ферме лука


    

    internal float growthTimePotato = 5f;
    internal float elapsedTimePotato = 0f;
    internal bool isGrowingPotato;
    internal float growthTimeOnion = 25f;
    internal float elapsedTimeOnion = 0f;
    internal bool isGrowingOnion;






    private static GameManager gameManagerInstance; //Синглтон

    void Awake() //этот синглтон, а также получение ссылки на дата менеджер
    {
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        dataManager = DataManager.GetInstance();
    }

    public static GameManager GetInstance()
    {
        return gameManagerInstance;
    }





    //Посчитать статы Универсальная
    internal (double, double, double, double, double, double, double, double) countFarmStats(double FarmLevel, double PoopPerCycle, double BasePrice, double BaseUpgradeCost, float CostRateExponent, double Money)
    {
        double MaxPoopIn = FarmLevel * PoopPerCycle;
        double FarmLevelMinusOne = FarmLevel - 1;
        double MultiplierFromFarmLevel = FarmLevelMinusOne * 0.05f + 1;  //Насколько дороже становится продукт
        double CurrentPrice = BasePrice * MultiplierFromFarmLevel;  //Стоимость одного продукта
        double NextUpgradeCost =  BaseUpgradeCost * Math.Pow(CostRateExponent, FarmLevelMinusOne);
        double ProductionModifier = math.floor(FarmLevel / 25) * 2 + math.floor(FarmLevel / 100) * 2;
        double ProductionPerCycle = 1;
        if(ProductionModifier > 1)
        {
        ProductionPerCycle = 1 * ProductionModifier;
        }

        double UpgradeCost10;
        double UpgradeCost25;
        double UpgradeCostMax;
        double maxUpgradeNumber;

        maxUpgradeNumber = HowMuchCanUpgradeUniversal(BasePrice, CostRateExponent,  FarmLevel, Money);
        UpgradeCost10 = NumberUpgradeCost(10, CostRateExponent, BasePrice, FarmLevel);
        UpgradeCost25 = NumberUpgradeCost(25, CostRateExponent, BasePrice, FarmLevel);
        UpgradeCostMax = NumberUpgradeCost(maxUpgradeNumber, CostRateExponent, BasePrice, FarmLevel);

        return (MaxPoopIn, CurrentPrice, NextUpgradeCost, ProductionPerCycle, UpgradeCost10, UpgradeCost25, UpgradeCostMax, maxUpgradeNumber);
    }





    //ПОЛОЖИТЬ КАКАШКИ В УНИВЕРСАЛЬНАЯ
    internal (double, double) putPoopInUniversal(double Poop, double PoopInContainer, double MaxPoopIn)
    {
         if(PoopInContainer == 0)
                {
                    if(Poop >= MaxPoopIn)
                    {
                        Poop -= MaxPoopIn;
                        PoopInContainer = MaxPoopIn;
                        return (Poop, PoopInContainer);
                    }
                    else
                    {
                        PoopInContainer += Poop;
                        Poop = 0;
                        return (Poop, PoopInContainer);
                    }
                }
                else
                {
                    potatoPoopDifference = MaxPoopIn - PoopInContainer;
                    if(Poop >= potatoPoopDifference)
                    {
                        Poop -= potatoPoopDifference;
                        PoopInContainer += potatoPoopDifference;
                        return (Poop, PoopInContainer);
                    }
                    else
                    {
                        PoopInContainer += Poop;
                        Poop = 0;
                        return (Poop, PoopInContainer);
                    }
                }
    }
    //Ускорение универсальное
    internal float SpeedUpUniversal(bool IsGrowing, float ElapsedTime)
    {
        if(IsGrowing)
        {
            ElapsedTime += 1f;
            return ElapsedTime;
        }
        else
        {
            return ElapsedTime;
        }
    }

    //Подсчёт на сколько апгрейдов хватит денег

    internal double HowMuchCanUpgradeUniversal(double BasePrice, float CostRateExponent, double FarmLevel, double money)
    {
        double maxUpgrade = Math.Floor(Math.Log(money * (CostRateExponent - 1) / (BasePrice * math.pow(CostRateExponent, FarmLevel)) + 1 , CostRateExponent));
        return maxUpgrade;
    }

    //стоимость максимума апгрейдов

    internal double NumberUpgradeCost(double number, float CostRateExponent, double BasePrice, double FarmLevel)
    {
        double numberUpgradeCost = BasePrice * (math.pow(CostRateExponent, FarmLevel) * (math.pow(CostRateExponent, number) - 1) / (CostRateExponent - 1));
        return numberUpgradeCost; 
    }



    //Положить какашки в
    internal void putPoopInPotato()
    {
        (dataManager.Poop, dataManager.poopInPotato) = putPoopInUniversal(dataManager.Poop, dataManager.poopInPotato, dataManager.maxPoopInPotato);  
    }



    internal void putPoopInOnion()
        {
        (dataManager.Poop, dataManager.poopInOnion) = putPoopInUniversal(dataManager.Poop, dataManager.poopInOnion, dataManager.maxPoopInOnion);  
        }




    //ПРОДАТЬ

    internal void sellAllPotato()
    {
                dataManager.money += dataManager.potatoCount * dataManager.potatoPrice;
                dataManager.potatoCount = 0;
                Debug.Log("Sold all potato");
    }
        internal void sellAllOnion()
    {
                dataManager.money += dataManager.onionCount * dataManager.onionPrice;
                dataManager.onionCount = 0;
                Debug.Log("Sold all onion");
    }
    



    //УЛУЧШИТЬ
    internal void upgradePotato()
    {
        if(dataManager.money >= dataManager.potatoNextUpgradeCost) //если достаточно денег
        {
            dataManager.money -= dataManager.potatoNextUpgradeCost;
            dataManager.farmPotatoLevel += 1;
            (dataManager.maxPoopInPotato, dataManager.potatoPrice, dataManager.potatoNextUpgradeCost, dataManager.potatoPerCycle, dataManager.potatoUpgradeCost10, dataManager.potatoUpgradeCost25, dataManager.potatoUpgradeCostMax, dataManager.potatoUpgradeNumberMax) = countFarmStats(dataManager.farmPotatoLevel, dataManager.poopPerPotatoCycle, dataManager.potatoBasicPrice, dataManager.potatoBaseUpgradeCost, dataManager.potatoCostRateExponent, dataManager.money);
            Debug.Log("Potato upgraded");
        }
        else
        {
            Debug.Log("Not enough money to upgrade potato");
        }
    }
    
    internal void upgradePotato10()
    {
        if (dataManager.money > dataManager.potatoUpgradeCost10)
            {
                dataManager.money -= dataManager.potatoUpgradeCost10;
                dataManager.farmPotatoLevel += 10;
                (dataManager.maxPoopInOnion,  dataManager.onionPrice, dataManager.onionNextUpgradeCost, dataManager.onionPerCycle, dataManager.onionUpgradeCost10, dataManager.onionUpgradeCost25, dataManager.onionUpgradeCostMax, dataManager.onionUpgradeNumberMax) = countFarmStats(dataManager.farmOnionLevel, dataManager.poopPerOnionCycle, dataManager.onionBasicPrice, dataManager.onionBaseUpgradeCost, dataManager.onionCostRateExponent, dataManager.money);
            }
    }

    internal void upgradePotato25()
    {
        if (dataManager.money > dataManager.potatoUpgradeCost25)
            {
                dataManager.money -= dataManager.potatoUpgradeCost25;
                dataManager.farmPotatoLevel += 25;
                (dataManager.maxPoopInOnion,  dataManager.onionPrice, dataManager.onionNextUpgradeCost, dataManager.onionPerCycle, dataManager.onionUpgradeCost10, dataManager.onionUpgradeCost25, dataManager.onionUpgradeCostMax, dataManager.potatoUpgradeNumberMax) = countFarmStats(dataManager.farmOnionLevel, dataManager.poopPerOnionCycle, dataManager.onionBasicPrice, dataManager.onionBaseUpgradeCost, dataManager.onionCostRateExponent, dataManager.money);
            }
    }

    internal void upgradePotatoMax()
    {
        if (dataManager.money > dataManager.potatoUpgradeCostMax)
            {
                dataManager.money -= dataManager.potatoUpgradeCostMax;
                dataManager.farmPotatoLevel += dataManager.potatoUpgradeNumberMax;
                (dataManager.maxPoopInOnion,  dataManager.onionPrice, dataManager.onionNextUpgradeCost, dataManager.onionPerCycle, dataManager.onionUpgradeCost10, dataManager.onionUpgradeCost25, dataManager.onionUpgradeCostMax, dataManager.onionUpgradeNumberMax) = countFarmStats(dataManager.farmOnionLevel, dataManager.poopPerOnionCycle, dataManager.onionBasicPrice, dataManager.onionBaseUpgradeCost, dataManager.onionCostRateExponent, dataManager.money);
            }
    }






        private void growPotato()
    {
        //Забрали какашку
        dataManager.poopInPotato -= dataManager.poopPerPotatoCycle;

        //Дали картошку
        dataManager.potatoCount += dataManager.potatoPerCycle;
    }

    internal void upgradeOnion()
    {
        if(dataManager.money >= dataManager.onionNextUpgradeCost) //если достаточно денег
        {
            dataManager.money -= dataManager.onionNextUpgradeCost;
            dataManager.farmOnionLevel += 1;
            (dataManager.maxPoopInOnion,  dataManager.onionPrice, dataManager.onionNextUpgradeCost, dataManager.onionPerCycle, dataManager.onionUpgradeCost10, dataManager.onionUpgradeCost25, dataManager.onionUpgradeCostMax, dataManager.onionUpgradeNumberMax) = countFarmStats(dataManager.farmOnionLevel, dataManager.poopPerOnionCycle, dataManager.onionBasicPrice, dataManager.onionBaseUpgradeCost, dataManager.onionCostRateExponent, dataManager.money);
            Debug.Log("Onion upgraded");
        }
        else
        {
            Debug.Log("Not enough money to upgrade Onion");
        }
    }

    internal void upgradeOnion10()
    {
        if (dataManager.money > dataManager.onionUpgradeCost10)
            {
                dataManager.money -= dataManager.onionUpgradeCost10;
                dataManager.farmOnionLevel += 10;
                (dataManager.maxPoopInOnion,  dataManager.onionPrice, dataManager.onionNextUpgradeCost, dataManager.onionPerCycle, dataManager.onionUpgradeCost10, dataManager.onionUpgradeCost25, dataManager.onionUpgradeCostMax, dataManager.onionUpgradeNumberMax) = countFarmStats(dataManager.farmOnionLevel, dataManager.poopPerOnionCycle, dataManager.onionBasicPrice, dataManager.onionBaseUpgradeCost, dataManager.onionCostRateExponent, dataManager.money);
            }
    }

    internal void upgradeOnion25()
    {
        if (dataManager.money > dataManager.onionUpgradeCost25)
            {
                dataManager.money -= dataManager.onionUpgradeCost25;
                dataManager.farmOnionLevel += 25;
                (dataManager.maxPoopInOnion,  dataManager.onionPrice, dataManager.onionNextUpgradeCost, dataManager.onionPerCycle, dataManager.onionUpgradeCost10, dataManager.onionUpgradeCost25, dataManager.onionUpgradeCostMax, dataManager.onionUpgradeNumberMax) = countFarmStats(dataManager.farmOnionLevel, dataManager.poopPerOnionCycle, dataManager.onionBasicPrice, dataManager.onionBaseUpgradeCost, dataManager.onionCostRateExponent, dataManager.money);
            }
    }

    internal void upgradeOnionMax()
    {
        if (dataManager.money > dataManager.onionUpgradeCostMax)
            {
                dataManager.money -= dataManager.onionUpgradeCostMax;
                dataManager.farmOnionLevel += dataManager.onionUpgradeNumberMax;
                (dataManager.maxPoopInOnion,  dataManager.onionPrice, dataManager.onionNextUpgradeCost, dataManager.onionPerCycle, dataManager.onionUpgradeCost10, dataManager.onionUpgradeCost25, dataManager.onionUpgradeCostMax, dataManager.onionUpgradeNumberMax) = countFarmStats(dataManager.farmOnionLevel, dataManager.poopPerOnionCycle, dataManager.onionBasicPrice, dataManager.onionBaseUpgradeCost, dataManager.onionCostRateExponent, dataManager.money);
            }
    }


        private void growOnion()
    {
        //Забрали какашку
        dataManager.poopInOnion -= dataManager.poopPerOnionCycle;

        //Дали лук
        dataManager.onionCount += dataManager.onionPerCycle;    
    }
    //РАСТИТЬ
   
    void Update()
    {
        //Картошка
        if (dataManager.poopInPotato >= dataManager.poopPerPotatoCycle && !isGrowingPotato)  //есть удобрение и рост не идёт, начинаем
        {
            isGrowingPotato = true;  //теперь мы растим 
            elapsedTimePotato = 0f; //счётчик на нуле
        }
        
        if (isGrowingPotato)  //если мы начали растить
        {
            elapsedTimePotato += Time.deltaTime; //счётчик времени идёт

            if (elapsedTimePotato >= growthTimePotato) //Как время роста закончилось
            {   
                isGrowingPotato = false; //перестаём растить
                growPotato(); //обмениваем какашки на картошку



if (dataManager.toggleValues.Count == 0)
{
    {
        Debug.Log("LIST IS EMPTY");
    }
}



            }
        }


        //ЛУК
         if (dataManager.poopInOnion >= dataManager.poopPerOnionCycle && !isGrowingOnion)  //есть удобрение и рост не идёт, начинаем
        {
            isGrowingOnion = true;  //теперь мы растим 
            elapsedTimeOnion = 0f; //счётчик на нуле
        }
        
        if (isGrowingOnion)  //если мы начали растить
        {
            elapsedTimeOnion += Time.deltaTime; //счётчик времени идёт
            if (elapsedTimeOnion >= growthTimeOnion) //Как время роста закончилось
            {   
                isGrowingOnion = false; //перестаём растить
                growOnion(); //обмениваем какашки на картошку
            }
        }
    }




    //Ускорение времени


    internal void speedUpPotato()
    {
        elapsedTimePotato = SpeedUpUniversal(isGrowingPotato, elapsedTimePotato);
    }

    internal void speedUpOnion()
    {
        elapsedTimeOnion = SpeedUpUniversal(isGrowingOnion, elapsedTimeOnion);
    }




}	
