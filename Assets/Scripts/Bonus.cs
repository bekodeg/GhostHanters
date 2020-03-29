using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] string txt;
    public virtual void Use()
    {
        GameManager.Instance().hint.text = txt;
        Destroy(gameObject);
    }
}

