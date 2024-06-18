using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatHandler : MonoBehaviour 
{
    // 기본스탯과 추가스탯들을 계산해서 최종 스탯을 계산하는 로직이 있음
    // 그넫 지금은 그냥 기본 스탯만!

    [SerializeField] private CharacterStat baseStat;
    public CharacterStat CurrentStat { get; private set; } // 지금 능력치를 저장할 수 있도록 하는 것

    public List <CharacterStat> statModifiers = new List<CharacterStat>(); // (버프같은) 어떤 추가스탯들이 있는지 배열로 담아놓는것.

    private void Awake()
    {
        UpdateCharacterStat();
    }

    private void UpdateCharacterStat()
    {
        AttackSO attackSO = null;
        if (baseStat.attackSO != null) // 베이스 스탯 가져오기
        {
            attackSO = Instantiate(baseStat.attackSO); // 서로 달라질 것이기때문에 인스턴시에이트 필요.
        }

        CurrentStat = new CharacterStat {  attackSO = attackSO };
        // TODO : 지금은 기본능력치만 적용되어 큰 의미가 있진않음. 앞으로는 능력치강화기능이 적용된다.

        CurrentStat.statsChangeType = baseStat.statsChangeType;
        CurrentStat.maxHealth = baseStat.maxHealth;
        CurrentStat.speed = baseStat.speed;
    }
}