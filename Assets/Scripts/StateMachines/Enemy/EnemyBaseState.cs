using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine stateMachine;
    
    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected bool IsInChaseRange()
    {
        //float playerDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;
        //return playerDistanceSqr <= stateMachine.PlayerChaseRange * stateMachine.PlayerChaseRange;

        if (stateMachine.Player.isDead) { return false; }

        float distanceToPlayer = Vector3.Distance(stateMachine.Player.transform.position, stateMachine.transform.position);
        return distanceToPlayer <= stateMachine.PlayerChaseRange;
    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.movement) * deltaTime);
    }

    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }

    protected void FacePlayer()
    {
        if (stateMachine.Player == null) { return; }

        Vector3 lookDirection = stateMachine.Player.transform.position - stateMachine.transform.position;
        lookDirection.y = 0f;

        stateMachine.transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}
