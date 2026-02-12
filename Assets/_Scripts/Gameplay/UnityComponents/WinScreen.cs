using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TicToe.UnityComponents
{
    public class WinScreen : Screen
    {
        public Text text;

        public void SetWinner(string name)
        { 
            text.text = name + " ПОБЕДИЛ!";
        }

        public void OnRestartClicked() =>
            SceneManager.LoadScene(SceneNames.GAMEPLAY);

        public void OnGoToMenuClicked() =>
          SceneManager.LoadScene(SceneNames.MAIN_MENU);
    }
}