using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsUI : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        ApplyVolumes();
    }

    public void ApplyVolumes()
    {
        if (AudioManager.instance == null) return;

        float master = masterSlider.value;
        float music = musicSlider.value;
        float sfx = sfxSlider.value;

        AudioManager.instance.menuMusicSource.volume = master * music;
        AudioManager.instance.sfxSource.volume = master * sfx;

        PlayerPrefs.SetFloat("MasterVolume", master);
        PlayerPrefs.SetFloat("MusicVolume", music);
        PlayerPrefs.SetFloat("SFXVolume", sfx);

        PlayerPrefs.Save();
    }
}