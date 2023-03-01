using UnityEngine;

public class Bullet : MonoBehaviour 
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _force;

    private Vector3 direction;
    private float force;

    public void Construct(Vector3 direction, float force)
    {
        this.direction = direction; 
        this.force = force;
    }

    private void Start() => 
        Destroy(gameObject, 3f);

    private void FixedUpdate() =>
        _rigidbody.AddForce(direction.normalized * force, ForceMode.Impulse);
}