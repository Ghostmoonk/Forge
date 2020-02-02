using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeScene(string sceneName)
    {
        _MGR_SceneManager.Instance.LoadScene(sceneName);
    }
}
