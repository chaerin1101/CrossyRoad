using UnityEngine;

public enum StatsChangeType // 순서 중요. 정렬을 할것인데 작은것부터 큰것 순서로 적용되기 때문에
{
    Add, // 0
    Multiple, // 1
    Override // 2
}

// 데이터 폴더처럼 사용할 수 있게 만들어주는 Attribute
[System.Serializable]

public class CharacterStat // 캐릭터 스탯에는 AttackSO를 넣어줌. 능력치를 저장할 수 있는 클래스 (데이터컨테이너)
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;
    public AttackSO attackSO;
}