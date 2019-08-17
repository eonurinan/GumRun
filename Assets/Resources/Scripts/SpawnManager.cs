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

        spawnPosition = new Vector3(startingPosX, 0, 0);

        doorArray = Resources.LoadAll<GameObject>("Prefabs/Doors");

        InvokeRepeating("InstantiateRandomObstacle", 0.1f, ConfigManager.instance.spawnRate);
    }
    #endregion

    private void InstantiateRandomObstacle()
    {
        int rand = Random.Range(0, doorArray.Length);

        Instantiate(doorArray[rand], spawnPosition, Quaternion.Euler(0, 0, 0));
    }
}
