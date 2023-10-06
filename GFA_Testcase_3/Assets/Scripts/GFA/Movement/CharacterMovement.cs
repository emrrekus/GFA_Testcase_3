using System;
using UnityEngine;

namespace GFA.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : MonoBehaviour
    {
        private CharacterController _characterController;

        [SerializeField] private float _jumpForce;
        [SerializeField] private float _ySpeed;
     
       
        public Vector2 MovementInput { get; set; }
     

        [SerializeField] private float _movementSpeed = 4;
        public Vector3 Velocity => _characterController.velocity;

        private Transform _cameraTransform;
        public Vector3 ExternalForce { get; set; }

        private Vector3 moveDirection;

        private bool _isJump;

        public bool IsJump
        {
            get => _isJump;
            set => _isJump = value;
        }

        public Transform CameraTransform
        {
            get => _cameraTransform;
            set => _cameraTransform = value;
        }

        public bool IsGrounded => _characterController.isGrounded;

     
        public float MovementSpeed
        {
            get => _movementSpeed;
            set => _movementSpeed = value;
        }

        private void Start()
        {
            _ySpeed = 0;
            _isJump = false;
        }


        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }
        

        private void Update()
        {
           
         
            Vector3 cameraForward = Vector3.Scale(_cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
            moveDirection = cameraForward * MovementInput.y + _cameraTransform.right * MovementInput.x;

            transform.rotation = Quaternion.Euler(0, _cameraTransform.transform.eulerAngles.y , 0);

            Vector3 velocity = moveDirection * _movementSpeed+ ExternalForce;
            _ySpeed += Physics.gravity.y * Time.deltaTime;
            if (IsJump && IsGrounded)
            {
                
                _ySpeed = _jumpForce;
                _isJump = false;
               
            }
            velocity.y = _ySpeed;
            
            _characterController.Move(velocity*Time.deltaTime);
            ExternalForce = Vector3.Lerp(ExternalForce, Vector3.zero, 4 * Time.deltaTime);
           

            
        }


     


       
    }
}