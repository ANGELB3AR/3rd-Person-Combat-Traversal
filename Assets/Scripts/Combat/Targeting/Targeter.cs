using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    [SerializeField] List<Target> targets = new List<Target>();

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
}
