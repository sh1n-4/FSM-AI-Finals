using UnityEngine;

namespace Platformer
{
    public class Enemy_AttackState : Enemy_BaseState
    {
        public Enemy_AttackState(EnemyController enemy, Animator anim) : base(enemy, anim) { }

        public override void OnEnter()
        {
            if (enemy.attackTimer.IsFinished)
            {
                anim.CrossFade(Enemy_AttackHash, crossFadeDuration);
            }
        }

        public override void Update()
        {
            if (enemy.attackTimer.IsFinished)
            {
                enemy.Attack();
                enemy.attackTimer.Reset();
            }
        }


        public override void FixedUpdate()
        {
            enemy.HandleMovement();
        }
    }
}
