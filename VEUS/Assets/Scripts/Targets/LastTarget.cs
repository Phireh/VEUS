﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastTarget : MonoBehaviour
{
    public Transform target;
    public GameObject actualTarget;
    public GameObject actualGoal;
    public float HideDistance;
    public GameObject lastTarget;

    void Update()
    {
        if (lastTarget.activeInHierarchy == false)
        {
            Vector3 dir = target.position - transform.position;

            if (dir.magnitude < HideDistance)
            {
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }
                actualTarget.SetActive(false);
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
}
