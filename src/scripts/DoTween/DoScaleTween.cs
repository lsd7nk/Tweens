using UnityEngine;

namespace Tween
{
    [RequireComponent(typeof(Transform))]
    public sealed class DoScaleTween : DoTween<Transform, Vector3>
    {
        protected override Vector3 TargetValue
        {
            get => TargetComponent.localScale;
            set => TargetComponent.localScale = value;
        }

        protected override void StartLoop(float delay)
        {
            TargetValue = startValue;
            tweenCase = TargetComponent.DOScale(endValue, duration);

            base.StartLoop(delay);
        }

        protected override void IncrementLoopChangeValues()
        {
            var difference = endValue - startValue;

            startValue = endValue;
            endValue += difference;
        }
    }
}
