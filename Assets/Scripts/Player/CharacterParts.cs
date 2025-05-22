using UnityEngine;

namespace My.PlayerController
{
    public class CharacterParts : PlayerSystem
    {
        public Transform MeshRoot;
        public Transform CameraFollowPoint;

        protected override void Awake()
        {
            base.Awake();

            player.Id.Character.Parts = this;
        }
    }
}
