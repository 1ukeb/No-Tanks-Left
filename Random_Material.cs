using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Material : MonoBehaviour
{
    public Material[] materials;
    public GameObject[] tankRenderers;

    void Start()
    {
        Material mat = materials[Random.Range(0, materials.Length)];
        for(int i = 0; i < tankRenderers.Length; i++)
        {
            tankRenderers[i].GetComponent<Renderer>().material = mat;
        }
    }
}
