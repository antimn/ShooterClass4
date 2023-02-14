using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int prefabCount = 4;
    private int destroyedPrefabCount = 0;
    [SerializeField] private string sceneName;

    public void OnPrefabDestroyed()
    {
        destroyedPrefabCount++;
        if (destroyedPrefabCount >= prefabCount)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadSceneAsync(sceneName);
    }
}