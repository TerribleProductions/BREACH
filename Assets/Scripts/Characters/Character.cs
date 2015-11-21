﻿    using UnityEngine;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour {

    public struct CharAbilities
    {
        public CharAbilities(Ability mainAbility, Ability secondaryAbility, Ability defensiveAbility)
        {
            this.mainAbility = mainAbility;
            this.secondaryAbility = secondaryAbility;
            this.defensiveAbility = defensiveAbility;
        }
        public Ability mainAbility;
        public Ability secondaryAbility;
        public Ability defensiveAbility;
    }
    #region resources
    public float hp { get; set; }
    public float maxHp { get; set; }
    public float energy { get; set; }
    public float energyRegeneration { get; set; }
    public float moveSpeed { get; set; }
    #endregion


    public int playerNumber { get; set; }
    public Vector3 movementVector { get; set; }
    public Rigidbody playerRigidbody { get; set; }

    public StateManager stateManager { get; private set; }
    public  BuffManager buffManager { get; set; }

    protected ControlInterface controller { get; set; }
    protected CharAbilities abilities { get; set; }


    
    protected virtual void Awake()
    {
        stateManager = new StateManager(this);
        buffManager = new BuffManager(this);
        stateManager.SetNeutralState();
        playerRigidbody = GetComponent<Rigidbody>();
        controller = new ControlInterface(playerNumber);
    }

    #region input
    protected void moveInput()
    {
        bool isMoving = HasState(CharacterState.States.MOVING);
        float h = controller.getMovementHorizontal();
        float v = controller.getMovementVertical();
        if((h != 0 || v != 0) && (SetState(new StateEffect(CharacterState.States.MOVING)) || isMoving))
        {
            // Set the movement vector based on the axis input.
            movementVector = new Vector3(h, 0f, v);

            // Normalise the movement vector and make it proportional to the speed per second.
            movementVector = movementVector.normalized * moveSpeed * Time.deltaTime;

            // Move the player to it's current position plus the movement.
            playerRigidbody.MovePosition(transform.position + movementVector);
        }
        else if((h == 0 && v == 0) && isMoving)
        {
            stateManager.SetNeutralState();
        }
    }

    protected void abilityInput()
    {

        if (controller.getFire())
        {
            SetState(abilities.mainAbility.stateChain);
        }
        if (controller.getFire2())
        {
            SetState(abilities.secondaryAbility.stateChain);

        }
        //TODO: Add code for other buttons here
    }
    #endregion

    #region Mutators

    public void DamageCharacter(float amount)
    {
        hp -= amount;
    }

    public void AddBuff(Buff buff)
    {
        buffManager.AddBuff(buff);
    }

    public bool SetState(StateEffect state)
    {
        return stateManager.SetState(state);
    }

    public bool HasState(CharacterState.States state)
    {
        return stateManager.HasState(state);
    }

    public void SapEnergy(float amount)
    {
        energy -= amount;
    }
    /// <summary>
    /// Regenerates energyRegeneration amount. Should be called every x tick?
    /// </summary>
    public void RegenEnergy()
    {
        energy += energyRegeneration;
    }

    public void MultiplyMovespeed(float amount)
    {
        moveSpeed *= amount;
    }

    #endregion

}
