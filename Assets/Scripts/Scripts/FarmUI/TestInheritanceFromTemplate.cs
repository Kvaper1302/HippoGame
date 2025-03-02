using System.Collections;
using System.Collections.Generic;
using New.Scripts.FarmUI;
using UnityEditor.Rendering;
using UnityEngine;

public class TestInheritanceFromTemplate : FarmButtonHandler
{
    public override void PrintTemplateMessage()
    {
        Debug.Log("EverythingIsWorking!");
    }
}
