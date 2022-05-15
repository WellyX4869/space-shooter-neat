using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    [Header("Settings")]
    [Range(0, 1)] public float SoundVolume;
    [Range(0, 1)] public float SfxVolume;
    [HideInInspector] public bool SoundOn = true, SfxOn = true;
    [HideInInspector] public bool VibrateOn = true;

    public void SaveSettings()
    {

    }

    public void LoadSettings()
    {

    }
}
