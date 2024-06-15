using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class LoadHippoGame : MonoBehaviour
{
    [SerializeField] Button ButtonGoEat;
        void Start()
    {
       ButtonGoEat.onClick.AddListener(StartHippoGame);
    }

    private void StartHippoGame() 
    {
        MyScenesManager.Instance.LoadHippoGame();
    }

}
