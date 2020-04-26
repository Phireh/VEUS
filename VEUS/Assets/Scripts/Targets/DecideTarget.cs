using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DecideTarget : MonoBehaviour
{
    public GameObject nextTarget;
    public GameObject nextGoal;

    [YarnCommand("jump")]
    public void Jump()
    {
        nextTarget.SetActive(true);
        nextGoal.SetActive(true);
        Debug.Log("Cambiando target!");
    }
}
