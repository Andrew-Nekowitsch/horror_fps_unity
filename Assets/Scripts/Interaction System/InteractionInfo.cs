using UnityEngine;

namespace My.Interactables
{
    [CreateAssetMenu(fileName = "InteractionInfo", menuName = "A1/InteractionInfo")]
    public class InteractionInfo : ScriptableObject
    {
        [Header("UI")]
        public string InteractableText;
        public string NotInteractableText;
    }
}
