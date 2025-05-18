namespace My.Interactables
{
    public class EventOnlyInteractable : InteractableAbstraction
    {
        private void Awake()
        {
            useEvents = true;
        }
    }
}
