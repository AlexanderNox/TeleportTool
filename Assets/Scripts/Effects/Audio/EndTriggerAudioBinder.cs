using Infrastructure;
using UnityEngine;

[RequireComponent(typeof(EndTrigger), typeof(AudioSource))]
public class EndTriggerAudioBinder : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    private EndTrigger _endTrigger;
    private AudioSource _audioSource;

    private void Awake()
    {
        _endTrigger = GetComponent<EndTrigger>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClip;
    }
    
    private void OnEnable()
    {
        _endTrigger.Triggerred += OnTriggerred;
    }

    private void OnDisable()
    {
        _endTrigger.Triggerred -= OnTriggerred;
    }

    private void OnTriggerred()
    {
        _audioSource.Play();
    }
}
