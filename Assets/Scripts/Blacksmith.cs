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
        Debug.Log("DEbug avant" + GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakin>().shakeDuration);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakin>().shakeDuration = 1f;
        Debug.Log("Debug après" + GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakin>().shakeDuration);
        //_MGR_SoundDesign.Instance.PlaySound("" + _MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType, gameObject.GetComponent<AudioSource>());
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
                            Debug.Log("REUSSI A");
                            Debug.Log(_MGR_GameManager.Instance.currentPatternItem.succeedCount);
                            _MGR_GameManager.Instance.currentPatternItem.succeedCount++;
                        }
                        //C'est raté
                        else
                        {
                            //_MGR_SoundDesign.Instance.PlaySound("" + _MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType + "_fail", gameObject.GetComponent<AudioSource>());

                        }
                    }
                    if (Input.GetButtonDown("B"))
                    {
                        if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType == InputType.B)
                        {
                            //_MGR_SoundDesign.Instance.PlaySound("B", gameObject.GetComponent<AudioSource>());
                            Debug.Log("REUSSI B");
                            _MGR_GameManager.Instance.currentPatternItem.succeedCount++;
                        }
                        else
                        {

                        }
                    }
                    if (Input.GetButtonDown("X"))
                    {
                        if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType == InputType.X)
                        {
                            Debug.Log("REUSSI X");
                            //_MGR_SoundDesign.Instance.PlaySound("X", gameObject.GetComponent<AudioSource>());
                            //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakin>().shakeDuration = 0.5f;
                            _MGR_GameManager.Instance.currentPatternItem.succeedCount++;
                        }
                        else
                        {

                        }
                    }
                    if (Input.GetButtonDown("Y"))
                    {
                        if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType == InputType.Y)
                        {
                            Debug.Log("REUSSI Y");
                            //_MGR_SoundDesign.Instance.PlaySound("Y", gameObject.GetComponent<AudioSource>());
                            _MGR_GameManager.Instance.currentPatternItem.succeedCount++;
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
                            _MGR_GameManager.Instance.currentPatternItem.RepairItem();
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
