using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theExchangerOfCoins : triggerZone
{
    public int attempts = 0;
    public override void Use(PlayerController pc)
    {
        if (GameManager.Instance().Money > 0)
        {
            attempts += 1;
            GameManager.Instance().Money -= 1;
        }
    }
}
