using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{


       // Перечисление для кнопок
    public enum ButtonType
    {
        putPoopInPotato, 
        sellAllPotato,
        upgragePotato,
        speedUpPotato,
        putPoopInOnion,
        sellAllOnion,
        upgrageOnion,
        speedUpOnion,
    }

    [SerializeField] private Button[] buttons; 

    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameManager.GetInstance();
    }


    public enum ButtonAction
    {
        putPoopInPotato,
        sellAllPotato,
        upgragePotato,
        speedUpPotato,
        putPoopInOnion,
        sellAllOnion,
        upgrageOnion,
        speedUpOnion,

    }


     // Функция для выполнения действия, связанного с кнопкой
    public void DoButtonAction(ButtonAction action)
    {
        switch (action)
        {
            case ButtonAction.putPoopInPotato:
                gameManager.putPoopInPotato();
                break;
            case ButtonAction.sellAllPotato:
                gameManager.sellAllPotato();
                break;
            case ButtonAction.upgragePotato:
                gameManager.upgradePotato();
                break;
            case ButtonAction.speedUpPotato:
                gameManager.speedUpPotato();
                break;
            case ButtonAction.putPoopInOnion:
                gameManager.putPoopInOnion();
                break;
            case ButtonAction.sellAllOnion:
                gameManager.sellAllOnion();
                break;
            case ButtonAction.upgrageOnion:
                gameManager.upgradeOnion();
                break;
            case ButtonAction.speedUpOnion:
                gameManager.speedUpOnion();
                break;
        }
    }
       void Start()
    {
        // Назначаем обработчики нажатия для каждой кнопки
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i; // Запоминаем индекс кнопки
            buttons[i].onClick.AddListener(() => 
            {
                // Получаем тип кнопки
                ButtonType buttonType = (ButtonType)buttonIndex;

                // Вызываем соответствующее действие
                switch (buttonType)
                {
                    case ButtonType.putPoopInPotato:
                        DoButtonAction(ButtonAction.putPoopInPotato); 
                        break;
                    case ButtonType.sellAllPotato:
                        DoButtonAction(ButtonAction.sellAllPotato); 
                        break;
                    case ButtonType.upgragePotato:
                        DoButtonAction(ButtonAction.upgragePotato);
                        break;
                    case ButtonType.speedUpPotato:
                        DoButtonAction(ButtonAction.speedUpPotato);
                        break;
                    case ButtonType.putPoopInOnion:
                        DoButtonAction(ButtonAction.putPoopInOnion); 
                        break;
                    case ButtonType.sellAllOnion:
                        DoButtonAction(ButtonAction.sellAllOnion); 
                        break;
                    case ButtonType.upgrageOnion:
                        DoButtonAction(ButtonAction.upgrageOnion);
                        break;
                    case ButtonType.speedUpOnion:
                        DoButtonAction(ButtonAction.speedUpOnion);
                        break;
                }
            });
        }
    }


}
