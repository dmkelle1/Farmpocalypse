using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 newPos = player.position;
            newPos.z = transform.position.z;
            transform.position = newPos;
        }
    }
}
