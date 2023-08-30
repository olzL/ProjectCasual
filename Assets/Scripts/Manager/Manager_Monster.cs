using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Manager_Monster : MonoSingleton<Manager_Monster>
{
    public List<Character_Monster> AliveMonsterList { get { return _aliveMonsterList; } }

    private List<Character_Monster> _aliveMonsterList;
    private List<Character_Monster> _monsterList;
    private int _monsterIndex;
    private Vector3 _SpawnPos;

    // 임시
    private bool _isSpawned;
    private float _spawnTime;
    private float _elapsedTime;

    private void Awake()
    {
        _monsterList = new List<Character_Monster>();
        _aliveMonsterList = new List<Character_Monster>();
    }

    void Start()
    {
        _monsterIndex = 0;
        _SpawnPos = new Vector3(20f, 0f, 0f);

        // 임시
        _isSpawned = true;
    }

    public void CreateMonster()
    {
        Character_Monster monster = _monsterList.Find(o => o.gameObject.activeSelf == false);

        // 오브젝트 풀링
        if (monster == null)
        {
            GameObject monsterRc = Resources.Load<GameObject>("Character/Prefabs/MonsterOrigin");
            GameObject monsterInst = Instantiate(monsterRc);
            monster = monsterInst.AddComponent<Character_Monster>();
            _monsterList.Add(monster);
        }
        else
        {
            monster.Respawn();
        }

        // 임시
        monster.InitData(11010001, Manager_Stage.Instance.Level);
        monster.gameObject.name = monster.Name + "_" + _monsterIndex++;
        monster.transform.position = _SpawnPos;
        _aliveMonsterList.Add(monster);
    }

    public void RemoveMonster(string name)
    {
        Character_Monster monster = _monsterList.Find(o => o.gameObject.name == name);
        _aliveMonsterList.Remove(monster);
    }

    // 임시
    private void RandomSpawn()
    {
        _elapsedTime += Time.deltaTime;
        if (_isSpawned)
        {
            _spawnTime = Random.Range(0.1f, 1.5f);
            _isSpawned = false;
        }

        if (_elapsedTime >= _spawnTime)
        {
            CreateMonster();
            _elapsedTime = 0;
            _isSpawned = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            CreateMonster();
        }

        RandomSpawn();
    }
}
