using UnityEngine;

namespace Platformer
{
    public class Enemy_BaseState : IState
    {
        protected readonly EnemyController enemy;
        protected readonly Animator anim;

        protected static readonly int Enemy_LocomotionHash = Animator.StringToHash("Locomotion");
        protected static readonly int Enemy_JumpHash = Animator.StringToHash("Jump");
        protected static readonly int Enemy_DashHash = Animator.StringToHash("Dash");
        protected static readonly int Enemy_AttackHash = Animator.StringToHash("Attack");

        protected const float crossFadeDuration = 0.1f;

        protected Enemy_BaseState(EnemyController enemy, Animator anim)
        {
            this.enemy = enemy;
            this.anim = anim;
        }

        public virtual void OnEnter() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void OnExit() { }
    }
}
