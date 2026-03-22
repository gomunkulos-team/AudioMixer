using UnityEngine;
using UnityEngine.Audio;

public class AudioPanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    private const string MasterVolume = "MasterVolume";
    private const string ButtonsVolume = "ButtonsVolume";
    private const string BackgroundVolume = "BackgroundVolume";

    private float _minVolume = 0.001f;

    public void ToggleAllSound(bool enabled)
    {
        if (enabled)
            _mixer.audioMixer.SetFloat(MasterVolume, 0);
        else
            _mixer.audioMixer.SetFloat(MasterVolume, -80);
    }

    public void ChangeAllVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(MasterVolume, ValueToVolume(volume));
    }

    public void ChangeButtonsVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(ButtonsVolume, ValueToVolume(volume));
    }

    public void ChangeBackgroundVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(BackgroundVolume, ValueToVolume(volume));
    }

    private float ValueToVolume(float value)
    {
        return Mathf.Log10(Mathf.Clamp(value, _minVolume, 1f)) * 20;
    }
}