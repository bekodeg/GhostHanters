using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Bonus
{
    [SerializeField] [Range(1, 50)] int suum = 1;
    public override void Use()
    {
        GameManager.Instance().Money += suum;
        base.Use();
    }
}