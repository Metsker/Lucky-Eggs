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
    private void OnEnable()
    {
        Egg.RespawnEgg += SpawnEgg;
    }

    private void OnDisable()
    {
        Egg.RespawnEgg -= SpawnEgg;
    }
    
    //Перенес SpawnManager внутрь канваса на сцене, тк один хуй спавнит текстурки а мне лень было думать как в методе
    //SpawnEgg дать другого парента (всм канвас задать парентом) + позиция один хуй кривая)))
}
