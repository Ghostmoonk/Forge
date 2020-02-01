using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternItem : MonoBehaviour
{
    #region Component
        Queue<InputEvent> InputEvents;
        InputEvent current;
        InputEvent second;
        Color colorSecondInputE;
    #endregion
    
    float speedInputEvent;
    enum State { Repaired, Broken }
    State state = State.Broken;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // fonction qui se fait appeler par le game manager pour avancer
    void InputEventManagement()
    {
        //on définit le current event 
        if (second == null)
        {
            current = InputEvents.Dequeue();
            current.gameObject.SetActive(true);
        }
        else
        {
            current = second;
            current.gameObject.GetComponent<SpriteRenderer>().color = colorSecondInputE;
        }
        //on lance l'anim du current event
        current.SetCurrentInputEvent();
        //On définit un second InputEvent et on l'active, et on le met avec une animation inisble
        second = InputEvents.Dequeue();
        second.gameObject.SetActive(true);
        second.succeedState = SucceedableState.PENDING;
        colorSecondInputE = second.gameObject.GetComponent<SpriteRenderer>().color;
        second.gameObject.GetComponent<SpriteRenderer>().color = new Color(colorSecondInputE.r, colorSecondInputE.g, colorSecondInputE.b, colorSecondInputE.a / 2);
        //apparemment on lance un AddListener
        current.endEvent.AddListener(InputEventManagement);
        Destroy(current.gameObject);
    }
}
