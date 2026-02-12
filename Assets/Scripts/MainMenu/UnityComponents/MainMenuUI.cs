using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Slider slider;
    public Text playerCountText;

    public void SetPlayerCountText(int count) =>
        playerCountText.text = count.ToString();

    public int SlidetValue() =>
        (int)slider.value;
}