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
                Debug.Log(_MGR_GameManager.Instance.currentPatternItem.currentInputEvent);
                if (Input.GetButtonDown("A"))
                {
                    Debug.Log("A pressed");
                    //Si on a appuyé sur le bon bouton
                    if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType == InputType.A)
                    {
                        //Appelle une fonction de succès du QTE chez le gameManager
                        Debug.Log("Call success function QTE");
                    }
                    //C'est raté
                    else
                    {
                        //Appelle une fonction de raté du QTE chez le gameManager
                    }
                }
                if (Input.GetButtonDown("B"))
                {
                    Debug.Log("B pressed");
                    if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType == InputType.B)
                    {

                    }
                    else
                    {

                    }
                }
                if (Input.GetButtonDown("X"))
                {
                    Debug.Log("X pressed");
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
            }
            else
            {
                Debug.Log("Pas encore de pattern actif");
            }
        }
        else
        {
            //Debug.Log("Pas de current input");
        }
    }

}
