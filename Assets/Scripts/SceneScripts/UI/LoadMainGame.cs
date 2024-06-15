using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadMainGame : MonoBehaviour
{
    [SerializeField] Button ButtonGoPoop;
        void Start()
    {
       ButtonGoPoop.onClick.AddListener(GoPoop);
    }

    private void GoPoop() 
    {
        MyScenesManager.Instance.MainMenu();
    }
    
}
