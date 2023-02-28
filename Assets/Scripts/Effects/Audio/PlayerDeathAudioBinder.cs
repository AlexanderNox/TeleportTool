using Infrastructure;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerDeathAudioBinder : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private Player _player;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    private void OnDied()
    {
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }
}
