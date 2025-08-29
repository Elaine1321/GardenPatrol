using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 shootDir;

    public void SetUp(Vector3 ShootDir)
    {
        this.shootDir = ShootDir;
        transform.eulerAngles = new Vector3(0, 0, GenAngleFromVector(shootDir));
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Boss")
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
            other.gameObject.GetComponent<Boss>().TakeDamage(5);
        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        float movespeed = 3;
        transform.position += shootDir * movespeed * Time.deltaTime;
    }

    public static float GenAngleFromVector(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
            n += 360;

        return n;
    }
}
