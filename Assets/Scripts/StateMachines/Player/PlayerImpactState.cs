using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpactState : PlayerBaseState
{
    readonly int impactHash = Animator.StringToHash("Impact");

    const float crossFadeDuration = 0.1f;
    float duration = 1f;

    public PlayerImpactState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(impactHash, crossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);
        
        duration -= deltaTime;

        if (duration <= 0)
        {
            ReturnToLocomotion();
        }
    }

    public override void Exit() { }
}
