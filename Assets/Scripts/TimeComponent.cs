using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Egg))]
public class TimeComponent : MonoBehaviour
{

    private TextMeshProUGUI _text;
    private int i;
    private TimeSpan lifeTime;

    [SerializeField] private int days, hours, minutes, seconds;

    private void Awake()
    {
        GameObject g = new GameObject();
        var childTimer = Instantiate(g, gameObject.transform);

        _text = childTimer.AddComponent<TextMeshProUGUI>();

        lifeTime = new TimeSpan(days, hours, minutes, seconds);
    }

    private void Start()
    {
        StartCoroutine(TimerRoutine());
    }


    private IEnumerator TimerRoutine()
    {
        while (lifeTime > TimeSpan.Zero)
        {
            lifeTime -= new TimeSpan(0, 0, 1);
            UpdateUI(lifeTime);
            
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
        if (lifeTime > TimeSpan.Zero)
        {
            
            lifeTime -= new TimeSpan(0, 0, time);
            TimeSpan timeSpan = lifeTime > TimeSpan.Zero ? lifeTime : TimeSpan.Zero; 
            UpdateUI(timeSpan);
            
        }
    }
}
