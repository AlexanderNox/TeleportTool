using UnityEngine;
using Random = UnityEngine.Random;

public class TurretGun : MonoBehaviour
{
    private IBulletFactory bulletFactory;

    [SerializeField] private float _reloadTime;
    [SerializeField] private float _bulletSpread;
    [SerializeField] private Transform _shootDirection;
    [SerializeField] private TargetObserver _turretTargetObserver;
    [SerializeField] private Bullet _bulletPrefab;
    
    private const float MaxSpread = 2;
    private const float MinSpread = 0;
    private float _reloadTimer;

    private float bulletSpreadByTargetScale
    {
        get
        {
            if (targetScale >= MaxSpread)
                return _bulletSpread * MaxSpread;
            else if (targetScale <= MinSpread)
                return 0;

            return _bulletSpread * targetScale;
        }
    }
    
    private float halfOfBulletSpreadAmount => bulletSpreadByTargetScale / 2;

    private Transform target => _turretTargetObserver.Player;
    private float targetScale => (targetLocalScale.y + targetLocalScale.x + targetLocalScale.z) / 3;
    private Vector3 targetLocalScale => target.localScale;
    private bool isReloaded => _reloadTimer < 0;

    private void Awake()
    {
        bulletFactory = GetComponent<BulletFactory>();
    }
    
    private void Update()
    {
        _reloadTimer -= Time.deltaTime;

        if (_turretTargetObserver.IsPlayerClose && isReloaded)
        {
            Shoot();
            _reloadTimer = _reloadTime;
        }
    }

    private Vector3 GetDirectionWithSpread()
    {
        return (_shootDirection.position - transform.position) + GetSpreadVector();
    }

    private Vector3 GetSpreadVector()
    {
        return new Vector3(0,
            Random.Range(-halfOfBulletSpreadAmount, halfOfBulletSpreadAmount),
            Random.Range(-halfOfBulletSpreadAmount, halfOfBulletSpreadAmount));
    }

    private void Shoot()
    {
        Vector3 direction = GetDirectionWithSpread();

        Debug.Log(_shootDirection.position);
        Debug.Log(direction);

        bulletFactory.CreateBullet(_bulletPrefab, direction);
    }
}