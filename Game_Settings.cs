using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Settings : MonoBehaviour
{
    public GameObject textOn;
    public GameObject textOff;

    public static Game_Settings instance;
    void Awake()
    {
        isPowerups = true;
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public bool isPowerups = true;
    public void TogglePowerups() {
        isPowerups = !isPowerups;

        if (isPowerups)
        {
            textOn.SetActive(true);
            textOff.SetActive(false);
        }else if (!isPowerups)
        {
            textOn.SetActive(false);
            textOff.SetActive(true);
        }
 }
}
