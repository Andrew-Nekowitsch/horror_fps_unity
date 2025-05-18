using UnityEngine;
using UnityEngine.Events;

namespace My.Interactables
{
    [RequireComponent(typeof(InteractableAbstraction))]
    public class InteractionEvent : MonoBehaviour
    {
        public UnityEvent OnInteract;

        private void Start()
        {
            var interactable = GetComponent<InteractableAbstraction>();
            interactable.Event = this;
            interactable.useEvents = true;
        }
    }
}
