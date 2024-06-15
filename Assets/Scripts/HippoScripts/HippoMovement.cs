using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HippoMovement : MonoBehaviour
{
    [SerializeField]
    internal HippoMainScript MainScript;
    
    [SerializeField]
    float move_speed;
    [SerializeField]
    float rotate_speed;

    private void FixedUpdate()
    {
        transform.Rotate(0,0,MainScript.InputManager.RotationAxis * rotate_speed);
        transform.Translate(new Vector2(0, MainScript.InputManager.ForwardOrBack * move_speed));
    }
}
