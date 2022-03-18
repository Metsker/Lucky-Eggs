using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Components
{
    public class TimeComponent : BaseComponent, IPointerClickHandler
    {
        [SerializeField] private int days, hours, minutes, seconds;
        
        [Header("Optional")][Range(0,60)]
        [SerializeField] private int timeToRemoveOnClick;
    
        private int _i;
        private TimeSpan _lifeTime;

        private void Start()
        {
            _lifeTime = new TimeSpan(days, hours, minutes, seconds);
            StartCoroutine(TimerRoutine());
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _lifeTime -= new TimeSpan(0, 0, timeToRemoveOnClick);
            if (_lifeTime > TimeSpan.Zero)
            {
                var timeSpan = _lifeTime > TimeSpan.Zero ? _lifeTime : TimeSpan.Zero; 
                UpdateUI(timeSpan);
            }
            else
            {
                GoalCompleted();
            }
        }
        
        private IEnumerator TimerRoutine()
        {
            while (_lifeTime > TimeSpan.Zero)
            {
                _lifeTime -= new TimeSpan(0, 0, 1);
                UpdateUI(_lifeTime);
            
                yield return new WaitForSeconds(1);
            }
            GoalCompleted();
            UpdateUI(TimeSpan.Zero);
        }

        private void UpdateUI(TimeSpan timeSpan)
        {
            Text.SetText(timeSpan.ToString());
        }
    }
}
