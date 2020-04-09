using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexTest : MonoBehaviour
{
    [Range(0f, 1f)] public float indexValue1;
    [Range(0f, 1f)] public float indexValue2;
    [Range(0f, 1f)] public float indexValue3;
    [Range(0f, 1f)] public float indexValue4;
    public Index index1;
    public Index index2;
    public Index index3;
    public Index index4;
    public Index.STATE state1;
    public Index.STATE state2;
    public Index.STATE state3;
    public Index.STATE state4;
    [Range(-100, 100)] public int influence2;
    [Range(-100, 100)] public int influence3;
    [Range(-100, 100)] public int influence4;
    // Start is called before the first frame update
    void Start()
    {
        index1 = new Index("1", "Descripción",
            Index.GetRoughValueFromState(state1));
        Initialize();
    }

    void Initialize()
    {
        index2 = new Index("2", "Descripción",
            Index.GetRoughValueFromState(state2));
        index3 = new Index("3", "Descripción",
            Index.GetRoughValueFromState(state3));
        index4 = new Index("4", "Descripción",
            Index.GetRoughValueFromState(state4));
        Dependency dep2 = new Dependency(index2, influence2, Dependency.TYPE.ADDITION);
        Dependency dep3 = new Dependency(index3, influence3, Dependency.TYPE.ADDITION);
        Dependency dep4 = new Dependency(index4, influence4, Dependency.TYPE.ADDITION);
        index1.AddDependency(dep2);
        index1.AddDependency(dep3);
        index1.AddDependency(dep4);

        state1 = index1.GetIndexState();
        state2 = index2.GetIndexState();
        state3 = index3.GetIndexState();
        state4 = index4.GetIndexState();
        indexValue1 = index1.Value;
        indexValue2 = index2.Value;
        indexValue3 = index3.Value;
        indexValue4 = index4.Value;
        Debug.Log("Initialized");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Initialize();
        }
    }
}
