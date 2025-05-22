using UnityEngine;

namespace My.PlayerController
{
    public class SPCamera : PlayerSystem
    {
        public Vector3 PlanarDirection { get; set; }
        private float targetVerticalAngle;
        private Quaternion targetRotation;

        protected override void Awake()
        {
            base.Awake();

            // player.Id.Character.FpsCamera = this;
            player.Id.Input.OnLookEvent += HandleInput;

            targetVerticalAngle = 0f;
        }

        private void Start()
        {
            if (player.Id.Character.Camera != null)
            {
                PlanarDirection = player.Id.Character.Camera.transform.forward;
            }
        }

        private void LateUpdate()
        {
            ApplyRotation();
            // player.Id.Character.CharacterController.PostInputUpdate(Time.deltaTime, transform.forward);
        }

        protected void ApplyRotation()
        {
            if (player.Id.Character.Camera != null)
            {
                player.Id.Character.Parts.CameraFollowPoint.SetPositionAndRotation(player.Id.Character.Camera.transform.position, targetRotation);
            }
        }

        public void HandleInput(Vector2 rotationInput)
        {
            if (player.Id.Character.Camera.transform)
            {
                if (player.Id.Settings.InvertX)
                {
                    rotationInput.x *= -1f;
                }
                if (player.Id.Settings.InvertY)
                {
                    rotationInput.y *= -1f;
                }

                // Process rotation input
                Quaternion rotationFromInput = Quaternion.Euler(player.Id.Character.Camera.transform.up * (rotationInput.x * player.Id.Settings.RotationSpeed));
                PlanarDirection = rotationFromInput * PlanarDirection;
                PlanarDirection = Vector3.Cross(player.Id.Character.Camera.transform.up, Vector3.Cross(PlanarDirection, player.Id.Character.Camera.transform.up));
                Quaternion planarRot = Quaternion.LookRotation(PlanarDirection, player.Id.Character.Camera.transform.up);
                targetVerticalAngle -= rotationInput.y * player.Id.Settings.RotationSpeed;
                targetVerticalAngle = Mathf.Clamp(targetVerticalAngle, player.Id.Settings.MinVerticalAngle, player.Id.Settings.MaxVerticalAngle);
                Quaternion verticalRot = Quaternion.Euler(targetVerticalAngle, 0, 0);
                targetRotation = Quaternion.Slerp(player.Id.Character.Parts.CameraFollowPoint.rotation, planarRot * verticalRot, 1f - Mathf.Exp(-player.Id.Settings.RotationSharpness * Time.deltaTime));

                // player.Id.Character.CharacterController.SetLookRotation(targetRotation);
            }
        }
    }
}
