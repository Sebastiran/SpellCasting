using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSpell", menuName = "Spells/Shapes/ProjectileSpell")]
public class ProjectileSpell : Spell
{
    public float speed = 10f;
    public float range = 10f;
    public GameObject spellPrefab;
    
    public override void CastSpell()
    {
        base.CastSpell();
        shooter.Fire(this);
    }
}
