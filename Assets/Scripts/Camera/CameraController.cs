using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{

    private Vector3 cameraPos;
    private float cameraSpeed;

    void Start()
    {
        cameraPos = new Vector3(5, 0, -10);
        //cameraSpeed = 4f;
    }

    void LateUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position , Character_Player.instance.transform.position + cameraPos, Time.deltaTime * cameraSpeed);
        transform.position = Character_Player.Instance.transform.position + cameraPos;
    }
}
