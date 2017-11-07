using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipmentSlot; // Slot to store equipmnent in
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;

    public int armorModifier;           // Increase/decrease in armor
    public int damageModifer;           // Increase/decrease in damage

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);  // Equip it
        RemoveFromInventory();                  // Remove it from inventory
    }
}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Feet, Offhand }
public enum EquipmentMeshRegion { Legs, Arms, Torso }; // Corresonds to body blendshapes.