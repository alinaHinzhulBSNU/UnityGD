using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Score", menuName = "Levels")]
public class Levels : ScriptableObject{
    private int LEVELS_QUANTITY = 10; // загальна кількість рівнів у грі
    private int GEMS = 5; // кількість кристалів для переходу на новий рівень
    private int CURRENT_LEVEL = 1; // поточний рівень
    
    private int MAX_QUANTITY_OF_GEMS; // максимальна кількість кристалів, яку можна зібрати у грі для перемоги (для переходу по рівнях + виграш на останньому рівні)

    private int requiredExperience; // кількість кристалів, які залишилось здобути для переходу на новий рівень
    private int expCumulative; // загальна кількість кристалів для переходу на наступний рівень

    // Наявна кількість кристалів, від якої залежить перехід на інший рівень
    public int experience; // Не здобувається у грі, а вводиться в меню (для спрощення коду)!
    
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
