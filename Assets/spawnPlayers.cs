using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class spawnPlayers : MonoBehaviour 
{
    // Start is called before the first frame update

    public GameObject spawn;
    public Vector3[] spawns = { new Vector3(56.2700005f, 97.3000031f, -28.2000008f), new Vector3(76.9489288f, 97.2793427f, -10.94999981f), new Vector3(66f, 97.3000031f, -70.5999985f) };
    public Vector3 spawnPosition;
    private void Start()
    {
        int spawnArea = Random.Range(0, 2);
        spawnPosition = spawns[spawnArea];
        PhotonNetwork.Instantiate(spawn.name, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame

}
