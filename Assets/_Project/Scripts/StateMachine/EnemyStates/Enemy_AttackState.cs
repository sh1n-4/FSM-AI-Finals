using UnityEngine;

namespace Platformer
{
    public class Enemy_AttackState : Enemy_BaseState
    {
        public Enemy_AttackState(EnemyController enemy, Animator anim) : base(enemy, anim) { }

        public override void OnEnter()
        {
            Debug.Log($"[AttackState] Entered. Cooldown ready? {enemy.attackTimer.IsFinished}");

            if (enemy.attackTimer.IsFinished)
            {
                anim.CrossFade(Enemy_AttackHash, crossFadeDuration);
                enemy.Attack();
                enemy.attackTimer.Reset();
                Debug.Log("[AttackState] Attack performed. Cooldown reset.");
            }
            else
            {
                Debug.Log("[AttackState] Skipped attack — cooldown not ready.");
            }
        }


        public override void FixedUpdate()
        {
            enemy.HandleMovement();
        }
    }
}
