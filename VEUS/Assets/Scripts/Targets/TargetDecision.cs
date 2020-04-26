using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDecision : MonoBehaviour
{
    public Transform target;
    public GameObject targetChosed;
    public float HideDistance;

    void Update()
    {
        if (targetChosed.activeInHierarchy == true)
        {
            Vector3 dir = target.position - transform.position;

            if (dir.magnitude < HideDistance)
            {
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }
                targetChosed.SetActive(false);
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
