using UnityEngine;

[CreateAssetMenu(fileName = "SelfSpell", menuName = "Spells/Shapes/SelfSpell")]
public class SelfSpell : Spell
{
    public override void CastSpell()
    {
        base.CastSpell();
        shooter.Fire(this);
    }
}
