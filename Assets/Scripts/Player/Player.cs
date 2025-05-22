using UnityEngine;
using My.PlayerController;

namespace My.KinematicWithInputSystem
{
    public class Player : MonoBehaviour
    {
        public PlayerId Id;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        void OnValidate()
        {
            if (Id == null)
            {
                return;
            }
            if (Id.Settings == null)
            {
                Id.Settings = ScriptableObject.CreateInstance<PlayerSettings>();
            }
            Id.Settings.DefaultVerticalAngle = Mathf.Clamp(Id.Settings.DefaultVerticalAngle, Id.Settings.MinVerticalAngle, Id.Settings.MaxVerticalAngle);
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;

            // Tell camera to follow transform
            Id.Character.CharacterCamera.SetFollowTransform(Id.Character.CameraFollowPoint);

            // Ignore the character's collider(s) for camera obstruction checks
            Id.Character.CharacterCamera.IgnoredColliders.Clear();
            Id.Character.CharacterCamera.IgnoredColliders.AddRange(Id.Character.CharacterController.GetComponentsInChildren<Collider>());
        }
    }
}
