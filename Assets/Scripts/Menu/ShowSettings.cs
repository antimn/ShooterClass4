using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    public GameObject settingsPanel;

    public void ShowSettings()
    {
        if (settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
        }
        else
        {
            settingsPanel.SetActive(true);
        }
    }
}