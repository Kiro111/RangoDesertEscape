using UnityEngine;

public class TouchAimController : MonoBehaviour
{
    public float aimSpeedCanvas = 5f;
    public float minX = -100f;
    public float minY = -100f;
    public float maxX = 100f;
    public float maxY = 100f;

    private RectTransform targetRectTransform;
    private bool isInputActive;
    private Vector2 initialInputPosition;

    void Start()
    {
        targetRectTransform = GetComponent<RectTransform>();
        isInputActive = false;
    }

    void Update()
    {
        // ���������, ������� �� ������� �� ��������� ���������� ��� ����������� ���� �� ����������
        isInputActive = Input.touchCount > 0 || Input.GetMouseButton(0);

        if (isInputActive)
        {
            Vector2 inputPosition;

            // ���� ���������� ������������ ������� (��������� ����������), �������� ������� �������
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                inputPosition = touch.position;
            }
            // �����, ���� ������������ ���� (�� ����������), �������� ������� ����
            else
            {
                inputPosition = Input.mousePosition;
            }

            // ���� ��� ������ ������ ������� ��� ����������� ����, ��������� ��������� ���������
            if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                initialInputPosition = inputPosition;
            }

            Vector2 displacement = inputPosition - initialInputPosition;
            Vector2 anchoredPosition = targetRectTransform.anchoredPosition + displacement;

            // ������������ ������� ������� �� ���� X � Y
            anchoredPosition.x = Mathf.Clamp(anchoredPosition.x, minX, maxX);
            anchoredPosition.y = Mathf.Clamp(anchoredPosition.y, minY, maxY);

            // ������ ���������� ������ � ������� � ������ ��������
            targetRectTransform.anchoredPosition = Vector2.Lerp(
                targetRectTransform.anchoredPosition, anchoredPosition, Time.deltaTime * aimSpeedCanvas);
        }
    }
}
