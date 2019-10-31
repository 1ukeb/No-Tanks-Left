using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character_Controller : MonoBehaviour
{
    Rigidbody rb;
    public string thisKey;
    public float turnSpeed;
    public float moveSpeed = 10f;


    public Transform firePoint;
    public GameObject bullet;
    public float bulletForce;

    public int killCount = 0;

    Character_Health ch;

    public float shootCooldown;
    private float shootCooldownTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ch = GetComponent<Character_Health>();
        shootCooldownTimer = shootCooldown;
    }

    Character_Controller(string newKey)
    {
        thisKey = newKey;
    }

    void Update()
    {
        if(shootCooldownTimer > 0)
            shootCooldownTimer -= Time.deltaTime;
        if (shootCooldownTimer <= 0)
        {
            shootCooldownTimer = shootCooldown;
            Fire();
        }

        //check if fell of map
        if (transform.position.y < -15)
            ch.Die();
        //check if turned sideways
        if (Mathf.Abs(transform.rotation.z) > .45f || Mathf.Abs(transform.rotation.x) > .45f)
            ch.Die();
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (Input.GetKey(thisKey))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0, Space.World);
        }
    }

    public void Fire()
    {
        Vector3 newPos = new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z);
        GameObject GO = Instantiate(bullet, newPos, firePoint.rotation);
        GO.GetComponent<Bullet>().fireParent = this;
        GO.GetComponent<Rigidbody>().AddForce(firePoint.forward * bulletForce);
    }

    public void DecFireRate(int dec)
    {
        if (shootCooldown - dec > 1)
            shootCooldown -= dec;
        else
            shootCooldown = 1;
    }

    public void GotKill()
    {
        //lower fire rate
        if (shootCooldown - .5f > 1)
            shootCooldown -= .5f;
        else
            shootCooldown = 1;

        killCount++;
    }
}
