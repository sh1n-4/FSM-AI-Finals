using UnityEngine;

namespace Platformer
{
    public class Enemy_JumpState : Enemy_BaseState
    {
        public Enemy_JumpState(EnemyController enemy, Animator anim) : base(enemy, anim) { }

        public override void OnEnter()
        {
            anim.CrossFade(Enemy_JumpHash, crossFadeDuration);
        }
    }
}
