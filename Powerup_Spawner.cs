using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Spawner : MonoBehaviour
{
    public Vector2 spawnDelayRange;
    float spawnDelay;
    float spawnDelayTimer;

    public GameObject[] powerups;
    public List<Transform> powerupSpawnpoints = new List<Transform>();
   // [HideInInspector]
    public List<Transform> existingPowerups = new List<Transform>();

    #region SINGLETON
    public static Powerup_Spawner instance;
    void Awake()
    {
        if (Game_Settings.instance != null)
        {
            if (Game_Settings.instance.isPowerups == false)
                Destroy(this);
        }

        if (instance == null)
            instance = this;
        else if (instance != null)
            Debug.Log("Two spawners!!!");

        //DontDestroyOnLoad(this);
        FindPowerupTransforms();
    }
    #endregion

    void OnLevelWasLoaded()
    {
        FindPowerupTransforms();
    }

    //finds all powerup spawnpoints in the level
    void FindPowerupTransforms()
    {
        spawnDelay = Random.Range(spawnDelayRange.x, spawnDelayRange.y);
        spawnDelayTimer = spawnDelay;
        powerupSpawnpoints.Clear();
        foreach(GameObject sp in GameObject.FindGameObjectsWithTag("Powerup"))
        {
            Transform t = sp.GetComponent<Transform>();
            powerupSpawnpoints.Add(t);
        }
    }

    void Update()
    {
        if (spawnDelayTimer > 0)
            spawnDelayTimer -= Time.deltaTime;

        if (spawnDelayTimer <= 0)
        {
            SpawnPowerup();
            spawnDelayTimer = spawnDelay;
            spawnDelay = Random.Range(spawnDelayRange.x, spawnDelayRange.y + 1);
        }
    }

    void SpawnPowerup()
    {
        Debug.Log(existingPowerups.Count + " " + powerupSpawnpoints.Count);

        GameObject p = powerups[Random.Range(0, powerups.Length)];
        Transform t = powerupSpawnpoints[Random.Range(0, powerupSpawnpoints.Count)];
        if (existingPowerups.Contains(t) && existingPowerups.Count < powerupSpawnpoints.Count)
        {
            Debug.Log("Powerup is already here...");
            SpawnPowerup();
        }
        else if(existingPowerups.Count < powerupSpawnpoints.Count)
        {
            existingPowerups.Add(t);
            p.GetComponent<Powerup>().thisSpawnpoint = t;
            Instantiate(p, t.position, Quaternion.identity);
        }
    }
}
