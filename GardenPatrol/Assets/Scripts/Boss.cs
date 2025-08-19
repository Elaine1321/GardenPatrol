using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boss : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currenthealth;
    public Transform Trash;
    public Transform[] guns;
    private float timer = 6;

    public BossHealthBar healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currenthealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        StartCoroutine("Fire");
    }


    private void Update()
    {

        timer -= Time.deltaTime;

        if(timer <0){
            timer= 6;
            Fire();

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;  
        healthBar.SetHealth(currenthealth);
   
    }

    public void Fire()
    {
        
        foreach(Transform gun in guns)
        {
            Vector2 direction = (gun.localRotation * Vector2.right).normalized;
            Transform bullet =Instantiate(Trash,  gun.position, Quaternion.Euler(new Vector3(0,0,90)));
            EnemyBullet eb= bullet.GetComponent<EnemyBullet>();
            eb.direction=direction;
        }
        //Debug.Log("Firing");
        
       

    }

   
}
