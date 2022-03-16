using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Egg))]
public class TimeComponent : MonoBehaviour
{
    
    private int _i;
    public TimeSpan LifeTime;
    private Egg _egg;
    private TextMeshProUGUI _text;
    
    private SpawnManager _spawnManager;

    [SerializeField] private int days, hours, minutes, seconds;

    private void Awake()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
        _egg = GetComponent<Egg>();
        _text = Instantiate(_egg.text, transform).GetComponent<TextMeshProUGUI>();
        

        LifeTime = new TimeSpan(days, hours, minutes, seconds);
    }

    private void Start()
    {
        StartCoroutine(TimerRoutine());
    }


    private IEnumerator TimerRoutine()
    {
        while (LifeTime > TimeSpan.Zero)
        {
            LifeTime -= new TimeSpan(0, 0, 1);
            UpdateUI(LifeTime);
            
            yield return new WaitForSeconds(1);
        }
        
        UpdateUI(TimeSpan.Zero);
    }

    public void UpdateUI(TimeSpan timeSpan)
    {
        _text.SetText(timeSpan.ToString());
    }
    
    public void TimeRemove(int time)
    {
        if (LifeTime > TimeSpan.Zero)
        {
            
            LifeTime -= new TimeSpan(0, 0, time);
            TimeSpan timeSpan = LifeTime > TimeSpan.Zero ? LifeTime : TimeSpan.Zero; 
            UpdateUI(timeSpan);
            
        }
        else
        {
            _spawnManager.DeleteEgg();
        }
    }
}
