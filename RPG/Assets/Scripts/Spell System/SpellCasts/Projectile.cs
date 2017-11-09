using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public ProjectileSpell spell;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, startPos) > spell.range)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != spell.caster)
        {
            CharacterStats stats = other.GetComponent<CharacterStats>();

            if (stats != null)
            {
                for (int i = 0; i < spell.components.Length; i++)
                {
                    spell.components[i].ApplyComponentEffect(stats);
                }
            }

            Destroy(this.gameObject);
        }
    }
}
