using UnityEngine;
using System.Collections.Generic;
using Utilities;
using UnityEngine.AI;

namespace Platformer
{
    public class EnemyController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] public Animator anim;
        [SerializeField] public PlayerDetector detector;
        [SerializeField] public NavMeshAgent agent;

        [Header("Attack Settings")]
        [SerializeField] public float attackCooldown = 0.5f;
        [SerializeField] float attackDistance = 1f;
        [SerializeField] int attackDamage = 5;

        public CountdownTimer attackTimer;

        StateMachine stateMachine;

        void Awake()
        {
            attackTimer = new CountdownTimer(attackCooldown);
            SetupStateMachine();
        }


        void SetupStateMachine()
        {
            stateMachine = new StateMachine();

            var locomotionState = new Enemy_LocomotionState(this, anim);
            var attackState = new Enemy_AttackState(this, anim);
            var dashState = new Enemy_DashState(this, anim);
            var jumpState = new Enemy_JumpState(this, anim);
            var chaseState = new Enemy_ChaseState(this, anim);

            Debug.Log($"[CanAttack] InRange: {detector.CanAttackPlayer()}, CooldownReady: {attackTimer.IsFinished}");


            /*FuncPredicate CanAttackWithCooldown = new FuncPredicate(() =>
                detector.CanAttackPlayer() && attackTimer.IsFinished);*/

            At(locomotionState, attackState, new FuncPredicate(() =>
                detector.CanAttackPlayer() && attackTimer.IsFinished));
            At(locomotionState, chaseState, new FuncPredicate(() => detector.CanDetectPlayer()));
            At(attackState, locomotionState, new FuncPredicate(() => !detector.CanAttackPlayer()));
            At(chaseState, locomotionState, new FuncPredicate(() => !detector.CanDetectPlayer()));
            At(chaseState, attackState, new FuncPredicate(() =>
                detector.CanAttackPlayer() && attackTimer.IsFinished));
            At(attackState, chaseState, new FuncPredicate(() => !detector.CanAttackPlayer() && detector.CanDetectPlayer()));

            stateMachine.SetState(locomotionState);
        }


        void At(IState from, IState to, IPredicate condition) => stateMachine.AddTransition(from, to, condition);
        void Any(IState to, IPredicate condition) => stateMachine.AddAnyTransition(to, condition);

        void Update()
        {
            attackTimer.Tick(Time.deltaTime);
            Debug.Log($"[Timer] Cooldown done: {attackTimer.IsFinished}");
            stateMachine.Update();
        }

        void FixedUpdate()
        {
            stateMachine.FixedUpdate();
        }

        public void Attack()
        {
            if (!attackTimer.IsFinished) return;

            if (detector.Player != null)
            {
                if (detector.CanDetectPlayer() && detector.CanAttackPlayer())
                {
                    detector.PlayerHealth.TakeDamage(attackDamage);
                }
            }
        }

        public void HandleMovement()
        {
            
            float speedPercent = agent.velocity.magnitude / agent.speed;

            if (agent.velocity.magnitude > 0f)
            {
                
                SmoothSpeed(speedPercent);
            } else
            {
                SmoothSpeed(0f);
            }
        }


        void SmoothSpeed(float speedPercent)
        {
            anim.SetFloat("Speed",  speedPercent, 0.1f, Time.deltaTime);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, attackDistance);
        }
    }
}
