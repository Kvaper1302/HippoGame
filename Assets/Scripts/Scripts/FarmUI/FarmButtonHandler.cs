using UnityEngine;


namespace New.Scripts.FarmUI
{
    public abstract class FarmButtonHandler : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("Hello");
            PrintTemplateMessage();
        }

        public abstract void PrintTemplateMessage();
        
    }
}

