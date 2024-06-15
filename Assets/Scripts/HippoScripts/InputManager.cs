using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class InputManager : MonoBehaviour
{
    [SerializeField]
    internal HippoMainScript MainScript;




        NewControls controls;
        internal float RotationAxis;
        internal float ForwardOrBack;

        private void Awake()
        {
    


            controls = new NewControls();
            controls.Enable();

            controls.Walking.Move.performed += movementfact =>
            {
                ForwardOrBack = movementfact.ReadValue<float>(); 
            };
            controls.Walking.Rotate.performed += ctxrot =>
            {
                RotationAxis = ctxrot.ReadValue<float>();
            };
        }





}
