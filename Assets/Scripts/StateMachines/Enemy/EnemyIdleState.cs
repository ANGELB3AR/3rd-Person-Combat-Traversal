using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    readonly int locomotionBlendTreeHash = Animator.StringToHash("LocomotionBlendTree");
    readonly int speedHash = Animator.StringToHash("Speed");

    const float crossFadeDuration = 0.1f;
    const float animatorDampTime = 0.1f;

    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(locomotionBlendTreeHash, crossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        if (IsInChaseRange())
        {
            Debug.Log("In Range");
            // Transition to chasing state
            return;
        }
        
        stateMachine.Animator.SetFloat(speedHash, 0, animatorDampTime, deltaTime);
    }

    public override void Exit() { }
}