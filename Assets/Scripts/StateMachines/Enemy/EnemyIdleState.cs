using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    readonly int locomotionBlendTreeHash = Animator.StringToHash("LocomotionBlendTree");
    readonly int speedHash = Animator.StringToHash("Speed");

    const float crossFadeDuration = 0.1f;

    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFade(locomotionBlendTreeHash, crossFadeDuration);
        stateMachine.Animator.SetFloat(speedHash, 0);
    }

    public override void Tick(float deltaTime)
    {
        
    }

    public override void Exit() { }
}
