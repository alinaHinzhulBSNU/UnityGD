using UnityEngine;
using DG.Tweening;

public class DOTweenDemo : MonoBehaviour
{
    private Transform tasks; // ����
    private bool isVisible; // �������� ����
    
    private float tasksInitialPosition; // ��������� ��������� ����
    private float buttonInitialPosition; // ��������� ��������� ������
    
    private float duration = 2; // ��������� �������
    private float tasksShift = -20; // ���� ����
    private float buttonShift = -10; // ���� ������

    void Start()
    {
        isVisible = true;
        tasks = GameObject.FindWithTag("tasks").GetComponent<Transform>();
        tasksInitialPosition = tasks.position.x;
        buttonInitialPosition = transform.position.x;
    }
    
    public void Animate()
    {
        if (isVisible)
        {
            tasks.DOMoveX(tasksShift, duration); // ���������� ����
            transform.DOMoveX(buttonShift, duration); // ���������� ������
            transform.DOScale(-1, duration); // ����������� ������
        }
        else
        {
            tasks.DOMoveX(tasksInitialPosition, duration); // ��������� ���� � ��������� ���������
            transform.DOMoveX(buttonInitialPosition, duration); // ��������� ������ � ��������� ���������
            transform.DOScale(1, duration); // ����������� ������
        }

        isVisible = !isVisible;
    }
}