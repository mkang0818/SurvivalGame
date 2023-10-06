using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject StartUI;
    public GameObject CharselectUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectStart() => CharselectUI.SetActive(true);


    public void CharacterSelect(int charnum) => GameManager.instance.playerNum = charnum;
    public void GameStart() => SceneManager.LoadScene("GameScene");
    public void Quit() => Application.Quit();
}
