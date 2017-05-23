using UnityEngine;
using System.Collections;

public class SpawnJewels : MonoBehaviour {
    public int xRange = 10;
    public int yRange = 3;
    public int numObjects = 16;

    public GameObject[] objects;
    // Use this for initialization
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i <= numObjects; i++)
        {
            Vector3 spawnLoc = new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange), 0);
            int objectPick = Random.Range(0, objects.Length);
            Instantiate(objects[objectPick], spawnLoc, Random.rotation);
        }
    }
}
