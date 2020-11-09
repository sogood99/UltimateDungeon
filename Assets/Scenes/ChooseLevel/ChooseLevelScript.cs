using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevelScript : MonoBehaviour
{
    public void GotoIntroduction()
    {
        SceneManager.LoadScene("CutScene0");
        Destroy(GameObject.Find("Audio Source"));
    }
    public void GotoGameScene1()
    {
        SceneManager.LoadScene("CutScene1");
        Destroy(GameObject.Find("Audio Source"));
    }
    public void GotoGameScene2()
    {
        SceneManager.LoadScene("CutScene2");
        Destroy(GameObject.Find("Audio Source"));
    }
    public void GotoGameScene3()
    {
        SceneManager.LoadScene("CutScene3");
        Destroy(GameObject.Find("Audio Source"));
    }
    public void GotoGameScene4()
    {
        SceneManager.LoadScene("CutScene4");
        Destroy(GameObject.Find("Audio Source"));
    }
    public void GotoGameScene5()
    {
        SceneManager.LoadScene("CutScene5");
        Destroy(GameObject.Find("Audio Source"));
    }
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
        Destroy(GameObject.Find("Audio Source"));
    }
}
