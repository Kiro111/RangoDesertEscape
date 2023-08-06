using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость перемещения стикмена

    private Vector2 inputPosition; // Позиция ввода (касание или позиция мыши)
    private bool isMoving = false; // Флаг, указывающий на то, что стикмен движется

    private RectTransform rectTransform; // Ссылка на компонент RectTransform персонажа

    void Start()
    {
        // Получаем компонент RectTransform из текущего объекта
        rectTransform = GetComponent<RectTransform>();

        // Проверка на null, чтобы убедиться, что компонент был успешно получен
        if (rectTransform == null)
        {
            Debug.LogError("RectTransform not found!");
        }
    }

    void Update()
    {
        // Обработка свайпов на экране или перемещения мыши
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Начало свайпа
            if (touch.phase == TouchPhase.Began)
            {
                inputPosition = touch.position;
                isMoving = true;
            }
            // Перемещение свайпа
            else if (touch.phase == TouchPhase.Moved)
            {
                isMoving = true;
            }
            // Конец свайпа
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isMoving = false;
            }
        }
        // Обработка перемещения мыши
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
            // Получение текущей позиции свайпа или курсора мыши
            Vector2 currentInputPosition = Input.touchCount > 0 ? Input.GetTouch(0).position : (Vector2)Input.mousePosition;

            // Вычисление направления движения
            Vector2 direction = currentInputPosition - inputPosition;

            // Нормализация направления движения
            direction.Normalize();

            // Применение силы для перемещения стикмена
            Vector3 movement = new Vector3(direction.x, direction.y, 0f) * moveSpeed * Time.fixedDeltaTime;
            rectTransform.anchoredPosition3D += movement; // Используйте anchoredPosition3D вместо anchoredPosition

            inputPosition = currentInputPosition;
        }
    }

    // Вызывается, когда игрок начинает движение (например, когда кнопка движения нажата)
    public void StartMoving(Vector2 direction)
    {
        isMoving = true;
    }

    // Вызывается, когда игрок явно хочет остановить движение (например, когда кнопка остановки нажата)
    public void StopMoving()
    {
        isMoving = false;
    }
}
