using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_After : MonoBehaviour
{
    public float seconds;
    void Start()
    {
        Destroy(gameObject, seconds);
    }
}
