using UnityEngine;

namespace Platformer
{
    public class Enemy_AttackState : Enemy_BaseState
    {
        public Enemy_AttackState(EnemyController enemy, Animator anim) : base(enemy, anim) { }

        public override void OnEnter()
        {
            anim.CrossFade(Enemy_AttackHash, crossFadeDuration);
            enemy.Attack();
        }

        public override void FixedUpdate()
        {
            enemy.HandleMovement();
        }
    }
}
