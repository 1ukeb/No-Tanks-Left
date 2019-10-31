using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    //the player object to be spawned
    public GameObject playerPrefab;
    //all players in current game
    public List<Character_Controller> currentPlayers = new List<Character_Controller>();
    //all spawn points on current scene
    public List<Transform> spawnPoints = new List<Transform>();

    public bool isPaused;
    public GameObject UICanvas;

    public static Game_Manager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

            //Debug.Log("More than one instance!");

    }

    void Update()
    {
        PauseHandling();
    }

    void PauseHandling()
    {
        if (Input.GetKeyDown("escape"))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0;
                UICanvas.SetActive(true);
            }
            else if (!isPaused)
            {
                Time.timeScale = 1;
                UICanvas.SetActive(false);
            }

        }
    }

    void OnLevelWasLoaded()
    {
        spawnPoints.Clear();
        //Find all the spawn points in the current scene!
        foreach (GameObject spawnpoint in GameObject.FindGameObjectsWithTag("Spawnpoint"))
        {
            spawnPoints.Add(spawnpoint.GetComponent<Transform>());
        }
    }

    public void LoadLevel(string scene)
    {
        Time.timeScale = 1;

        if (scene == "Main Menu" && GameObject.Find("Game Settings") != null)
           Destroy(GameObject.Find("Game Settings"));

        SceneManager.LoadScene(scene);
    }

    void Start()
    {
        OnLevelWasLoaded();
    }

    void OnGUI()
    {
        if(Event.current.isKey && Event.current.type == EventType.KeyDown && Input.anyKeyDown)
        {
            string output = Event.current.keyCode.ToString().ToLower();
            if (output == "none" || output == "escape")
                return;

            Debug.Log(output);
            foreach (Character_Controller c in currentPlayers)
            {
                if (c.thisKey == output)
                    return;
            }

            Debug.Log("Spawning player...");
            int listSlot = Random.Range(0, spawnPoints.Count);
            Transform spawnP = spawnPoints[listSlot];

            GameObject GO = Instantiate(playerPrefab, spawnP.position, Quaternion.Euler(0, Random.Range(0,361), 0));
            currentPlayers.Add(GO.GetComponent<Character_Controller>());
            GO.GetComponent<Character_Controller>().thisKey = output;
        }
    }

    public void RemoveTank(Character_Controller c)
    {
        currentPlayers.Remove(c);
    }
}
