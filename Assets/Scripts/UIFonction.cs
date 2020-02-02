using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFonction : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
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
        panel.SetActive(true);
    }

    public void QuitUI()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        panel.SetActive(false);
    }
}
