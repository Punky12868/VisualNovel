using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetShitToThatOtherShit : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<DebugStuff>().skippingPanel = this.gameObject;
    }
}
