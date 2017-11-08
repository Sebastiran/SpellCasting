using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    public ProjectileSpell spell;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != spell.caster)
        {
            CharacterStats stats = other.GetComponent<CharacterStats>();

            if (stats != null)
            {
                stats.TakeDamage(spell.damage);
            }

            Destroy(this.gameObject);
        }
    }
}
