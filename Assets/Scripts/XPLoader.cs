using UnityEngine;
using UnityEngine.UI;

public class XPLoader : MonoBehaviour
{
    public Slider progressBar; // progress bar для відображення XP

    public Color32 progressBarColor; // колір progress bar
    private Text value; // текстова інформація про XP

    public float maxXP; // максимальне значення XP
    public float deltaXP; // крок, з яким змінюється XP
    private float currentXP; // поточне значення XP

    private void Start()
    {
        this.value = GameObject.Find("Value").GetComponent<Text>();

        this.currentXP = 0; // спочатку гри XP у гравця немає

        if (!this.isInputCorrect()) // якщо користувач використав некоректні дані, то ввести значення за замовчуванням
        {
            this.maxXP = 100;
            this.deltaXP = 10;
        }

        // налаштування min та max значення для progress bar
        this.progressBar.minValue = 0;
        this.progressBar.maxValue = this.maxXP;

        // встановлення кольору progress bar
        progressBar.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = progressBarColor;
    }

    private void Update() // оновити дані в progress bar
    {
        this.progressBar.value = currentXP;
        this.value.text = currentXP + " / " + maxXP;
    }

    public void AddXP() // поточний XP не може бути більше максимальної кількості XP
    {
        if(this.currentXP + deltaXP <= maxXP) this.currentXP += deltaXP;
    }

    public void ReduceXP() // поточний XP не може бути менше 0
    {
        if(this.currentXP - deltaXP >= 0) this.currentXP -= deltaXP;
    }

    private bool isInputCorrect() // максимальне значення XP має бути кратне кроку, з яким XP змінюється 
    {
        return maxXP % deltaXP == 0;
    }
}