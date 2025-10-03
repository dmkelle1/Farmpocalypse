using UnityEngine;
using UnityEngine.Events;

public class FlipSprite : MonoBehaviour
{
    public bool flipX;
    private bool facingLeft;

    public bool flipY;

    public bool alterPos;
    private bool facingDown;
    private SpriteRenderer spriteRenderer;
    public UnityEvent alterPosEvent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mouseFollow();
    }

    // Update is called once per frame
    void Update()
    {
        mouseFollow();
    }

    void mouseFollow()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        //Debug.Log(gameObject.name + " rotation = " + difference.ToString());

        if (flipX)
        {
            // mouse is on right side of player
            if (difference.x < 00 && !facingLeft)
            {
                //flip sprite to face right
                spriteRenderer.flipX = facingLeft = true;
            }
            // mouse is on left side
            if (difference.x >= 0 && facingLeft)
            {
                //flip sprite to face left
                spriteRenderer.flipX = facingLeft = false;
            }
        }
        if (flipY)
        {
            // mouse is on right side of player
            if (difference.x < 00 && !facingDown)
            {
                //flip sprite to face right
                spriteRenderer.flipY = facingDown = true;
                if (alterPos)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x * -1,
                        transform.localPosition.y, transform.localPosition.z);

                    alterPosEvent?.Invoke();
                }
            }
             //mouse is on left side
            if (difference.x >= 0 && facingDown)
            {
                //flip sprite to face left
                spriteRenderer.flipY = facingDown = false;
                if (alterPos)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x * -1,
                        transform.localPosition.y, transform.localPosition.z);

                    alterPosEvent?.Invoke();
                }
            }
        }
    }
}
