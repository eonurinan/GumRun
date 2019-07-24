using UnityEngine;

/// <summary>
/// Scrolls the texture of the attached object
/// </summary>
public class ScrollTexture : MonoBehaviour
{
    private Renderer rend;      // Renderer

    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void Update()
    {
        if (ConfigManager.instance.scrollSpeed != 0)
        {
            // Mode 5, because I didn't want to make the number so large, may find a better solution later
            float offset = (Time.timeSinceLevelLoad * ConfigManager.instance.scrollSpeed) % 5;
            rend.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
        }
    }
}
