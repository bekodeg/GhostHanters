using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerZone : MonoBehaviour
{
    //public string txt; //{ get; private set; }
    [SerializeField] string useTxt;

    public virtual void Use()
    {
        if (useTxt != null)
            GameManager.Instance().hint.text = useTxt;
    }
}
