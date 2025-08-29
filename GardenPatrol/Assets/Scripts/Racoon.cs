using System.Collections;
using UnityEngine;

public class Racoon : MonoBehaviour
{
    public bool moving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moving = false;
        StartCoroutine("Wait");
    }

    // Update is called once per frame
    void Update()
    {
        if (moving == true)
        {
            this.transform.Translate(Vector3.down * Time.deltaTime * 10);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        moving = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject, 3);
        }

        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Health>().TakeDamage(2);
        }

        if (other.gameObject.tag == "Trash")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "PBullet")
        {
            Destroy(gameObject);
        }
    }
}
