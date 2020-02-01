using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SucceedableState
{
    PENDING,
    FAILABLE,
    SUCCEEDABLE
}

public class InputEvent : MonoBehaviour
{
    #region Components
    Animator circleAnimator;
    #endregion
    [HideInInspector] public SucceedableState succeedState;

    bool isActive;


    void Start()
    {
        circleAnimator = transform.Find("Circle").GetComponent<Animator>();
        isActive = false;
        succeedState = SucceedableState.PENDING;
        gameObject.SetActive(false);
    }

    //Fonction qui lance l'animation du cercle
    public void PlayCircleAnimation()
    {
        circleAnimator.SetTrigger("BecomeCurrentInput");
    }
    //Fonction qui vérifie si il est bon
    public bool CheckSucceed()
    {
        return true;
    }

}
