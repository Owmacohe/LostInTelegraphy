using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public string buttonType;
    public string sceneName;

    private void OnMouseDown()
    {
        if (buttonType == "start")
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (buttonType == "exit")
        {
            Application.Quit();
        }
    }
}
