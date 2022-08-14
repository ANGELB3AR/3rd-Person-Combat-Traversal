using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    List<Target> targets = new List<Target>();

    public Target CurrentTarget { get; private set; }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Target>(out Target target))
        {
            targets.Add(target);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Target>(out Target target))
        {
            targets.Remove(target);
        }
    }

    public bool SelectTarget()
    {
        if (targets.Count == 0) { return false; }

        CurrentTarget = targets[0];
        return true;
    }

    public void Cancel()
    {
        CurrentTarget = null;
    }
}
