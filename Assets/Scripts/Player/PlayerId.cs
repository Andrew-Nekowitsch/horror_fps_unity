using My.KinematicWithInputSystem;
using UnityEngine;

namespace My.PlayerController
{
    [CreateAssetMenu(fileName = "PlayerId", menuName = "Player/PlayerId/v0")]
    public class PlayerId : ScriptableObject
    {
        public Character Character;
        public PlayerSettings Settings;
        public PlayerEvents Events;
        public InputReader Input;
    }
}
