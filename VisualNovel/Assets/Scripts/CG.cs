using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG : MonoBehaviour
{
    public bool[] CGs;
    public void unlockCG(int i)
    {
        CGs[i] = true;
    }
}
