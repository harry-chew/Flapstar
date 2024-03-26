using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [Header("Clouds")]
    public GameObject[] cloudPrefabVariants;
    public Transform cloudSpawnPoint;
    public float minCloudY, maxCloudY;
    public float minCloudSpawnTime, maxCloudSpawnTime;
    public float minCloudForce, maxCloudForce;

    public List<GameObject> spawnedClouds;

    private void Start()
    {
        StartCoroutine(SpawnCloudCoroutine());
    }

    public void SpawnCloud()
    {
        int indexToSpawn = GetRandomCloudIndex(cloudPrefabVariants);
        GameObject cloud = Instantiate(GetCloudFromIndex(indexToSpawn), GetSpawnPosition(), Quaternion.identity, transform);
        spawnedClouds.Add(cloud);
        float randomSpeed = Random.Range(minCloudForce, maxCloudForce);
        cloud.GetComponent<Cloud>().Init(randomSpeed);
    }

    public IEnumerator SpawnCloudCoroutine()
    {
        while(true)
        {
            if (GameManager.Instance.isGameRunning)
            {
                SpawnCloud();

                float spawnTime = Random.Range(minCloudSpawnTime, maxCloudSpawnTime);
                yield return new WaitForSeconds(spawnTime);
            }
            yield return null;
        }
    }

    private int GetRandomCloudIndex(GameObject[] cloudPrefabVariants)
    {
        return Random.Range(0, cloudPrefabVariants.Length - 1);
    }

    private GameObject GetCloudFromIndex(int index)
    {
        return cloudPrefabVariants[index];
    }

    private Vector3 GetSpawnPosition()
    {
        float randomHeight = Random.Range(minCloudY, maxCloudY);
        return new Vector3(cloudSpawnPoint.position.x, cloudSpawnPoint.position.y + randomHeight, cloudSpawnPoint.position.z);
    }

    public void ClearOld()
    {
        if (spawnedClouds.Count > 30)
        {
            GameObject obj = spawnedClouds[0].gameObject;
            spawnedClouds.RemoveAt(0);
            Destroy(obj);
        }
    }
}