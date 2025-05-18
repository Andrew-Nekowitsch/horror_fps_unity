using UnityEngine;

namespace My.PlayerController
{
    [CreateAssetMenu(fileName = "Character", menuName = "Player/Character")]
    public class Character : ScriptableObject
    {
        // Camera settings
        [Header("Camera Settings")]
        public Camera Camera;
        public Transform CameraFollowPoint;
    }
}
