/*
 * Gerard Lamoureux
 * PlayerState
 * Assignment9
 * Handles the interface for player states
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerState
{
    void EnterState();
    void UpdateState();
    void ExitState();
}
