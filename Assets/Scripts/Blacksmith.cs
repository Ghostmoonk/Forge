using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : MonoBehaviour
{
    #region Components
    Animator animator;
    SpriteRenderer spriteRenderer;
    [SerializeField] ParticleSystem Sparks;
    #endregion

    PatternItem itemToRepair;
    #region Points
    Transform scorePopUpSpawner;
    Transform scorePopUpContainer;
    [SerializeField] GameObject scorePopUpPrefab;
    #endregion

    public void vibrationStop()
    {
        XInputDotNetPure.GamePad.SetVibration(0, 0.0f, 0.0f);
    }
    public void SetVoidSound()
    {
        gameObject.GetComponent<AudioSource>().clip = null;
    }
    public void CameraShaking()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakin>().shakeDuration = 0.4f;
        XInputDotNetPure.GamePad.SetVibration(0, 20.0f, 20.0f);
        Invoke("vibrationStop", 0.3f);
        if (itemToRepair != null)
        {
            _MGR_GameManager.Instance.currentPatternItem.RepairItem(itemToRepair);
            itemToRepair = null;
        }

        Sparks.Play();
        //_MGR_SoundDesign.Instance.PlaySound("" + _MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType, gameObject.GetComponent<AudioSource>());
    }

    private void Start()
    {
        scorePopUpSpawner = GameObject.FindGameObjectWithTag("SpawnScorePopUp").transform;
        scorePopUpContainer = GameObject.FindGameObjectWithTag("ScorePopUpContainer").transform;
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
                            _MGR_SoundDesign.Instance.PlaySound("A", gameObject.GetComponent<AudioSource>());
                            Debug.Log("REUSSI A");
                            _MGR_GameManager.Instance.currentPatternItem.succeedCount++;
                        }
                        //C'est raté
                        else
                        {
                            _MGR_SoundDesign.Instance.PlaySound("" + _MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType + "_fail", gameObject.GetComponent<AudioSource>());

                        }
                    }
                    else if (Input.GetButtonDown("B"))
                    {
                        if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.CheckSucceed(InputType.B))
                        {
                            _MGR_SoundDesign.Instance.PlaySound("B", gameObject.GetComponent<AudioSource>());
                            Debug.Log("REUSSI B");
                            _MGR_GameManager.Instance.currentPatternItem.succeedCount++;
                        }
                        else
                        {
                            _MGR_SoundDesign.Instance.PlaySound("" + _MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType + "_fail", gameObject.GetComponent<AudioSource>());
                        }
                    }
                    else if (Input.GetButtonDown("X"))
                    {
                        if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.CheckSucceed(InputType.X))
                        {
                            _MGR_SoundDesign.Instance.PlaySound("X", gameObject.GetComponent<AudioSource>());
                            //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakin>().shakeDuration = 0.5f;
                            _MGR_GameManager.Instance.currentPatternItem.succeedCount++;
                        }
                        else
                        {
                            _MGR_SoundDesign.Instance.PlaySound("" + _MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType + "_fail", gameObject.GetComponent<AudioSource>());
                        }
                    }
                    else if (Input.GetButtonDown("Y"))
                    {
                        if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.CheckSucceed(InputType.Y))
                        {
                            _MGR_SoundDesign.Instance.PlaySound("Y", gameObject.GetComponent<AudioSource>());
                            _MGR_GameManager.Instance.currentPatternItem.succeedCount++;
                        }
                        else
                        {
                            _MGR_SoundDesign.Instance.PlaySound("" + _MGR_GameManager.Instance.currentPatternItem.currentInputEvent.inputType + "_fail", gameObject.GetComponent<AudioSource>());
                        }
                    }
                    if (_MGR_GameManager.Instance.currentPatternItem.currentInputEvent.succeed)
                    {
                        _MGR_ScoreManager.Instance.UpdateScore(_MGR_GameManager.Instance.currentPatternItem.pointsPerInput);
                        GameObject scorePopUp = Instantiate(scorePopUpPrefab, scorePopUpSpawner.position, scorePopUpSpawner.rotation, scorePopUpContainer);
                        scorePopUp.GetComponent<TextMesh>().text = "+ " + (_MGR_GameManager.Instance.currentPatternItem.pointsPerInput * _MGR_ScoreManager.Instance.scoreMultiplier).ToString();
                    }

                    if (_MGR_GameManager.Instance.currentPatternItem.inputEvents.Count == 0 && _MGR_GameManager.Instance.currentPatternItem.secondInputEvent == null)
                    {
                        if (!_MGR_GameManager.Instance.canMoveConveyorBelt)
                        {
                            // _MGR_GameManager.Instance.currentPatternItem.RepairItem();
                            _MGR_GameManager.Instance.MoveConveyorBelt();
                        }
                        itemToRepair = _MGR_GameManager.Instance.currentPatternItem;
                        // _MGR_GameManager.Instance.currentPatternItem.RepairItem();
                    }
                    else
                    {
                        _MGR_GameManager.Instance.currentPatternItem.GoNextCurrentInputEvent();
                    }
                }
            }
            else
            {
                //Debug.Log("Pas encore de current input event actif");
            }
        }
        else
        {
            //Debug.Log("Pas de current input");
        }
    }
}
