using UnityEngine.SceneManagement;

namespace TicToe.UnityComponents
{
    public class LoseScreen : Screen
    {
        public void OnRestartClicked() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}