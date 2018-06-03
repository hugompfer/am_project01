﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player localPlayer;

    private void Start()
    {
        localPlayer = gameObject.GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            localPlayer.movement.jump();
            localPlayer.tracker.addAction(ActionType.JUMP);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            localPlayer.movement.sprinting = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            localPlayer.movement.sprinting = false;
        }


        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            localPlayer.movement.stop();
            localPlayer.tracker.addAction(ActionType.STOP);
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            localPlayer.movement.moveLeft();
            localPlayer.tracker.addAction(ActionType.MOVE_LEFT);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0.1f)
        {
            localPlayer.movement.moveRight();
            localPlayer.tracker.addAction(ActionType.MOVE_RIGHT);
        }

    }

}
