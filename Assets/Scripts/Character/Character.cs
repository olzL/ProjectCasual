using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public string Name { get; private set; }
    public int Hp { get; private set; }
    public int Atk { get; private set; }
    /// <summary>
    /// aniIndex(0: Walk, 1: Attack, 2: Death, 3: Jump)
    /// </summary>
    public Animator MyAnimator { get; private set; }
    public BoxCollider2D HitBoxCollider { get; private set; }

    protected Dictionary<int, GlobalValueData> _globalValueDic;

    private CharacterData _characterData;

    protected virtual void Awake()
    {
        _characterData = new CharacterData();

        if (HitBoxCollider != null)
        {
            HitBoxCollider = gameObject.GetComponent<BoxCollider2D>();
        }
        else
        {
            HitBoxCollider = gameObject.AddComponent<BoxCollider2D>();
        }

        if (MyAnimator != null)
        {
            MyAnimator = gameObject.GetComponent<Animator>();
        }
        else
        {
            MyAnimator = gameObject.AddComponent<Animator>();
        }
        _globalValueDic = Table_101_GlobalValue.Instance.DataDic;
    }

    protected virtual void Start()
    {
        Manager_Stage.Instance.LevelInit += StageLevelUp;
    }

    protected virtual void StageLevelUp() { }

    public abstract void Death();



    public void InitData(int index, int level)
    {
        _characterData = Table_110_Character.Instance.DataDic[index];
        // 기본 정보
        Name = _characterData.Name.ToString();
        Atk = _characterData.AtkBase + level * _characterData.AtkAdd;
        Hp = _characterData.HpBase + level * _characterData.HpAdd;
        // 히트 박스
        HitBoxCollider.size = new Vector2(_characterData.ScaleX, _characterData.ScaleY);
        // 애니메이션
        MyAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Character/AnimatorControllers/" + _characterData.AnimatorName);
        WalkAnimationSpeedUp();
    }

    public void WalkAnimationSpeedUp()
    {
        float aniSpeedAdd = _globalValueDic[10000009].FloatValue;
        float maxAniSpeed = _globalValueDic[10000003].FloatValue;
        int stageLevel = Manager_Stage.Instance.StageLevel;

        if(MyAnimator.speed <= maxAniSpeed)
        {
            MyAnimator.SetFloat("walkSpeed", 0.5f + stageLevel * aniSpeedAdd);
        }
    }

    public void Hit(Character attackChar)
    {
        Hp -= attackChar.Atk;
        Debug.Log(gameObject.name + "의 HP = " + Hp);

        if (Hp <= 0)
        {
            Death();
        }
    }
}
