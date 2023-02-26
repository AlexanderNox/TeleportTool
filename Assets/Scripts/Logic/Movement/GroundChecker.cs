using UnityEngine;

namespace Logic.Movement
{
    
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private Transform _lowerPosition;
        [SerializeField] private LayerMask _groundLayer;
        private const float RayCastMaxDistance = 0.2f;

        public bool GroundCheck()
        {
            return Physics.Raycast(_lowerPosition.position, 
                Vector3.down, RayCastMaxDistance, _groundLayer);
        }
    }
}