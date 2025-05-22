using UnityEngine;

namespace My.Assets.Scripts.Player.v1
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

        // private void LateUpdate()
        // {
        //     // Handle rotating the camera along with physics movers
        //     if (CharacterCamera.RotateWithPhysicsMover && Character.Motor.AttachedRigidbody != null)
        //     {
        //         CharacterCamera.PlanarDirection = Character.Motor.AttachedRigidbody.GetComponent<PhysicsMover>().RotationDeltaFromInterpolation * CharacterCamera.PlanarDirection;
        //         CharacterCamera.PlanarDirection = Vector3.ProjectOnPlane(CharacterCamera.PlanarDirection, Character.Motor.CharacterUp).normalized;
        //     }

        //     HandleCameraInput();
        // }

//         private void HandleCameraInput()
//         {
//             // Create the look input vector for the camera
//             float mouseLookAxisUp = Input.GetAxisRaw(MouseYInput);
//             float mouseLookAxisRight = Input.GetAxisRaw(MouseXInput);
//             Vector3 lookInputVector = new Vector3(mouseLookAxisRight, mouseLookAxisUp, 0f);

//             // Prevent moving the camera while the cursor isn't locked
//             if (Cursor.lockState != CursorLockMode.Locked)
//             {
//                 lookInputVector = Vector3.zero;
//             }

//             // Input for zooming the camera (disabled in WebGL because it can cause problems)
//             float scrollInput = -Input.GetAxis(MouseScrollInput);
// #if UNITY_WEBGL
//         scrollInput = 0f;
// #endif

//             // Apply inputs to the camera
//             CharacterCamera.UpdateWithInput(Time.deltaTime, scrollInput, lookInputVector);

//             // Handle toggling zoom level
//             if (Input.GetMouseButtonDown(1))
//             {
//                 CharacterCamera.TargetDistance = CharacterCamera.TargetDistance == 0f ? CharacterCamera.DefaultDistance : 0f;
//             }
//         }
    }
}
