using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerZone : MonoBehaviour
{
    public string txt; //{ get; private set; }

    public virtual void Use(PlayerController pc)
    {
        GameManager.Instance().hint.text = txt;
    }
}
