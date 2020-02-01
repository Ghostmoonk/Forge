using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFonction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartUI()
    {
        _MGR_SceneManager.Instance.LoadScene("Menu");
    }

    public void ScoresUI()
    {
    }

    public void QuitUI()
    {
        Application.Quit();
    }
}
