using UnityEngine;

public class Shape : MonoBehaviour
{
    private SkinnedMeshRenderer rend;       // Renderer
    private MeshCollider meshColl;          // Collider

    #region Unity Callbacks
    void Start()
    {
        rend = GetComponent<SkinnedMeshRenderer>();
        meshColl = GetComponent<MeshCollider>();
        BakeCollider();
    }
    private void Update()
    {

        // I wanted to make a more dynamic game, so i have tried to make an animation
        // with a value changing every frame. 1st coefficient changes time interval, 2nd morphing range.

        float scaleAnimCoeff = Mathf.Sin(Time.time * ConfigManager.instance.morphAnimSpeed) / ConfigManager.instance.morphAnimIntensity;
        Morph(scaleAnimCoeff);

    }
    #endregion

    //Changes object's BlendShape value to shift its shape.
    // 0 -----> Rectangular Prism 100 -----> Sphere
    public void Morph(float toBeAddded)
    {
        float newValue = rend.GetBlendShapeWeight(0) + toBeAddded;
        newValue = Mathf.Clamp(newValue, 0, 100);
        rend.SetBlendShapeWeight(0, newValue);
    }

    //Bakes object's current mesh and assigns it as collider.
    public void BakeCollider()
    {
        Mesh bakedMesh = new Mesh();
        rend.BakeMesh(bakedMesh);
        meshColl.sharedMesh = bakedMesh;
    }
}
