using System;
using UnityEngine.UI;
using TicToe.Components;
using UnityEngine.SceneManagement;

namespace TicToe.UnityComponents
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