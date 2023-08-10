using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    void Start()
    {
        TableLoadAll();
    }

    void Update()
    {
        
    }


    private void TableLoadAll()
    {
        Table_110_Character.Instance.LoadData("110_Character");
        Table_910_Text.Instance.LoadData("910_Text");
    }

    public void StartStage()
    {
        SceneManager.LoadScene(1);
    }
}
