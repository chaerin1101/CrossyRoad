using System.Security.Cryptography;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;

    [SerializeField] private SpriteRenderer characterRenderer;

    private Controller controller;

    private void Awake()
    {
        controller = GetComponent<Controller>(); // Controller가 없으면 밑에서 Event를 등록할 수 없음
    }

    private void Start()
    {
        controller.OnLookEvent += OnAim; // OnLookEvent에 OnAim을 등록
    }

    private void OnAim(Vector2 direction)
    {
        RotateArm(direction);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // 회전을 오일러에 넣을 것이기 때문에 Radian과 degree를 추가해줘야됨

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f; // 회전이 적용되는 과정
        // ↑ Abs = AbsolutValue = 절댓값
        // x축(가로) 기준으로 절대값이 90도 보다 크면 뒤집어라
        // ㅡㅡㅡ 0도(올라가면 90도/내려가면 -90도)
        // 올라가서 90도보다 작아지면 왼쪽으로, 내려가서 -90도보다 커지면 오른쪽으로

        armPivot.rotation = Quaternion.Euler(0, 0, rotZ); // 오일러 각을 넣어주는것. z축을 회전하기위해.
        // ↑ 캐릭터에서 마우스를 바라보는 각도를 얻은 것

    }

}