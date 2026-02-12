using System;
using UnityEngine;
using UnityEngine.UI;

namespace TicToe.UnityComponents
{
    public class GameHUD : Screen
    {
        public Text singText;
        public Text timerText;
        public Image timerImage;

        public void SetTurn(string currentID)
        {
            singText.text = "Ходит: " + currentID;
        }

        public void UpdateTextTimer(float time)
        {
            timerText.text = Math.Round(time, 1).ToString();

            SetColor(time);
        }

        private void SetColor(float time)
        {
            float percent = time / GameData.instance.timeToMove;
            
            var color =
                percent <= 0.2f ? Color.red :
                percent <= 0.5f ? Color.yellow :
                Color.green;

            timerText.color = color;
            timerImage.color = color;
        }
            

        public void OnCloseGameClicked() =>
            Application.Quit();
    }
}