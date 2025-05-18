using UnityEngine;

namespace My.Interactables
{
    public class Interactable : InteractableAbstraction
    {
        protected override void PreInteract() { }
        protected override void Interact() { }
        protected override void PostInteract() { }
        protected override void NotInteractable() { }
        protected override void PreEvents() { }
        protected override void PostEvents() { }
    }
}
