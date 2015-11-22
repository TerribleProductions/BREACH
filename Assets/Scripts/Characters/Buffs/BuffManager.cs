using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BuffManager {

    public List<Buff> buffs {get; private set; }
    private Character self;

    public BuffManager(Character self)
    {
        buffs = new List<Buff>();
        Debug.Log(buffs);
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


        foreach(Buff buff in buffs)
        {
            buff.duration -= deltaTime;
        }

        //The new list list is there because casting will throw an exception, and "as" defaults to null, while this defaults to the empty list.
        var finishedBuffs = new List<Buff>(buffs.Where(buff =>
        {
            return buff.duration < 0;
        }));

        foreach(var finishedBuff in finishedBuffs)
        {
            finishedBuff.Unapply(self);
        }
        

        buffs = new List<Buff>(buffs.Except(finishedBuffs));
    }

}
