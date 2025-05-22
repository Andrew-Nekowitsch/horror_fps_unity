using System;

namespace My.PlayerController
{
    public struct PlayerEvents 
    {
        public Action OnPlayerJump;
        public Action OnPlayerMove;
        public Action OnPlayerInteract;

        public Action OnPlayerAttack;
        public Action OnPlayerDie;
        public Action OnPlayerRespawn;
        public Action OnPlayerTakeDamage;
        public Action OnPlayerHeal;
        public Action OnPlayerLevelUp;
        public Action OnPlayerChangeWeapon;
    }
}
