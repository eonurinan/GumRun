using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager instance;           // Singleton instance
    public float spawnRate = 5f;                    // Obstacle spawn rate.
    public float scrollSpeed = .5f;                 // Scroll speed of road and obstacles
    public float gameSpeedUpIncreaseRate = 0.0025f; // Game speed increase rate. Every n seconds, the value will be added to scrollSpeed.
    public float gameSpeedUpInterval = 5;           // Sets the speed-up interval as seconds.
    public int gameSpeedUpStartingSecond = 5;       // Sets the number of seconds before the game starts speeding up
    public int colliderRefreshInterval = 2;         // BakeShapesCollider() will be called by this interval by InputManager if user is touching. Unit is frames.
    public float swipeSensitivity = 0.5f;           // Morph per swipe rate.
    public float morphAnimSpeed = 5f;               // Speed of shape's animation
    public float morphAnimIntensity = 5f;           // Range of morph, of shape's animation
    public float jumpHeight = 7.5f;                 // Jump height of shape, also coin height. 
    public float coinSpeedMultiplier = 1f;          // Multiplied by scrollSpeed, resulting as coin speed
 //   public float coinIndexSpaces = .5f;              // How close will coins be

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
