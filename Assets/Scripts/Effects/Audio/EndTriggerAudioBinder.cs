using Infrastructure;
using UnityEngine;

[RequireComponent(typeof(LevelEndTrigger), typeof(AudioSource))]
public class EndTriggerAudioBinder : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    private LevelEndTrigger _levelEndTrigger;
    private AudioSource _audioSource;

    private void Awake()
    {
        _levelEndTrigger = GetComponent<LevelEndTrigger>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClip;
    }
    
    private void OnEnable()
    {
        _levelEndTrigger.Triggerred += OnTriggerred;
    }

    private void OnDisable()
    {
        _levelEndTrigger.Triggerred -= OnTriggerred;
    }

    private void OnTriggerred()
    {
        _audioSource.Play();
    }
}
