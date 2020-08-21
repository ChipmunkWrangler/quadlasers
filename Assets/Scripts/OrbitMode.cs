using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMode : MonoBehaviour
{
    [SerializeField] public GameObject[] subscribers;
    private const string Key = "orbitMode";
    private const int NumOrbitModes = 3;

    public void IncrementOrbitMode()
    {
        SetOrbitMode((GetOrbitMode() + 1) % NumOrbitModes);
        OnOrbitModeUpdate();
    }
    private static int GetOrbitMode()
    {
        return PlayerPrefs.GetInt(Key, 0);
    }


    private static void SetOrbitMode(int mode)
    {
        PlayerPrefs.SetInt(Key, mode);
    }
    
    private void OnOrbitModeUpdate()
    {
        AssemblyCSharp.SharedLibrary.InformSubscribers(subscribers, "OrbitModeUpdated", GetOrbitMode());
    }

    public void Start()
    {
        OnOrbitModeUpdate();
    }
}
