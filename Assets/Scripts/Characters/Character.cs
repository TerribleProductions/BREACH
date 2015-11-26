﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour {

    public struct CharAbilities
    {
        public CharAbilities(Ability mainAbility, Ability secondaryAbility, Ability defensiveAbility, Ability movementAbility)
        {
            this.mainAbility = mainAbility;
            this.secondaryAbility = secondaryAbility;
            this.defensiveAbility = defensiveAbility;
            this.movementAbility = movementAbility;
        }
        public Ability mainAbility;
        public Ability secondaryAbility;
        public Ability defensiveAbility;
        public Ability movementAbility;
    }
    #region resources
    public float hp;
    public float maxHp { get; set; }
    public float energy
    {
        get; set;
    }
    public float energyRegeneration { get; set; }
    public float maxEnergy { get; set; }
    public float moveSpeed
    {
        get; set;
    }

    public float moveSpeedMultiplier { get; set; }
    #endregion

	public Slider healthSlider;
	public Slider energySlider;

    public float regenTick = 0.5f;
    public float regenTimer;

    StateEffect moveState = new StateEffect(CharacterState.MOVING, Mathf.Infinity);

    public int playerNumber;
    public Vector3 movementVector { get; set; }
    public Rigidbody playerRigidbody { get; set; }

    public StateManager stateManager { get; private set; }
    public  BuffManager buffManager { get; set; }

    protected ControlInterface controllerInterface { get; set; }
    protected CharAbilities abilities { get; set; }


    
    protected virtual void Awake()
    {
        stateManager = new StateManager(this);
        buffManager = new BuffManager(this);
        stateManager.SetNeutralState();
        playerRigidbody = GetComponent<Rigidbody>();
        controllerInterface = new ControlInterface(playerNumber);

        moveSpeedMultiplier = 1f;

        regenTimer = regenTick;
    }

    #region input
    protected void moveInput()
    {
        bool isMoving = HasState(CharacterState.MOVING);
        float h = controllerInterface.getMovementHorizontal();
        float v = controllerInterface.getMovementVertical();
        if((h != 0 || v != 0) && (CanSetState(moveState) || isMoving || HasState(CharacterState.CHANNELING)))
        {
            if (!HasState(CharacterState.MOVING))
            {
                SetState(moveState);
            }
            // Set the movement vector based on the axis input.
            movementVector = new Vector3(h, 0f, v);

            // Normalise the movement vector and make it proportional to the speed per second.
            movementVector = movementVector.normalized * moveSpeed  * moveSpeedMultiplier * Time.deltaTime;

            // Move the player to it's current position plus the movement.
            playerRigidbody.MovePosition(transform.position + movementVector);
        }
        else if((h == 0 && v == 0) && isMoving)
        {
            stateManager.SetNeutralState();
        }
    }

    protected void Turn()
    {
        float h = controllerInterface.getLookHorizontal();
        float v = controllerInterface.getLookVertical();
            
        Vector3 newDirection = Vector3.Normalize(new Vector3(h, 0.0f, v));

        if (!controllerInterface.equalsZero(newDirection))
        {
            transform.forward = newDirection;
        }
    }

    bool isUp = false;
    bool secIsUp = false;

    protected void abilityInput()
    {
        
        if (controllerInterface.getFire())
        {
            isUp = false;
            abilities.mainAbility.CastIfPossible();

        }
        Debug.Log(controllerInterface.getFire() );
        if (!controllerInterface.getFire() && !isUp)
        {
            abilities.mainAbility.TriggerUp();
            isUp = true;
        }
        if (controllerInterface.getFireSecondaryUp() && !secIsUp)
        {
            secIsUp = true;
            abilities.secondaryAbility.TriggerUp();
        }
        if (controllerInterface.getFireSecondary())
        {
            abilities.secondaryAbility.CastIfPossible();
            secIsUp = false;
        }
        if (controllerInterface.getAbility())
        {
            
            abilities.defensiveAbility.CastIfPossible();
        }
        if (controllerInterface.getAbilitySecondary())
        {
            abilities.movementAbility.CastIfPossible();
        }
        //TODO: Add code for other buttons here
    }
    #endregion

    #region Mutators

    public void ClearAllDebuffs()
    {
        buffManager.RemoveDebuffs();
    }

    public void DamageCharacter(float amount)
    {
        hp -= amount;
    }

    public void AddBuff(Buff buff)
    {
        buffManager.AddBuff(buff);
    }

    public void RemoveBuff(Buff buff)
    {
        buffManager.RemoveBuff(buff);
    }

    public bool SetState(StateEffect state)
    {
        return stateManager.SetState(state);
    }



    public bool SapEnergy(float amount)
    {
        float newEnergy = energy - amount;
        if(newEnergy >= 0)
        {
            energy = newEnergy;
			energySlider.value = energy;
            return true;
        }
        return false;
    }
    /// <summary>
    /// Regenerates energyRegeneration amount. Should be called every x tick?
    /// </summary>
    public void RegenEnergy()
    {
        if(energy >= maxEnergy)
        {
            energy = maxEnergy;
            return;
        }
        if(regenTimer <= 0)
        {
            if (energy > maxEnergy)
            {
                energy = maxEnergy;
            }
            energy += energyRegeneration;
            
            regenTimer = regenTick;
        }
        regenTimer -= Time.deltaTime;

		energySlider.value = energy;
    }

    public void MultiplyMovespeed(float amount)
    {
        moveSpeedMultiplier *= amount;
    }

    #endregion

    #region getters
    public bool HasState(State state)
    {
        return stateManager.HasState(state);
    }

    public bool HasBuff(Buff buff)
    {
        return buffManager.HasBuff(buff);
    }

    public bool CanSetState(StateEffect state)
    {
        return stateManager.CanSetState(state);
    }

    public bool CanSapEnergy(float amount)
    {
        return amount <= energy;
    }
    #endregion

}
