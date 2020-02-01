using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum SucceedableState
{
    INVISIBLE,
    PENDING,
    FAILABLE,
    SUCCEEDABLE
}

public enum InputType
{
    A, B, X, Y, NONE
}

public class InputEvent : MonoBehaviour
{
    #region Components
    [SerializeField] Animator circleAnimator;
    public SpriteRenderer buttonSprite;
    #endregion

    [HideInInspector] public SucceedableState succeedState;
    public InputType inputType;

    [HideInInspector] public UnityEvent endEvent;

    void Start()
    {
        succeedState = SucceedableState.PENDING;
        endEvent = new UnityEvent();
    }

    //Fonction qui lance l'animation du cercle
    public void PlayCircleAnimation()
    {
        circleAnimator.SetTrigger("BecomeCurrentInput");
    }

    //Fonction qui vérifie si il est bon
    public bool CheckSucceed(InputType type)
    {
        //_MGR_GameManager.Instance

        endEvent.Invoke();
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
