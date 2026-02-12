using UnityEngine;

namespace TicToe.UnityComponents
{
    public class Screen : MonoBehaviour
    {
        public void Show(bool state) =>
            gameObject.SetActive(state);
    }
}