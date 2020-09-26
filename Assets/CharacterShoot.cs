using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float speed;
    public float offsetFactor;
    public float timeDelay;

    private float lastShotTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - lastShotTime > timeDelay)
            {
                GameObject projectile = Instantiate(projectilePrefab, transform.position + transform.up * offsetFactor, Quaternion.identity) as GameObject;
                projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
                lastShotTime = Time.time;
            }
        }
    }
}
