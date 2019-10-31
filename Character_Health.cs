using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Health : MonoBehaviour
{
    public int health;
    public GameObject namePlate;
    public GameObject dieParticle;

    void Update()
    {
        NamePlate();
    }

    void NamePlate()
    {
        namePlate.transform.LookAt(Camera.main.transform.position);
        namePlate.transform.Rotate(0, 180, 0);
        namePlate.GetComponent<TextMesh>().text = GetComponent<Character_Controller>().thisKey.ToUpper() + "-" + GetComponent<Character_Controller>().killCount;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    public void Die()
    {
        //give the particle effect a random rotation
        Quaternion newRot = Quaternion.Euler(0, Random.Range(0, 361), 0);
        Instantiate(dieParticle, transform.position, newRot);

        Audio_Manager.instance.PlayTankExplode();

        Game_Manager.instance.RemoveTank(gameObject.GetComponent<Character_Controller>());
        Destroy(gameObject);
        //delete this object
    }
}
