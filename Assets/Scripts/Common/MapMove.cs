using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    [SerializeField] Camera _playerCam;
    [SerializeField] Transform[] _BackGround;

    private float _camCenterPosX;

    private Vector2 _firstGroundPos;
    private Vector2 _middleGroundPos;
    private Vector2 _lastGroundPos;
    private Vector2 _playerStartPos;

    private Transform _nextGround;
    private Transform _curGround;
    private Transform _prevGround;

    private int _mapIndex;
    private int MapIndex
    {
        get{ return _mapIndex; }
        set 
        {
            int tmp = value;
            if (tmp >= _BackGround.Length)
            {
                _mapIndex = 0;
            }
            else if(tmp < 0)
            {
                _mapIndex = _BackGround.Length - 1;
            }
            else
            {
                _mapIndex = value;
            }
        }
    }

    private int myVar;

    public int MyProperty
    {
        get { return myVar; }
        set { myVar = value; }
    }


    void Start()
    {
        MapIndex = 2;

        _prevGround = _BackGround[0].transform;
        _curGround = _BackGround[1].transform;
        _nextGround = _BackGround[2].transform;

        _firstGroundPos = _BackGround[0].transform.position;
        _middleGroundPos = _BackGround[1].transform.position;
        _lastGroundPos = _BackGround[2].transform.position;
        _playerStartPos = Character_Player.Instance.transform.position;
    }

    void Update()
    {
        _camCenterPosX = _playerCam.transform.position.x;

        if (_camCenterPosX >= _nextGround.position.x)
        {
            Debug.Log("¸Ê Áö³ªÄ§");

            _curGround.position = _firstGroundPos;
            _nextGround.position = _middleGroundPos;
            _prevGround.position = _lastGroundPos;

            _nextGround = _BackGround[MapIndex += 1].transform;
            _curGround = _BackGround[MapIndex -= 1].transform;
            _prevGround = _BackGround[MapIndex -= 1].transform;

            Character_Player.Instance.transform.position = _playerStartPos;

            //Vector3 tmpPos = _prevGround.position;
            //_prevGround.position = _nextGround.position;
            //_nextGround.position = tmpPos;
            //Character_Player.instance.transform.position = tmpPos;

            //if (_nextGround == BackGround_0)
            //{
            //    _nextGround = BackGround_1;
            //    _prevGround = BackGround_0;
            //}
            //else
            //{
            //    _nextGround = BackGround_0;
            //    _prevGround = BackGround_1;
            //}
        }
    }
}
