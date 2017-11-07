﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Handles interaction with the Enemy */
[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats myStats;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }

    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if (playerManager != null)
        {
            playerCombat.Attack(myStats);
        }
    }
}
