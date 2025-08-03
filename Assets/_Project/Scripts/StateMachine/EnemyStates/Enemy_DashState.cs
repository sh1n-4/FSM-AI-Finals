using UnityEngine;

namespace Platformer
{
    public class Enemy_DashState : Enemy_BaseState
    {
       public Enemy_DashState(EnemyController enemy, Animator anim) : base(enemy, anim) { }

       public override void OnEnter()
       {
            anim.CrossFade(Enemy_DashHash, crossFadeDuration);
       }

       public override void FixedUpdate()
       {
            enemy.HandleMovement();
       }
    }
}
