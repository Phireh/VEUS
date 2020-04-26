using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CustomConcejalC : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public GameObject nextGoal;
    public GameObject nextTarget;


    public void Awake()
    {

        // Create a new command called 'camera_look', which looks at a target.
        dialogueRunner.AddCommandHandler(
            "decide_d",     // the name of the command
            DecideB // the method to run
        );
    }

    private void DecideB(string[] parameters)
    {
        nextTarget.SetActive(true);
        nextGoal.SetActive(true);
        Debug.Log("Cambiando target!");
    }
}
