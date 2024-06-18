using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : Controller
    {
    private Camera camera;
    // 밑에있는 camera.ScreenToViewportPoint 사용에 필요해서 가져온것.
    protected override void Awake()
    {
        base.Awake();
        camera = Camera.main; // 메인카메라에 태그 붙어있는 카메라를 가져온다
    }

    // Controller로 가기전에 전처리 작업을 하는 곳
    // ㄴ normalized 같은 과정들을 처리한 후 컨트롤러에서 Invoke를 사용하여 부른다.
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
        // ↑ 실제 움직이는 처리는 PlayerMovement에서 함
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToViewportPoint(newAim);
        // ↑ 마우스 위치는 화면 좌표계에 있음. 월드포스로 바꿔줘야됨
        // = 카메라가 찍고 있는 위치를 마우스가 찍고있는 월드좌표로 바꿔준것

        newAim = (worldPos - (Vector2)transform.position).normalized;
        // transform 에서 World 의 좌표로 가는 거리는
        // World - transform 으로 구할 수 있다.


        CallLookEvent(newAim);
    }

    public void OnFire(InputValue value) // 플레이어 인풋에서 SendMessages 통해서
    {
        IsAttacking = value.isPressed; // IsAttacking을 누르고 있는지의 여부로
    }
}
