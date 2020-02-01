using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MGR_Scenes : MonoBehaviour
{
    private static _MGR_Scenes _instance;
    public static _MGR_Scenes Instance
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
}
