using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public string Name { get; private set; }
    public int MaxHp { get; private set; }
    public int CurHp { get; private set; }
    public int Atk { get; private set; }
    public ECharacterType Type { get; private set; }

    public BoxCollider2D HitBoxCollider { get; private set; }

    protected Dictionary<int, GlobalValueData> _globalValueDic;

    private CharacterData _characterData;
    private Animator _animator;

    protected virtual void Awake()
    {
        _characterData = new CharacterData();

        if (HitBoxCollider == null)
        {
            HitBoxCollider = gameObject.AddComponent<BoxCollider2D>();
        }

        if (_animator == null)
        {
            _animator = gameObject.AddComponent<Animator>();
        }
        _globalValueDic = Table_101_GlobalValue.Instance.DataDic;
    }

    protected virtual void Start()
    {
        Manager_Stage.Instance.LevelUpAction += StageLevelUp;
    }

    protected virtual void StageLevelUp() { }

    public abstract void Death();

    public void InitData(int index, int level)
    {
        _characterData = Table_110_Character.Instance.DataDic[index];
        // 기본 정보
        Name = _characterData.Name.ToString();
        Atk = _characterData.AtkBase + level * _characterData.AtkAdd;
        MaxHp = _characterData.HpBase + level * _characterData.HpAdd;
        CurHp = _characterData.HpBase + level * _characterData.HpAdd;
        Type = _characterData.Type;
        // 히트 박스 및 크기
        Vector2 charScale = new Vector2(_characterData.ScaleX, _characterData.ScaleY);
        HitBoxCollider.size = charScale;
        transform.localScale = charScale;
        // 애니메이션
        _animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Character/AnimatorControllers/" + _characterData.AnimatorName);
        WalkAnimationSpeedUp();
    }

    public void WalkAnimationSpeedUp()
    {
        float aniSpeedAdd = _globalValueDic[10000009].FloatValue;
        float maxAniSpeed = _globalValueDic[10000003].FloatValue;
        int stageLevel = Manager_Stage.Instance.StageLevel;

        if(_animator.speed <= maxAniSpeed)
        {
            _animator.SetFloat("walkSpeed", 0.5f + stageLevel * aniSpeedAdd);
        }
    }

    /// <summary>
    /// aniIndex(0:Walk, 1:Attack, 2:Death, 3:Jump, 4:Hit, 5:Resurrection)
    /// </summary>
    public void PlayAnimation(int aniIndex)
    {
        _animator.SetInteger("aniIndex", aniIndex);
    }

    public void Hit(Character attackChar)
    {
        CurHp -= attackChar.Atk;
        Debug.Log(gameObject.name + "의 HP = " + CurHp);

        if (CurHp <= 0)
        {
            // Kill
            if (attackChar == Character_Player.Instance)
            {
                Manager_Stage.Instance.AddKillScore();
                Debug.Log("킬!");
            }
            PlayAnimation(2);
        }
    }

    protected void SetHp(int hp)
    {
        CurHp = hp;
    }

    protected void SetHitBox(Vector2 size)
    {
        HitBoxCollider.size = size;
    }

    protected void SetHitBox(Vector2 size, Vector2 offset)
    {
        HitBoxCollider.size = size;
        HitBoxCollider.offset = offset;
    }
}
