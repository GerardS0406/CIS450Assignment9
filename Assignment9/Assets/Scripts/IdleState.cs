/*
 * Gerard Lamoureux
 * IdleState
 * Assignment9
 * Handles the player idle state
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    private PlayerController playerController;

    public IdleState(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void EnterState()
    {
        Debug.Log("Entering idle state");
    }

    public void UpdateState()
    {
    }

    public void ExitState()
    {
        Debug.Log("Exiting idle state");
    }
}
