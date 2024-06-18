using UnityEngine;

public enum StatsChangeType // ���� �߿�. ������ �Ұ��ε� �����ͺ��� ū�� ������ ����Ǳ� ������
{
    Add, // 0
    Multiple, // 1
    Override // 2
}

// ������ ����ó�� ����� �� �ְ� ������ִ� Attribute
[System.Serializable]

public class CharacterStat // ĳ���� ���ȿ��� AttackSO�� �־���. �ɷ�ġ�� ������ �� �ִ� Ŭ���� (�����������̳�)
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;
    public AttackSO attackSO;
}