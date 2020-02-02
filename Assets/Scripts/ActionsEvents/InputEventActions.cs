﻿using System.Collections;
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
        Debug.Log("Le state actuel du current truc devient : " + state);
        inputEvent.succeedableState = state;
    }

    public void EndCircleAnim()
    {
        if (!inputEvent.succeed)
        {
            inputEvent.succeedableState = SucceedableState.FAILABLE;
            inputEvent.CheckSucceed(InputType.NONE);

            //Il n'y a plus de QTE dans le pattern, on change d'item
            if (inputEvent == _MGR_GameManager.Instance.currentPatternItem.currentInputEvent)
            {
                if (_MGR_GameManager.Instance.currentPatternItem.inputEvents.Count == 0 && _MGR_GameManager.Instance.currentPatternItem.secondInputEvent == null)
                {
                    _MGR_GameManager.Instance.currentPatternItem.RepairItem();
                    _MGR_GameManager.Instance.MoveConveyorBelt();
                }
                else
                {
                    _MGR_GameManager.Instance.currentPatternItem.GoNextCurrentInputEvent();
                }
            }
        }
        Destroy(inputEvent.gameObject);
    }
}
