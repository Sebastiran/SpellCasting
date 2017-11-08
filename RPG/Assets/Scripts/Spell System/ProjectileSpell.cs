using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSpell", menuName = "Spells/ProjectileSpell")]
public class ProjectileSpell : Spell
{
    public float speed = 10f;
    public int damage = 10;
    public GameObject projectilePrefab;

    private ProjectileSpellShooter pjShoot;

    public override void Initialize(GameObject caster)
    {
        this.caster = caster.transform;

        pjShoot = caster.GetComponent<ProjectileSpellShooter>();
        pjShoot.speed = speed;
        pjShoot.projectilePrefab = projectilePrefab;
    }

    public override void CastSpell()
    {
        pjShoot.Fire();
    }
}
