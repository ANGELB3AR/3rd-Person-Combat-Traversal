using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    readonly int locomotionBlendTreeHash = Animator.StringToHash("LocomotionBlendTree");
    readonly int speedHash = Animator.StringToHash("Speed");

    const float crossFadeDuration = 0.1f;
    const float animatorDampTime = 0.1f;

    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(locomotionBlendTreeHash, crossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        if (!IsInChaseRange())
        {
            stateMachine.SwitchState(new EnemyIdleState(stateMachine));
            return;
        }
        else if (IsInAttackRange())
        {
            stateMachine.SwitchState(new EnemyAttackingState(stateMachine));
            return;
        }

        MoveToPlayer(deltaTime);
        FacePlayer();

        stateMachine.Animator.SetFloat(speedHash, 1f, animatorDampTime, deltaTime);
    }

    public override void Exit()
    {
        stateMachine.Agent.ResetPath();
        stateMachine.Agent.velocity = Vector3.zero;
    }

    void MoveToPlayer(float deltaTime)
    {
        stateMachine.Agent.destination = stateMachine.Player.transform.position;

        Move(stateMachine.Agent.desiredVelocity.normalized * stateMachine.MovementSpeed, deltaTime);

        stateMachine.Agent.velocity = stateMachine.Controller.velocity;
    }

    bool IsInAttackRange()
    {
        float distanceToPlayer = Vector3.Distance(stateMachine.Player.transform.position, stateMachine.transform.position);
        return distanceToPlayer <= stateMachine.AttackRange;
    }
}
