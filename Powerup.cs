using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject particleEffect;
    public float duration = 5f;
    [HideInInspector]
    public Transform thisSpawnpoint;
    [HideInInspector]
    public Character_Controller c;
    bool running = false;
    public AudioClip clip;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Audio_Manager.instance.PlaySound(clip);
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<ParticleSystem>().Stop();
            GetComponent<Light>().enabled = false; 
            c = col.GetComponent<Character_Controller>();
            if (particleEffect != null)
                Instantiate(particleEffect, transform.position, Quaternion.Euler(0, Random.Range(0, 361), 0));
            running = true;
            StartPowerup();
        }
    }

    void Update()
    {
        if (running)
            duration -= Time.deltaTime;
        if (duration <= 0)
            StopPowerup();
    }

    public virtual void StartPowerup()
    {

    }

    public virtual void StopPowerup()
    {
        Powerup_Spawner.instance.existingPowerups.Remove(thisSpawnpoint);
        Destroy(gameObject);
    }

    /*
    float newMoveSpeed = 3f;
    void SpeedBoost()
    {
        if (select == 0)
        {
            if (duration > 0)
            {
                c.moveSpeed = newMoveSpeed;
            }
            else
            {
                c.moveSpeed = 1;
                Destroy(gameObject);
            }
        }
    }

    bool ranThis;
    float newAttackSpeedCooldown = .5f;
    float oldAttackSpeed;
    void AttackSpeed()
    {
        if (select == 1)
        {
            if (!ranThis)
                oldAttackSpeed = c.shootCooldown;

            ranThis = true;

            if (duration > 0)
            {
                c.shootCooldown = newAttackSpeedCooldown;
            }
            else
            {
                c.shootCooldown = oldAttackSpeed;
                Destroy(gameObject);
            }
        }
    }
    */
}
