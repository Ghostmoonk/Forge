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
    [SerializeField] Animator animator;
    public SpriteRenderer buttonSprite;
    #endregion

    #region Sprites
    [SerializeField] Sprite ASprite;
    [SerializeField] Sprite BSprite;
    [SerializeField] Sprite XSprite;
    [SerializeField] Sprite YSprite;
    #endregion

    [HideInInspector] public SucceedableState succeedState;
    public InputType inputType;
    public Sprite sprite;

    [HideInInspector] public UnityEvent endEvent;

    public void AdaptButtonSprite()
    {
        switch (inputType)
        {
            case InputType.A:
                buttonSprite.sprite = ASprite;
                break;
            case InputType.B:
                buttonSprite.sprite = BSprite;
                break;
            case InputType.X:
                buttonSprite.sprite = XSprite;
                break;
            case InputType.Y:
                buttonSprite.sprite = YSprite;
                break;
            default:
                break;
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        succeedState = SucceedableState.INVISIBLE;
        endEvent = new UnityEvent();

        //transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform);
    }

    //Fonction qui lance l'animation du cercle
    public void PlayAnimation()
    {
        switch (succeedState)
        {
            case SucceedableState.PENDING:
                animator.SetTrigger("BecomeSecondInput");
                break;
            case SucceedableState.FAILABLE:
                animator.SetTrigger("BecomeCurrentInput");
                break;
            default:
                break;
        }
    }

    //Fonction qui vérifie si il est bon
    public bool CheckSucceed(InputType type)
    {

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
