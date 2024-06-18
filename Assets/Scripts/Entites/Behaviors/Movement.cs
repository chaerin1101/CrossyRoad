using UnityEngine;

public class Movement : MonoBehaviour
{
    // 실제로 이동이 일어날 컴포넌트

    private Controller controller; // 컨트롤러가 필요
    private Rigidbody2D movementRigidbody; // 실제 이동이 있기 때문에 필요
    private CharacterStatHandler characterStatHandler;

    private Vector2 movementDirection = Vector2.zero; // 오류날 수도 있어서 =기본값 입력

    private void Awake()
    {
        // Awake 는 주로 내 컴포넌트 안에서 끝나는거

        // ↓ 캐싱. 컨트롤러를 가져오는 작업
        // controller랑 Movement랑 같은 게임 오브젝트에 있다는 가정. 없으면 find로 찾아줘야됨.
        controller = GetComponent<Controller>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        characterStatHandler = GetComponent<CharacterStatHandler>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
        // OnMove할때 발생할 수 있는 다양한 Event. 여기에 다양한 컴포넌트를 추가한다음
        // Controller에 있는 Invoke만 하면 되기때문에 훨씬 더 편하다.
        // 확장가능한 구조
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
        // 움직인다면 여기서 움직여라 하고 걸어놓기만 함.
        // 실제 움직임은 FixedUpdate에서 ApplyMovement
    }

    private void FixedUpdate()
    {
        // FixedUpdate는 물리업데이트 관련
        // rigidbody의 값을 바꾸니까 FixedUpdate
        ApplyMovement(movementDirection);
    }

    private void ApplyMovement(Vector2 direction) // ApplyMovement가 실행이 안됨 -> FixedUpdate
    {
        direction = direction * characterStatHandler.CurrentStat.speed;
        // direction *5 처럼 그냥 숫자를 넣으면 나중에 변경 시 코드를 다시 짜야되는 문제가 있음
        // 인스펙터에서 수정할수도 있지만 그러면 고정된 숫자만 사용해야됨.
        // 변하는 값이기 때문에 상수로 넣을 수 있는 값이 아님.
        // private CharacterStatHandler characterStatHandler; 로 변수를 넣어주는 것이 좋다

        movementRigidbody.velocity = direction;
    }

}