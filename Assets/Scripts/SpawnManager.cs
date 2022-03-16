using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject objectToDelete;
    [SerializeField] private GameObject objectToSpawn;
    

    

    public void DeleteEgg()
    {
        Destroy(objectToDelete);
    }

    public void SpawnEgg()
    {
        Instantiate(objectToSpawn, transform);
    }
}
