using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    [SerializeField] List<Target> targets = new List<Target>();

    void OnTriggerEnter(Collider other)
    {
        Target target = other.GetComponent<Target>();

        if (target != null)
        {
            targets.Add(target);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Target target = other.GetComponent<Target>();

        if (target != null)
        {
            targets.Remove(target);
        }
    }
}
