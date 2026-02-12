using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public Slider slider;
    public Text playerCountText;

    public void SetPlayerCountText(int count) =>
        playerCountText.text = count.ToString();

    public int GetSliderValue() =>
        (int)slider.value;

    public void OnPlayButtonClicked() =>
        SceneManager.LoadScene(SceneNames.GAMEPLAY);
}