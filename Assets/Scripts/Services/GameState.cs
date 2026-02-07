using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

namespace TicToe
{
    public class GameState
    {
        public SignType currentType = SignType.Ring;
        public Dictionary<Vector2Int, EcsEntity> cells = new();
    }
}