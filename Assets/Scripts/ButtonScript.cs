using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Tooltip tooltip;

    public void PointerEnter()
    {
        tooltip.Show();
    }

    public void PointerExit()
    {
        tooltip.Hide();
    }
}
