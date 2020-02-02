using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFonction : MonoBehaviour
{
    public GameObject panel;
    Button playButton;
    Button backButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<Button>();
        panel.SetActive(false);
    }

    public void StartUI()
    {
        _MGR_SceneManager.Instance.LoadScene("Sylve_Bloom");
    }

    public void ScoresUI()
    {
        panel.SetActive(true);
        backButton = GameObject.FindGameObjectWithTag("BackButton").GetComponent<Button>();
        backButton.Select();
    }

    public void QuitUI()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        panel.SetActive(false);
        playButton.Select();
    }
}