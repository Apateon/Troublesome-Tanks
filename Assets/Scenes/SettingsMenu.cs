using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    public Dropdown resolutionsDropDown;

    private Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionsDropDown.ClearOptions();

        List<string> resolutionNames = new List<string>();

        int currentResolutionIndex = 0;
        for (int i=0;i<resolutions.Length;i++)
        {
            string resolutionName = resolutions[i].width + "x" + resolutions[i].height;
            resolutionNames.Add(resolutionName);

            if (resolutions[i].width==Screen.currentResolution.width && resolutions[i].height==Screen.currentResolution.height)
                currentResolutionIndex = i;
        }
        resolutionsDropDown.AddOptions(resolutionNames);
        resolutionsDropDown.value = currentResolutionIndex;
        resolutionsDropDown.RefreshShownValue();
    }
    public void setVolume(float volume)
    {
        audiomixer.SetFloat("Volume", volume);
    }

    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void setFullScreen(bool isfullScreen)
    {
        Screen.fullScreen = isfullScreen;
    }
    public void setResolution(int resolutionIndex)
    {
        Resolution resolution= resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }
    
    public void goBack()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
