using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Components
{
    [RequireComponent(typeof(Egg))]
    public class ClickComponent : BaseComponent, IPointerClickHandler
    {
        [SerializeField] private int touchGoal;
    
        private int _touchCount;

        private void Start()
        {
            UpdateUI();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(isCompleted) return;
            _touchCount++;
            UpdateUI();
            
            if (_touchCount < touchGoal) return;
            GoalCompleted();
        }

        private void UpdateUI()
        {
            Text.SetText($"{touchGoal - _touchCount} click(s) left");
        }
    }
}
