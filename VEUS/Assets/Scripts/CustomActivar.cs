using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CustomActivar : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public GameObject col;


    public void Awake()
    {

        // Create a new command called 'camera_look', which looks at a target.
        dialogueRunner.AddCommandHandler(
            "activar",     // the name of the command
            Activar // the method to run
        );
    }

    private void Activar(string[] parameters)
    {
        col.SetActive(true);
    }
}
