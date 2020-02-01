using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MGR_GameManager : MonoBehaviour
{

    #region Components
    [SerializeField] BoxCollider itemTrigger;
    GameObject itemContainer;
    #endregion

    public float conveyorBeltSpeed;
    bool canMoveConveyorBelt;

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
        canMoveConveyorBelt = true;
        //Génère une queue de tous les items
        queuesPattern = new Queue<PatternItem>();
        itemContainer = GameObject.FindGameObjectWithTag("ItemContainer");

        //On enqueue les premiers items 
        for (int i = 0; i < itemContainer.transform.childCount; i++)
        {
            queuesPattern.Enqueue(itemContainer.transform.GetChild(i).GetComponent<PatternItem>());
        }

        // //On dequeue le premeir item
        // if (queuesPattern.Count > 0)
        // {
        //     currentPatternItem = queuesPattern.Dequeue();
        // }
        //On commence les QTE 1s après le début du jeu
        StartCoroutine(nameof(ConveyorBelt));

    }

    public void ChangeItem()
    {
        if (queuesPattern.Count > 0)
        {
            currentPatternItem = queuesPattern.Dequeue();
        }

        itemContainer.transform.Translate(Vector3.right * 100f);
    }

    IEnumerator ConveyorBelt()
    {
        while (canMoveConveyorBelt)
        {
            yield return new WaitForSeconds(0.05f);
            itemContainer.transform.position += new Vector3(conveyorBeltSpeed * Time.deltaTime, 0, 0);
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

}
