using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HippoCollision : MonoBehaviour
{
    [SerializeField]
    internal HippoMainScript MainScript;
    
        private DataManager dataManager;

    void Awake()
    {
        dataManager = DataManager.GetInstance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            if (dataManager.FoodInTheBelly < dataManager.BellySize) //If you have more space in the belly
            {
                Destroy(collision.gameObject); //Eat the food
                dataManager.FoodInTheBelly += 1; //food added in the belly
                Debug.Log(dataManager.FoodInTheBelly);
                

                if(dataManager.FoodInTheBelly == dataManager.BellySize) //if the belly is full
                {
                    Debug.Log("TheBellyIsFull");
                    dataManager.Poop += dataManager.BellySize;
                    //Ты больше не можешь двигаться
                    dataManager.FoodInTheBelly = 0;
                    dataManager.Day += 1;
                    MyScenesManager.Instance.MainMenu();
                
                }
                
            }
            else
            {
            Debug.Log("He realised that the belly is full");  //You can't eat anymore  
            }
        }

    }                
}
