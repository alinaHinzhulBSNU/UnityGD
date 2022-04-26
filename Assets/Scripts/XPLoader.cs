using UnityEngine;
using UnityEngine.UI;

public class XPLoader : MonoBehaviour
{
    public Slider progressBar; // progress bar ��� ����������� XP

    public Color32 progressBarColor; // ���� progress bar
    private Text value; // �������� ���������� ��� XP

    public float maxXP; // ����������� �������� XP
    public float deltaXP; // ����, � ���� ��������� XP
    private float currentXP; // ������� �������� XP

    private void Start()
    {
        this.value = GameObject.Find("Value").GetComponent<Text>();

        this.currentXP = 0; // �������� ��� XP � ������ ����

        if (!this.isInputCorrect()) // ���� ���������� ���������� ��������� ���, �� ������ �������� �� �������������
        {
            this.maxXP = 100;
            this.deltaXP = 10;
        }

        // ������������ min �� max �������� ��� progress bar
        this.progressBar.minValue = 0;
        this.progressBar.maxValue = this.maxXP;

        // ������������ ������� progress bar
        progressBar.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = progressBarColor;
    }

    private void Update() // ������� ��� � progress bar
    {
        this.progressBar.value = currentXP;
        this.value.text = currentXP + " / " + maxXP;
    }

    public void AddXP() // �������� XP �� ���� ���� ����� ����������� ������� XP
    {
        if(this.currentXP + deltaXP <= maxXP) this.currentXP += deltaXP;
    }

    public void ReduceXP() // �������� XP �� ���� ���� ����� 0
    {
        if(this.currentXP - deltaXP >= 0) this.currentXP -= deltaXP;
    }

    private bool isInputCorrect() // ����������� �������� XP �� ���� ������ �����, � ���� XP ��������� 
    {
        return maxXP % deltaXP == 0;
    }
}