using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class Character_Lobby : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public void Init(int charIndex)
    {
        string animatorName = Table_110_Character.Instance.DataDic[charIndex].AnimatorName;
        _animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Character/AnimatorControllers/" + animatorName);
        _animator.Play("Idle");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
