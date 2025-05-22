using UnityEngine;

namespace My.Assets.Scripts.Player.v1
{
    [CreateAssetMenu(fileName = "PlayerId", menuName = "Player/PlayerId/v1")]
    public class PlayerId : ScriptableObject
    {
        public Character Character;
        public PlayerSettings Settings;
        public PlayerEvents Events;
        public InputReader Input;
    }
}
