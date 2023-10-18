using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetButtonStateSize : Button
{
    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);

        switch (state)
        {
            case SelectionState.Normal:
                //do something
                GetComponent<ButtonSizeController>().highlighted = false;
                break;
            case SelectionState.Highlighted:
                // do something
                GetComponent<ButtonSizeController>().highlighted = true;
                break;
                // repeat for other states
        }
    }
}
