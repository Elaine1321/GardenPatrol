using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform bullet;

    private void Awake()
    {
        GetComponent<PlayerAim>().Shooting += PlayerShoot_Shooting;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayerShoot_Shooting(object Sender,PlayerAim.onShootEventArgs e ){
        Instantiate(bullet, e.gunEndPointPosition, Quaternion.identity);
    }
}
