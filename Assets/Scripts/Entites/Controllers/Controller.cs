using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour // OnMoveEvent�� OnLookEvent�� ȣ�����ִ� ��
{
    // ���Ϳ� ĳ������ �������� ��ɵ��� �ִ°�
    // ���⼭ Invoke�� �� �ֵ��� event�� �޾Ƴ���.
    // Action�� ����� �� �� �ִ�.
    // �� Move�� ���� Vector2�� �޾� �ൿ�� ó��,
    // �� Look�� ���콺��ġ�� �޾� ó��.
    // CallMoveEvent�� �׵��� ��ϵǾ��ִ� �̺�Ʈ�� Invoke ���ִ°�
    // �� �װ� OnMove���� ������.(PlayerInputController)

    public event Action<Vector2> OnMoveEvent; // Action�� ������ void�� ��ȯ. �ƴϸ� Func
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    protected bool IsAttacking { get; set; } // ��ӹ޴� Ŭ���������� �۾� �����ϵ��� protected
    // OnFire�� ������ true / false�� �ٲ�°�

    private float timeSinceLastAttack = float.MaxValue; // ���� ������ �ϰ� ���ʰ� ��������

    // protected ������Ƽ�� �� ���� : ���� �ٲٰ������ �������°� �� ��ӹ޴� Ŭ�����鵵 �� �� �ְ�!
    protected CharacterStatHandler stats {  get; private set; }
    // get�� protected, set�� private���� ���鶧

    protected virtual void Awake()
    {
        stats = GetComponent<CharacterStatHandler>();
    }

    private void Update()
    {
        HandleAttackDelay(); 
    }

    private void HandleAttackDelay()
    {
        // TODO : MAGIC NUMBER ����
        // ���� ������ ���Ƚý��� ����ǵ� �ű��ִ� ���ڵ��� �ٲܰ���
        if(timeSinceLastAttack < stats.CurrentStat.attackSO.delay) // �����Ҷ� ��Ÿ��
        {
            timeSinceLastAttack += Time.deltaTime; // �� �ð��� ������
        }
        else if(IsAttacking && timeSinceLastAttack >= stats.CurrentStat.attackSO.delay)
            // stats.CurrentStat.attackSO.delay �̻��̸� IsAttacking���� ������ �ִٴ°� Ȯ��.
        {
            timeSinceLastAttack = 0f; // 0.2f�� �Ѿ��ٴ� �Ŵϱ� �ٽ� 0f�� ������ְ�
            CallAttackEvent(stats.CurrentStat.attackSO); // �� ������ CallAttackEvent ȣ���ϱ�
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?. ������ ���� ������ ����
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}
