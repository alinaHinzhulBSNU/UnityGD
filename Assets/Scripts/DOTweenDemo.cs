using UnityEngine;
using DG.Tweening;

public class DOTweenDemo : MonoBehaviour
{
    private Transform tasks; // меню
    private bool isVisible; // видимість меню
    
    private float tasksInitialPosition; // початкове положення меню
    private float buttonInitialPosition; // початкове положення кнопки
    
    private float duration = 2; // тривалість анімації
    private float tasksShift = -20; // зсув меню
    private float buttonShift = -10; // зсув кнопки

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
            tasks.DOMoveX(tasksShift, duration); // перемістити меню
            transform.DOMoveX(buttonShift, duration); // перемістити кнопку
            transform.DOScale(-1, duration); // перевернути кнопку
        }
        else
        {
            tasks.DOMoveX(tasksInitialPosition, duration); // повернути меню в початкове положення
            transform.DOMoveX(buttonInitialPosition, duration); // повернути кнопку в початкове положення
            transform.DOScale(1, duration); // перевернути кнопку
        }

        isVisible = !isVisible;
    }
}