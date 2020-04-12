using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollowingCamera : MonoBehaviour
{
    Camera mycam;

    [Range(1, 20)] public int sensitivity;
    float realSensitivity;
       
    // Start is called before the first frame update
    void Start()
    {
        mycam = GetComponent<Camera>();
        sensitivity = 5;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        realSensitivity = sensitivity / 100f;
        Vector2 vp = mycam.ScreenToViewportPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        vp.x -= 0.5f;
        vp.y -= 0.5f;
        vp.x *= realSensitivity;
        vp.y *= realSensitivity;
        vp.x += 0.5f;
        vp.y += 0.5f;
        Vector2 sp = mycam.ViewportToScreenPoint(vp);
        Vector2 v = mycam.ScreenToWorldPoint(sp);
        mycam.transform.position = new Vector3(v.x, v.y, -10);
    }
}
