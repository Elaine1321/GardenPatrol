using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBullet : MonoBehaviour
{
    public Vector2 shootDir = new Vector2(0,-1);
     private float movespeed = 8;

     public Vector2 velocity;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

    private void OnCollisionEnter2D(Collision2D other)
    {
       
        

        if(other.gameObject.tag== "Wall")
        {
            
        Destroy(gameObject);
        }

        if(other.gameObject.tag== "Player")
        {
            
        Destroy(gameObject);
        other.gameObject.GetComponent<Health>().TakeDamage(2);
        }
    }
}
