using UnityEngine;

internal interface IBulletFactory
{
    void CreateBullet(Bullet bulletPrefab, Vector3 direction);
}