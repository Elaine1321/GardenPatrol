using UnityEngine;

public class Player : MonoBehaviour
{
    public float movespeed;
    public float health;
    public Rigidbody2D Body;
    private Vector2 moveDirection;

    private void Start() { }

    // Update is called once per frame
    void Update()
    {
        Processinput();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Processinput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void Move()
    {
        {
            Body.linearVelocity = new Vector2(
                moveDirection.x * movespeed,
                moveDirection.y * movespeed
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "eBullet")
        {
            this.gameObject.GetComponent<Health>().TakeDamage(2);
        }

        if (other.gameObject.tag == "Boss")
        {
            this.gameObject.GetComponent<Health>().TakeDamage(2);
        }
    }
}
