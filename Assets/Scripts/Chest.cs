using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Bonus
{
    public override void Use(PlayerController pc)
    {
        GameManager.Instance().EndGame(true);
    }
}
