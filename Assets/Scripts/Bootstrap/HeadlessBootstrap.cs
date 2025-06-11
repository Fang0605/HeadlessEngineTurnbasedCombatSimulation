using UnityEngine;

public static class HeadlessBootstrap
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Run()
    {
        Debug.Log("HeadlessBootstrap: Entered Run()");

#if UNITY_SERVER
        Debug.Log("Running headless simulation.");
        Object.DontDestroyOnLoad(new GameObject("GameRunner").AddComponent<TurnBasedEngine>());
#else
    Debug.LogWarning("HeadlessBootstrap: Not running in server mode.");
#endif
    }
}