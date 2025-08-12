using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform bullet;
    public bool spreadshot;

    private void Awake()
    {
        GetComponent<PlayerAim>().OnShoot += PlayerShoot_Shooting;
        //spreadshot = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void PlayerShoot_Shooting(object Sender, PlayerAim.onShootEventArgs e)
    {
        if (spreadshot == true)
        {
            Transform bulletTransform = Instantiate(
                bullet,
                e.gunEndPointPosition,
                Quaternion.identity
            );
            Transform bulletTransform2 = Instantiate(
                bullet,
                e.gunEndPointPosition + new Vector3(0, 1, 0),
                Quaternion.identity
            );
            Transform bulletTransform3 = Instantiate(
                bullet,
                e.gunEndPointPosition - new Vector3(0, 1, 0),
                Quaternion.identity
            );

            Vector3 shootDir = e.shootPosition - e.gunEndPointPosition.normalized;
            bulletTransform.GetComponent<Bullet>().SetUp(shootDir);
            bulletTransform2.GetComponent<Bullet>().SetUp(shootDir);
            bulletTransform3.GetComponent<Bullet>().SetUp(shootDir);
        }
        else
        {
            Transform bulletTransform = Instantiate(
                bullet,
                e.gunEndPointPosition,
                Quaternion.identity
            );

            Vector3 shootDir = e.shootPosition - e.gunEndPointPosition.normalized;
            bulletTransform.GetComponent<Bullet>().SetUp(shootDir);
        }
    }
}
