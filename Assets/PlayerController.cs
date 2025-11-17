using System.Drawing;
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

    private bool isDashing;

    private SpriteRenderer spriteRenderer;

    public Transform player;

    public int maxHealth = 5;
    int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        activeMoveSpeed = moveSpeed;
        currentHealth = maxHealth;
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
                isDashing = true;
                if (isDashing == true)
                {
                    //change alpha value down some
                    UnityEngine.Color color = spriteRenderer.color;
                    color.a = 0.75f;
                    spriteRenderer.color = color;
                }
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            
            if (dashCounter <= 0)
            {
                isDashing = false;
                if (isDashing == false)
                {
                    UnityEngine.Color color = spriteRenderer.color;
                    color.a = 1f;
                    spriteRenderer.color = color;
                }
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
