using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderForAudio : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private string _mixerName;

    private Slider _slider;

    private float _minVolume = 0.01f;
    private float _maxVolume = 1f;
    private float _volumeMultiplier = 20;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(ChangeButtonsVolume);
    }

    private void ChangeButtonsVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(_mixerName, ValueToVolume(volume));
    }

    private float ValueToVolume(float value)
    {
        return Mathf.Log10(Mathf.Clamp(value, _minVolume, _maxVolume)) * _volumeMultiplier;
    }
}