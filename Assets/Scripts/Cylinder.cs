using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public bool IsRendered; //{ get; private set; }
    public bool HasWall;
    public void OnFound()
    {
        IsRendered = true;
    }

    public void OnLost()
    {
        IsRendered = false;
    }
}
