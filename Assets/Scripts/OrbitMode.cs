using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMode : MonoBehaviour
{
    [SerializeField] public GameObject[] subscribers;
    [SerializeField] public int defaultMode;
    private const string Key = "orbitMode";
    private const int NumOrbitModes = 6;

    public void IncrementOrbitMode()
    {
        SetOrbitMode((GetOrbitMode() + 1) % NumOrbitModes);
        OnOrbitModeUpdate();
    }
    private int GetOrbitMode()
    {
        return PlayerPrefs.GetInt(Key, defaultMode);
    }


    private static void SetOrbitMode(int mode)
    {
        PlayerPrefs.SetInt(Key, mode);
    }
    
    private void OnOrbitModeUpdate()
    {
        SharedLibrary.InformSubscribers(subscribers, "OrbitModeUpdated", GetOrbitMode());
    }

    public void Start()
    {
        OnOrbitModeUpdate();
    }
}
