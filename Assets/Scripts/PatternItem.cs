using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternItem : MonoBehaviour
{
    class InputEvent
    {
        public string name;
    }
    InputEvent[] InputEvents;
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

    void InputEventManagement()
    {
        for (int i = 0; InputEvents.Length >= i; i++)
        {
            //InputEvents[i].fonctionquilanceleqte
            if (InputEvents[i + 1] != null)
            {
                //InputEvents[i + 1].SetActive(true);
                //InputEvents[i + 1].name = "Opacity = 30%";
            }

        }
    }
}
