using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgingState : PlayerBaseState
{
    readonly int dodgeBlendTreeHash = Animator.StringToHash("DodgeBlendTree");
    readonly int dodgeForwardHash = Animator.StringToHash("DodgeForward");
    readonly int dodgeRightHash = Animator.StringToHash("DodgeRight");

    Vector3 dodgingDirectionInput;
    float remainingDodgeTime;
    const float crossFadeDuration = 0.1f;

    public PlayerDodgingState(PlayerStateMachine stateMachine, Vector3 dodgingDirectionInput) : base(stateMachine) 
    {
        this.dodgingDirectionInput = dodgingDirectionInput;
    }

    public override void Enter()
    {
        remainingDodgeTime = stateMachine.DodgeDuration;

        stateMachine.Animator.SetFloat(dodgeForwardHash, dodgingDirectionInput.y);
        stateMachine.Animator.SetFloat(dodgeRightHash, dodgingDirectionInput.x);
        stateMachine.Animator.CrossFadeInFixedTime(dodgeBlendTreeHash, crossFadeDuration);

        stateMachine.Health.SetInvulnerable(true);
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();

        movement += stateMachine.transform.right * dodgingDirectionInput.x * stateMachine.DodgeDistance / stateMachine.DodgeDuration;
        movement += stateMachine.transform.forward * dodgingDirectionInput.y * stateMachine.DodgeDistance / stateMachine.DodgeDuration;

        Move(movement, deltaTime);

        FaceTarget();

        remainingDodgeTime -= deltaTime;

        if (remainingDodgeTime <= 0f)
        {
            stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
        }
    }

    public override void Exit() 
    {
        stateMachine.Health.SetInvulnerable(false);
    }
}
