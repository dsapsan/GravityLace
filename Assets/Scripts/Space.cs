using UnityEngine;

namespace GravityLace
{
    public class Space
    {
        public const double ScaleFactor = 149597870691d * 0.1d; // 1 au = 10 units

        //public const double TimeSpeed = 86400d; //Day per second
        public const double TimeSpeed = 31558432.98d * 0.1d; //Year per ten seconds

        public static double SpaceDeltaTime => TimeSpeed * Time.fixedDeltaTime;

        public static Vector3d GetSpacePosition(Vector3 position)
        {
            return (Vector3d) position * ScaleFactor;
        }

        public static Vector3 GetPositionFromSpace(Vector3d position)
        {
            return (Vector3) (position / ScaleFactor);
        }
    }
}
