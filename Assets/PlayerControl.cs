using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 2f; // Ќачальна€ скорость движени€ персонажа

    private bool isMoving = true; // ‘лаг, определ€ющий, двигаетс€ ли персонаж вперед

    // Start вызываетс€ перед первым кадром обновлени€
    void Start()
    {
        // ѕерсонаж начинает двигатьс€ вперед автоматически при старте игры
        isMoving = true;
    }

    // Update вызываетс€ один раз за кадр
    void Update()
    {
        if (isMoving)
        {
            // –ассчитываем вектор движени€
            // ћы используем только ось Z (вперед), поэтому координаты X и Y оставл€ем равными 0
            Vector3 movement = new Vector3(0f, 0f, 1f) * moveSpeed * Time.deltaTime;

            // ѕеремещаем персонажа
            // ‘ункци€ Translate перемещает объект вдоль заданного вектора
            // ¬ результате персонаж будет двигатьс€ вперед автоматически
            // Time.deltaTime гарантирует плавное движение независимо от количества кадров в секунду
            transform.Translate(movement);
        }
    }
}
