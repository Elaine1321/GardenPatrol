using UnityEngine;

public class Boss : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currenthealth;

    public BossHealthBar healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currenthealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    private void Update()
    {
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
}
