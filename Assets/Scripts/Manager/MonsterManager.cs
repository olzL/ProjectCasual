using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MonsterManager : MonoSingleton<MonsterManager>
{
    private List<Character_Monster> _monsterList;
    private int _monsterIndex;
    private Vector3 _SpawnPos;

    private void Awake()
    {
        _monsterList = new List<Character_Monster>();
    }
    void Start()
    {
        _monsterIndex = 0;
        _SpawnPos = new Vector3(20f, 0f, 0f);
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
            monster.gameObject.SetActive(true);
        }

        // 임시
        monster.InitData(11010001, 10);
        SetMonster(monster);
    }

    private void SetMonster(Character_Monster monster)
    {
        monster.gameObject.name = monster.Name + "_" + _monsterIndex++;
        monster.transform.position = _SpawnPos;
    }

    public void RemoveMonster(string name)
    {
        Character_Monster monster = _monsterList.Find(o => o.gameObject.name == name);
        monster.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            CreateMonster();
        }
    }
}
