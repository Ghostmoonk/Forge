using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : MonoBehaviour
{
    #region Components
    Animator animator;
    SpriteRenderer spriteRenderer;
    #endregion
    public void PlayASound()
    {
        Debug.Log("" + _MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType);
        _MGR_SoundDesign.Instance.PlaySound("" + _MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType, gameObject.GetComponent<AudioSource>());
    }
    private void Update()
    {
        if (_MGR_GameManager.Instance.currentPatternItem != null)
        {
            if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent != null)
            {
                if (Input.GetButtonDown("A") || Input.GetButtonDown("B") || Input.GetButtonDown("X") || Input.GetButtonDown("Y"))
                {
                    //Debug.Log("Il reste " + _MGR_GameManager.Instance.currentPatternItem.inputEvents.Count + "dans la queue");
                    gameObject.GetComponent<Animator>().SetTrigger("Forge");

                    if (Input.GetButtonDown("A"))
                    {
                        //Si on a appuyé sur le bon bouton
                        if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.CheckSucceed(InputType.A))
                        {
                            //Appelle une fonction de succès du QTE chez le gameManager
                            //_MGR_SoundDesign.Instance.PlaySound("A", gameObject.GetComponent<AudioSource>());

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
                            //_MGR_SoundDesign.Instance.PlaySound("B", gameObject.GetComponent<AudioSource>());
                        }
                        else
                        {

                        }
                    }
                    if (Input.GetButtonDown("X"))
                    {
                        if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType == InputType.X)
                        {
                            //_MGR_SoundDesign.Instance.PlaySound("X", gameObject.GetComponent<AudioSource>());
                        }
                        else
                        {

                        }
                    }
                    if (Input.GetButtonDown("Y"))
                    {
                        if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType == InputType.Y)
                        {
                            //_MGR_SoundDesign.Instance.PlaySound("Y", gameObject.GetComponent<AudioSource>());
                        }
                        else
                        {

                        }
                    }
                    if (_MGR_GameManager.Instance.currentPatternItem.inputEvents.Count == 0 && _MGR_GameManager.Instance.currentPatternItem.secondInputEvent == null)
                    {
                        if (!_MGR_GameManager.Instance.canMoveConveyorBelt)
                        {
                            Debug.Log("Je déplace le tapis");
                            _MGR_GameManager.Instance.MoveConveyorBelt();
                        }
                        _MGR_GameManager.Instance.currentPatternItem.RepairItem();
                    }
                    else
                    {
                        _MGR_GameManager.Instance.currentPatternItem.GoNextCurrentInputEvent();
                    }
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
