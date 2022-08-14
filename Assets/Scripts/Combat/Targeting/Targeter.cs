using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    [SerializeField] List<Target> targets = new List<Target>();

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Target>() != null)
        {
            targets.Add(other.GetComponent<Target>());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Target>() != null)
        {
            targets.Remove(other.GetComponent<Target>());
        }
    }
}
