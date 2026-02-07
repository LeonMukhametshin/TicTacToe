using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TicToe
{
    public class WinScreen : Screen
    {
        public Text text;

        public void SetWinner(SignType value)
        {
            switch (value)
            {
                case SignType.Cross:
                    text.text = "Крестик победил";
                    break;
                case SignType.Ring:
                    text.text = "Нолик победил";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public void OnRestartClicked() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}