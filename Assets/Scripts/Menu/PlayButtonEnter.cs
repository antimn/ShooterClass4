using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonEnter : MonoBehaviour
{
    public GameObject gameObject;
    [SerializeField] private string sceneName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))

        {
            enterPlay();
            Debug.Log("Button pressed");
        }
    }

    public void enterPlay()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}