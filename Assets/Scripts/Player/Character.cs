using My.Assets.Scripts.Player.v1;
using My.Interactables;
using My.KinematicWithInputSystem;
using UnityEngine;

namespace My.PlayerController
{
    [CreateAssetMenu(fileName = "Character", menuName = "Player/Character")]
    public class Character : ScriptableObject
    {
        // Movement settings
        [Header("Movement Settings")]
        public ExampleCharacterController CharacterController;
        public ExampleCharacterCamera CharacterCamera;
        public Transform MeshRoot;
        public Transform CameraFollowPoint;

        // Camera settings
        [Header("Camera Settings")]
        public Camera Camera;
        
        // Misc settings
        [Header("Misc Settings")]
        public CharacterParts Parts;
        public PlayerInteract Interact;
    }
}
