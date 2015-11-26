using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class BuffManager {

    public List<Buff> buffs {get; private set; }
    private Character self;

    public BuffManager(Character self)
    {
        buffs = new List<Buff>();
        this.self = self;
    }

    public void AddBuff(Buff buff)
    {
        
        if (buffs.Contains(buff))
        {
            if (buff.stackable)
            {
                buff.Apply(self); //Apply the effect of the buff again since it stacks;
            }
            else
            { 
                buffs.Remove(buff); //refresh duration of buff
            }
        }
        else
        {
            buff.Apply(self);
        }

        buffs.Add(buff);

    }

    //Update buffs per frame
    public void Update(float deltaTime)
    {
        if (buffs.Count == 0)
        {
            return;
        }

        for(int i = 0; i < buffs.Count; i++)
        {
            Debug.Log(i + " " + buffs[i].duration);
        }


        foreach(Buff buff in buffs)
        {
            buff.duration -= deltaTime;
        }

        var finishedBuffs = buffs.Where(buff =>
        {
            return buff.duration <= 0;
        });


        foreach(Buff finishedBuff in finishedBuffs)
        {
            finishedBuff.Unapply(self);
        }
        

        buffs = new List<Buff>(buffs.Except(finishedBuffs));
    }

    public bool RemoveBuff(Buff buff)
    {
        var removed = buffs.Remove(buff);
        if (removed)
        {
            buff.Unapply(self);
        }
        return removed;
    }

    public void RemoveDebuffs()
    {
        var debuffs = buffs.Where(buff =>
        {
            return buff.debuff;
        });
        foreach(Buff debuff in debuffs)
        {
            debuff.Unapply(self);
        }
        buffs = new List<Buff>(buffs.Except(debuffs));
    }

    public bool HasBuff(Buff buff)
    {
        return buffs.Contains(buff);
    }

}
