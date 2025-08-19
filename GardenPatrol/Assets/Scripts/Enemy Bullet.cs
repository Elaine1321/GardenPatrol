using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBullet : MonoBehaviour
{
    public Vector2 shootDir = new Vector2(0,-1);
     public float movespeed = 3;

     public Vector2 velocity;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        velocity= shootDir * movespeed;
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.deltaTime;

        transform.position = pos;
    }
}
