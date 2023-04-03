/*
 * Gerard Lamoureux
 * DeadState
 * Assignment9
 * Handles the player dead state
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : PlayerState
{
    PlayerController playerController;

    public DeadState(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void EnterState()
    {
        playerController.spriteRenderer.color = Color.red;
        Debug.Log("Player is Dead. Very sad");
    }

    public void UpdateState()
    {
    }

    public void ExitState()
    {
    }
    
}
