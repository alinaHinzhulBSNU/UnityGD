using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public Text contentField; // елемент, який містить текст в tooltip
    public List<int> tooltipLinesMaxChars; // кількість символів у кожному рядку
    public string text; // текст в tooltip

    private void Start()
    {
        this.Hide(); // треба сховати елемент, адже він має бути видимим лише при наведенні на кнопку 
        text = contentField.text;
    }

    private void Update() 
    {
        this.contentField.text = this.FormatText(); // при оновленні даних форматувати текст
    }

    public void Show()
    {
        this.gameObject.SetActive(true); // показати Tooltip
    }

    public void Hide()
    {
        this.gameObject.SetActive(false); // сховати Tooltip
    }

    private string FormatText()
    {
        // УМОВА 1: якщо список пустий, то створити один рядок за замовчуванням
        if (tooltipLinesMaxChars.Count == 0) tooltipLinesMaxChars.Add(27);
        
        List<string> lines = new List<string>(); // рядки
        string[] words = text.Split(' '); // слова, з яких складається текст

        int lastWordIndex = 0; // індекс останнього слова, що було додане до результату

        foreach (int maxLength in tooltipLinesMaxChars) // проходимо всі задані для рядків довжини
        {
            StringBuilder sb = new StringBuilder();

            for (int i = lastWordIndex; i < words.Length; i++) // проходимо слова, які ще не були додані до результату
            {
                String result = sb.ToString();

                if(i != 0)
                {
                    sb.Append(' '); // перед першим словом у тексті пробілу не має бути
                }
                sb.Append(words[i]);

                if (sb.Length >= maxLength) // якщо нове слово вже зайве - додаємо попередній варіант рядка (result) до результату
                {
                    lines.Add(result);
                    lastWordIndex = i;
                    break;
                }
                else if(i == words.Length - 1) // додаємо останнє слово, якщо необхідно, до результату
                {
                    lines.Add(words[i]);
                }
            }
        }

        // УМОВА 2: якщо є зайвий текст, то він просто обрізається
        return string.Join("\n", lines.ToArray());
    }
}