using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currenthealth;
    public Transform Trash;
    public Transform Target;
    public Transform Racoonimg;
    public Transform[] guns;
    public Transform[] lineposition;
    private float timer = 3;
    private float timer2 = 6;
    private float timer3 = 6;
    public bool Phase2;
    public bool Phase3;

    public BossHealthBar healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currenthealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        StartCoroutine("Fire");
        //missile();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timer2 -= Time.deltaTime;
        timer3 -= Time.deltaTime;

        if (timer < 0)
        {
            timer = 3;
            Fire();
        }

        if (timer2 < 0)
        {
            if (Phase2 == true)
            {
                missile();
                timer2 = 6;
            }
        }

        if (timer3 < 0)
        {
            if (Phase3 == true)
            {
                RacoonLine();
                timer3 = 6;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        if (MaxHealth <= 50)
        {
            Phase2 = true;
        }

        if (MaxHealth <= 50 && MaxHealth <= 35)
        {
            Phase3 = true;
        }
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        healthBar.SetHealth(currenthealth);
    }

    public void Fire()
    {
        foreach (Transform gun in guns)
        {
            Vector2 direction = (gun.localRotation * Vector2.right).normalized;
            Transform bullet = Instantiate(
                Trash,
                gun.position,
                Quaternion.Euler(new Vector3(0, 0, 90))
            );
            EnemyBullet eb = bullet.GetComponent<EnemyBullet>();
            eb.shootDir = direction;
        }
        //Debug.Log("Firing");
    }

    public void missile()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Transform target = Instantiate(
            Target,
            new Vector2(player.transform.position.x, player.transform.position.y),
            Quaternion.identity
        );
        Debug.Log("Missile launched");
    }

    public void RacoonLine()
    {
        foreach (Transform position in lineposition)
        {
            Transform Racoon = Instantiate(Racoonimg, position.position, Quaternion.identity);
            Racoon.transform.parent = position.transform;
        }
    }
}
