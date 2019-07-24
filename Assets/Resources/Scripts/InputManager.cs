using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector3 posPrev, posCurr;

    void Update()
    {
        // If there is a touch on screen,
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //If it's the initial touch
            if (touch.phase == TouchPhase.Began)
            {
                posPrev = touch.position;
            }

            //If it's a swipe
            if (touch.phase == TouchPhase.Moved)
            {
                posCurr = touch.position;

                // Check if it moved vertically
                if (Mathf.Abs(posCurr.y - posPrev.y) != 0)
                {                    
                    // If it was, morph the shape
                    float morpher = (posCurr.y -posPrev.y) * ConfigManager.instance.swipeSensitivity;

                    GameManager.instance.MorphShape(morpher);
                }

                posPrev = touch.position;
            }
            // Re-bake the collider on every colliderRefreshInterval frames or when the finger is lifted
            if (Time.frameCount % ConfigManager.instance.colliderRefreshInterval == 0 || touch.phase == TouchPhase.Ended)
            {
                GameManager.instance.BakeShapesCollider();
            }
        }
    }
}

