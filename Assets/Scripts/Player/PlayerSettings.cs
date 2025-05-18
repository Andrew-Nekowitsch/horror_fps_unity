using UnityEngine;

namespace My.KinematicWithInputSystem
{
    [CreateAssetMenu(menuName = "My/PlayerSettings")]
    public class PlayerSettings : ScriptableObject
    {
        public InputReader _inputReader;


        public bool InvertX = false;
        public bool InvertY = false;


        public float RotationSpeed = 1f;
        public float RotationSharpness = 10000f;
    }
}
