using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBrowser : MonoBehaviour
{
    [SerializeField] Button[] menuButtons;

    void Start()
    {
        menuButtons[0].Select();
    }
}
