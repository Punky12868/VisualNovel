using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCatPanel : MonoBehaviour
{
    public GameObject catPanel;
    private void Awake()
    {
        FindObjectOfType<CommandBehaviours>().desitionPanel = catPanel;
    }
}
