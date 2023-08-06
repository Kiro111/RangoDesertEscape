using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� ����������� ��������

    private Vector2 inputPosition; // ������� ����� (������� ��� ������� ����)
    private bool isMoving = false; // ����, ����������� �� ��, ��� ������� ��������

    private RectTransform rectTransform; // ������ �� ��������� RectTransform ���������

    void Start()
    {
        // �������� ��������� RectTransform �� �������� �������
        rectTransform = GetComponent<RectTransform>();

        // �������� �� null, ����� ���������, ��� ��������� ��� ������� �������
        if (rectTransform == null)
        {
            Debug.LogError("RectTransform not found!");
        }
    }

    void Update()
    {
        // ��������� ������� �� ������ ��� ����������� ����
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // ������ ������
            if (touch.phase == TouchPhase.Began)
            {
                inputPosition = touch.position;
                isMoving = true;
            }
            // ����������� ������
            else if (touch.phase == TouchPhase.Moved)
            {
                isMoving = true;
            }
            // ����� ������
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isMoving = false;
            }
        }
        // ��������� ����������� ����
        else if (Input.GetMouseButton(0))
        {
            inputPosition = Input.mousePosition;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            // ��������� ������� ������� ������ ��� ������� ����
            Vector2 currentInputPosition = Input.touchCount > 0 ? Input.GetTouch(0).position : (Vector2)Input.mousePosition;

            // ���������� ����������� ��������
            Vector2 direction = currentInputPosition - inputPosition;

            // ������������ ����������� ��������
            direction.Normalize();

            // ���������� ���� ��� ����������� ��������
            Vector3 movement = new Vector3(direction.x, direction.y, 0f) * moveSpeed * Time.fixedDeltaTime;
            rectTransform.anchoredPosition3D += movement; // ����������� anchoredPosition3D ������ anchoredPosition

            inputPosition = currentInputPosition;
        }
    }

    // ����������, ����� ����� �������� �������� (��������, ����� ������ �������� ������)
    public void StartMoving(Vector2 direction)
    {
        isMoving = true;
    }

    // ����������, ����� ����� ���� ����� ���������� �������� (��������, ����� ������ ��������� ������)
    public void StopMoving()
    {
        isMoving = false;
    }
}
