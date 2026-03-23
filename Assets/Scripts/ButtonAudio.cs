using UnityEngine;
using UnityEngine.Audio;

public class ButtonAudio : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    private const string ButtonsVolume = "ButtonsVolume";

    private float _minVolume = 0.001f;

    public void ChangeButtonsVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(ButtonsVolume, ValueToVolume(volume));
    }

    private float ValueToVolume(float value)
    {
        return Mathf.Log10(Mathf.Clamp(value, _minVolume, 1f)) * 20;
    }
}
