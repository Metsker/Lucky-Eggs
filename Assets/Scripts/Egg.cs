using System;
using TMPro;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private Sprite typeSprite;
    
    public bool checkGoalInAllComponents;
    public TextMeshProUGUI textPref;
    public static event Action<Egg> TryGoToNextEgg;

    public static void InvokeEggDestroy(Egg egg)
    {
        TryGoToNextEgg?.Invoke(egg);
    }
}