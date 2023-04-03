/*
 * Gerard Lamoureux
 * DefenseAndWalkingState
 * Assignment9
 * Handles the player defense/shielded and walking state
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseAndWalkingState : PlayerState
{
    private PlayerController playerController;
    private WalkingState walkingState;
    private DefenseState defenseState;

    public DefenseAndWalkingState(PlayerController playerController, float walkingSpeed, int shieldAmount)
    {
        this.playerController = playerController;
        walkingState = new WalkingState(playerController, walkingSpeed);
        defenseState = new DefenseState(playerController, shieldAmount);
    }

    public void EnterState()
    {
        walkingState.EnterState();
        defenseState.EnterState();
    }

    public void UpdateState()
    {
        walkingState.UpdateState();
        defenseState.UpdateState();
    }

    public void ExitState()
    {
        walkingState.ExitState();
        defenseState.ExitState();
    }
}
