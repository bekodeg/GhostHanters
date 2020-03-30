using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : triggerZone
{
    public override void Use()
    {
        GameManager.Instance().EndGame(true);
    }
}
