using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyADCMain : Enemy
{

    public GameObject player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), player.transform.position, speed * Time.deltaTime);
    }
}
