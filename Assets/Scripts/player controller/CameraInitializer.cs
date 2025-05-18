using UnityEngine;

namespace My.PlayerController
{
    public class CameraInitializer : PlayerSystem
    {
        private void Awake()
        {
            character.Camera = GetComponent<Camera>();
        }
    }
}
