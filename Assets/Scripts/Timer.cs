using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class Timer : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        private float i;


        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            StartCoroutine(StartTimerRoutine(DateTime.Now.AddHours(1)));
        }

        private IEnumerator StartTimerRoutine(DateTime dateTime)
        {
            for (i = dateTime.Second; i > 0; i-=1)
            {
                yield return new WaitForSeconds(1);
                _text.SetText(i.ToString());
            }
        }

        public void RemoveTime(float time)
        {
            i -= time;
        }
    }
}