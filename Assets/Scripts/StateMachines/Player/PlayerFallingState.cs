using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerBaseState
{
    readonly int fallHash = Animator.StringToHash("Fall");

    const float crossFadeDuration = 0.1f;
    Vector3 momentum;

    public PlayerFallingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(fallHash, crossFadeDuration);

        momentum = stateMachine.Controller.velocity;
        momentum.y = 0f;
    }

    public override void Tick(float deltaTime)
    {
        Move(momentum, deltaTime);

        if (stateMachine.Controller.isGrounded)
        {
            ReturnToLocomotion();
        }

        FaceTarget();
    }

    public override void Exit() { }
}
