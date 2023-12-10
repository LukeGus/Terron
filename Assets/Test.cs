using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject treePrefab;
    public Transform treeSpawnPoint;
    
    public void SpawnTree()
    {
        Instantiate(treePrefab, treeSpawnPoint.position, treeSpawnPoint.rotation);
    }
}

public class Test : MonoBehaviour
{
    public GameObject CubePrefab;
    public transform CubeSpawnPoint;
    
    
}    
    
    