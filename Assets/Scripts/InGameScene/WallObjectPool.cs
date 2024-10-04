using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class WallObjectPool : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> wallPrefab;

    private int stackCapacity = 10;
    private int maxPoolSize = 10;

    private Vector3 wallSpawnPos;
    private float distanceToCam = 12f;

    private void Awake()
    {
        float screenHeight = distanceToCam * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);

        wallSpawnPos = new Vector3(0, screenHeight + 1, 0);

        EventBus.Subscribe(EventType.START, SpawnWall);
        EventBus.Subscribe(EventType.FOWARD, SpawnWall);
    }

    private IObjectPool<Wall> pool
    {
        get
        {
            if(_pool == null)
            {
                _pool = new ObjectPool<Wall>(
                            CreateWall,
                            TakeFromPool,
                            ReturnedPool,
                            DestroyPoolObj,
                            true,
                            stackCapacity,
                            maxPoolSize);
            }
            return _pool;
        }
    }
    private IObjectPool<Wall> _pool;

    private Wall CreateWall()
    {
        int randIdx = Random.Range(0, wallPrefab.Count - 1);
        var obj = Instantiate(wallPrefab[randIdx]);

        Wall wall = obj.GetComponent<Wall>();

        wall.name = "Wall";
        wall.pool = pool;

        return wall;
    }

    private void TakeFromPool(Wall wall)
    {
        wall.gameObject.SetActive(true);
    }

    private void ReturnedPool(Wall wall)
    {
        wall.gameObject.SetActive(false);
    }

    private void DestroyPoolObj(Wall wall)
    {
        Destroy(wall.gameObject);
    }

    private void SpawnWall()
    {
        var wall = pool.Get();

        wall.transform.position = wallSpawnPos;
    }
}
