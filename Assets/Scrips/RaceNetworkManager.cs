using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceNetworkManager : NetworkManager
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private SpawnObstacle spawnObstacle;
    [SerializeField] private float spawnThreshold = 3f;
    [SerializeField] private float countTime = 0;
    [SerializeField] private int maxConn = 1;

    private void FixedUpdate()
    {
        if(!isNetworkActive && numPlayers != maxConn) return;
        countTime += Time.fixedDeltaTime;
        if(countTime >= spawnThreshold)
        {
            countTime -= spawnThreshold;
            spawnObstacle.Spawn();
        }
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        //base.OnServerAddPlayer(conn);
        Vector3 spawnPoint = spawnPoints[numPlayers].position;
        var player = Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player);
    }
}
