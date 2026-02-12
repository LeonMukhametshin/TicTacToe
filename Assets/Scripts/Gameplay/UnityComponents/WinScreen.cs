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
                case SignType.Square:
                    text.text = "Квадрат победил";
                    break;
                case SignType.Triangle:
                    text.text = "Треугольник победил";
                    break;
                case SignType.Star:
                    text.text = "Звезда победила";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public void OnRestartClicked() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}