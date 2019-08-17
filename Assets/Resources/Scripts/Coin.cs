using UnityEngine;

/// <summary>
/// Script of coins
/// </summary>
public class Coin : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        // Move the coin every frame.
        rb.MovePosition(rb.position + new Vector3(-ConfigManager.instance.scrollSpeed, 0, 0));
    }

    void OnBecameInvisible()
    {
        //If exited the screen, destroy the coin.
        Destroy(gameObject);
    }

    // If the coin is collided with the player, add a coin to the wallet
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddCoin();
        }
    }
}