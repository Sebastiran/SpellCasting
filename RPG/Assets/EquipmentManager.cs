using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Keep track of equipment. Has functions for adding and removing items .*/
public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of Iventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public Equipment[] defaultItems;
    public SkinnedMeshRenderer targetMesh;
    Equipment[] currentEquipment;           // Items we currently have equipped
    SkinnedMeshRenderer[] currentMeshes;    // Meshes of the items we currently have equipped

    // Callback for when an item is equipped/unequipped
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;    // Reference to our inventory

    private void Start()
    {
        inventory = Inventory.instance;

        // Initialize currentEquipment based on number of euipemnt slots
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];

        EquipDefaultItems();
    }

    public void Equip(Equipment newItem)
    {
        // Find out what slot the item fits in
        int slotIndex = (int)newItem.equipmentSlot;
        Equipment oldItem = Unequip(slotIndex);

        if (onEquipmentChanged != null)
            onEquipmentChanged.Invoke(newItem, oldItem);

        SetEquipmentBlendShaped(newItem, 100);

        // Insert the item into the slot
        currentEquipment[slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh, targetMesh.transform);

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;
    }

    public Equipment Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if (currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }

            Equipment oldItem = currentEquipment[slotIndex];
            SetEquipmentBlendShaped(oldItem, 0);
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
                onEquipmentChanged.Invoke(null, oldItem);

            return oldItem;
        }
        return null;
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
        EquipDefaultItems();
    }

    void SetEquipmentBlendShaped(Equipment item, int weight)
    {
        foreach (EquipmentMeshRegion blendShape in item.coveredMeshRegions)
        {
            targetMesh.SetBlendShapeWeight((int)blendShape,  weight);
        }
    }

    void EquipDefaultItems()
    {
        foreach (Equipment item in defaultItems)
        {
            Equip(item);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}
