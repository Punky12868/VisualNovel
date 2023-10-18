using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetButtonStateGameplayMenu : Button
{
    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);

        switch (state)
        {
            case SelectionState.Normal:
                //do something
                //GetComponent<TMPro.TMP_Text>().color = false;
                break;
            case SelectionState.Highlighted:
                // do something
                //GetComponent<ButtonSizeController>().highlighted = true;
                break;
                // repeat for other states
        }
    }
}
