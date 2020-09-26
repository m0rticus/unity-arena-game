using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTermination : MonoBehaviour
{

    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name != "explosion")
        {
            Destroy(gameObject, lifetime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
