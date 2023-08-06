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
        // ѕровер€ем, активно ли касание на мобильном устройстве или перемещение мыши на компьютере
        isInputActive = Input.touchCount > 0 || Input.GetMouseButton(0);

        if (isInputActive)
        {
            Vector2 inputPosition;

            // ≈сли устройство поддерживает касание (мобильное устройство), получаем позицию касани€
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                inputPosition = touch.position;
            }
            // »наче, если используетс€ мышь (на компьютере), получаем позицию мыши
            else
            {
                inputPosition = Input.mousePosition;
            }

            // ≈сли это начало нового касани€ или перемещени€ мыши, сохран€ем начальное положение
            if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                initialInputPosition = inputPosition;
            }

            Vector2 displacement = inputPosition - initialInputPosition;
            Vector2 anchoredPosition = targetRectTransform.anchoredPosition + displacement;

            // ќграничиваем позицию прицела по ос€м X и Y
            anchoredPosition.x = Mathf.Clamp(anchoredPosition.x, minX, maxX);
            anchoredPosition.y = Mathf.Clamp(anchoredPosition.y, minY, maxY);

            // ѕлавно перемещаем прицел в позицию с учетом смещени€
            targetRectTransform.anchoredPosition = Vector2.Lerp(
                targetRectTransform.anchoredPosition, anchoredPosition, Time.deltaTime * aimSpeedCanvas);
        }
    }
}
