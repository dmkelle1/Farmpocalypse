using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public GameObject item;
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerHealth player = collision.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.Heal(50);
            Destroy(item);
        }
    }
}
