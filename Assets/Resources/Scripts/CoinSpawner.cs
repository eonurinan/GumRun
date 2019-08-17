using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private GameObject coinPrefab;
    private Vector3 spawnPosition;      // Spawn positions of coins, set to end of the road
    private float coinSpace;
    private bool isSpawning = false;
    // private Stack<int> indexStack;
    #region Unity Callbacks

    void Start()
    {
        coinPrefab = Resources.Load<GameObject>("Prefabs/Coin");
        coinSpace = coinPrefab.GetComponent<Renderer>().bounds.extents.y;

        GameObject road = GameObject.Find("Road");
        float startingPosX = road.GetComponent<Renderer>().bounds.extents.x;
        startingPosX += road.transform.position.x;
        startingPosX += 10;

        spawnPosition = new Vector3(startingPosX, ConfigManager.instance.jumpHeight, 0);

        Stack<int> coins = new Stack<int>();
        coins.Push(0);
        coins.Push(1);
        coins.Push(2);
        coins.Push(3);
        coins.Push(4);
        coins.Push(3);
        coins.Push(2);
        coins.Push(1);
        coins.Push(0);
        coins.Push(1);
        coins.Push(2);
        coins.Push(3);

        SpawnCoins(coins);
        SpawnCoins(coins);
    }

    #endregion

    public void SpawnCoins(Stack<int> spawnIndexes)
    {
        StartCoroutine(Spawn(spawnIndexes));
    }

    IEnumerator Spawn(Stack<int> spawnIndexes)
    {
        if (!isSpawning)
            isSpawning = true;
        else
            yield return null;

        float elapsedTime = 0;

        while (spawnIndexes.Count > 0)
        {
            Instantiate(coinPrefab,
                        spawnPosition - Vector3.up * spawnIndexes.Peek() * coinSpace,
                        Quaternion.Euler(0, 0, 0));
            
            spawnIndexes.Pop();
            elapsedTime += Time.deltaTime;
            print(elapsedTime);
            yield return new WaitForSeconds(1f);
        }

        isSpawning = false;
        yield return null;
    }
}

