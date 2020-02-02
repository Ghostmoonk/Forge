using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _MGR_SceneManager : MonoBehaviour
{
    private static _MGR_SceneManager p_instance = null;
    public static _MGR_SceneManager Instance { get { return p_instance; } }

    public string[] arr_SceneName;


    void Awake()
    {
        // ===>> SingletonMAnager
        //Check if instance already exists
        if (p_instance == null)
            //if not, set instance to this
            p_instance = this;
        //If instance already exists and it's not this:
        else if (p_instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene(string __nom_scene)
    {
        SceneManager.LoadScene(__nom_scene);
    }

    public void LoadEndScene(string __nom_scene)
    {
        SceneManager.LoadScene(__nom_scene);
        StartCoroutine(WaitForLoad());
    }

    IEnumerator WaitForLoad()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject panel = GameObject.Find("FonctionUI").GetComponent<UIFonction>().panel;
        panel.SetActive(true);
        Debug.Log(GameObject.Find("YourScore").GetComponent<Text>());
        _MGR_ScoreManager.Instance.yourScore = GameObject.Find("YourScore").GetComponent<Text>();
        for (int i = 0; i < _MGR_ScoreManager.Instance.highScore.Length; i++)
        {
            _MGR_ScoreManager.Instance.highScore[i] = GameObject.Find("HighScores").transform.GetChild(i).transform.GetChild(0).GetComponent<Text>();
        }
        _MGR_ScoreManager.Instance.gameover();
    }
}
