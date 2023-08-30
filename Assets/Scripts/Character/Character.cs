using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public string Name { get; private set; }
    public int Hp { get; private set; }
    public int Atk { get; private set; }
    public BoxCollider2D HitBoxCollider { get; private set; }

    /// <summary>
    /// aniIndex(0: Walk, 1: Attack, 2: Death)
    /// </summary>
    public Animator MyAnimator { get; private set; }

    private CharacterData _characterData;

    protected virtual void Awake()
    {
        _characterData = new CharacterData();

        if (HitBoxCollider == null)
        {
            HitBoxCollider = gameObject.AddComponent<BoxCollider2D>();
        }
        if (MyAnimator == null)
        {
            MyAnimator = gameObject.AddComponent<Animator>();
        }
    }

    protected virtual void OnEnable()
    {

    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    public abstract void Attack();
    public abstract void Death();

    public void InitData(int index, int level)
    {
        _characterData = Table_110_Character.Instance.DataList.Find(o => o.Index == index);
        Name = _characterData.Name.ToString();
        Atk = _characterData.AtkBase + level * _characterData.AtkAdd;
        Hp = _characterData.HpBase + level * _characterData.HpAdd;
        HitBoxCollider.size = new Vector2(_characterData.ScaleX, _characterData.ScaleY);
        MyAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Character/AnimatorControllers/" + _characterData.AnimatorName);
        MyAnimator.speed = Manager_Stage.Instance.Level;
    }

    public void SetWalkAnimationSpeed(float speed)
    {
        MyAnimator.SetFloat("walkSpeed", speed);
    }

    public void Hit(Character attackChar)
    {
        Hp -= attackChar.Atk;
        Debug.Log(gameObject.name + "ÀÇ HP = " + Hp);

        if (Hp <= 0)
        {
            Death();
        }
    }
}
