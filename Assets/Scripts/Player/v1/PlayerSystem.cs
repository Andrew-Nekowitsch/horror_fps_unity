using Unity.VisualScripting;
using UnityEngine;

namespace My.Assets.Scripts.Player.v1
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
            AddInputs();
        }

        protected virtual void OnDisable()
        {
            RemoveInputs();
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
