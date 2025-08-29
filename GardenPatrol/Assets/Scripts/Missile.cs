using System.Collections;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Animator animator;
    public Transform Rocketimage;
    public Transform rocket;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //animator = GetComponent<Animator>();
        StartCoroutine("rocketFall");
    }

    // Update is called once per frame
    void Update()
    {
        if (rocket != null)
        {
            if (rocket.position.y <= -0.056)
            {
                Debug.Log(rocket.position.y);
                this.gameObject.GetComponent<Collider2D>().enabled = true;
                this.gameObject.GetComponent<Collider2D>().isTrigger = true;
                StartCoroutine("DeleteAll");
            }
            else
            {
                rocket.transform.Translate(Vector3.up * Time.deltaTime * 2);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Health>().TakeDamage(2);
        }
    }

    IEnumerator rocketFall()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Rocket Lands");
        rocket = Instantiate(
            Rocketimage,
            new Vector2(this.transform.position.x, this.transform.position.y + 4),
            Quaternion.identity
        );
        rocket.transform.parent = this.transform;
        rocket.transform.Rotate(0, 0, 180);
    }

    IEnumerator DeleteAll()
    {
        yield return new WaitForSeconds(2);
        GameObject.Destroy(transform.GetChild(0).gameObject);
        Destroy(gameObject);
    }
}
