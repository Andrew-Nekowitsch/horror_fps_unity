using System.ComponentModel;
using My.Assets.Scripts.Player.v1;
using UnityEngine;

namespace My.Interactables
{
    public class PlayerInteract : PlayerSystem
    {
        [Header("Raycast Settings")]
        [SerializeField]
        private float _maxDistance = 3f;
        [SerializeField]
        private LayerMask _layerMask;

        [Header("Debugging")]
        [SerializeField]
        [ReadOnly(true)]
        private InteractableCollider _interactable;
        [SerializeField]
        private bool _debugRay = true;

        private void Update()
        {
            InteractionScan();
        }

        private void InteractionScan()
        {
            Ray ray = new Ray(player.Id.Character.Camera.transform.position, player.Id.Character.Camera.transform.forward);
            if (_debugRay)
                Debug.DrawRay(ray.origin, ray.direction * _maxDistance, Color.red);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _maxDistance, _layerMask))
            {
                if (hit.collider.TryGetComponent<InteractableCollider>(out _interactable))
                {
                    // add the ui prompt here
                    Debug.Log(hit.collider.name);
                }
            }
            else
            {
                _interactable = null;
            }
        }

        public void Interact()
        {
            if (_interactable != null)
            {
                _interactable.Interactable.BaseInteract();
            }
        }

        private void OnDrawGizmos()
        {
            if (player != null && player.Id.Character.Camera != null)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawRay(player.Id.Character.Camera.transform.position, player.Id.Character.Camera.transform.forward * (_maxDistance + 0.5f));
            }
        }
    }
}
