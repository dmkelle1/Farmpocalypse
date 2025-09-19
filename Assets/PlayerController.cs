using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private Vector2 movement;
    public Rigidbody2D rb;

    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = .3f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        movement.Normalize();
        movement.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        movement.y = Input.GetAxisRaw("Vertical") * moveSpeed;
        rb.linearVelocity = movement * activeMoveSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
}
