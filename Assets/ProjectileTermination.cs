using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTermination : MonoBehaviour
{
    public GameObject player;
    public GameObject explosionParticle;
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag != "Projectile")
        {
            Destroy(gameObject, lifetime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Projectile" && collision.gameObject != player)
        {   
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Enemy>().ApplyDamage(1);
            }
            GameObject explosion = Instantiate(explosionParticle, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }
    }
}
