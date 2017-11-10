using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEObject : MonoBehaviour
{
    [HideInInspector] public AoE spell;

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.transform != spell.caster)
        {
            Collider[] objectsInRange = Physics.OverlapSphere(transform.position, spell.radius);

            foreach (Collider col in objectsInRange)
            {
                CharacterStats stats = col.gameObject.GetComponent<CharacterStats>();
                if (stats != null && col.transform != spell.caster)
                {
                    for (int i = 0; i < spell.components.Length; i++)
                    {
                        spell.components[i].ApplyComponentEffect(stats);
                    }
                }
            }
            Destroy(this.gameObject);
        }*/
    }
}