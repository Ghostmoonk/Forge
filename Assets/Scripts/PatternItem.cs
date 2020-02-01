using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternItem : MonoBehaviour
{
    #region Components
    Mesh mesh;
    [SerializeField] MeshFilter repairedMesh;
    [SerializeField] Material[] materials;
    Queue<InputEvent> inputEvents;
    [HideInInspector] public InputEvent currentInputEvent;
    [HideInInspector] public InputEvent secondInputEvent;
    Color colorSecondInputE;
    #endregion

    int queueSize;
    float speedInputEvent;
    enum State { REPAIRED, BROKEN }
    State state = State.BROKEN;

    // Start is called before the first frame update
    void Start()
    {
        currentInputEvent = null;
        secondInputEvent = null;
        inputEvents = new Queue<InputEvent>();
        mesh = GetComponent<MeshFilter>().mesh;
        for (int i = 0; i < transform.childCount; i++)
        {
            inputEvents.Enqueue(transform.GetChild(i).GetComponent<InputEvent>());
            transform.GetChild(i).GetComponent<InputEvent>().gameObject.SetActive(false);
        }
        queueSize = inputEvents.Count;
    }

    // fonction qui se fait appeler par le game manager pour avancer
    public void SwapInputEvents()
    {
        //on définit le current event 
        if (secondInputEvent == null)
        {
            currentInputEvent = inputEvents.Dequeue();
            Debug.Log(currentInputEvent);
        }
        else
        {
            currentInputEvent = secondInputEvent;
            currentInputEvent.gameObject.GetComponent<SpriteRenderer>().color = colorSecondInputE;
        }
        currentInputEvent.endEvent.AddListener(SwapInputEvents);
        //on lance l'anim du current event
        currentInputEvent.GetCurrentInputEvent();
        //On définit un second InputEvent et on l'active, et on le met avec une animation inisble
        secondInputEvent = inputEvents.Dequeue();
        secondInputEvent.gameObject.SetActive(true);
        secondInputEvent.succeedState = SucceedableState.PENDING;
        colorSecondInputE = secondInputEvent.buttonSprite.color;
        secondInputEvent.buttonSprite.color = new Color(colorSecondInputE.r, colorSecondInputE.g, colorSecondInputE.b, colorSecondInputE.a / 2);
        //apparemment on lance un AddListener

        Destroy(currentInputEvent.gameObject);
    }

    private void RepairItem()
    {

    }
}
