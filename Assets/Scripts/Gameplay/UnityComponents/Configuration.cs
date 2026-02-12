using System.Collections.Generic;
using UnityEngine;

namespace TicToe.UnityComponents
{
    [CreateAssetMenu]
    public class Configuration : ScriptableObject
    {
        [field: SerializeField] public int levelWidth { get; private set; } = 3;
        [field: SerializeField] public int levelHeight { get; private set; } = 3;
        [field: SerializeField] public int chainLenght { get; private set; } = 3;

        [field: SerializeField] public int timeToMove { get; private set; }

        [field: SerializeField] public CellView cellView { get; private set; }
        [field: SerializeField] public Vector2 offset { get; private set; }

        [SerializeField] public SignView[] signViews;

        public IReadOnlyList<SignView> readOnlySignList => signViews;

    }
}