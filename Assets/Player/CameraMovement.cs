using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public float speed = 1f;
    public GameObject target;
    public GameObject cam;

    void FixedUpdate()
    {
        float distance = (-10 + Vector3.Distance(cam.transform.position, target.transform.position)) * 10;
        float step = speed * Time.deltaTime;
        cam.transform.position = Vector2.MoveTowards(cam.transform.position, target.transform.position, step * distance);
        var newPos = cam.transform.position;
        cam.transform.position = new Vector3(newPos.x, newPos.y, -10.0f);
    }
}
