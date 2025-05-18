using UnityEngine;

namespace My.Interactables
{
    public abstract class InteractableAbstraction : MonoBehaviour
    {
        [Header("UI")]
        public string PromptMessage;
        public InteractionInfo Info;

        [Header("Interactions")]
        public bool isInteractable = true;
		public bool useEvents;
        public InteractionEvent Event;

        public void BaseInteract()
		{
			if (!isInteractable)
			{
                NotInteractable();
                return;
			}
			if (useEvents)
			{
                PreEvents();
                Event.OnInteract.Invoke();
                PostEvents();
            }
			PreInteract();
			Interact();
			PostInteract();
        }

        protected virtual void PreInteract() { }
        protected virtual void Interact() { }
        protected virtual void PostInteract() { }
        protected virtual void NotInteractable() { }
        protected virtual void PreEvents() { }
        protected virtual void PostEvents() { }
    }
}