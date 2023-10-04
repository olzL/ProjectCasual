using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CharacterSelect : MonoBehaviour
{
    [SerializeField] Character_Lobby _characterNext;
    [SerializeField] Character_Lobby _characterPrev;

    private List<int> characterIndexList;

    private void Awake()
    {
        CharacterListInit();
    }

    private void OnEnable()
    {
        SetCharacterDummyActive(true);
    }

    private void OnDisable()
    {
        SetCharacterDummyActive(false);
    }

    private void SetCharacterDummyActive(bool isActive)
    {
        _characterNext.gameObject.SetActive(isActive);
        _characterPrev.gameObject.SetActive(isActive);

        if (isActive)
        {
            _characterNext.Init(GetCharacterIndex(1));
            _characterPrev.Init(GetCharacterIndex(-1));
        }
    }

    private void CharacterListInit()
    {
        characterIndexList = new List<int>();

        List<CharacterData> CharacterDataList = Table_110_Character.Instance.DataList;

        for (int i = 0; i < CharacterDataList.Count; i++)
        {
            if (CharacterDataList[i].Type == ECharacterType.Character)
            {
                characterIndexList.Add(CharacterDataList[i].Index);
            }
        }
    }

    /// <summary>
    /// 현재 선택된 캐릭터(0)에서 count만큼 거리의 인덱스에서 캐릭터인덱스 값 반환
    /// </summary>
    private int GetCharacterIndex(int count)
    {
        int curCharaterIndex = Manager_Game.Instance.CurCharacterIndex;
        int tmpIndex = 0;

        for (int i = 0; i < characterIndexList.Count; i++)
        {
            if (characterIndexList[i] == curCharaterIndex)
            {
                tmpIndex = i;
                break;
            }
        }

        int resultIndex = tmpIndex + count;

        if (resultIndex >= characterIndexList.Count)
        {
            resultIndex -= characterIndexList.Count;
        }
        else if (resultIndex < 0)
        {
            resultIndex += characterIndexList.Count;
        }

        return characterIndexList[resultIndex];
    }
}
