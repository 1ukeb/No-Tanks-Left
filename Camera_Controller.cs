using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public float zOffset;
    public Transform target;
    private Vector3 camPos;

    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z + zOffset);
    }
}
