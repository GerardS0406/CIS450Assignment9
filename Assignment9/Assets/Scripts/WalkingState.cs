/*
 * Gerard Lamoureux
 * WalkingState
 * Assignment9
 * Handles the player walking state
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : PlayerState
{
    private PlayerController playerController;
    private float speed;

    public WalkingState(PlayerController playerController, float speed)
    {
        this.playerController = playerController;
        this.speed = speed;
    }

    public void EnterState()
    {
    }

    public void UpdateState()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(horizontalInput * speed, 0f, 0f);
        playerController.transform.position += movement * Time.deltaTime;

        if (horizontalInput == 0f)
        {
            playerController.SetState(playerController.idleState);
        }
    }

    public void ExitState()
    {
    }
}
