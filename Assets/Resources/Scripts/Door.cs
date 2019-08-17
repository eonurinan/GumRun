using UnityEngine;

/// <summary>
/// Script of obstacles
/// </summary>
public class Door : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        // Move the door every frame.
        rb.MovePosition(rb.position + new Vector3(-ConfigManager.instance.scrollSpeed, 0, 0));
    }

    void OnBecameInvisible()
    {
        //If exited the screen, destroy the door.
        Destroy(gameObject);
    }

    // If the door is collided with the player, end the game
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }
}