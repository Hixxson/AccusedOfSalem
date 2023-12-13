using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event System.Action<bool> OnFreezePlayer;

    public static void TriggerFreezePlayer(bool freeze)
    {
        OnFreezePlayer?.Invoke(freeze);
    }
}
