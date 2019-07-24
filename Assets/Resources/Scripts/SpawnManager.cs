using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private Vector3 spawnPosition;      // Spawn positions of doors, set to end of the road
    private GameObject[] doorArray;     // Array of door prefabs

    #region Unity Callbacks

    void Start()
    {
        GameObject road = GameObject.Find("Road");
        float startingPosX = road.GetComponent<Renderer>().bounds.extents.x;
        startingPosX += road.transform.position.x;
        startingPosX += 10;

        //1.3 is temporary
        spawnPosition = new Vector3(startingPosX, 1.3f, 0);

        doorArray = Resources.LoadAll<GameObject>("Prefabs/Doors");

        InvokeRepeating("InstantiateRandomObstacle", 0.1f, ConfigManager.instance.spawnRate);
    }
    #endregion

    private void InstantiateRandomObstacle()
    {
        int rand = Random.Range(0, doorArray.Length);

        // X rotation is -90 because blender's coordinate system is different, this is temporary.
        Instantiate(doorArray[rand], spawnPosition, Quaternion.Euler(-90, 0, 0));
    }
}
