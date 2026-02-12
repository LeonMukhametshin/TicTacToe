using System;
using UnityEngine;
using UnityEngine.UI;
using TicToe.Components;

namespace TicToe.UnityComponents
{
    public class GameHUD : Screen
    {
        public Text singText;
        public Text timerText;

        public void SetTurn(SignType gameStateCurrentType)
        {
            switch (gameStateCurrentType)
            {
                case SignType.Cross:
                    singText.text = "Ходит крестик";
                    break;
                case SignType.Square:
                    singText.text = "Ходит нолик";
                    break;
                case SignType.Triangle:
                    singText.text = "Ходит треугольник";
                    break;
                case SignType.Star:
                    singText.text = "Ходит звезда";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateCurrentType), gameStateCurrentType, null);
            }
        }

        public void UpdateTextTimer(float time) =>
            timerText.text = Math.Round(time, 2).ToString();

        public void OnCloseGameClicked() =>
            Application.Quit();
    }
}