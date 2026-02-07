using System;
using UnityEngine;
using UnityEngine.UI;

namespace TicToe
{
    public class GameHUD : MonoBehaviour
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
    }
}