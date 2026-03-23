using UnityEngine;
using UnityEngine.Audio;

public class BackgoundAudio : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    private const string BackgroundVolume = "BackgroundVolume";

    private float _minVolume = 0.001f;

    public void ChangeBackgroundVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(BackgroundVolume, ValueToVolume(volume));
    }

    private float ValueToVolume(float value)
    {
        return Mathf.Log10(Mathf.Clamp(value, _minVolume, 1f)) * 20;
    }
}
