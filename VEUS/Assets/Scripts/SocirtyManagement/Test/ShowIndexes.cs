using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIndexes : MonoBehaviour
{
    public GameObject IndexBar;
    public static Dictionary<int, GameObject> indeXIDToBar = new Dictionary<int, GameObject>();
    Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        spawnPos = new Vector3(-5f, 3f, 0f);
        int columnCounter = 0;
        GameObject aux;
        foreach (Index I in Index.indexesDict.Values)
        {
            aux = Instantiate(IndexBar);
            aux.transform.localPosition = spawnPos;
            if (columnCounter > 9)
            {
                columnCounter = 0;
                spawnPos += new Vector3(750f, 450, 0f);
            }
            else spawnPos += new Vector3(0, -45f, 0f);
            indeXIDToBar.Add(I.ID, aux);
            aux.GetComponent<IndexBarController>().IndexID = I.ID;
            columnCounter++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
