using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasReg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance().canvas = transform;
    }
}
