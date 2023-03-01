using Infrastructure;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TargetObserver : MonoBehaviour
{
    public bool IsPlayerClose { private set; get; }
    public Transform Player { private set; get; }

    private Transform _player;

    private void OnTriggerEnter(Collider other)
    {
        if (IsPlayer(other))
        {
            IsPlayerClose = true;
            _player = other.transform;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (IsPlayer(other))
            IsPlayerClose = false;
    }

    private void Update()
    {
        if (IsPlayerClose)
            Player = _player;
    }

    private bool IsPlayer(Collider other) =>
        other.TryGetComponent(out Player player) == true;
}