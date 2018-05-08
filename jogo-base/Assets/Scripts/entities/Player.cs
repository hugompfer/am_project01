using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Character character;
    private Vitals vitals;
    private Inventory inventory;
  
    public PlayerMovement movementScript;


    public Player()
    {
        inventory = new Inventory();
    }

    void Start()
    {
        movementScript = gameObject.GetComponentInParent<PlayerMovement>();
        character = new Scout();
        vitals = new Vitals(character.getLevel(Skill.Resistance));
    }

    void Update()
    {
        if (movementScript!=null && movementScript.sprinting)
            Debug.Log("Alterar stamina aqui");
        else
            vitals.restoreStamina();

        vitals.Update();
    }

    public void stun()
    {
        vitals.stun();
    }

}
