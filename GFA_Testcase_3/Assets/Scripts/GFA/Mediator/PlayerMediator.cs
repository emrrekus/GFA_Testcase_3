using System;
using Cinemachine;
using GFA.Animation;
using GFA.Input;
using GFA.Movement;
using GFA.Camera;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GFA.Mediator
{
    public class PlayerMediator : MonoBehaviour
    {
        [SerializeField] private UIManager _uıManager;

        private GameInput _gameInput;
        private CharacterMovement _characterMovement;
        private PlayerAnimation _playerAnimation;
        private UnityEngine.Camera _camera;

        [SerializeField] private CinemachinePOVExtension _cinemachinePovExtension;


        private Plane _plane = new(Vector3.up, Vector3.zero);
        [SerializeField] private float _rollpower;

        private void Awake()
        {
            _gameInput = new GameInput();
            _camera = UnityEngine.Camera.main;
            _characterMovement = GetComponent<CharacterMovement>();
            _playerAnimation = GetComponent<PlayerAnimation>();
        }

        private void OnEnable()
        {
            _gameInput.Player.Rolling.performed += OnPlayerRoll;
            _gameInput.Player.Jump.performed += OnPlayerJump;
            _gameInput.Enable();
        }

        private void OnDisable()
        {
            _gameInput.Player.Rolling.performed -= OnPlayerRoll;
            _gameInput.Player.Jump.performed -= OnPlayerJump;
            _gameInput.Disable();
        }

        private void Update()
        {
            HandleMovement();
            HandleRotation();
            _playerAnimation.Velocity = _characterMovement.Velocity;
        }


        private void HandleMovement()
        {
            var movementInput = _gameInput.Player.Movement.ReadValue<Vector2>();
            _characterMovement.MovementInput = movementInput;

            _characterMovement.CameraTransform = _camera.transform;
        }

        private void HandleRotation()
        {
            _cinemachinePovExtension.DeltaInput = _gameInput.Player.CLook.ReadValue<Vector2>();
        }


        private void OnPlayerJump(InputAction.CallbackContext obj)
        {
            if (!_characterMovement.IsGrounded) return;
            ;
            _characterMovement.IsJump = true;
            _playerAnimation.PlayJumpAnimation();
        }

        private void OnPlayerRoll(InputAction.CallbackContext obj)
        {
            if (!_characterMovement.IsGrounded) return;


            _playerAnimation.PlayRollingAnimation();
            _characterMovement.IsJump = false;
            _characterMovement.ExternalForce += _characterMovement.Velocity.normalized * _rollpower;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _uıManager.LoseCanvas();
            }

            if (other.gameObject.CompareTag("Finish"))
            {
                _uıManager.WinCanvas();
            }
        }
    }
}