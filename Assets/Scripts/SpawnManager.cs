using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Components;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> eggsToSpawn;
    [SerializeField] private Transform parent;

    private int _i;

    private void Start()
    {
        SpawnEgg();
    }

    private async void RefreshEgg(Egg egg)
    {
        if (egg.checkGoalInAllComponents && !egg.GetComponents<BaseComponent>().All(c => c.isCompleted))
        {
            return;
        }
        Destroy(egg.gameObject);
        await Task.Delay(500);
        SpawnEgg();
    }
    private void OnEnable()
    {
        Egg.TryGoToNextEgg += RefreshEgg;
    }
    private void OnDisable()
    {
        Egg.TryGoToNextEgg -= RefreshEgg;
    }

    private void SpawnEgg()
    {
        if (_i >= eggsToSpawn.Count)
        {
            print("Game ends");
            return;
        }
        Instantiate(eggsToSpawn[_i], parent);
        _i++;

    }
    private bool IsValid()
    {
        return Random.Range(0, 2) == 0;
    }
    
    //Перенес SpawnManager внутрь канваса на сцене, тк один хуй спавнит текстурки а мне лень было думать как в методе
    //SpawnEgg дать другого парента (всм канвас задать парентом) + позиция один хуй кривая)))
}
