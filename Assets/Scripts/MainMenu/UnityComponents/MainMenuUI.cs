using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public SlidedSystem playerCountSlider;
    public SlidedSystem timeToMoveSlider;

    public void OnPlayButtonClicked() =>
        SceneManager.LoadScene(SceneNames.GAMEPLAY);
}