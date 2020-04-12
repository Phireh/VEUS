using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMethods : MonoBehaviour
{
    public static float GetRandom(int l, int h)
    {
        return Random.Range(l, h + 1) / 100f;
    }
    public static void PrintError(string error)
    {
        Debug.LogError(error);
    }
}
