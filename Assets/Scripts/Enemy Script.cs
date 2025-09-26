using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject targetObject;
    public float moveSpeed = 1f;
    public int currentHealth = 100;
    public int dealtDamage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            Vector2 newposition = Vector2.MoveTowards(transform.position, targetObject.transform.position, moveSpeed * Time.deltaTime);
            transform.position = newposition;
        }
        else
        {
            Debug.Log("Target not found");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullets(Clone)")
        {
            Destroy(collision.gameObject);
            currentHealth = currentHealth - dealtDamage;
            Debug.Log("Shot, Remaining Health: " + currentHealth);
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
