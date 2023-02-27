using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cannon : MonoBehaviour
{
    // [SerializeField] private Transform _spawnPopsition;
    [SerializeField] private Rigidbody[] _projectilePrefabs;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _force;
    [SerializeField] private float _projectilesLifeTime;
    private Coroutine _coroutine;
    
    private void OnEnable()
    {
        _coroutine = StartCoroutine(ShootCoroutine());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(_cooldown);
        }
    }
    
    private void Shoot()
    {
        Rigidbody projectile = Instantiate(_projectilePrefabs[GetProjectileIndex()], transform.position, transform.rotation);
        projectile.AddForce(projectile.transform.forward * _force);
        Destroy(projectile.gameObject, _projectilesLifeTime);
    }

    private int GetProjectileIndex()
    {
        int projectileIndex;
        if (_projectilePrefabs.Length > 1)
            projectileIndex = Random.Range(0, _projectilePrefabs.Length);
        else
            projectileIndex = 0;
        
        return projectileIndex;
    }
}
