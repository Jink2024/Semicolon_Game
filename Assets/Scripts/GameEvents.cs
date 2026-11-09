using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static event Action OnSemicolonPickup;
    public static event Action OnSemicolonPlace;

    public static void TriggerSemicolonPickup()
    {
        OnSemicolonPickup?.Invoke();
    }

    public static void TriggerSemicolonPlace()
    {
        OnSemicolonPlace?.Invoke();
    }
}
