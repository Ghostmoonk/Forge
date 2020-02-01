using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MGR_GameManager : MonoBehaviour
{
    private static _MGR_GameManager _instance;
    public static _MGR_GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    Queue<PatternItem> queuesPattern;

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

    [HideInInspector] public InputEvent currentInputEvent;

    private void Start()
    {
        currentInputEvent = null;
    }

    private void UnfoldQueues()
    {
        
    }



}
