using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TestingCommands : MonoBehaviour
{

    [YarnCommand("PrintTheTrueWords")]
    public void PrintTheTrueWords(string TheWords)
    {
        Debug.Log(TheWords);
    }

}
