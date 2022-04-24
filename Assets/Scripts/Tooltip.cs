using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public Text contentField; // �������, ���� ������ ����� � tooltip
    public List<int> tooltipLinesMaxChars; // ������� ������� � ������� �����
    public string text; // ����� � tooltip

    private void Start()
    {
        this.Hide(); // ����� ������� �������, ���� �� �� ���� ������� ���� ��� �������� �� ������ 
        text = contentField.text;
    }

    private void Update() 
    {
        this.contentField.text = this.FormatText(); // ��� �������� ����� ����������� �����
    }

    public void Show()
    {
        this.gameObject.SetActive(true); // �������� Tooltip
    }

    public void Hide()
    {
        this.gameObject.SetActive(false); // ������� Tooltip
    }

    private string FormatText()
    {
        // ����� 1: ���� ������ ������, �� �������� ���� ����� �� �������������
        if (tooltipLinesMaxChars.Count == 0) tooltipLinesMaxChars.Add(27);
        
        List<string> lines = new List<string>(); // �����
        string[] words = text.Split(' '); // �����, � ���� ���������� �����

        int lastWordIndex = 0; // ������ ���������� �����, �� ���� ������ �� ����������

        foreach (int maxLength in tooltipLinesMaxChars) // ��������� �� ����� ��� ����� �������
        {
            StringBuilder sb = new StringBuilder();

            for (int i = lastWordIndex; i < words.Length; i++) // ��������� �����, �� �� �� ���� ����� �� ����������
            {
                String result = sb.ToString();

                if(i != 0)
                {
                    sb.Append(' '); // ����� ������ ������ � ����� ������ �� �� ����
                }
                sb.Append(words[i]);

                if (sb.Length >= maxLength) // ���� ���� ����� ��� ����� - ������ ��������� ������ ����� (result) �� ����������
                {
                    lines.Add(result);
                    lastWordIndex = i;
                    break;
                }
                else if(i == words.Length - 1) // ������ ������ �����, ���� ���������, �� ����������
                {
                    lines.Add(words[i]);
                }
            }
        }

        // ����� 2: ���� � ������ �����, �� �� ������ ���������
        return string.Join("\n", lines.ToArray());
    }
}