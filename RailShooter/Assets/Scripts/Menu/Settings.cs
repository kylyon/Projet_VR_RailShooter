using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public TMP_Dropdown resoDropdown;

    private Resolution[] _resolution;
    private void Start()
    {
        _resolution = Screen.resolutions;
        
        resoDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentReso = 0;
        for (int i = 0; i < _resolution.Length; i++)
        {
            string option = _resolution[i].width + " x " + _resolution[i].height;
            options.Add(option);

            if (_resolution[i].width == Screen.currentResolution.width && _resolution[i].height == Screen.currentResolution.height)
            {
                currentReso = i;
            }
        }
            
        resoDropdown.AddOptions(options);
        resoDropdown.value = currentReso;
        resoDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetResolution(int resoIndex)
    {
        Resolution resolution = _resolution[resoIndex];
        Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.FullScreenWindow);
    }
}
