using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Spells/Shapes/Projectile")]
public class Projectile : Shape
{
    public float speed = 10f;
    public float range = 10f;

    private GameObject spellPrefab;

    private void Awake()
    {
        spellPrefab = Resources.Load<GameObject>("SpellObjects/ProjectileObject");
    }

    public override void BeginCast(Spell spell)
    {
        Debug.Log("Casting Projectile: " + spell.name);

        Vector3 targetPos = spell.targetPosition;
        Transform castPosition = spell.caster.transform.Find("CastPosition");

        targetPos.y += castPosition.localPosition.y;
        Vector3 direction = (targetPos - castPosition.position).normalized;

        //Instantiate a copy of our spellPrefab
        GameObject spellClone = Instantiate(spellPrefab, castPosition.position, Quaternion.LookRotation(direction));
        spellClone.GetComponent<ProjectileObject>().spell = spell;
        spellClone.GetComponent<ProjectileObject>().projectile = this;
        spellClone.GetComponent<Rigidbody>().velocity = direction * speed;

        foreach (Component c in spell.components)
        {
            if(c.GetAssemblyParticles() != null)
                Instantiate(c.GetAssemblyParticles(), spellClone.transform);
        }
    }

    public override float GetManaModifier()
    {
        return 1f;
    }

    public override float GetEffectModifier()
    {
        return 1f;
    }
}
