using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoSingleton<StageManager>
{
    public float MoveSpeed { get; private set; } // �� �� ���� �̵� �ӵ�

    private float elapsedTime;

    private void Start()
    {
        MoveSpeed = 5.0f;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 1f)
        {
            MoveSpeed++;
            elapsedTime = 0f;
        }
    }

    public void EndStage()
    {
        SceneManager.LoadScene(0);
    }

}
