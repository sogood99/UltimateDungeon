using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public static bool isStart = false;
    public GameObject playerChoosePanel;
    public GameObject playerPlaceIndicator;
    public GameObject colliderDetect;

    private void Start()
    {
        isStart = false;
    }

    public void PlayerStart()
    {
        isStart = true;
        playerChoosePanel.SetActive(false);
        playerPlaceIndicator.SetActive(false);
        colliderDetect.SetActive(false);
    }
}
