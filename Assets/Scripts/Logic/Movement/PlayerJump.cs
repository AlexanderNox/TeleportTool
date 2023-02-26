using Logic.Movement;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player.Movement
{
    [RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(GroundChecker))]
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _jumpCooldown;
        
        private Rigidbody _rigidbody;
        private GroundChecker _groundChecker;
        private InputActionMaps _inputActionMaps;
        private float _remainingJumpCooldown;

        [Inject]
        private void Construct(InputActionMaps inputActionMaps)
        {
            _inputActionMaps = inputActionMaps;
        }

        private void OnEnable()
        {
            _inputActionMaps.Map.Jump.performed += Jump;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _groundChecker = GetComponent<GroundChecker>();
        }

        private void OnDisable()
        {
            _inputActionMaps.Map.Jump.performed -= Jump;
        }

        private void Update()
        {
            _remainingJumpCooldown -= Time.deltaTime;
        }

        private void Jump(InputAction.CallbackContext callbackContext)
        {
            if (ReadyToJump())
            {
                var velocity = _rigidbody.velocity;
                velocity = new Vector3(velocity.x, 0f, velocity.z);
                _rigidbody.velocity = velocity;
                _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);

                _remainingJumpCooldown = _jumpCooldown;
            }
        }

        private bool ReadyToJump()
        {
            if (_groundChecker.GroundCheck() && _remainingJumpCooldown <= 0)
                return true;

            return false;
        }
    }
}