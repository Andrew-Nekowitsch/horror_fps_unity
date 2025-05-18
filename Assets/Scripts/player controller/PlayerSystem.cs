using UnityEngine;

namespace My.PlayerController
{
    public abstract class PlayerSystem : MonoBehaviour
    {
        /// <summary>
        /// The player is the root object of the player system. It is used to access player-related data and functionality.
        /// </summary>
        protected Player player;

        /// <summary>
        /// The character system is a ScriptableObject that contains character-related data. It is destructible.
        /// </summary>
        protected Character character;

        protected virtual void Awake()
        {
            player = transform.root.GetComponent<Player>();
            character = ScriptableObject.CreateInstance<Character>();
        }
    }
}
