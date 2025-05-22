using UnityEngine;

namespace My.Assets.Scripts.Player.v1
{
    [CreateAssetMenu(menuName = "Player/PlayerSettings/v1")]
    public class PlayerSettings : ScriptableObject
    {
        public bool InvertX = false;
        public bool InvertY = false;


        public float RotationSpeed = 1f;
        public float RotationSharpness = 10000f;

        [Header("Rotation")]
        [Range(-90f, 90f)]
        public float DefaultVerticalAngle = 20f;
        [Range(-90f, 90f)]
        public float MinVerticalAngle = -90f;
        [Range(-90f, 90f)]
        public float MaxVerticalAngle = 90f;
    }
}
