using UnityEngine;

namespace Platformer
{
    public class Enemy_LocomotionState : Enemy_BaseState
    { 
        public Enemy_LocomotionState(EnemyController enemy, Animator anim) : base(enemy, anim) { }

        public override void OnEnter()
        {
            anim.CrossFade(Enemy_LocomotionHash, crossFadeDuration);
        }

        public override void FixedUpdate()
        {
            enemy.HandleMovement();
        }
    }
}
