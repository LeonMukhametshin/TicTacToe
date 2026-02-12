using DG.Tweening;
using UnityEngine;

namespace TicToe.UnityComponents
{
    [CreateAssetMenu]
    public class AnimationConfiguration : ScriptableObject
    {
        [field: SerializeField] public float duration { get; private set; }
        [field: SerializeField] public Vector2 startSize { get; private set; }
        [field: SerializeField] public Ease ease { get; private set; } = Ease.OutFlash;
    }
}