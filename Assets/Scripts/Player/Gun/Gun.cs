using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera cam;
    Vector2 mousePos;
    public Vector3 originalLocalPos;
    public Rigidbody2D rb;
    private FlipSprite flipGun;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        flipGun = GetComponent<FlipSprite>();
        originalLocalPos = transform.localPosition;
    }

    private void OnEnable()
    {
        flipGun.alterPosEvent.AddListener(FlipOriginalPos);
    }

    private void OnDisable()
    {
        flipGun.alterPosEvent.RemoveListener(FlipOriginalPos);
    }

    void FlipOriginalPos()
    {
        originalLocalPos = new Vector3(originalLocalPos.x * -1,
                        originalLocalPos.y, originalLocalPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePos - rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;


        transform.localPosition = originalLocalPos;
    }
}
