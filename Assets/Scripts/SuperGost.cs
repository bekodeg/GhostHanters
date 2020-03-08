using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperGost : Bonus
{
    public override void Use(PlayerController pc)
    {
        pc.superGhost = true;
        base.Use(pc);
    }
}
