using System;
using UnityEngine;

namespace GFA.Animation
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public Vector3 Velocity { get; set; }
        private Vector3 _appliedVelocity;
        private Vector3 _currentTranstionVelocity;
        private static readonly int Jumping = Animator.StringToHash("Jumping");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Rolling = Animator.StringToHash("Rolling");

        private void Update()
        {
            var transformedVelocity = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * Velocity;

            _appliedVelocity = Vector3.SmoothDamp(_appliedVelocity, transformedVelocity, ref _currentTranstionVelocity,
                (transformedVelocity.magnitude < 0.01f ? 3 : 8) * Time.deltaTime);

            _animator.SetFloat(Speed, _appliedVelocity.z);
        }


        public void PlayJumpAnimation()
        {
            _animator.SetTrigger(Jumping);
        }

        public void PlayRollingAnimation()
        {
            _animator.SetTrigger(Rolling);
        }
    }
}