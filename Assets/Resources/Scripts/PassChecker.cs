using UnityEngine;

/// <summary>
/// Attached to a door's child object named "PassChecker", checks if the player is passed
/// </summary>
public class PassChecker : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        print("Triggered");
        // If the player passed under the door, meaning succesfully exited the Pass Collider
        if (other.CompareTag("Player"))
        {
            print("Entered");
            // Increase the score
            GameManager.instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
