using Unity.Netcode;
using UnityEngine;

namespace My.KinematicWithInputSystem
{
    public class FPSCamera : NetworkBehaviour
    {
        private Camera _camera;

        public Transform CameraTransform { get; private set; }
        public Transform PlayerCameraTransform { get; private set; }

        public Vector3 PlanarDirection { get; set; }

        private float _targetVerticalAngle;

        private InputReader _inputReader;
        private PlayerCharacterController _character;
        private Player _player;
        private Quaternion targetRotation;

        void Awake()
        {
            if (IsOwner)
            {
                _camera = GetCamera();

                CameraTransform = this.transform;

                _targetVerticalAngle = 0f;

                PlanarDirection = Vector3.forward;
            }
        }

        private void LateUpdate()
        {
            if (IsOwner)
            {
                Look();
                _character.PostInputUpdate(Time.deltaTime, transform.forward);
            }
        }

        public void SetInputReader(InputReader inputReader)
        {
            _inputReader = inputReader;
            _inputReader.OnLookEvent += HandleInput;
        }

        private void Look()
        {
            // Apply rotation
            CameraTransform.SetPositionAndRotation(PlayerCameraTransform.position, targetRotation);
        }

        public void HandleInput(Vector2 rotationInput)
        {
            if (PlayerCameraTransform)
            {
                if (_player.Settings.InvertX)
                {
                    rotationInput.x *= -1f;
                }
                if (_player.Settings.InvertY)
                {
                    rotationInput.y *= -1f;
                }

                // Process rotation input
                Quaternion rotationFromInput = Quaternion.Euler(PlayerCameraTransform.up * (rotationInput.x * _player.Settings.RotationSpeed));
                PlanarDirection = rotationFromInput * PlanarDirection;
                PlanarDirection = Vector3.Cross(PlayerCameraTransform.up, Vector3.Cross(PlanarDirection, PlayerCameraTransform.up));
                Quaternion planarRot = Quaternion.LookRotation(PlanarDirection, PlayerCameraTransform.up);

                _targetVerticalAngle -= (rotationInput.y * _player.Settings.RotationSpeed);
                _targetVerticalAngle = Mathf.Clamp(_targetVerticalAngle, _player.MinVerticalAngle, _player.MaxVerticalAngle);
                Quaternion verticalRot = Quaternion.Euler(_targetVerticalAngle, 0, 0);
                targetRotation = Quaternion.Slerp(CameraTransform.rotation, planarRot * verticalRot, 1f - Mathf.Exp(-_player.Settings.RotationSharpness * Time.deltaTime));

                _character.SetLookRotation(targetRotation);
            }
        }

        // Set the transform that the camera will orbit around
        public void SetFollowTransform(Transform t)
        {
            PlayerCameraTransform = t;
            PlanarDirection = PlayerCameraTransform.forward;
        }

        public Camera GetCamera()
        {
            return GetComponent<Camera>();
        }
    }
}
