using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Spells/Components/Heal")]
public class Heal : Component
{
    public override void ApplyComponentEffect(CharacterStats stats)
    {
        base.ApplyComponentEffect(stats);
        stats.Heal(10);
    }
}