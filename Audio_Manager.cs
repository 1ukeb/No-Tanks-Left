using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(this);
    }

    public GameObject audioObject;
    public AudioClip[] tankExplode;
    public AudioClip[] rocketExplode;

    public void PlayTankExplode()
    {
        AudioClip clip = tankExplode[Random.Range(0, tankExplode.Length)];
        PlaySound(clip);
    }
    public void PlayRocketExplode()
    {
        AudioClip clip = rocketExplode[Random.Range(0, rocketExplode.Length)];
        PlaySound(clip);
    }

    public void PlaySound(AudioClip clip)
    {
        GameObject GO = Instantiate(audioObject, transform.position, Quaternion.identity);
        AudioSource audSource = GO.GetComponent<AudioSource>();
        audSource.clip = clip;
        audSource.Play();
    }
}
