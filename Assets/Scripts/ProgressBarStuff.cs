using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ProgressBarStuff : MonoBehaviour
{
[SerializeField]
private Image progressBarPotato;
[SerializeField]
private Image progressBarOnion;


 private GameManager gameManager;

 void Awake()
{
    gameManager = GameManager.GetInstance();
    progressBarPotato.gameObject.SetActive(true);
    progressBarOnion.gameObject.SetActive(true);
}




void Update()
{
    
    //Картофель
    progressBarPotato.fillAmount = gameManager.elapsedTimePotato / gameManager.growthTimePotato;
    if (gameManager.elapsedTimePotato >= gameManager.growthTimePotato)
    {
        progressBarPotato.gameObject.SetActive(false);
        progressBarPotato.gameObject.SetActive(true);
        progressBarPotato.fillAmount = 0;
    }
    //Лук
    progressBarOnion.fillAmount = gameManager.elapsedTimeOnion / gameManager.growthTimeOnion;
    if (gameManager.elapsedTimeOnion >= gameManager.growthTimeOnion)
    {
        progressBarOnion.gameObject.SetActive(false);
        progressBarOnion.gameObject.SetActive(true);
        progressBarOnion.fillAmount = 0;
    }

}

}



