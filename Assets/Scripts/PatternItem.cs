using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    int queueSize;
    float speedInputEvent;

    public enum State { REPAIRED, BROKEN }

    public State state = State.BROKEN;

    [SerializeField] int numberOfInput;

    public void UpdateModel()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();

        if (state == State.REPAIRED)
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
        currentInputEvent = null;
        secondInputEvent = null;
        inputEvents = new Queue<InputEvent>();
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();

        for (int i = 0; i < transform.childCount; i++)
        {
            inputEvents.Enqueue(transform.GetChild(i).GetComponent<InputEvent>());
        }
        queueSize = inputEvents.Count;
    }

    // fonction qui se fait appeler par le game manager pour avancer
    public void GoNextCurrentInputEvent()
    {
        //on définit le current event 
        if (secondInputEvent == null)
        {
            currentInputEvent = inputEvents.Dequeue();
            secondInputEvent = inputEvents.Dequeue();
        }
        else
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
        currentInputEvent.succeedState = SucceedableState.FAILABLE;
        currentInputEvent.PlayAnimation();

        if (secondInputEvent != null)
        {
            secondInputEvent.succeedState = SucceedableState.PENDING;
            secondInputEvent.PlayAnimation();
        }
    }

    public void RepairItem()
    {
        meshFilter.mesh = model.repairedMesh.sharedMesh;
    }

}
