using System;
using UnityEngine;

namespace Unvurn.Unity.Math
{
    public class DualGuidedLinearSmoother : ISmoother
    {
        public DualGuidedLinearSmoother(float center, float outerLo, float outerHi, float? innerLo = null,
            float? innerHi = null, float tolerance = 0.00001f)
        {
            _center = center;
            _outerLo = outerLo;
            _outerHi = outerHi;

            _innerLo = innerLo;
            _innerHi = innerHi;

            _tolerance = tolerance;

            _average = 0;
            _count = 0;
        }

        public float Smooth(float value)
        {
            if (_innerLo is null || _innerHi is null)
            {
                throw new InvalidOperationException("_innerLo or _innerHi are null");
            }

            return Smooth(value, (float)_innerLo, (float)_innerHi);
        }

        public float Smooth(float value, float innerLo, float innerHi)
        {
            lock (_lockSmooth)
            {
                var result = Smooth(value, _average, innerLo, innerHi);

                _average = (_average * _count + result) / (_count + 1);
                _count++;

                return result;
            }
        }

        public float Smooth(float value, float average)
        {
            if (_innerLo is null || _innerHi is null)
            {
                throw new InvalidOperationException("_innerLo or _innerHi are null");
            }

            return Smooth(value, average, (float)_innerLo, (float)_innerHi);
        }

        public float Smooth(float value, float average, float innerLo, float innerHi)
        {
            var result = 0f;

            var dLo = Mathf.Abs(average - innerLo);
            var dHi = Mathf.Abs(average - innerHi);

            if (dLo > _tolerance || dHi > _tolerance)
            {
                var d = 0f;
                if (value < average)
                {
                    d = dLo <= _tolerance
                        ? (_center - _outerHi) / (average - innerHi)
                        : (_center - _outerLo) / (average - innerLo);
                }
                else
                {
                    d = dHi <= _tolerance
                        ? (_center - _outerLo) / (average - innerLo)
                        : (_center - _outerHi) / (average - innerHi);
                }

                result = d * (value - average) + _center;
            }
            else
            {
                result = value;
            }

            return Mathf.Clamp(result, _outerLo, _outerHi);
        }

        private readonly float _center;
        private readonly float _outerLo;
        private readonly float _outerHi;
        private readonly float? _innerLo;
        private readonly float? _innerHi;

        private readonly float _tolerance;

        private float _average;
        private long _count;

        private readonly object _lockSmooth = new object();
    }
}
