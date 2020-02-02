using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        GameObject panel = GameObject.Find("FonctionUI").GetComponent<UIFonction>().panel;
        panel.SetActive(true);
    }
}
