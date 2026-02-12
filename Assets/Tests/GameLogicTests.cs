using UnityEngine;
using Leopotam.Ecs;
using NUnit.Framework;
using TicToe.Services;
using TicToe.Components;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture] 
    public class GameLogicTests
    {
        [Test]
        public void CheckHorizontalCheinZero()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = CreateDictionary(world);

            var chainLenght = GameExtentions.GetLongestChain(cells, Vector2Int.zero);

            Assert.AreEqual(0, chainLenght);
        }

        [Test]
        public void CheckHorizontalCheinOne()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = CreateDictionary(world);

            cells[Vector2Int.zero].Get<Taken>().data = DefaultSign.firstSign;

            var chainLenght = cells.GetLongestChain(Vector2Int.zero);

            Assert.AreEqual(1, chainLenght);
        }

        [Test]
        public void CheckHorizontalCheinTwoLeft()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = CreateDictionary(world);

            cells[new Vector2Int(2, 0)].Get<Taken>().data = DefaultSign.firstSign;
            cells[new Vector2Int(1, 0)].Get<Taken>().data = DefaultSign.firstSign;

            var chainLenght = cells.GetLongestChain(new Vector2Int(2,0));

            Assert.AreEqual(2, chainLenght);
        }

        [Test]
        public void CheckHorizontalCheinTwoRight()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = CreateDictionary(world);

            cells[new Vector2Int(2, 0)].Get<Taken>().data = DefaultSign.firstSign;
            cells[new Vector2Int(1, 0)].Get<Taken>().data = DefaultSign.firstSign;

            var chainLenght = cells.GetLongestChain(new Vector2Int(1, 0));

            Assert.AreEqual(2, chainLenght);
        }

        [Test]
        public void CheckHorizontalCheinTwoVertical()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = CreateDictionary(world);

            cells[new Vector2Int(0, 1)].Get<Taken>().data = DefaultSign.firstSign;
            cells[new Vector2Int(0, 2)].Get<Taken>().data = DefaultSign.firstSign;

            var chainLenght = cells.GetLongestChain(new Vector2Int(0, 1));

            Assert.AreEqual(2, chainLenght);
        }

        [Test]
        public void CheckHorizontalCheinThreeVertical()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = CreateDictionary(world);

            cells[new Vector2Int(0, 0)].Get<Taken>().data = DefaultSign.firstSign;
            cells[new Vector2Int(0, 1)].Get<Taken>().data = DefaultSign.firstSign;
            cells[new Vector2Int(0, 2)].Get<Taken>().data = DefaultSign.firstSign;

            var chainLenght = cells.GetLongestChain(new Vector2Int(0, 0));

            Assert.AreEqual(3, chainLenght);
        }

        [Test]
        public void CheckHorizontalCheinThreeDiagonalOne()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = CreateDictionary(world);
                
            cells[new Vector2Int(0, 0)].Get<Taken>().data = DefaultSign.firstSign;
            cells[new Vector2Int(0, 1)].Get<Taken>().data = DefaultSign.firstSign;
            cells[new Vector2Int(0, 2)].Get<Taken>().data = DefaultSign.firstSign;

            var chainLenght = cells.GetLongestChain(new Vector2Int(0, 0));

            Assert.AreEqual(3, chainLenght);
        }

        [Test]
        public void CheckHorizontalCheinThreeDiagonalOther()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = CreateDictionary(world);

            cells[new Vector2Int(0, 2)].Get<Taken>().data = DefaultSign.firstSign;
            cells[new Vector2Int(1, 1)].Get<Taken>().data = DefaultSign.firstSign;
            cells[new Vector2Int(2, 0)].Get<Taken>().data = DefaultSign.firstSign;

            var chainLength = cells.GetLongestChain(new Vector2Int(1, 1));

            Assert.AreEqual(3, chainLength);
        }

        private static EcsEntity CreateCell(EcsWorld world, Vector2Int postion)
        {
            var entity = world.NewEntity();
            entity.Get<Position>().value = postion;
            entity.Get<Cell>();

            return entity;
        }

        private static Dictionary<Vector2Int, EcsEntity> CreateDictionary(EcsWorld world)
        {
            return new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world,new Vector2Int(0,0))},
                {new Vector2Int(0, 1), CreateCell(world,new Vector2Int(0,1))},
                {new Vector2Int(0, 2), CreateCell(world,new Vector2Int(0,2))},
                {new Vector2Int(1, 0), CreateCell(world,new Vector2Int(1,0))},
                {new Vector2Int(1, 1), CreateCell(world,new Vector2Int(1,1))},
                {new Vector2Int(1, 2), CreateCell(world,new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world,new Vector2Int(2,0))},
                {new Vector2Int(2, 1), CreateCell(world,new Vector2Int(2,1))},
                {new Vector2Int(2, 2), CreateCell(world,new Vector2Int(2,2))},
            };
        }
    }
}