using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public delegate void OnEquipmentChanged(Equipment new_item, Equipment old_item);
    public OnEquipmentChanged onEquipmentChanged;
    [SerializeField]
    private Equipment[] current_equipment;
    private Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;
        int num_slots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        current_equipment = new Equipment[num_slots];
    }

    public void Equip(Equipment new_item)
    {
        int slot_index = (int)new_item.equip_slot;
        Equipment old_item = null;

        if(current_equipment[slot_index] != null)
        {
            old_item = current_equipment[slot_index];
            inventory.Add(old_item);
        }

        if (onEquipmentChanged != null)
            onEquipmentChanged.Invoke(new_item, old_item);

        current_equipment[slot_index] = new_item;
    }

    public void Unequip(int slot_index)
    {
        if(current_equipment[slot_index] != null)
        {
            Equipment old_item = current_equipment[slot_index];
            inventory.Add(old_item);

            current_equipment[slot_index] = null;

            if (onEquipmentChanged != null)
                onEquipmentChanged.Invoke(null, old_item);
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < current_equipment.Length; i++)
        {
            Unequip(i);
        }
    }
}
