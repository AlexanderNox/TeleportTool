using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Logic.Movement
{
   [RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(GroundChecker))]
   public class PlayerHorizontalMovement : MonoBehaviour
   {
      [SerializeField] private float _groundDrag;
      [SerializeField] private Transform _orientation;
      [SerializeField] private float _airMultiplier;
      [SerializeField] private float _maxMoveSpeed;

      private const int MoveSpeedMultiplier = 10;

      private InputActionMaps _inputActionMaps;
      private GroundChecker _groundChecker;
      private Rigidbody _rigidbody;
      private Vector2 _horizontalMoveDirection;
      private Vector3 _moveDirection;
     

      [Inject]
      private void Construct(InputActionMaps inputActionMaps)
      {
         _inputActionMaps = inputActionMaps;
      }
   
      private void Awake()
      {
         _groundChecker = GetComponent<GroundChecker>();
         _rigidbody = GetComponent<Rigidbody>();
      }

      private void OnEnable()
      {
         _inputActionMaps.Map.MovementVector2.performed  += OnWalkDirectionPerformed;
      }

      private void FixedUpdate()
      {
         ApplyDrag();
         SpeedControl(GetFlatVelocity());
         MovePlayer(_horizontalMoveDirection);
      }

      private void OnDisable()
      {
         _inputActionMaps.Map.MovementVector2.performed  -= OnWalkDirectionPerformed;
      }

      private void ApplyDrag()
      {
         if (_groundChecker.GroundCheck())
         {
            _rigidbody.drag = _groundDrag;
         }
         else
         {
            _rigidbody.drag = 0;
         }
      }

      private void OnWalkDirectionPerformed(InputAction.CallbackContext inputCallbackContext)
      {
         _horizontalMoveDirection = inputCallbackContext.ReadValue<Vector2>();
      }

      private void MovePlayer(Vector2 movementVector2)
      {
         _moveDirection = _orientation.forward * movementVector2.y + _orientation.right * movementVector2.x;
      
         if (_groundChecker.GroundCheck())
         {
            _rigidbody.AddForce(_moveDirection.normalized * _maxMoveSpeed * MoveSpeedMultiplier, ForceMode.Force);
         }
         else if (_groundChecker.GroundCheck() == false)
         {
            _rigidbody.AddForce(_moveDirection.normalized * _maxMoveSpeed * MoveSpeedMultiplier * _airMultiplier, ForceMode.Force);
         }
      }

      private void SpeedControl(Vector3 flatVelocity)
      {
         
         if (flatVelocity.magnitude > _maxMoveSpeed && _groundChecker.GroundCheck())
         {
            Debug.Log("SpeedControl");
            Vector3 limitedVelocity = flatVelocity.normalized * _maxMoveSpeed;
            _rigidbody.velocity = new Vector3(limitedVelocity.x, _rigidbody.velocity.y, limitedVelocity.z);
         }
      }

      private Vector3 GetFlatVelocity()
      {
         Vector3 flatVelocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
         return flatVelocity;
      }
   }
}