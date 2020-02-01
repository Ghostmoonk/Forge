using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEventActions : MonoBehaviour
{
    InputEvent inputEvent;

    private void Start()
    {
        inputEvent = GetComponent<InputEvent>();
    }
    public void ChangeSucceedableState(SucceedableState state)
    {
        inputEvent.succeedState = state;
    }

    public void EndCircleAnim()
    {
        inputEvent.succeedState = SucceedableState.FAILABLE;
        inputEvent.CheckSucceed(InputType.NONE);

        //Il n'y a plus de QTE dans le pattern, on change d'item
        if (_MGR_GameManager.Instance.currentPatternItem.inputEvents.Count == 0 && _MGR_GameManager.Instance.currentPatternItem.secondInputEvent == null)
        {
            _MGR_GameManager.Instance.MoveConveyorBelt();
        }
        else
        {
            _MGR_GameManager.Instance.currentPatternItem.GoNextCurrentInputEvent();
        }
        //Destroy(_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.gameObject);
    }
}
