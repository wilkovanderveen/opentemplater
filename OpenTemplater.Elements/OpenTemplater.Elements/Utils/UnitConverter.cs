namespace OpenTemplater.Elements.Utils
{
    public static class UnitConverter
    {
        private const float POINTS_PER_MILIMETER = 2.83464567f;

        public static float GetPoints(float milimeters)
        {
            return milimeters*POINTS_PER_MILIMETER;
        }
    }
}