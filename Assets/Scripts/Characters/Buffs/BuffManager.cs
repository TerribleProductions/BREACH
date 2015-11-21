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
        buffs.Add(buff);
        buff.Apply(self);
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
