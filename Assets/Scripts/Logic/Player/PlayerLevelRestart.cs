using Infrastructure;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Logic
{
    [RequireComponent(typeof(Player))]
    public class PlayerLevelRestart : MonoBehaviour
    {
        private InputActionMaps _inputActionMaps;
        private Player _player;
        
        [Inject]
        private void Construct(InputActionMaps inputActionMaps)
        {
            _inputActionMaps = inputActionMaps;
        }

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void OnEnable()
        {
            _inputActionMaps.Map.LevelRestart.performed += OnLevelRestartInput;
        }

        private void OnDisable()
        {
            _inputActionMaps.Map.LevelRestart.performed -= OnLevelRestartInput;
        }

        private void OnLevelRestartInput(InputAction.CallbackContext obj)
        {
            _player.InvokeRestartRequest();
        }
    }
}