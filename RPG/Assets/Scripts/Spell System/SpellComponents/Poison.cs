using UnityEngine;

[CreateAssetMenu(fileName = "Poison", menuName = "Spells/Components/Poison")]
public class Poison : Component
{
    public override void ApplyComponentEffect(CharacterStats stats)
    {
        base.ApplyComponentEffect(stats);
        stats.Poison(2, 4f);
    }
}