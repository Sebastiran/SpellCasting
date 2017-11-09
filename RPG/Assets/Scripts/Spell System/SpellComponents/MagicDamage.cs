using UnityEngine;

[CreateAssetMenu(fileName = "MagicDamage", menuName = "Spells/Components/MagicDamage")]
public class MagicDamage : Component
{
    public override void ApplyComponentEffect(CharacterStats stats)
    {
        base.ApplyComponentEffect(stats);
        stats.TakeMagicDamage(5);
    }
}
