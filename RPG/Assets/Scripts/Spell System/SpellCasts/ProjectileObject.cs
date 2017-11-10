using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileObject : MonoBehaviour
{
    [HideInInspector] public Spell spell;
    [HideInInspector] public Projectile projectile;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, startPos) > projectile.range)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != spell.caster.transform)
        {
            Debug.Log("Other: " + other.transform.name);
            Debug.Log("Caster: " + spell.caster.transform.name);
            CharacterStats stats = other.GetComponent<CharacterStats>();
            if (stats != null)
            {
                SpellHelper.instance.ApplySpellToEntity(stats, spell);
                SpellHelper.instance.SpellHitEntity(stats, spell);
            }
            else
            {
                SpellHelper.instance.SpellHitGround(transform.position, spell);
            }

            Destroy(this.gameObject);
        }
    }
}