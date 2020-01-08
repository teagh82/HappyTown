using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScriptToGameover : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene(15);
    }

    public void ClickToTitle()
    {
        SceneManager.LoadScene(0);
    }
}