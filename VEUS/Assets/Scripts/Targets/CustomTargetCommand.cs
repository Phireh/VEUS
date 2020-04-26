using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CustomTargetCommand : MonoBehaviour
{
    // Drag and drop your Dialogue Runner into this variable.
    public DialogueRunner dialogueRunner;
    public GameObject nextGoal;
    public GameObject nextTarget;


    public void Awake()
    {

        // Create a new command called 'camera_look', which looks at a target.
        dialogueRunner.AddCommandHandler(
            "decide_a",     // the name of the command
            DecideA // the method to run
        );
    }

    private void DecideA(string[] parameters)
    {
        nextTarget.SetActive(true);
        nextGoal.SetActive(true);
        Debug.Log("Cambiando target!");
    }
}
