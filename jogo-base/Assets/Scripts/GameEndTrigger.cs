﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndTrigger : MonoBehaviour {

    private EndGameMenu endMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody2D>().angularVelocity = 0f;

            endMenu = GetComponent<EndGameMenu>();

            endMenu.show(Result.DEFEAT,GameManager.instance.sessionManager.getCurrentSession().elapsedTime);

            //end screen e isso
        }
    }

}
