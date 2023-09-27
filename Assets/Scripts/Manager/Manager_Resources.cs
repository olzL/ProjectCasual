using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Resources : MonoSingleton<Manager_Resources>
{
    void Start()
    {
        TableLoadAll();
        Debug.Log("테이블 로드");
        SceneManager.LoadScene("Lobby");
    }

    private void TableLoadAll()
    {
        Table_110_Character.Instance.LoadData("110_Character");
        Table_910_Text.Instance.LoadData("910_Text");
        Table_101_GlobalValue.Instance.LoadData("101_GlobalValue");
        Table_210_Stage.Instance.LoadData("210_Stage");
    }

    void Update()
    {
        
    }
}
