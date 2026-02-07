using System;
using UnityEngine;
using UnityEngine.UI;
using TicToe.Components;

namespace TicToe.UnityComponents
{
    public class GameHUD : Screen
    {
        public Text text;

        public void SetTurn(SignType gameStateCurrentType)
        {
            switch (gameStateCurrentType)
            {
                case SignType.Cross:
                    text.text = "Ходит крестик";
                    break;
                case SignType.Ring:
                    text.text = "Ходит нолик";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateCurrentType), gameStateCurrentType, null);
            }
        }


        public void OnCloseGameClicked() =>
            Application.Quit();
    }
}