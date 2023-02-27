using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Logic.Metamorphos
{
    public class MetamorphosGun : MonoBehaviour
    {
        [SerializeField] private MetamorphosedОbject _gunUser;
    
        private const float Range = 10000;
        private Camera _camera;
        private InputActionMaps _inputActionMaps;

        [Inject]
        private void Construct(InputActionMaps inputActionMaps)
        {
            _inputActionMaps = inputActionMaps;
        }
    
        private void Awake()
        {
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _inputActionMaps.Map.Shoot.performed += OnShootInput;
        }

        private void OnShootInput(InputAction.CallbackContext obj)
        {
            Shoot();
        }

        private void Shoot()
        {
            if (Physics.Raycast(_camera.transform.position,
                    GetShootDirection(), out RaycastHit hit))
            {
                if (hit.transform.TryGetComponent(out IMetamorphosable iMetamorphosable))
                    Metamorphos(iMetamorphosable);
            }
        }

        private void Metamorphos(IMetamorphosable iMetamorphosable)
        {
            MetamorphosData enteringMetamorphosData = iMetamorphosable.GetMetamorphosData();
        
            iMetamorphosable.Metamorphos(_gunUser.GetMetamorphosData());
        
            _gunUser.Metamorphos(enteringMetamorphosData);
        }

        private Vector3 GetShootDirection()
        {
            Vector3 targetPosition = _camera.transform.position + _camera.transform.forward * Range;

            Vector3 direction = targetPosition - _camera.transform.position;
            
            Debug.DrawRay(_camera.transform.position, direction * Range, Color.yellow, 5f);
            return direction.normalized;
        }
    }
}