using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatHandler : MonoBehaviour 
{
    // �⺻���Ȱ� �߰����ȵ��� ����ؼ� ���� ������ ����ϴ� ������ ����
    // �׆� ������ �׳� �⺻ ���ȸ�!

    [SerializeField] private CharacterStat baseStat;
    public CharacterStat CurrentStat { get; private set; } // ���� �ɷ�ġ�� ������ �� �ֵ��� �ϴ� ��

    public List <CharacterStat> statModifiers = new List<CharacterStat>(); // (��������) � �߰����ȵ��� �ִ��� �迭�� ��Ƴ��°�.

    private void Awake()
    {
        UpdateCharacterStat();
    }

    private void UpdateCharacterStat()
    {
        AttackSO attackSO = null;
        if (baseStat.attackSO != null) // ���̽� ���� ��������
        {
            attackSO = Instantiate(baseStat.attackSO); // ���� �޶��� ���̱⶧���� �ν��Ͻÿ���Ʈ �ʿ�.
        }

        CurrentStat = new CharacterStat {  attackSO = attackSO };
        // TODO : ������ �⺻�ɷ�ġ�� ����Ǿ� ū �ǹ̰� ��������. �����δ� �ɷ�ġ��ȭ����� ����ȴ�.

        CurrentStat.statsChangeType = baseStat.statsChangeType;
        CurrentStat.maxHealth = baseStat.maxHealth;
        CurrentStat.speed = baseStat.speed;
    }
}