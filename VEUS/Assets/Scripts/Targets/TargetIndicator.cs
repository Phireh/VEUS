using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public GameObject go;
    public GameObject nextTarget;
    public GameObject nextGoal;
    public GameObject actualGoal;
    public Transform target;
    public float HideDistance;

    void Update()
    {
        Vector3 dir = target.position - transform.position;

        if(dir.magnitude < HideDistance)
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            go.SetActive(false);
            nextTarget.SetActive(true);
            nextGoal.SetActive(true);
            actualGoal.SetActive(false);
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

