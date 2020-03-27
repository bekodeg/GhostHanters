using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theExchangerOfCoins : triggerZone
{
    public int attempts = 0;
    private void Start()
    {
        BoxCollider2D collider = transform.GetComponent<BoxCollider2D>();
        for (int i= 1; i < transform.childCount; i++)
        {
            BoxCollider2D box = gameObject.AddComponent<BoxCollider2D>();
            box.size = collider.size;
            box.offset = transform.GetChild(i).position;
        }
    }
    public override void Use(PlayerController pc)
    {
        if (GameManager.Instance().Money > 0)
        {
            attempts += 1;
            GameManager.Instance().Money -= 1;
        }
    }
}
