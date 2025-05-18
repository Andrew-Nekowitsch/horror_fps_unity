using UnityEngine;

namespace My.PlayerController
{
    public class SPCamera : PlayerSystem
    {
        public Vector3 PlanarDirection { get; set; }
        private float _targetVerticalAngle;
        private InputReader _inputReader;
        private KinematicWithInputSystem.PlayerCharacterController _character;
        private KinematicWithInputSystem.Player _player;
        private Quaternion targetRotation;

        protected override void Awake()
        {
            base.Awake();

            character.CameraFollowPoint = this.transform;

            _targetVerticalAngle = 0f;
        }

        private void Start()
        {
            if (character.Camera != null)
            {
                PlanarDirection = character.Camera.transform.forward;
            }
        }

        private void LateUpdate()
        {
            ApplyRotation();
            _character.PostInputUpdate(Time.deltaTime, transform.forward);
        }

        public void SetInputReader(InputReader inputReader)
        {
            _inputReader = inputReader;
            _inputReader.OnLookEvent += HandleInput;
        }

        protected void ApplyRotation()
        {
            if (character.Camera != null)
            {
                character.CameraFollowPoint.SetPositionAndRotation(character.Camera.transform.position, targetRotation);
            }
        }

        public void HandleInput(Vector2 rotationInput)
        {
            if (character.Camera.transform)
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
                Quaternion rotationFromInput = Quaternion.Euler(character.Camera.transform.up * (rotationInput.x * _player.Settings.RotationSpeed));
                PlanarDirection = rotationFromInput * PlanarDirection;
                PlanarDirection = Vector3.Cross(character.Camera.transform.up, Vector3.Cross(PlanarDirection, character.Camera.transform.up));
                Quaternion planarRot = Quaternion.LookRotation(PlanarDirection, character.Camera.transform.up);

                _targetVerticalAngle -= (rotationInput.y * _player.Settings.RotationSpeed);
                _targetVerticalAngle = Mathf.Clamp(_targetVerticalAngle, _player.MinVerticalAngle, _player.MaxVerticalAngle);
                Quaternion verticalRot = Quaternion.Euler(_targetVerticalAngle, 0, 0);
                targetRotation = Quaternion.Slerp(character.CameraFollowPoint.rotation, planarRot * verticalRot, 1f - Mathf.Exp(-_player.Settings.RotationSharpness * Time.deltaTime));

                _character.SetLookRotation(targetRotation);
            }
        }
    }
}
