using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

	// Use this for initialization
	void Start () {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEquipmentChanged(Equipment new_item, Equipment old_item)
    {
        if(new_item != null)
        {
            armor.AddModifier(new_item.armor_modifier);
            damage.AddModifier(new_item.damage_modifier);
        }
        if(old_item != null)
        {
            armor.RemoveModifier(old_item.armor_modifier);
            damage.RemoveModifier(old_item.damage_modifier);
        }
    }

    public override void Die()
    {
        base.Die();

        Destroy(gameObject);
    }
}
