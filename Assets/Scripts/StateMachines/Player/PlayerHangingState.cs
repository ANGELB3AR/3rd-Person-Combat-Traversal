using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHangingState : PlayerBaseState
{
    readonly int hangHash = Animator.StringToHash("Hang");

    const float crossFadeDuration = 0.1f;
    Vector3 ledgeForward;

    public PlayerHangingState(PlayerStateMachine stateMachine, Vector3 ledgeForward) : base(stateMachine) 
    {
        this.ledgeForward = ledgeForward;
    }

    public override void Enter()
    {
        stateMachine.transform.rotation = Quaternion.LookRotation(ledgeForward, Vector3.up);

        stateMachine.Animator.CrossFadeInFixedTime(hangHash, crossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.InputReader.MovementValue.y < 0f)
        {
            stateMachine.Controller.Move(Vector3.zero);
            stateMachine.ForceReceiver.Reset();
            stateMachine.SwitchState(new PlayerFallingState(stateMachine));
        }
    }

    public override void Exit() { }
}
