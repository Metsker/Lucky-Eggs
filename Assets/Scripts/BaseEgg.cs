using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public abstract class BaseEgg : MonoBehaviour
{
    [SerializeField] private Sprite typeSprite;
    [SerializeField] private DateTime lifeTime;
    public int TouchCount { get; private set; }
    private Timer _timer;

    private void Awake()
    {
        _timer = FindObjectOfType<Timer>();
    }

    public void OnClick()
    {
        TouchCount++;
        _timer.RemoveTime(5);
        print(TouchCount);
    }
   
}
