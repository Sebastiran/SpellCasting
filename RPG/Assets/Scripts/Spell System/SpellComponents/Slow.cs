using UnityEngine;

[CreateAssetMenu(fileName = "Slow", menuName = "Spells/Components/Slow")]
public class Slow : Component
{
    public override void ApplyComponentEffect(CharacterStats stats)
    {
        base.ApplyComponentEffect(stats);
        stats.Slow(.7f, 4f);
    }
}