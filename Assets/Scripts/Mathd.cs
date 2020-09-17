// Source: https://github.com/sldsmkd/vector3d
// Licence: The Unlicense
using System;

namespace UnityEngine
{
    /// <summary>
    /// A collection of common math functions using doubles.
    /// </summary>
    public struct Mathd
    {
        public const double E = Math.E;
        public const double PI = Math.PI;
        public const double Infinity = double.PositiveInfinity;
        public const double NegativeInfinity = double.NegativeInfinity;
        public const double Deg2Rad = Math.PI / 180d;
        public const double Rad2Deg = 180d / Math.PI;
        public const double Epsilon = 1.401298E-45d;

        /// <summary>
        /// Returns the sine of angle f.
        /// </summary>
        /// <param name="d">The input angle, in radians.</param>
        /// <returns>The return value between -1 and +1.</returns>
        public static double Sin(double d)
        {
            return Math.Sin(d);
        }

        /// <summary>
        /// Returns the cosine of angle f.
        /// </summary>
        /// <param name="d">The input angle, in radians.</param>
        /// <returns>The return value between -1 and 1.</returns>
        public static double Cos(double d)
        {
            return Math.Cos(d);
        }

        /// <summary>
        /// Returns the tangent of angle f in radians.
        /// </summary>
        public static double Tan(double d)
        {
            return Math.Tan(d);
        }

        /// <summary>
        /// Returns the arc-sine of f - the angle in radians whose sine is f.
        /// </summary>
        public static double Asin(double d)
        {
            return Math.Asin(d);
        }

        /// <summary>
        /// Returns the arc-cosine of f - the angle in radians whose cosine is f.
        /// </summary>
        public static double Acos(double d)
        {
            return Math.Acos(d);
        }

        /// <summary>
        /// Returns the arc-tangent of f - the angle in radians whose tangent is f.
        /// </summary>
        public static double Atan(double d)
        {
            return Math.Atan(d);
        }

        /// <summary>
        /// Returns the angle in radians whose Tan is y/x.
        /// </summary>
        public static double Atan2(double y, double x)
        {
            return Math.Atan2(y, x);
        }

        /// <summary>
        /// Returns square root of f.
        /// </summary>
        public static double Sqrt(double d)
        {
            return Math.Sqrt(d);
        }

        /// <summary>
        /// Returns the absolute value of value.
        /// </summary>
        public static double Abs(double d)
        {
            return Math.Abs(d);
        }

