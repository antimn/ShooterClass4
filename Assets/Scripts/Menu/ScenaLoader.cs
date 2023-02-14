using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void load()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}