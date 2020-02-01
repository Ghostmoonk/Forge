using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum SucceedableState
{
    PENDING,
    FAILABLE,
    SUCCEEDABLE
}

public enum InputType
{
    A, B, X, Y
}

public class InputEvent : MonoBehaviour
{
    #region Components
    Animator circleAnimator;
    #endregion
    [HideInInspector] public SucceedableState succeedState;
    public InputType inputType;

    bool isActive;

    UnityEvent endEvent;


    void Start()
    {
        circleAnimator = transform.Find("Circle").GetComponent<Animator>();
        isActive = false;
        succeedState = SucceedableState.PENDING;
        gameObject.SetActive(false);
    }

    //Fonction qui lance l'animation du cercle
    public InputEvent SetCurrentInputEvent()
    {
        circleAnimator.SetTrigger("BecomeCurrentInput");
        return this;
    }

    //Fonction qui vérifie si il est bon
    public bool CheckSucceed(InputType type)
    {
        //_MGR_GameManager.Instance
        if (succeedState == SucceedableState.SUCCEEDABLE && inputType == type)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
