using System.Collections;
using Infrastructure;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Level))]
public class LevelBackgrounMusic : MonoBehaviour
{
    [SerializeField] private float _offDuration;
    [SerializeField] private AudioClip _audioClip;
    private AudioSource _audioSource;
    private Level _level;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _level = GetComponent<Level>();
        _audioSource.clip = _audioClip;
    }

    private void OnEnable()
    {
        _level.LevelComplete += Off;
    }

    private void Start()
    {
        _audioSource.Play();
    }

    private void Off()
    {
        StartCoroutine(OffMusic());
    }

    private IEnumerator OffMusic()
    {
        float currentAudioDuration = 0;
        while (_audioSource.volume > 0)
        {
            _audioSource.volume =  Mathf.InverseLerp(0, _offDuration, 
                currentAudioDuration);
            
            currentAudioDuration += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
