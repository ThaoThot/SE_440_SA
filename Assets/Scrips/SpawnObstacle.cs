using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnObstacle : NetworkBehaviour
{
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float radius = 20f;
    private float _timer;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        //_timer += Time.deltaTime;
        //if (_timer >= spawnInterval)
        //{
        //    _timer = 0;
        //    Spawn();
        //}

    }

    public void Spawn()
    {
        if (!ObjectPool.Instance.CanSpawn()) return;
        var obj = ObjectPool.Instance.PickOne(transform);
        var pos = UnityEngine.Random.insideUnitSphere * radius;
        pos.y = Mathf.Abs(pos.y);
        obj.transform.position = pos;
        obj.SetActive(true);
        NetworkServer.Spawn(obj);
    }

}

