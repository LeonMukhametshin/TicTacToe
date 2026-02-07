using UnityEngine;
using Leopotam.Ecs;
using TicToe.Components;
using System.Collections.Generic;

namespace TicToe.Services
{
    public class GameState
    {
        public SignType currentType = SignType.Ring;
        public Dictionary<Vector2Int, EcsEntity> cells = new();
    }
}