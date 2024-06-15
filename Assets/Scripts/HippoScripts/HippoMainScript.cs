using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
public class HippoMainScript : MonoBehaviour
{
    [SerializeField]
    internal HippoCollision CollisionScript;

    [SerializeField]
    internal HippoMovement MovementScript;

    [SerializeField]
    internal InputManager InputManager;

    [SerializeField]
    internal DataManager DataManager;
}