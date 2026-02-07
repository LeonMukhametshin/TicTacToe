using UnityEngine.SceneManagement;

namespace TicToe
{
    public class LoseScreen : Screen
    {
        public void OnRestartClicked() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}