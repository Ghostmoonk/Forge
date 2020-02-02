using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemState { REPAIRED, BROKEN }

public class PatternItem : MonoBehaviour
{
    #region Components
    public ItemModel model;
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    public Queue<InputEvent> inputEvents;
    [HideInInspector] public InputEvent currentInputEvent;
    [HideInInspector] public InputEvent secondInputEvent;

    #endregion

    #region Variables
    [Range(0, 3)]
    [SerializeField] float speedInputEventAnim;
    int queueSize;
    [HideInInspector] public int succeedCount;
    #endregion

    #region Etat
    public ItemState state = ItemState.BROKEN;
    #endregion

    public void UpdateModel()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();

        if (state == ItemState.REPAIRED)
        {
            meshFilter.mesh = model.repairedMesh.sharedMesh;
            GetComponent<MeshRenderer>().sharedMaterials = model.repairedMeshRenderer.sharedMaterials;
        }
        else
        {
            meshFilter.mesh = model.brokenMesh.sharedMesh;
            GetComponent<MeshRenderer>().sharedMaterials = model.brokenMeshRenderer.sharedMaterials;
        }
    }

    void Start()
    {
        if (speedInputEventAnim <= 0.1f)
        {
            speedInputEventAnim = 1f;
        }
        succeedCount = 0;
        currentInputEvent = null;
        secondInputEvent = null;
        inputEvents = new Queue<InputEvent>();
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();

        for (int i = 0; i < transform.childCount; i++)
        {
            inputEvents.Enqueue(transform.GetChild(i).GetComponent<InputEvent>());
            transform.GetChild(i).GetComponent<Animator>().speed = speedInputEventAnim;
        }
        queueSize = inputEvents.Count;
    }

    // fonction qui se fait appeler par le game manager pour avancer
    public void GoNextCurrentInputEvent()
    {
        if (secondInputEvent == null && inputEvents.Count > 1)
        {
            currentInputEvent = inputEvents.Dequeue();
            secondInputEvent = inputEvents.Dequeue();
        }
        else if (secondInputEvent != null)
        {
            currentInputEvent = secondInputEvent;
            if (inputEvents.Count > 0)
                secondInputEvent = inputEvents.Dequeue();
            else
            {
                secondInputEvent = null;
            }
        }
        //on lance l'anim du current event
        if (currentInputEvent != null)
        {
            currentInputEvent.succeedableState = SucceedableState.FAILABLE;
            currentInputEvent.PlayAnimation();
        }

        if (secondInputEvent != null)
        {
            secondInputEvent.succeedableState = SucceedableState.PENDING;
            secondInputEvent.PlayAnimation();
        }
    }

    public bool RepairItem()
    {
        //Debug.Log("Le suceed coount est de : " + succeedCount);
        //Debug.Log("La condition minimum pour reparer est : " + Mathf.FloorToInt(queueSize / 2));
        if (succeedCount > Mathf.FloorToInt(queueSize / 2))
        {
            //Debug.Log("je devrais le réparer");
            meshFilter.mesh = model.repairedMesh.sharedMesh;
            //Multiplicateur score +1 !
            return true;
        }
        return false;
    }
}
