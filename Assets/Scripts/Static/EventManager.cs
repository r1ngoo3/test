using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent OnGenerateLevel = new UnityEvent();
    public static UnityEvent OnClickRequestButton = new UnityEvent();

    public static void Reset()
    {
        OnGenerateLevel.RemoveAllListeners();
        OnClickRequestButton.RemoveAllListeners();
    }
}
