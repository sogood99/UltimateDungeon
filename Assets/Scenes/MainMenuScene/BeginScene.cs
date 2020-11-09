using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginScene : MonoBehaviour
{
    public GameObject menuScene;
    public GameObject optionScene;
    public GameObject helpScene;
    void Start()
    {
        menuScene.SetActive(true);
        optionScene.SetActive(false);
        helpScene.SetActive(false);
    }
}
