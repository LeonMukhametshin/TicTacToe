using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TicToe.UnityComponents
{
    public class WinScreen : Screen
    {
        public Text text;

        public void SetWinner(string name)
        { 
            text.text = name + " WIN!";
        }

        public void OnRestartClicked() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}