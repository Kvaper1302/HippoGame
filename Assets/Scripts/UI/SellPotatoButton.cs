using System;
using UnityEngine;
using UnityEngine.UI;

public class SellPotatoButton : MonoBehaviour
{
    [SerializeField] private Button button;
    
    
    
    
    public Action<string> OnPotatoSellButtonPressed;


    private void Start()
    {
        button.onClick.AddListener(Invoke);
    }

    private void Invoke()
    {
        OnPotatoSellButtonPressed?.Invoke("Potato");
    }
}
