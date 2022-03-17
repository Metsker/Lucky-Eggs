using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public static event Action RespawnEgg; 

    [SerializeField] private Sprite typeSprite;
    
    private TimeComponent _timeComponent;
    public TextMeshProUGUI text;


    private void Awake()
    {
        _timeComponent = GetComponent<TimeComponent>();
    }

    private void OnMouseDown()
    {
        if (_timeComponent.LifeTime <= TimeSpan.Zero) // моя логика - при нажатии мышкой если лайфтайм меньше 0 вызываем ивент на который подписан метод спавна
        {
            RespawnEgg?.Invoke();
        }
    }
}
