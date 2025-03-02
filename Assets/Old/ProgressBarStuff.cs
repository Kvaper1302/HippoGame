using UnityEngine;
using UnityEngine.UI;

public class ProgressBarStuff : MonoBehaviour
{
[SerializeField]
private Image progressBarPotato;
[SerializeField]
private Image progressBarOnion;


 private GameManager _gameManager;

 void Awake()
{
    _gameManager = GameManager.GetInstance();
    progressBarPotato.gameObject.SetActive(true);
    progressBarOnion.gameObject.SetActive(true);
}




void Update()
{
    
    //Картофель
    progressBarPotato.fillAmount = _gameManager.elapsedTimePotato / _gameManager.growthTimePotato;
    if (_gameManager.elapsedTimePotato >= _gameManager.growthTimePotato)
    {
        progressBarPotato.gameObject.SetActive(false);
        progressBarPotato.gameObject.SetActive(true);
        progressBarPotato.fillAmount = 0;
    }
    //Лук
    progressBarOnion.fillAmount = _gameManager.elapsedTimeOnion / _gameManager.growthTimeOnion;
    if (_gameManager.elapsedTimeOnion >= _gameManager.growthTimeOnion)
    {
        progressBarOnion.gameObject.SetActive(false);
        progressBarOnion.gameObject.SetActive(true);
        progressBarOnion.fillAmount = 0;
    }

}

}



