using My.KinematicWithInputSystem;
using UnityEngine;

namespace My.PlayerController
{
    public abstract class PlayerSystem : MonoBehaviour
    {
        /// <summary>
        /// Persisitent player data.
        /// </summary>
        protected Player player;
        protected InputReader inputReader;

        protected virtual void Awake()
        {
            Initialize();
            AddInputs();
        }

        protected virtual void OnEnable()
        {
            Initialize();
        }

        protected virtual void OnDisable()
        {
        }

        protected virtual void AddInputs()
        {
        }

        protected virtual void RemoveInputs()
        {
        }

        private void Initialize()
        {
            if (player == null)
            {
                player = transform.root.GetComponent<Player>();
            }
        }
    }
}
