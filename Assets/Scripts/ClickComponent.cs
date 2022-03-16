using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Egg))]
public class ClickComponent : MonoBehaviour, IPointerClickHandler
{
    
    [SerializeField] private int touchCap;
    [SerializeField][Range(-10, 10)] private int touchTimeRemover;
    
    private int _touchCount;
    private TimeComponent _timeComponent;
    private TextMeshProUGUI _text;
    private Egg _egg;

    private SpawnManager _spawnManager;

    private void Awake()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
        
        if (TryGetComponent(out _timeComponent)){}
            else
            {
                _egg = GetComponent<Egg>();
                _text = Instantiate(_egg.text, transform).GetComponent<TextMeshProUGUI>();
                UpdateUI();
            }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_timeComponent == null)
        {
            if (_touchCount < touchCap)
            {
                _touchCount++;
                UpdateUI();
            }
            else
            {
                _spawnManager.DeleteEgg();
                return;
            }
        }
        else
        {
            _timeComponent.TimeRemove(touchTimeRemover);
        }
    }

    private void UpdateUI()
    {
        _text.SetText((touchCap - _touchCount).ToString());
    }
}
