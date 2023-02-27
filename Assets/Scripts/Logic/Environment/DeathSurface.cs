using UnityEngine;

namespace Logic
{
    public class DeathSurface : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IСanDie canDie))
            {
                canDie.Death();
            }
        }
    }
}