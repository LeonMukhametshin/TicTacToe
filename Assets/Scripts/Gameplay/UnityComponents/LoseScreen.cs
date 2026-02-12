using UnityEngine.SceneManagement;

namespace TicToe.UnityComponents
{
    public class LoseScreen : Screen
    {
        public void OnRestartClicked() =>
            SceneManager.LoadScene(SceneNames.GAMEPLAY);

        public void OnGoToMenuClicked() =>
            SceneManager.LoadScene(SceneNames.MAIN_MENU);
    }
}