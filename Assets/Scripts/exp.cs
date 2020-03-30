using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exp : Bonus
{
    public override void Use(PlayerController pc)
    {
        GameManager.Instance().skore++;
        base.Use(pc);
    }
}
