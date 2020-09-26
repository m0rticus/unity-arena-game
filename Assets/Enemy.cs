using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public SpawnEnemies spawner;
    public int maxHealth;
    public int currentHealth;
    public Text scoreText;
    private bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            if (!spawned)
            {
                if (gameObject.name == "god(Clone)")
                {
                spawner.enemiesKilled += 14;
                }
                spawner.enemiesKilled++;
                spawner.EnemyDied();
                spawned = true;
                scoreText.text = "Score: " + (spawner.enemiesKilled * 100).ToString();
            }
        }
    }
}
