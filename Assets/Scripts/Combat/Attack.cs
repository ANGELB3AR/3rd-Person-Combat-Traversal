using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attack
{
    [Tooltip("Name of attack animation")]
    [field: SerializeField] public string AnimationName { get; private set; }
    [Tooltip("How long Animator has to blend into animation")]
    [field: SerializeField] public float TransitionDuration { get; private set; }
    [Tooltip("Which attack is next in combo")]
    [field: SerializeField] public int ComboStateIndex { get; private set; } = -1;
    [Tooltip("How far into combo player must attack again for it to combo")]
    [field: SerializeField] public float ComboAttackTime { get; private set; }
    [field: SerializeField] public float ForceTime { get; private set; }
    [field: SerializeField] public float Force { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public float Knockback { get; private set; }
}