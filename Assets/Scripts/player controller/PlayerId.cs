using My.KinematicWithInputSystem;
using UnityEngine;

namespace My.PlayerController
{
    [CreateAssetMenu(fileName = "PlayerId", menuName = "Player/PlayerId")]
    public class PlayerId : ScriptableObject
    {
        public PlayerSettings settings;
        public PlayerEvents events;
    }
}
