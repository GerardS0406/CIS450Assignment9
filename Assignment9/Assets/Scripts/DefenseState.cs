/*
 * Gerard Lamoureux
 * DefenseState
 * Assignment9
 * Handles the defense/shielded walking state
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseState : PlayerState
{
    private PlayerController playerController;
    private int shieldAmount;

    public DefenseState(PlayerController playerController, int shieldAmount)
    {
        this.playerController = playerController;
        this.shieldAmount = shieldAmount;
    }

    public void EnterState()
    {
        playerController.shield = shieldAmount;
        playerController.shieldObject.SetActive(true);
    }

    public void UpdateState()
    {
        if (!Input.GetMouseButton(1))
            playerController.SetState(playerController.idleState);
    }

    public void ExitState()
    {
        playerController.shield = 0;
        playerController.shieldObject.SetActive(false);
    }
}
