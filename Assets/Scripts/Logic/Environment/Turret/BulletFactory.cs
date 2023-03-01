using UnityEngine;

public class BulletFactory : MonoBehaviour, IBulletFactory
{
    public void CreateBullet(Bullet bulletPrefab, Vector3 direction)
    {
        GameObject bulletObject = Instantiate(bulletPrefab.gameObject, transform.position, Quaternion.identity);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.Construct(direction, 5f);
    }
}