using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MGR_GameManager : MonoBehaviour
{
    #region Components
    [SerializeField] BoxCollider itemTrigger;
    GameObject itemContainer;
    [HideInInspector] public GameObject tapisContainer;
    #endregion

    public AnimationCurve conveyorBeltSpeed;
    [HideInInspector] public bool canMoveConveyorBelt;

    private static _MGR_GameManager _instance;
    public static _MGR_GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    Queue<PatternItem> queuesPattern;
    public PatternItem currentPatternItem;

    private void Start()
    {
        _MGR_ScoreManager.Instance.comboReboot();
        canMoveConveyorBelt = true;
        //Génère une queue de tous les items
        queuesPattern = new Queue<PatternItem>();
        itemContainer = GameObject.FindGameObjectWithTag("ItemContainer");
        tapisContainer = GameObject.FindGameObjectWithTag("TapisContainer");

        //On enqueue les premiers items 
        for (int i = 0; i < itemContainer.transform.childCount; i++)
        {
            queuesPattern.Enqueue(itemContainer.transform.GetChild(i).GetComponent<PatternItem>());
        }

        StartCoroutine(nameof(ConveyorBelt));
    }

    public void AddItemPaternInQueue(PatternItem patternItem)
    {
        queuesPattern.Enqueue(patternItem);
    }

    #region Tapis roulant
    IEnumerator ConveyorBelt()
    {
        while (canMoveConveyorBelt)
        {
            yield return new WaitForSeconds(0.05f);
            tapisContainer.transform.position += new Vector3(conveyorBeltSpeed.Evaluate(Time.time) * Time.deltaTime, 0, 0);
            Debug.Log("Speed" + conveyorBeltSpeed.Evaluate(Time.time));
            for (int i = 0; i < itemContainer.transform.childCount; i++)
            {
                itemContainer.transform.GetChild(i).transform.position += new Vector3(conveyorBeltSpeed.Evaluate(Time.time) * Time.deltaTime, 0, 0);

            }
        }
    }

    public void MoveConveyorBelt()
    {
        canMoveConveyorBelt = true;
        StartCoroutine(ConveyorBelt());
    }

    public void StopConveyorBelt()
    {
        StopCoroutine(ConveyorBelt());
        canMoveConveyorBelt = false;
        currentPatternItem = queuesPattern.Dequeue();
        currentPatternItem.GoNextCurrentInputEvent();
    }
    #endregion

    public void EndGame()
    {

    }
}
