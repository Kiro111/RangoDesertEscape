using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 2f; // ��������� �������� �������� ���������

    private bool isMoving = true; // ����, ������������, ��������� �� �������� ������

    // Start ���������� ����� ������ ������ ����������
    void Start()
    {
        // �������� �������� ��������� ������ ������������� ��� ������ ����
        isMoving = true;
    }

    // Update ���������� ���� ��� �� ����
    void Update()
    {
        if (isMoving)
        {
            // ������������ ������ ��������
            // �� ���������� ������ ��� Z (������), ������� ���������� X � Y ��������� ������� 0
            Vector3 movement = new Vector3(0f, 0f, 1f) * moveSpeed * Time.deltaTime;

            // ���������� ���������
            // ������� Translate ���������� ������ ����� ��������� �������
            // � ���������� �������� ����� ��������� ������ �������������
            // Time.deltaTime ����������� ������� �������� ���������� �� ���������� ������ � �������
            transform.Translate(movement);
        }
    }
}
