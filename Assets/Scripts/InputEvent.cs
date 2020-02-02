using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum SucceedableState
{
    INVISIBLE,
    PENDING,
    FAILABLE,
    SUCCEEDABLE,
    FAILED
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

    [HideInInspector] public SucceedableState succeedableState;
    public InputType inputType;
    public Sprite sprite;

    [Range(0, 2)]

    [HideInInspector] public bool succeed;

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
        succeedableState = SucceedableState.INVISIBLE;
        succeed = false;

        //transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform);
    }

    //Fonction qui lance l'animation du cercle
    public void PlayAnimation()
    {
        switch (succeedableState)
        {
            case SucceedableState.PENDING:
                animator.SetTrigger("BecomeSecondInput");
                break;
            case SucceedableState.FAILABLE:
                animator.SetTrigger("BecomeCurrentInput");
                break;
            case SucceedableState.FAILED:
                animator.SetTrigger("BecomeFailed");
                break;
            default:
                break;
        }
    }

    //Fonction qui vérifie si il est bon
    public bool CheckSucceed(InputType type)
    {
        //Debug.Log("Le type envoyé est :" + type + " alors que le type du qte est :" + inputType);
        if (succeedableState == SucceedableState.SUCCEEDABLE && inputType == type)
        {
            succeed = true;
            return true;
        }
        else
        {
            return false;
        }
    }

}
