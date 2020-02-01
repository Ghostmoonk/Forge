using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : MonoBehaviour
{
    #region Components
    Animator animator;
    SpriteRenderer spriteRenderer;
    #endregion

    private void Update()
    {
        if (_MGR_GameManager.Instance.currentPatternItem != null)
        {
            if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent != null)
            {
                if (Input.GetButtonDown("A") || Input.GetButtonDown("B") || Input.GetButtonDown("X") || Input.GetButtonDown("Y"))
                {
                    if (_MGR_GameManager.Instance.currentPatternItem.inputEvents.Count == 0)
                    {
                        _MGR_GameManager.Instance.MoveConveyorBelt();
                    }
                    if (Input.GetButtonDown("A"))
                    {
                        //Si on a appuyé sur le bon bouton
                        if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.CheckSucceed(InputType.A))
                        {
                            //Appelle une fonction de succès du QTE chez le gameManager

                        }
                        //C'est raté
                        else
                        {
                            //Appelle une fonction de raté du QTE chez le gameManager

                        }
                    }
                    if (Input.GetButtonDown("B"))
                    {
                        if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType == InputType.B)
                        {

                        }
                        else
                        {

                        }
                    }
                    if (Input.GetButtonDown("X"))
                    {
                        if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType == InputType.X)
                        {

                        }
                        else
                        {

                        }
                    }
                    if (Input.GetButtonDown("Y"))
                    {
                        if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType == InputType.Y)
                        {

                        }
                        else
                        {

                        }
                    }
                    _MGR_GameManager.Instance.currentPatternItem.GoNextCurrentInputEvent();
                    //Destroy(_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.gameObject);
                }
            }
            else
            {
                Debug.Log("Pas encore de current input event actif");
            }
        }
        else
        {
            //Debug.Log("Pas de current input");
        }
    }
}
