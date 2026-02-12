using System;
using UnityEngine.UI;

[Serializable]
public class SlidedSystem
{
    public Slider slider;
    public Text text;

    public void SetText(int count) =>
        text.text = count.ToString();

    public int GetSiderValue() =>
        (int)slider.value;
}