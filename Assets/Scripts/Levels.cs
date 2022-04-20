using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Score", menuName = "Levels")]
public class Levels : ScriptableObject{
    private int LEVELS_QUANTITY = 10; // �������� ������� ���� � ��
    private int GEMS = 5; // ������� �������� ��� �������� �� ����� �����
    private int CURRENT_LEVEL = 1; // �������� �����
    
    private int MAX_QUANTITY_OF_GEMS; // ����������� ������� ��������, ��� ����� ������ � �� ��� �������� (��� �������� �� ����� + ������ �� ���������� ���)

    private int requiredExperience; // ������� ��������, �� ���������� ������� ��� �������� �� ����� �����
    private int expCumulative; // �������� ������� �������� ��� �������� �� ��������� �����

    // ������ ������� ��������, �� ��� �������� ������� �� ����� �����
    public int experience; // �� ����������� � ��, � ��������� � ���� (��� ��������� ����)!
    
    public void levelUp()
    {
        MAX_QUANTITY_OF_GEMS = GEMS * LEVELS_QUANTITY;

        if ((experience < 0) || (experience > MAX_QUANTITY_OF_GEMS))
        {
            Debug.Log("Invalid value of experience!");
        } 
        else if (experience == MAX_QUANTITY_OF_GEMS)
        {
            Debug.Log("You have won!");
        }
        else
        {
            calcLevel();

            expCumulative = GEMS * CURRENT_LEVEL;
            requiredExperience = expCumulative - experience;

            Debug.Log("Level: " + CURRENT_LEVEL + " \tGoal: " + expCumulative + " gems \tGems to rich goal: " + requiredExperience + " gems");
        }
    }

    private void calcLevel()
    {
        if(experience != 0)
        {
            CURRENT_LEVEL = (int)Math.Ceiling((decimal)experience / GEMS);
        }
    }
}
