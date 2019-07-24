using UnityEngine;

/// <summary>
/// Script of obstacles
/// </summary>
public class Door : MonoBehaviour
{
    void Update()
    {
        // Move the door every frame.
        transform.Translate(new Vector3(-ConfigManager.instance.scrollSpeed, 0, 0));
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