using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    private const string MasterVolume = "MasterVolume";

    private Toggle _toggle;

    private float _muteVolume = -80;
    private float _buferVolume = 0;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(ToggleAllSound);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(ToggleAllSound);
    }

    private void ToggleAllSound(bool enabled)
    {
        if (enabled)
        {
            _mixer.audioMixer.SetFloat(MasterVolume, _buferVolume);
        }
        else
        {
            _mixer.audioMixer.GetFloat(MasterVolume, out _buferVolume);
            _mixer.audioMixer.SetFloat(MasterVolume, _muteVolume);
        }
    }
}
