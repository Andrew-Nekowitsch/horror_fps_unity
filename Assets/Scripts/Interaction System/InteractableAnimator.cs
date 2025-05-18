using System;
using UnityEngine;

namespace My.Interactables
{
    [RequireComponent(typeof(InteractionEvent))]
    [RequireComponent(typeof(Animator))]
    public class InteractableAnimator : MonoBehaviour
    {
        private Animator _animator;
        [SerializeField] private string _animatorParamName;
        [SerializeField] private bool _activated;

        private void Awake()
        {
            _animator = _animator == null ? GetComponent<Animator>() : _animator;
        }

        private void OnValidate()
        {
            GetComponent<InteractableAbstraction>().useEvents = true;
            GetComponent<InteractionEvent>().OnInteract.AddListener(Animate);
        }

        private void OnDisable()
        {
            GetComponent<InteractionEvent>().OnInteract.RemoveListener(Animate);
        }

        public void Animate()
        {
            _activated = !_activated;
            SetAnimatorParam(_activated);
        }

        private void SetAnimatorParam(bool value)
        {
            if (_animator != null && !String.IsNullOrEmpty(_animatorParamName))
                _animator.SetBool(_animatorParamName, value);
        }
    }
}
