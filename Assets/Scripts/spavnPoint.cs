using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spavnPoint : triggerZone
{
    [SerializeField] bool firstSpavn = false;
    // Start is called before the first frame update
    void Start()
    {
        if (firstSpavn)
            GameManager.Instance().firstSpavn(transform);
    }
    public override void Use(PlayerController pc)
    { 
        GameManager.Instance().newSpavn(transform);
        base.Use(pc);
    }
}
