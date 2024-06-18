using UnityEngine;

[CreateAssetMenu(fileName = "RangedAttackSO", menuName = "Controller/Attacks/Ranged", order = 1)]
public class RangedAttackSO : AttackSO
{
    [Header("Ranged Attack Info")]
    public string bulletNameTag;
    public float duration; // 얼만큼의 시간동안 나가는지
    public float spread; // 얼마나 퍼질지
    public int numberOfProjectilePerShot; // 한번 나갈때 몇개씩 나가는지
    public float multipleProjectilesAngle;
    public Color projectileColor;
}
