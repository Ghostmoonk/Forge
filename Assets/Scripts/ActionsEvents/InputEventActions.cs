using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEventActions : MonoBehaviour
{
    InputEvent inputEvent;

    private void Start()
    {
        inputEvent = transform.parent.GetComponent<InputEvent>();
    }
    public void ChangeSucceedableState(SucceedableState state)
    {
        inputEvent.succeedState = state;
    }

    public void EndCircleAnim()
    {
        inputEvent.succeedState = SucceedableState.FAILABLE;
        //Apelle fail chez game
    }
}
