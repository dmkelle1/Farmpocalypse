using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [Header("References")]
    public Transform muzzlePoint;            // location bullets spawn
    public GameObject bulletPrefab;          // prefab must have Rigidbody2D and Bullet script
    public Transform bulletPoolParent;       // optional parent for pooled bullets

    [Header("Fire Settings")]
    public float fireRate = 6f;              // shots per second
    public float bulletSpeed = 20f;
    public int poolSize = 20;
    public float spreadDegrees = 0f;         // random cone angle
    public bool usePooling = true;

    //[Header("Optional Effects")]
    //public ParticleSystem muzzleFlash;
    //public AudioSource shootAudio;
    //public float recoilForce = 0.0f;         // if player has rigidbody, apply force in opposite direction

    float fireCooldown = 0f;
    Camera mainCam;
    GameObject[] pool;
    int poolIndex = 0;

    void Awake()
    {
        mainCam = Camera.main;
        if (usePooling) CreatePool();
    }

    void Update()
    {
        AimAtMouse();
        HandleShooting();
        if (fireCooldown > 0f) fireCooldown -= Time.deltaTime;
    }

    void AimAtMouse()
    {
        Vector3 mouseWorld = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorld - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void HandleShooting()
    {
        // left mouse or Fire1
        if ((Input.GetMouseButton(0) || Input.GetButton("Fire1")) && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / Mathf.Max(0.0001f, fireRate);
        }
    }

    void Shoot()
    {
        // compute spread
        float halfSpread = spreadDegrees * 0.5f;
        float randomAngle = Random.Range(-halfSpread, halfSpread);
        Quaternion rot = transform.rotation * Quaternion.Euler(0, 0, randomAngle);

        Vector2 dir = rot * Vector2.right; // local right is gun's forward

        GameObject bulletObj;
        if (usePooling)
        {
            bulletObj = pool[poolIndex];
            poolIndex = (poolIndex + 1) % poolSize;
            bulletObj.transform.position = muzzlePoint.position;
            bulletObj.transform.rotation = Quaternion.LookRotation(Vector3.forward, dir); // sets 2D rotation
            bulletObj.SetActive(true);
        }
        else
        {
            bulletObj = Instantiate(bulletPrefab, muzzlePoint.position, Quaternion.LookRotation(Vector3.forward, dir), bulletPoolParent);
        }

        Rigidbody2D rb = bulletObj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = dir.normalized * bulletSpeed;
            rb.angularVelocity = 0f;
        }

        
       

      
    }

    void CreatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            GameObject b = Instantiate(bulletPrefab, muzzlePoint.position, Quaternion.identity, bulletPoolParent);
            b.SetActive(false);
            pool[i] = b;
        }
    }
}
