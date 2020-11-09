using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfEnd : MonoBehaviour
{
    public GameObject allyWonScene;
    public GameObject enemyWonScene;
    public GameObject bgmObj;
    public GameObject winObj;
    public GameObject loseObj;

    private void Start()
    {
        allyWonScene.SetActive(false);
        enemyWonScene.SetActive(false);
    }

    void FixedUpdate()
    {
        if (StartScript.isStart)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                AllyWon();
            }
            else if (GameObject.FindGameObjectsWithTag("Ally").Length == 0)
            {
                EnemyWon();
            }
        }
    }

    public void AllyWon()
    {
        allyWonScene.SetActive(true);
        if (bgmObj!= null)
        {
            bgmObj.SetActive(false);
        }
        winObj.SetActive(true);

    }

    public void EnemyWon()
    {
        enemyWonScene.SetActive(true);
        if (bgmObj != null)
        {
            bgmObj.SetActive(false);
        }
        loseObj.SetActive(true);
    }
}
