using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] Collider myCollider;

    List<Collider> collidedWith = new List<Collider>();
    int damage;

    void OnEnable()
    {
        collidedWith.Clear();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) { return; }

        if (collidedWith.Contains(other)) { return; }

        collidedWith.Add(other);

        if (other.TryGetComponent<Health>(out Health health))
        {
            health.DealDamage(damage);
        }
    }

    public void SetAttack(int damage)
    {
        this.damage = damage;
    }
}
