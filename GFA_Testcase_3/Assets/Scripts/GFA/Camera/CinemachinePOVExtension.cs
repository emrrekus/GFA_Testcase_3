using UnityEngine;
using Cinemachine;

namespace GFA.Camera
{
    public class CinemachinePOVExtension : CinemachineExtension
    {
        [SerializeField] private float _verticalSpeed = 10f;
        [SerializeField] private float _horizontalSpeed = 10f;
        [SerializeField] private float _clampAngle = 80f;
        private Vector3 _startingRotation;
        private Vector2 _deltaInput;

        public Vector2 DeltaInput
        {
            get => _deltaInput;
            set => _deltaInput = value;
        }

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (vcam.Follow)
            {
                if (stage == CinemachineCore.Stage.Aim)
                {
                    if (_startingRotation == null)
                    {
                        _startingRotation = transform.localRotation.eulerAngles;
                    }

                    _startingRotation.x += _deltaInput.x * _verticalSpeed* Time.deltaTime;
                    _startingRotation.y += _deltaInput.y * _horizontalSpeed*Time.deltaTime;
                    _startingRotation.y = Mathf.Clamp(_startingRotation.y, -_clampAngle, _clampAngle);
                    state.RawOrientation=Quaternion.Euler(_startingRotation.y,_startingRotation.x,0f);
                }
            }
        }
    }
}