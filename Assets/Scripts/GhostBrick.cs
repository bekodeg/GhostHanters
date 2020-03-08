using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBrick : Bonus
{
    public void use(PlayerController pc)
    {
        if (pc.superGhost == true)
            gameObject.GetComponent<Collider2D>().isTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<Collider2D>().isTrigger = false;
    }
}
