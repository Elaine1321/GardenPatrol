using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float startinghealth;
    public float currentHealth { get; private set;}

     private void Awake()
    {
        currentHealth=startinghealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage ,0, startinghealth);

        if(currentHealth>0)
        {
         
        }
        else{

        }
    }

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(2);
        }
    }
}
