using System;
using UnityEngine;
using UnityEngine.UI;

namespace TicToe.UnityComponents
{
    public class GameHUD : Screen
    {
        public Text singText;
        public Text timerText;

        public void SetTurn(string currentID)
        {
            singText.text = "Ходит: " + currentID;
        }

        public void UpdateTextTimer(float time) =>
            timerText.text = Math.Round(time, 2).ToString();

        public void OnCloseGameClicked() =>
            Application.Quit();
    }
}