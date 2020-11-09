using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public GameObject[] prefab = new GameObject[10];
    public List<int> PrefabsCost = new List<int>();
    public int choice = -1;
    public int MoneyLeft = 100;
    Vector3 pz;
    public List<GameObject> playerChoosePrefabs = new List<GameObject>();
    private bool SetTag = false;
    public TMPro.TMP_Text txt;
    public Sprite[] spriteImg;
    public Image selectedImg;
    public TMPro.TMP_Text selectedText;
    public string nextLevelName;

    private void Update()
    {
        txt.text = MoneyLeft.ToString();
        if (!PauseMenuScript.isPaused && !StartScript.isStart)
        {
            if (Input.anyKeyDown)
            {
                for (int i = 1; i < prefab.Length; i++)
                {
                    if (Input.GetKey(i.ToString()))
                    {
                        choice = i;
                        selectedImg.sprite = spriteImg[choice];
                        Color c = selectedImg.color;
                        c.a = 50;
                        selectedImg.color = c;
                        Color b = selectedText.color;
                        b.a = 170;
                        selectedText.color = b;
                    }
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                Debug.Log(hit.collider);
                if (choice != -1 && MoneyLeft- PrefabsCost[choice]>=0 && hit.collider != null && hit.collider.gameObject.layer == 9)
                {
                    MoneyLeft -= PrefabsCost[choice];
                    //Debug.Log(hit.collider.gameObject.layer);
                    pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    pz.z = 0;
                    GameObject newPrefab =  Instantiate(prefab[choice], pz, Quaternion.identity);
                    newPrefab.tag = "Untagged";
                    playerChoosePrefabs.Add(newPrefab);
                }
            }
        }
        if (StartScript.isStart && !SetTag)
        {
            foreach (GameObject pfbs in playerChoosePrefabs)
            {
                pfbs.tag = "Ally";
            }
            SetTag = true;
        }
    }

    public void buttonPressed(int prefabNumber)
    {
        choice = prefabNumber;
        selectedImg.sprite = spriteImg[choice];
        Color c = selectedImg.color;
        c.a = 50;
        selectedImg.color = c;
        Color b = selectedText.color;
        b.a = 170;
        selectedText.color = b;
    }

    public void BackButton()
    {
        SceneManager.LoadScene("ChooseLevel");
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(nextLevelName);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
