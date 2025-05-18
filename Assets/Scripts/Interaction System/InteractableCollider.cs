using UnityEngine;

namespace My.Interactables
{
    public class InteractableCollider : MonoBehaviour
    {
        public InteractableAbstraction Interactable;

        private void OnValidate()
        {
            gameObject.layer = LayerMask.NameToLayer("Interactable");
        }
    }
}
