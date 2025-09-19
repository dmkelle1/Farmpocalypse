using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shotPoint;
    public GameObject bullet;
    public float bulletForce;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
        rb.AddForce(shotPoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
