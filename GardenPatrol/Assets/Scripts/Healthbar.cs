using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthbar;
    [SerializeField] private Image currentHealthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       totalhealthbar.fillAmount= playerHealth.currentHealth / 10; 
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount= playerHealth.currentHealth / 10;
    }
}
