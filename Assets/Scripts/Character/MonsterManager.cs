using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    List<Character_Monster> _monsterList;

    int _curIndex;
    private void Awake()
    {
        _monsterList = new List<Character_Monster>();
    }
    void Start()
    {

    }

    public void CreateMonster()
    {
        Character_Monster monster = _monsterList.Find(o => o.gameObject.activeSelf == false);

        // 오브젝트 풀링
        if (monster == null)
        {
            GameObject mobRc = Resources.Load<GameObject>("_3_Monster/MonsterOrigin");
            GameObject mobInst = Instantiate(mobRc);
            mobInst.gameObject.name = "Monster_" + _curIndex++;

            Character_Monster mob = mobInst.AddComponent<Character_Monster>();

            _monsterList.Add(mob);
        }
        else
        {
            monster.gameObject.SetActive(true);
        }
    }

    public void RemoveMonster(string name)
    {
        Character_Monster monster = _monsterList.Find(o => o.gameObject.name == name);
        monster.Die();
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
