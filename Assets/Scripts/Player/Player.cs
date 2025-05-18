using System;
using My.Interactables;
using UnityEngine;

namespace My.KinematicWithInputSystem
{
    [RequireComponent(typeof(PlayerCharacterController))]
    public class Player : MonoBehaviour
    {
        private FPSCamera FPCamera;
        private Transform CameraFollowPoint;
        private PlayerCharacterController Character;
        private PlayerInteract Interact;

        public PlayerSettings Settings;

        [Header("Rotation")]
        [Range(-90f, 90f)]
        public float DefaultVerticalAngle = 20f;
        [Range(-90f, 90f)]
        public float MinVerticalAngle = -90f;
        [Range(-90f, 90f)]
        public float MaxVerticalAngle = 90f;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        void OnValidate()
        {
            DefaultVerticalAngle = Mathf.Clamp(DefaultVerticalAngle, MinVerticalAngle, MaxVerticalAngle);
        }
    }
}
