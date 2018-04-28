using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable {

    private PlayerManager player_manager;
    private CharacterStats my_stats;

    private void Start()
    {
        player_manager = PlayerManager.instance;
        my_stats = GetComponent<CharacterStats>();
    }

    public override void Interact()
    {
        base.Interact();
        CharacterCombat player_combat = player_manager.player.GetComponent<CharacterCombat>();
        if(player_combat != null)
        {
            player_combat.Attack(my_stats);
        }
    }

}
