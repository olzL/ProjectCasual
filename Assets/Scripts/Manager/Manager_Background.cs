using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Background : MonoSingleton<Manager_Background>
{
    private float[] _layerMoveSpeed;
    private MeshRenderer[] _backgrounds;
    private Texture2D[] _backgroundsTex;

    private void Awake()
    {
        if (_backgrounds == null)
        {
            GameObject backgroundObj = GameObject.Find("Backgrounds");
            _backgrounds = backgroundObj.GetComponentsInChildren<MeshRenderer>();
        }
        _backgroundsTex = Resources.LoadAll<Texture2D>("Backgrounds");

        _layerMoveSpeed = new float[6];
        _layerMoveSpeed[0] = 0.5f;
        _layerMoveSpeed[1] = 0.3f;
        _layerMoveSpeed[2] = 0.1f;
        _layerMoveSpeed[3] = 0.05f;
        _layerMoveSpeed[4] = 0.01f;
        _layerMoveSpeed[5] = 0.005f;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        for (int i = 0; i < _backgrounds.Length; i++)
        {
            float speed = _layerMoveSpeed[i];
            _backgrounds[i].material.SetTextureOffset("_MainTex", Vector2.right * speed * Time.time);
        }
    }

    public void ChangeBackground(string name)
    {
        Texture2D[] textureArray = new Texture2D[_backgrounds.Length];
        int layerIndex = 0;
        for (int i = 0; i < _backgroundsTex.Length; i++)
        {
            string rcName = name + "_Layer_" + layerIndex;
            if (_backgroundsTex[i].name == rcName)
            {
                textureArray[layerIndex] = _backgroundsTex[i];
                layerIndex++;
            }
        }

        for (int i = 0; i < _backgrounds.Length; i++)
        {
            Texture2D changeTex = textureArray[i];
            if (changeTex != null)
            {
                _backgrounds[i].material.SetTexture("_MainTex", changeTex);
            }
        }
    }
}
