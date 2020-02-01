using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            _MGR_GameManager.Instance.StopConveyorBelt();
        }
    }
}