        /// <summary>
        /// Returns the absolute value of value.
        /// </summary>
        public static int Abs(int value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// Returns the smallest of two or more values.
        /// </summary>
        public static double Min(double a, double b)
        {
            return a < b
                ? a
                : b;
        }

        /// <summary>
        /// Returns the smallest of two or more values.
        /// </summary>
        public static double Min(params double[] values)
        {
            var length = values.Length;
            if (length == 0)
                return 0d;
            var num = values[0];
            for (var index = 1; index < length; ++index)
            {
                if (values[index] < num)
                    num = values[index];
            }
            return num;
        }

        /// <summary>
        /// Returns the smallest of two or more values.
        /// </summary>
        public static int Min(int a, int b)
        {
            return a < b
                ? a
                : b;
        }

        /// <summary>
        /// Returns the smallest of two or more values.
        /// </summary>
        public static int Min(params int[] values)
        {
            var length = values.Length;
            if (length == 0)
                return 0;
            var num = values[0];
            for (var index = 1; index < length; ++index)
            {
                if (values[index] < num)
                    num = values[index];
            }
            return num;
        }

        /// <summary>
        /// Returns the largest of two or more values.
        /// </summary>
        public static double Max(double a, double b)
        {
            return a > b
                ? a
                : b;
        }

        /// <summary>
        /// Returns the largest of two or more values.
        /// </summary>
        public static double Max(params double[] values)
        {
            var length = values.Length;
            if (length == 0)
                return 0d;
            var num = values[0];
            for (var index = 1; index < length; ++index)
            {
                if (values[index] > num)
                    num = values[index];
            }
            return num;
        }

        /// <summary>
        /// Returns the largest of two or more values.
        /// </summary>
        public static int Max(int a, int b)
        {
            return a > b
                ? a
                : b;
        }

        /// <summary>
        /// Returns the largest of two or more values.
        /// </summary>
        public static int Max(params int[] values)
        {
            var length = values.Length;
            if (length == 0)
                return 0;
            var num = values[0];
            for (var index = 1; index < length; ++index)
            {
                if (values[index] > num)
                    num = values[index];
            }
            return num;
        }

        /// <summary>
        /// Returns f raised to power p.
        /// </summary>
        public static double Pow(double d, double p)
        {
            return Math.Pow(d, p);
        }

        /// <summary>
        /// Returns e raised to the specified power.
        /// </summary>
        public static double Exp(double power)
        {
            return Math.Exp(power);
        }

        /// <summary>
        /// Returns the logarithm of a specified number in a specified base.
        /// </summary>
        public static double Log(double d, double p)
        {
            return Math.Log(d, p);
        }

        /// <summary>
        /// Returns the natural (base e) logarithm of a specified number.
        /// </summary>
        public static double Log(double d)
        {
            return Math.Log(d);
        }

        /// <summary>
        /// Returns the base 10 logarithm of a specified number.
        /// </summary>
        public static double Log10(double d)
        {
            return Math.Log10(d);
        }

        public static double Ceil(double d)
        {
            return Math.Ceiling(d);
        }

        /// <summary>
        /// Returns the largest integer smaller to or equal to f.
        /// </summary>
        public static double Floor(double d)
        {
            return Math.Floor(d);
        }

        /// <summary>
        /// Returns f rounded to the nearest integer.
        /// </summary>
        public static double Round(double d)
        {
            return Math.Round(d);
        }

        public static int CeilToInt(double d)
        {
            return (int)Math.Ceiling(d);
        }

        /// <summary>
        /// Returns the largest integer smaller to or equal to f.
        /// </summary>
        public static int FloorToInt(double d)
        {
            return (int)Math.Floor(d);
        }

        /// <summary>
        /// Returns f rounded to the nearest integer.
        /// </summary>
        public static int RoundToInt(double d)
        {
            return (int)Math.Round(d);
        }

        /// <summary>
        /// Returns the sign of f.
        /// </summary>
        public static double Sign(double d)
        {
            return d >= 0d ? 1d : -1d;
        }

        /// <summary>
        /// Clamps the given value between the given minimum and maximum values. Returns the given value if it is within the min and max range.
        /// </summary>
        /// <param name="value">The point value to restrict inside the range defined by the min and max values.</param>
        /// <param name="min">The minimum point value to compare against.</param>
        /// <param name="max">The maximum point value to compare against.</param>
        /// <returns>The result between the min and max values.</returns>
        public static double Clamp(double value, double min, double max)
        {
            return value < min
                ? min
                : value > max
                    ? max
                    : value;
        }

        /// <summary>
        /// Clamps the given value between the given minimum and maximum values. Returns the given value if it is within the min and max range.
        /// </summary>
        /// <param name="value">The point value to restrict inside the range defined by the min and max values.</param>
        /// <param name="min">The minimum point value to compare against.</param>
        /// <param name="max">The maximum point value to compare against.</param>
        /// <returns>The result between the min and max values.</returns>
        public static int Clamp(int value, int min, int max)
        {
            return value < min
                ? min
                : value > max
                    ? max
                    : value;
        }

        /// <summary>
        /// Clamps value between 0 and 1 and returns value.
        /// </summary>
        public static double Clamp01(double value)
        {
            return value < 0d
                ? 0d
                : value > 1d
                    ? 1d
                    : value;
        }

        /// <summary>
        /// Linearly interpolates between a and b by t.
        /// </summary>
        /// <param name="from">The start value.</param>
        /// <param name="to">The end value.</param>
        /// <param name="t">The interpolation value between the two doubles.</param>
        /// <returns>The interpolated result between the two values.</returns>
        public static double Lerp(double from, double to, double t)
        {
            return from + (to - from) * Clamp01(t);
        }

        /// <summary>
        /// Same as Lerp but makes sure the values interpolate correctly when they wrap around 360 degrees.
        /// </summary>
        public static double LerpAngle(double a, double b, double t)
        {
            var num = Repeat(b - a, 360d);
            if (num > 180d)
                num -= 360d;
            return a + num * Clamp01(t);
        }

        /// <summary>
        /// Moves a value current towards target.
        /// </summary>
        /// <param name="current">The current value.</param>
        /// <param name="target">The value to move towards.</param>
        /// <param name="maxDelta">The maximum change that should be applied to the value.</param>
        public static double MoveTowards(double current, double target, double maxDelta)
        {
            return Abs(target - current) <= maxDelta
                ? target
                : current + Sign(target - current) * maxDelta;
        }

        /// <summary>
        /// Same as MoveTowards but makes sure the values interpolate correctly when they wrap around 360 degrees.
        /// </summary>
        public static double MoveTowardsAngle(double current, double target, double maxDelta)
        {
            target = current + DeltaAngle(current, target);
            return MoveTowards(current, target, maxDelta);
        }

        /// <summary>
        /// Returns square root of f.
        /// </summary>
        public static double SmoothStep(double from, double to, double t)
        {
            t = Clamp01(t);
            t = -2d * t * t * t + 3d * t * t;
            return to * t + from * (1d - t);
        }

        public static double Gamma(double value, double absmax, double gamma)
        {
            var flag = false;
            if (value < 0d)
                flag = true;
            var num1 = Abs(value);
            if (num1 > absmax)
            {
                return flag ?
                    -num1
                    : num1;
            }
            else
            {
                var num2 = Pow(num1 / absmax, gamma) * absmax;
                return flag
                    ? -num2
                    : num2;
            }
        }

        /// <summary>
        /// Compares two values and returns true if they are similar.
        /// </summary>
        public static bool Approximately(double a, double b)
        {
            return Abs(b - a) < Max(1E-06d * Max(Abs(a), Abs(b)), 1.121039E-44d);
        }

        /// <summary>
        /// Gradually changes a value towards a desired goal over time.
        /// </summary>
        /// <param name="current">	The current position.</param>
        /// <param name="target">The position we are trying to reach.</param>
        /// <param name="currentVelocity">The current velocity, this value is modified by the function every time you call it.</param>
        /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
        public static double SmoothDamp(double current, double target, ref double currentVelocity, double smoothTime)
        {
            double deltaTime = Time.deltaTime;
            var maxSpeed = double.PositiveInfinity;
            return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        }

        /// <summary>
        /// Gradually changes a value towards a desired goal over time.
        /// </summary>
        /// <param name="current">	The current position.</param>
        /// <param name="target">The position we are trying to reach.</param>
        /// <param name="currentVelocity">The current velocity, this value is modified by the function every time you call it.</param>
        /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
        /// <param name="maxSpeed">Optionally allows you to clamp the maximum speed.</param>
        public static double SmoothDamp(double current, double target, ref double currentVelocity, double smoothTime, double maxSpeed)
        {
            double deltaTime = Time.deltaTime;
            return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        }

        /// <summary>
        /// Gradually changes a value towards a desired goal over time.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="target">The position we are trying to reach.</param>
        /// <param name="currentVelocity">The current velocity, this value is modified by the function every time you call it.</param>
        /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
        /// <param name="maxSpeed">Optionally allows you to clamp the maximum speed.</param>
        /// <param name="deltaTime">The time since the last call to this function. By default Time.deltaTime.</param>
        public static double SmoothDamp(double current, double target, ref double currentVelocity, double smoothTime, double maxSpeed, double deltaTime)
        {
            smoothTime = Max(0.0001d, smoothTime);
            var num1 = 2d / smoothTime;
            var num2 = num1 * deltaTime;
            var num3 = 1d / (1d + num2 + 0.479999989271164d * num2 * num2 + 0.234999999403954d * num2 * num2 * num2);
            var num4 = current - target;
            var num5 = target;
            var max = maxSpeed * smoothTime;
            var num6 = Clamp(num4, -max, max);
            target = current - num6;
            var num7 = (currentVelocity + num1 * num6) * deltaTime;
            currentVelocity = (currentVelocity - num1 * num7) * num3;
            var num8 = target + (num6 + num7) * num3;
            if (num5 - current > 0d == num8 > num5)
            {
                num8 = num5;
                currentVelocity = (num8 - num5) / deltaTime;
            }
            return num8;
        }

        /// <summary>
        /// Gradually changes an angle given in degrees towards a desired goal angle over time.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="target">The position we are trying to reach.</param>
        /// <param name="currentVelocity">	The current velocity, this value is modified by the function every time you call it.</param>
        /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
        public static double SmoothDampAngle(double current, double target, ref double currentVelocity, double smoothTime)
        {
            double deltaTime = Time.deltaTime;
            var maxSpeed = double.PositiveInfinity;
            return SmoothDampAngle(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        }

        /// <summary>
        /// Gradually changes an angle given in degrees towards a desired goal angle over time.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="target">The position we are trying to reach.</param>
        /// <param name="currentVelocity">The current velocity, this value is modified by the function every time you call it.</param>
        /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
        /// <param name="maxSpeed">Optionally allows you to clamp the maximum speed.</param>
        public static double SmoothDampAngle(double current, double target, ref double currentVelocity, double smoothTime, double maxSpeed)
        {
            double deltaTime = Time.deltaTime;
            return SmoothDampAngle(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        }

        /// <summary>
        /// Gradually changes an angle given in degrees towards a desired goal angle over time.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="target">The position we are trying to reach.</param>
        /// <param name="currentVelocity">The current velocity, this value is modified by the function every time you call it.</param>
        /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
        /// <param name="maxSpeed">Optionally allows you to clamp the maximum speed.</param>
        /// <param name="deltaTime">The time since the last call to this function. By default Time.deltaTime.</param>
        public static double SmoothDampAngle(double current, double target, ref double currentVelocity, double smoothTime, double maxSpeed, double deltaTime)
        {
            target = current + DeltaAngle(current, target);
            return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        }

        /// <summary>
        /// Loops the value t, so that it is never larger than length and never smaller than
        /// </summary>
        public static double Repeat(double t, double length)
        {
            return t - Floor(t / length) * length;
        }

        /// <summary>
        /// PingPongs the value t, so that it is never larger than length and never smaller than 0.
        /// </summary>
        public static double PingPong(double t, double length)
        {
            t = Repeat(t, length * 2d);
            return length - Abs(t - length);
        }

        /// <summary>
        /// Calculates the linear parameter t that produces the interpolant value within the range [a, b].
        /// </summary>
        /// <param name="from">Start value.</param>
        /// <param name="to">End value.</param>
        /// <param name="value">Value between start and end.</param>
        /// <returns>Percentage of value between start and end.</returns>
        public static double InverseLerp(double from, double to, double value)
        {
            if (from < to)
            {
                if (value < from)
                    return 0d;
                if (value > to)
                    return 1d;
                value -= from;
                value /= to - from;
                return value;
            }
            else
            {
                return from <= to 
                    ? 0d 
                    : value < to 
                        ? 1d 
                        : value > from 
                            ? 0d 
                            : 1d - (value - to) / (from - to);
            }
        }

        /// <summary>
        /// Calculates the shortest difference between two given angles given in degrees.
        /// </summary>
        public static double DeltaAngle(double current, double target)
        {
            var num = Repeat(target - current, 360d);
            if (num > 180d)
                num -= 360d;
            return num;
        }

        internal static bool LineIntersection(Vector2d p1, Vector2d p2, Vector2d p3, Vector2d p4, ref Vector2d result)
        {
            var num1 = p2.x - p1.x;
            var num2 = p2.y - p1.y;
            var num3 = p4.x - p3.x;
            var num4 = p4.y - p3.y;
            var num5 = num1 * num4 - num2 * num3;
            if (num5 == 0d)
                return false;
            var num6 = p3.x - p1.x;
            var num7 = p3.y - p1.y;
            var num8 = (num6 * num4 - num7 * num3) / num5;
            result = new Vector2d(p1.x + num8 * num1, p1.y + num8 * num2);
            return true;
        }

        internal static bool LineSegmentIntersection(Vector2d p1, Vector2d p2, Vector2d p3, Vector2d p4, ref Vector2d result)
        {
            var num1 = p2.x - p1.x;
            var num2 = p2.y - p1.y;
            var num3 = p4.x - p3.x;
            var num4 = p4.y - p3.y;
            var num5 = num1 * num4 - num2 * num3;
            if (num5 == 0d)
                return false;
            var num6 = p3.x - p1.x;
            var num7 = p3.y - p1.y;
            var num8 = (num6 * num4 - num7 * num3) / num5;
            if (num8 < 0d || num8 > 1d)
                return false;
            var num9 = (num6 * num2 - num7 * num1) / num5;
            if (num9 < 0d || num9 > 1d)
                return false;
            result = new Vector2d(p1.x + num8 * num1, p1.y + num8 * num2);
            return true;
        }
    }
}
