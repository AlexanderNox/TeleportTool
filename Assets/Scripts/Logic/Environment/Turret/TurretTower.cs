using Infrastructure;
using UnityEngine;
using Zenject;

public class TurretTower : MonoBehaviour
{
    [SerializeField] private TargetObserver _observer;
    [SerializeField] private float _maxTurnSpeed = 90f;
    private Transform _target;

    [Inject]
    private void Construct(Player player)
    {
        _target = player.transform;
    }
    private void Update()
    {
        if (_observer.IsPlayerClose)
        {
            Aim();
        }
    }

    private void Aim()
    {
        Vector3 direction = _target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _maxTurnSpeed * Time.deltaTime);
    }
}