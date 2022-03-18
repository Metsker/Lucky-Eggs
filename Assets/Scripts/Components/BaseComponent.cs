using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Egg))]
    public abstract class BaseComponent : MonoBehaviour
    {
        [HideInInspector]
        public bool isCompleted;
        protected TextMeshProUGUI Text;
        
        protected Egg Egg;
        private static List<TextMeshProUGUI> _textUguis = new();
        protected void Awake()
        {
            Egg = GetComponent<Egg>();
            
            if (_textUguis.Count > 0 && _textUguis.Count % 2 != 0)
            {
                var t = Instantiate(Egg.textPref, transform).GetComponent<TextMeshProUGUI>();
                var s = Egg.checkGoalInAllComponents ? "&" : "/";
                t.SetText(s);
                _textUguis.Add(t);
            }
            Text = Instantiate(Egg.textPref, transform).GetComponent<TextMeshProUGUI>();
            _textUguis.Add(Text);
        }

        private void OnDestroy()
        {
            _textUguis = new List<TextMeshProUGUI>();
        }

        protected void GoalCompleted()
        {
            isCompleted = true;
            Egg.InvokeEggDestroy(Egg);
        }
    }
}