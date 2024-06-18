using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour // OnMoveEvent와 OnLookEvent를 호출해주는 곳
{
    // 몬스터와 캐릭터의 공통적인 기능들이 있는곳
    // 여기서 Invoke할 수 있도록 event를 달아놨다.
    // Action에 등록을 할 수 있다.
    // ㄴ Move는 방향 Vector2를 받아 행동을 처리,
    // ㄴ Look은 마우스위치를 받아 처리.
    // CallMoveEvent는 그동안 등록되어있던 이벤트를 Invoke 해주는것
    // ㄴ 그건 OnMove에서 진행함.(PlayerInputController)

    public event Action<Vector2> OnMoveEvent; // Action은 무조건 void만 반환. 아니면 Func
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    protected bool IsAttacking { get; set; } // 상속받는 클래스에서만 작업 가능하도록 protected
    // OnFire를 했을때 true / false로 바뀌는것

    private float timeSinceLastAttack = float.MaxValue; // 저번 공격을 하고 몇초가 지났는지

    // protected 프로퍼티를 한 이유 : 나만 바꾸고싶지만 가져가는건 내 상속받는 클래스들도 볼 수 있게!
    protected CharacterStatHandler stats {  get; private set; }
    // get은 protected, set은 private으로 만들때

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
        // TODO : MAGIC NUMBER 수정
        // 값을 저장할 스탯시스템 만들건데 거기있는 숫자들을 바꿀것임
        if(timeSinceLastAttack < stats.CurrentStat.attackSO.delay) // 공격할때 쿨타임
        {
            timeSinceLastAttack += Time.deltaTime; // 이 시간이 누적됨
        }
        else if(IsAttacking && timeSinceLastAttack >= stats.CurrentStat.attackSO.delay)
            // stats.CurrentStat.attackSO.delay 이상이면 IsAttacking으로 누르고 있다는걸 확인.
        {
            timeSinceLastAttack = 0f; // 0.2f가 넘었다는 거니까 다시 0f로 만들어주고
            CallAttackEvent(stats.CurrentStat.attackSO); // 그 다음에 CallAttackEvent 호출하기
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?. 없으면 말고 있으면 실행
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
