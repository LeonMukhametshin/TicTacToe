using UnityEngine;
using Leopotam.Ecs;
using System.Collections.Generic;

namespace TicToe.Services
{
    public class GameState
    {
        public SignData currentSing = BaseSign.fistSign;
        public Dictionary<Vector2Int, EcsEntity> cells = new();
    }
}