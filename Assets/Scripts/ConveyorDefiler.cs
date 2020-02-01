using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorDefiler : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 firstConveyorPos;
    Vector3 secondLastConveyorPos;
    private void Start()
    {
        firstConveyorPos = transform.GetChild(0).transform.position;
        secondLastConveyorPos = transform.GetChild(1).transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(0).transform.position.x >= secondLastConveyorPos.x)
        {
            transform.GetChild(transform.childCount - 1).transform.position = firstConveyorPos;
            transform.GetChild(transform.childCount - 1).SetAsFirstSibling();
        }
    }
}
