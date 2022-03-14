using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Egg))]
public class ClickComponent : MonoBehaviour, IPointerClickHandler
{

    private int _touchCount;
    private TimeComponent _time;

    private void Awake()
    {
        if (TryGetComponent(out _time)) ;
        
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _touchCount++;
        print(_touchCount);

        if (_time == null) return;
        _time.TimeRemove(5);
    }
}
