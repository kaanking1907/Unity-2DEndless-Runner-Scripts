using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{

    public ObjectPooler coinPool;

    public float distanceBetweenCoins;

    public void SpawnCoins (Vector3 startPosition)
    {
        GameObject coin1 = coinPool.GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        GameObject coin2 = coinPool.GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        GameObject coin3 = coinPool.GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);
    }
}

