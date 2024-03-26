using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public Obstacle obstaclePrefab;
    public Transform obstacleSpawn;

    public List<Obstacle> spawnedObstacles = new List<Obstacle>();

    public float obstacleSpeed;
    public float currentObstacleSpeed;

    public float minRandomSpawn;
    public float maxRandomSpawn;

    private void Start()
    {
        GameEvents.ObstacleEvent += OnObstacleEvent;
        GameEvents.GameEvent += OnGameEvent;
    }

    private void OnDestroy()
    {
        GameEvents.ObstacleEvent -= OnObstacleEvent;
        GameEvents.GameEvent -= OnGameEvent;
    }

    private void OnObstacleEvent(object sender, ObstacleEventArgs e)
    {
        if (e.EventType == ObstacleEventType.TriggerSpawn)
        {
            Generate();
            ClearOld();
        }
        if (e.EventType == ObstacleEventType.PlayerPass)
        {
            ApplySpeedMultiplier();
        }
    }

    private void OnGameEvent(object sender, GameEventArgs e)
    {
        if (e.EventType == GameEventType.Restart)
        {
            ClearObstacles();
            currentObstacleSpeed = obstacleSpeed;
        }
    }

    private void ApplySpeedMultiplier()
    {
        currentObstacleSpeed *= GameManager.Instance.GetScoreMultiplier();
    }

    public void Generate()
    {
        Obstacle obstacle = Instantiate(obstaclePrefab, GetSpawnPos(), Quaternion.identity, obstacleSpawn.parent);
        obstacle.Init(currentObstacleSpeed);
        spawnedObstacles.Add(obstacle);
    }

    public Vector3 GetSpawnPos()
    {
        return new Vector3(obstacleSpawn.position.x, obstacleSpawn.position.y + UnityEngine.Random.Range(minRandomSpawn, maxRandomSpawn), obstacleSpawn.position.z);
    }

    public void ClearObstacles()
    {
        foreach (Obstacle obj in spawnedObstacles)
        {
            Destroy(obj.gameObject);
        }
        spawnedObstacles = new List<Obstacle>();
    }

    public void ClearOld()
    {
        if (spawnedObstacles.Count > 4)
        {
            GameObject obj = spawnedObstacles[0].gameObject;
            spawnedObstacles.RemoveAt(0);
            Destroy(obj);
        }
    }
}