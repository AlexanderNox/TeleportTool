using Logic.Metamorphos;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MetamorphosAudioBinder : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private MetamorphosedОbject _playerMetamorphosedОbject;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void OnEnable()
    {
        _playerMetamorphosedОbject.Metamorphosed += OnMetamorphosed;
    }

    private void OnDisable()
    {
        _playerMetamorphosedОbject.Metamorphosed -= OnMetamorphosed;
    }

    private void OnMetamorphosed()
    {
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }
}
