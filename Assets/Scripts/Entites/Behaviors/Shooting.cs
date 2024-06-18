using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooting : MonoBehaviour // 컴포넌트처럼 쓸것은 모노비헤이비어?
{
    private Controller controller;

    [SerializeField] private Transform projectileSpawnPosition; // 어디서 총알이 생성될지 지정(불렛스폰포인트)
    private Vector2 aimDirection = Vector2.right; // 기본은 벡터2.라이트

    public GameObject TestPrefab; 

    private void Awake()
    {
        controller = GetComponent<Controller>();
    }

    private void Start()
    {
        controller.OnAttackEvent += OnShoot; // 컨트롤러에서 온어택이벤트 등록. 온슛 함수만들기

        controller.OnLookEvent += OnAim; // 컨트롤러에 온룩이벤트 등록. 온에임 함수만들기
    }

    private void OnAim(Vector2 direction) // 마우스 위치는 인풋컨트롤러에서 변환을 해놓음. 그걸 aimDirection이라고 해서 넣어줄것.
    {
        aimDirection = direction; // 마우스 움직일때마다 aimDirection을 바꿔준다
    }

    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackSO rangedAttackSO = attackSO as RangedAttackSO;
        if (rangedAttackSO == null) return; // rangeAttackSO로 형변환을 해보는것. 실패하면 null 이 뜬다.

        float projectilesAngleSpace = rangedAttackSO.multipleProjectilesAngle;
        int numberOfProjectilesPerShot = rangedAttackSO.numberOfProjectilePerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackSO.multipleProjectilesAngle;
        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + i * projectilesAngleSpace;
            float randomSpread = Random.Range(-rangedAttackSO.spread, rangedAttackSO.spread);
            angle += randomSpread;
            CreateProjectile(rangedAttackSO, angle);
        }


        // CreateProjectile(); // Projectile = 투사체(표창이나 화살같은 날라가는 것)
    }

    private void CreateProjectile(RangedAttackSO rangedAttackSO, float angle)
    {
        GameObject obj = Instantiate(TestPrefab);
        obj.transform.position = projectileSpawnPosition.position;
        ProjectileController attackController = obj.GetComponent<ProjectileController> ();
        attackController.InitializeAttack(RotateVector2(aimDirection, angle), rangedAttackSO);

        //Instantiate(TestPrefab, projectileSpawnPosition.position, Quaternion.identity);
        // 테스트 프리팹을 생생한다. 프로젝타일 스폰포지션 위치에서. 회전없이.
        // TODO : 날라가지 않는 것을 날라가게 만들것. 지금은 둥둥떠다니는 상태
    }

    private static Vector2 RotateVector2(Vector2 v, float angle)
    {
        return Quaternion.Euler(0f, 0f, angle) * v;
    }

}