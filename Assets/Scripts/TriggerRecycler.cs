﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRecycler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Destroy(other.gameObject);
        }
    }
}
