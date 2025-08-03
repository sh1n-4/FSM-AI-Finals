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

        /*[Header("Movement Settings")]
        [SerializeField] float moveSpeed = 6f;
        [SerializeField] float rotationSpeed = 15f;
        [SerializeField] float smoothTime = 0.2f;*/

        [Header("Attack Settings")]
        [SerializeField] float attackCooldown = 0.5f;
        [SerializeField] float attackDistance = 1f;
        [SerializeField] int attackDamage = 5;

        // public Transform TargetToFace { get; set; }


        StateMachine stateMachine;

        void Awake()
        {
            SetupStateMachine();
            // agent.updateRotation = false;
        }


        void SetupStateMachine()
        {
            stateMachine = new StateMachine();

            var locomotionState = new Enemy_LocomotionState(this, anim);
            var attackState = new Enemy_AttackState(this, anim);
            var dashState = new Enemy_DashState(this, anim);
            var jumpState = new Enemy_JumpState(this, anim);
            var chaseState = new Enemy_ChaseState(this, anim);

            At(locomotionState, attackState, new FuncPredicate(() => detector.CanAttackPlayer()));
            At(locomotionState, chaseState, new FuncPredicate(() => detector.CanDetectPlayer()));
            At(attackState, locomotionState, new FuncPredicate(() => !detector.CanAttackPlayer()));
            At(chaseState, locomotionState, new FuncPredicate(() => !detector.CanDetectPlayer()));


            stateMachine.SetState(locomotionState);
        }

        void At(IState from, IState to, IPredicate condition) => stateMachine.AddTransition(from, to, condition);
        void Any(IState to, IPredicate condition) => stateMachine.AddAnyTransition(to, condition);

        void Update()
        {
            stateMachine.Update();
        }

        void FixedUpdate()
        {
            stateMachine.FixedUpdate();
        }

        public void Attack()
        {
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
            // Vector3 directionToPlayer = detector.Player.position - transform.position;
            float speedPercent = agent.velocity.magnitude / agent.speed;

            if (agent.velocity.magnitude > 0f)
            {
                // HandleRotation(directionToPlayer);
                SmoothSpeed(speedPercent);
            } else
            {
                SmoothSpeed(0f);
            }
        }

        /*void HandleRotation(Vector3 direction)
        {
            direction.y = 0f;
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }*/

        void SmoothSpeed(float speedPercent)
        {
            anim.SetFloat("Speed",  speedPercent, 0.1f, Time.deltaTime);
        }
    }
}
