namespace Unvurn.Unity.Math
{
    public static class Smoother
    {
        public static ISmoother DualGuidedLinearSmoother(float center, float outerLo, float outerHi,
            float? innerLo = null, float? innerHi = null, float tolerance = 0.00001f)
        {
            return new DualGuidedLinearSmoother(center, outerLo, outerHi, innerLo, innerHi, tolerance);
        }
    }
}
