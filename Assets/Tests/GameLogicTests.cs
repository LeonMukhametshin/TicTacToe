using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using TicToe;
using Leopotam.Ecs;

namespace Tests
{
    [TestFixture] 
    public class GameLogicTests
    {
        [Test]
        public void CheckHorizontalCheinZero()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new()
            {
                {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0,0))},
                {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0,1))},
                {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0,2))},
                {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1,0))},
                {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1,1))},
                {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2,0))},
                {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2,1))},
                {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2,2))}
            };

            var chainLenght = GameExtentions.GameLongestChain(cells, Vector2Int.zero);

            Assert.AreEqual(0, chainLenght);
        }

        [Test]
        public void CheckHorizontalCheinOne()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new()
            {
                {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0,0))},
                {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0,1))},
                {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0,2))},
                {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1,0))},
                {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1,1))},
                {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2,0))},
                {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2,1))},
                {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2,2))}
            };

            cells[Vector2Int.zero].Get<Taken>().value = SignType.Cross;

            var chainLenght = cells.GameLongestChain(Vector2Int.zero);

            Assert.AreEqual(1, chainLenght);
        }

        [Test]
        public void CheckHorizontalCheinTwoLeft()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new()
            {
                {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0,0))},
                {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0,1))},
                {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0,2))},
                {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1,0))},
                {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1,1))},
                {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2,0))},
                {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2,1))},
                {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2,2))}
            };

            cells[new Vector2Int(2, 0)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(1, 0)].Get<Taken>().value = SignType.Cross;

            var chainLenght = cells.GameLongestChain(new Vector2Int(2,0));

            Assert.AreEqual(2, chainLenght);
        }

        [Test]
        public void CheckHorizontalCheinTwoRight()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new()
            {
                {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0,0))},
                {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0,1))},
                {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0,2))},
                {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1,0))},
                {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1,1))},
                {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2,0))},
                {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2,1))},
                {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2,2))}
            };

            cells[new Vector2Int(2, 0)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(1, 0)].Get<Taken>().value = SignType.Cross;

            var chainLenght = cells.GameLongestChain(new Vector2Int(1, 0));

            Assert.AreEqual(2, chainLenght);
        }

        [Test]
        public void CheckHorizontalCheinTwoVertical()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new()
            {
                {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0,0))},
                {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0,1))},
                {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0,2))},
                {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1,0))},
                {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1,1))},
                {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2,0))},
                {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2,1))},
                {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2,2))}
            };

            cells[new Vector2Int(0, 1)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(0, 2)].Get<Taken>().value = SignType.Cross;

            var chainLenght = cells.GameLongestChain(new Vector2Int(0, 1));

            Assert.AreEqual(2, chainLenght);
        }

        [Test]
        public void CheckHorizontalCheinThreeVertical()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new()
            {
                {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0,0))},
                {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0,1))},
                {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0,2))},
                {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1,0))},
                {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1,1))},
                {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2,0))},
                {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2,1))},
                {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2,2))}
            };

            cells[new Vector2Int(0, 0)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(0, 1)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(0, 2)].Get<Taken>().value = SignType.Cross;

            var chainLenght = cells.GameLongestChain(new Vector2Int(0, 0));

            Assert.AreEqual(3, chainLenght);
        }

        [Test]
        public void CheckHorizontalCheinThreeDiagonalOne()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new()
            {
                {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0,0))},
                {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0,1))},
                {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0,2))},
                {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1,0))},
                {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1,1))},
                {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2,0))},
                {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2,1))},
                {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2,2))}
            };

            cells[new Vector2Int(0, 0)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(0, 1)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(0, 2)].Get<Taken>().value = SignType.Cross;

            var chainLenght = cells.GameLongestChain(new Vector2Int(0, 0));

            Assert.AreEqual(3, chainLenght);
        }

        [Test]
        public void CheckHorizontalCheinThreeDiagonalOther()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new()
            {
                {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0,0))},
                {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0,1))},
                {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0,2))},
                {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1,0))},
                {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1,1))},
                {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2,0))},
                {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2,1))},
                {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2,2))}
            };

            cells[new Vector2Int(0, 0)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(1, 0)].Get<Taken>().value = SignType.Cross;
            cells[new Vector2Int(2, 0)].Get<Taken>().value = SignType.Cross;

            var chainLenght = cells.GameLongestChain(new Vector2Int(0, 0));

            Assert.AreEqual(3, chainLenght);
        }

        private static EcsEntity CreateCell(EcsWorld world, Vector2Int postion)
        {
            var entity = world.NewEntity();
            entity.Get<Position>().value = postion;
            entity.Get<Cell>();

            return entity;
        }
    }
}
