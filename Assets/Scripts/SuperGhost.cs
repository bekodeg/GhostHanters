using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperGhost : Bonus
{
    public override void Use()
    {
        GameManager.Instance().player.superGhost = true;
        base.Use();
    }
}
