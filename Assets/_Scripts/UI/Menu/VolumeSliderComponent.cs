using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSliderComponent : MonoBehaviour
{
    public Slider slider;
    public string sliderPrefKey;
    public AudioMixer mixer;
    private void Start()
    {
        slider.onValueChanged.AddListener(OnSliderChanged);
        slider.minValue = -80f;
        slider.maxValue = 0f;

        LoadVolume();
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveListener(OnSliderChanged);
    }

    private void OnSliderChanged(float value)
    {
        SaveVolume(slider.value);
    }

    private void SaveVolume(float value)
    {
        PlayerPrefs.SetFloat(sliderPrefKey, value);
        mixer.SetFloat(sliderPrefKey, value);
        Debug.Log($"{sliderPrefKey}- {value}");
        PlayerPrefs.Save();
    }

    private void LoadVolume()
    {
        slider.value = PlayerPrefs.GetFloat(sliderPrefKey);
        mixer.SetFloat(sliderPrefKey, slider.value);
    }
}