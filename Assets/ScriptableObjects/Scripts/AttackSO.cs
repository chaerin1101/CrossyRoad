using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAttackSO", menuName = "Controller/Attacks/Default", order = 0)]

public class AttackSO : ScriptableObject
{
    [Header("Attack Info")] // 데이터를 카테고리화 시키는 것. 공격에 들어가는 기능들
    public float size;
    public float delay;
    public float power;
    public float speed;
    public LayerMask target; // 공격이 어떤 레이어에만 맞는지

    [Header("Knock Back Info")] // 넉백 구현
    public bool isOnKnockBack;
    public float knockbackPower;
    public float knockbackTime;
}
