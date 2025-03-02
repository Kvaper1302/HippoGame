using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MiniToggleManager : MonoBehaviour
{
    public List<Toggle> toggles; // Список всех тогглеров
    public List<string> togglePrefsKeys; // Список ключей PlayerPrefs для каждого тогглера

    private DataManager dataManager;
    
    void Awake()
    {
        dataManager = DataManager.GetInstance();
    }



    void Start()
    {
        // Проверяем, что количество тогглеров и ключей совпадает
        if (toggles.Count != togglePrefsKeys.Count)
        {
            Debug.LogError("Количество тогглеров не совпадает с количеством ключей PlayerPrefs!");
            return;
        }

        // Загрузка значений из PlayerPrefs при старте
            for (int i = 0; i < toggles.Count; i++)
            {
                toggles[i].isOn = PlayerPrefs.GetInt(togglePrefsKeys[i], 0) == 1;
                Debug.Log("Загрузил значения тогглеров из PlayerPrefs");
            }

        // Обновление значений в DataManager
        UpdateDataManager();
    }

    public void OnToggleChanged(int index)
    {
        // Обновление значения в DataManager
        Debug.Log("Увидел изменение тогглера");
        dataManager.SetToggleValue(index, toggles[index].isOn);
        Debug.Log("Обновил соответсующее значение в дата менеджере");

        // Сохранение значения в PlayerPrefs
        PlayerPrefs.SetInt(togglePrefsKeys[index], toggles[index].isOn ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log("Сохранил значения в PlayerPrefs");

    }

    private void UpdateDataManager()
    {
        // Обновление всех значений в DataManager
        for (int i = 0; i < toggles.Count; i++)
        {
            dataManager.SetToggleValue(i, toggles[i].isOn);
            Debug.Log("Обновил все значения тогглеров в дата менджере");
        }
    }
}


   