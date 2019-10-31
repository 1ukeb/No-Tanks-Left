using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public GameObject particleEffect;
    [HideInInspector]
    public Character_Controller fireParent;
    public int damage;

    void OnTriggerEnter(Collider col)
    {
        //if it hits a player do dmg and destroy bullet
        if(col.tag == "Player" && col.gameObject.GetComponent<Character_Controller>() != fireParent)
        {
            Instantiate(particleEffect, transform.position, Quaternion.identity);
            fireParent.GotKill();
            col.GetComponent<Character_Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
        //if it hits something else destroy the bullet
        if(col.gameObject.GetComponent<Character_Controller>() != fireParent)
        {
            Audio_Manager.instance.PlayRocketExplode();
            Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
