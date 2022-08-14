using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    [SerializeField] CinemachineTargetGroup targetGroup;

    List<Target> targets = new List<Target>();

    public Target CurrentTarget { get; private set; }

    void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<Target>(out Target target)) { return; }

        targets.Add(target);
        target.OnDestroyed += RemoveTarget;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<Target>(out Target target)) { return; }

        RemoveTarget(target);
    }

    void RemoveTarget(Target target)
    {
        if (CurrentTarget == target)
        {
            targetGroup.RemoveMember(CurrentTarget.transform);
            CurrentTarget = null;
        }

        target.OnDestroyed -= RemoveTarget;
        targets.Remove(target);
    }

    public bool SelectTarget()
    {
        if (targets.Count == 0) { return false; }

        CurrentTarget = targets[0];
        targetGroup.AddMember(CurrentTarget.transform, 1, 2);
        return true;
    }

    public void Cancel()
    {
        if (CurrentTarget == null) { return; }

        targetGroup.RemoveMember(CurrentTarget.transform);
        CurrentTarget = null;
    }
}
