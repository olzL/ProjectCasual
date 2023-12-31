using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Manager_Monster : MonoSingleton<Manager_Monster>
{
    public List<Character_Monster> AliveMonsterList { get { return _aliveMonsterList; } }

    [SerializeField]
    private List<Character_Monster> _aliveMonsterList;
    private List<Character_Monster> _monsterList;
    private int _monsterIndex;
    private Vector3 _SpawnPos;

    private Dictionary<int, StageData> _stageDataDic;
    private Dictionary<int, GlobalValueData> _globalDataDic;

    // 임시
    private bool _isSpawned;
    private float _spawnTime;
    private float _spawnIntervalMin;
    private float _spawnIntervalMax;
    private float _elapsedTime;

    private void Awake()
    {
        
    }

    void Start()
    {
        _monsterList = new List<Character_Monster>();
        _aliveMonsterList = new List<Character_Monster>();
        _stageDataDic = Table_210_Stage.Instance.DataDic;
        _globalDataDic = Table_101_GlobalValue.Instance.DataDic;

        _monsterIndex = 0;
        _SpawnPos = new Vector3(20f, 0f, 0f);
        _isSpawned = true;
        _spawnIntervalMin = _globalDataDic[10000013].FloatValue;
        _spawnIntervalMax = _globalDataDic[10000014].FloatValue;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            CreateMonster();
        }

        if (Character_Player.Instance.IsAlive == true)
        {
            RandomSpawn();
        }

        if (_aliveMonsterList != null)
        {
            PlayerToDistanceSort();
        }
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

        int stageLevel = Manager_Stage.Instance.StageLevel;
        int[] spawnIndex = _stageDataDic[stageLevel].SpawnIndex;
        int[] spawnRatio = _stageDataDic[stageLevel].SpawnRatio;
        int charIndex = CustomRandom.Random10000(spawnIndex, spawnRatio);

        monster.InitData(charIndex, stageLevel);
        monster.gameObject.name = monster.Name + "_" + _monsterIndex++;
        monster.transform.position = _SpawnPos;

        _aliveMonsterList.Add(monster);
    }

    public void RemoveMonster(string name)
    {
        Character_Monster monster = _monsterList.Find(o => o.gameObject.name == name);
        if (monster != null)
        {
            _aliveMonsterList.Remove(monster);
        }
    }

    private void RandomSpawn()
    {
        _elapsedTime += Time.deltaTime;
        if (_isSpawned)
        {
            _spawnTime = Random.Range(_spawnIntervalMin, _spawnIntervalMax);
            _isSpawned = false;
        }

        if (_elapsedTime >= _spawnTime)
        {
            CreateMonster();
            _elapsedTime = 0;
            _isSpawned = true;
        }
    }

    // 플레이어와 가까운 순으로 정렬
    private void PlayerToDistanceSort()
    {
        Vector3 playerPosition = Character_Player.Instance.transform.position;

        _aliveMonsterList.Sort((a, b) =>
        {
            float distanceA = Vector3.Distance(a.transform.position, playerPosition);
            float distanceB = Vector3.Distance(b.transform.position, playerPosition);
            return distanceA.CompareTo(distanceB);
        });

    }
}
