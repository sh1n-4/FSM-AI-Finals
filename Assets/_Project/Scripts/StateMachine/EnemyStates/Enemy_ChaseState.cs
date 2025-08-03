using UnityEngine;

namespace Platformer
{
    public class Enemy_ChaseState : Enemy_BaseState
    {
        public Enemy_ChaseState(EnemyController enemy, Animator anim) : base(enemy, anim) { }

        public override void OnEnter()
        {
            anim.CrossFade(Enemy_LocomotionHash, crossFadeDuration);
        }

        public override void Update()
        {
            if (enemy.detector.Player != null)
            {
                enemy.agent.SetDestination(enemy.detector.Player.position);
            }
        }

        public override void FixedUpdate()
        {
            enemy.HandleMovement();
        }
    }
}
