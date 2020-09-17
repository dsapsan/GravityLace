// Source: https://github.com/sldsmkd/vector3d
// Licence: The Unlicense
using System;

namespace UnityEngine
{
    /// <summary>
    /// Representation of 2D vectors and points using doubles.
    /// </summary>
    [Serializable]
    public struct Vector2d
    {
        public const double kEpsilon = 1E-05d;
        public const double kEpsilonNormalSqrt = 1E-15d;
        public double x;
        public double y;

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector2d index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector2d index!");
                }
            }
        }

        /// <summary>
        /// Returns this vector with a magnitude of 1 (Read Only).
        /// </summary>
        public Vector2d normalized
        {
            get
            {
                var vector2d = new Vector2d(x, y);
                vector2d.Normalize();
                return vector2d;
            }
        }

        /// <summary>
        /// Returns the length of this vector (Read Only).
        /// </summary>
        public double magnitude
        {
            get
            {
                return Mathd.Sqrt(sqrMagnitude);
            }
        }

        /// <summary>
        /// Returns the squared length of this vector (Read Only).
        /// </summary>
        public double sqrMagnitude
        {
            get
            {
                return x * x + y * y;
            }
        }

        /// <summary>
        /// Shorthand for writing Vector2d(0, 0).
        /// </summary>
        public static Vector2d zero
        {
            get
            {
                return new Vector2d(0d, 0d);
            }
        }

        /// <summary>
        /// Shorthand for writing Vector2d(1, 1).
        /// </summary>
        public static Vector2d one
        {
            get
            {
                return new Vector2d(1d, 1d);
            }
        }

        /// <summary>
        /// Shorthand for writing Vector2d(0, 1).
        /// </summary>
        public static Vector2d up
        {
            get
            {
                return new Vector2d(0d, 1d);
            }
        }

        /// <summary>
        /// Shorthand for writing Vector2d(0, -1).
        /// </summary>
        public static Vector2d down
        {
            get
            {
                return new Vector2d(0d, -1d);
            }
        }

        /// <summary>
        /// Shorthand for writing Vector2d(1, 0).
        /// </summary>
        public static Vector2d right
        {
            get
            {
                return new Vector2d(1d, 0d);
            }
        }

        /// <summary>
        /// Shorthand for writing Vector2d(-1, 0).
        /// </summary>
        public static Vector2d left
        {
            get
            {
                return new Vector2d(-1d, 0d);
            }
        }

        /// <summary>
        /// Constructs a new vector with given x, y components.
        /// </summary>
        public Vector2d(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Set x, and y components of an existing Vector2d.
        /// </summary>
        public void Set(double new_x, double new_y)
        {
            x = new_x;
            y = new_y;
        }

        /// <summary>
        /// Multiplies two vectors component-wise.
        /// </summary>
        public void Scale(Vector2d scale)
        {
            x *= scale.x;
            y *= scale.y;
        }

        /// <summary>
        /// Makes this vector have a magnitude of 1.
        /// </summary>
        public void Normalize()
        {
            var magnitude = this.magnitude;
            this = magnitude > kEpsilon
                ? this / magnitude
                : zero;
        }

        /// <summary>
        /// Rotates a vector by an angle in radians.
        /// </summary>
        public void Rotate(double angle)
        {
            var sin = Mathd.Sin(angle);
            var cos = Mathd.Cos(angle);
            Set(
                x * cos - y * sin,
                x * sin + y * cos);
        }

        /// <summary>
        /// Returns the squared length of this vector.
        /// </summary>
        public double SqrMagnitude()
        {
            return sqrMagnitude;
        }

        /// <summary>
        /// Returns a nicely formatted string for this vector.
        /// </summary>
        public string ToString(string format)
        {
            return $"({x.ToString(format)}, {y.ToString(format)})";
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() << 2;
        }

        /// <summary>
        /// Returns true if the given vector is exactly equal to this vector.
        /// </summary>
        public override bool Equals(object other)
        {
            return other is Vector2d vector2d
                && x.Equals(vector2d.x)
                && y.Equals(vector2d.y);
        }

        /// <summary>
        /// Linearly interpolates between vectors a and b by t.
        /// </summary>
        public static Vector2d Lerp(Vector2d from, Vector2d to, double t)
        {
            t = Mathd.Clamp01(t);
            return new Vector2d(from.x + (to.x - from.x) * t, from.y + (to.y - from.y) * t);
        }

        /// <summary>
        /// Moves a point current towards target.
        /// </summary>
        public static Vector2d MoveTowards(Vector2d current, Vector2d target, double maxDistanceDelta)
        {
            var vector = target - current;
            var magnitude = vector.magnitude;
            return magnitude <= maxDistanceDelta || magnitude == 0d
                ? target
                : current + vector / magnitude * maxDistanceDelta;
        }

        /// <summary>
        /// Gradually changes a value towards a desired goal over time.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="target">The position we are trying to reach.</param>
        /// <param name="currentVelocity">The current velocity, this value is modified by the function every time you call it.</param>
        /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
        public static Vector2d SmoothDamp(Vector2d current, Vector2d target, ref Vector2d currentVelocity, double smoothTime)
        {
            var deltaTime = (double)Time.deltaTime;
            var maxSpeed = double.PositiveInfinity;
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
        public static Vector2d SmoothDamp(Vector2d current, Vector2d target, ref Vector2d currentVelocity, double smoothTime, double maxSpeed)
        {
            var deltaTime = (double)Time.deltaTime;
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
        public static Vector2d SmoothDamp(Vector2d current, Vector2d target, ref Vector2d currentVelocity, double smoothTime, double maxSpeed, double deltaTime)
        {
            smoothTime = Mathd.Max(0.0001d, smoothTime);
            var num1 = 2d / smoothTime;
            var num2 = num1 * deltaTime;
            var num3 = 1d / (1d + num2 + 0.479999989271164d * num2 * num2 + 0.234999999403954d * num2 * num2 * num2);
            var vector = current - target;
            var vector_1 = target;
            var maxLength = maxSpeed * smoothTime;
            var vector_2 = ClampMagnitude(vector, maxLength);
            target = current - vector_2;
            var vector_3 = (currentVelocity + num1 * vector_2) * deltaTime;
            currentVelocity = (currentVelocity - num1 * vector_3) * num3;
            var vector_4 = target + (vector_2 + vector_3) * num3;
            if (Dot(vector_1 - current, vector_4 - vector_1) > 0d)
            {
                vector_4 = vector_1;
                currentVelocity = (vector_4 - vector_1) / deltaTime;
            }
            return vector_4;
        }

        /// <summary>
        /// Multiplies two vectors component-wise.
        /// </summary>
        public static Vector2d Scale(Vector2d a, Vector2d b)
        {
            return new Vector2d(a.x * b.x, a.y * b.y);
        }

        /// <summary>
        /// Z component of Cross Product of two vector2d.
        /// </summary>
        public static double Cross(Vector2d lhs, Vector2d rhs)
        {
            return lhs.x * rhs.y - lhs.y * rhs.x;
        }

        /// <summary>
        /// Rotates a vector by an angle in radians.
        /// </summary>
        public static Vector2d Rotate(Vector2d source, double angle)
        {
            source.Rotate(angle);
            return source;
        }

        /// <summary>
        /// Reflects a vector off the plane defined by a normal.
        /// </summary>
        public static Vector2d Reflect(Vector2d inDirection, Vector2d inNormal)
        {
            return -2d * Dot(inNormal, inDirection) * inNormal + inDirection;
        }

        /// <summary>
        /// Makes this vector have a magnitude of 1.
        /// </summary>
        public static Vector2d Normalize(Vector2d value)
        {
            var num = Magnitude(value);
            return num > kEpsilon
                ? value / num
                : zero;
        }

        /// <summary>
        /// Dot Product of two vectors.
        /// </summary>
        public static double Dot(Vector2d lhs, Vector2d rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y;
        }

        /// <summary>
        /// 	Returns the unsigned angle in degrees between from and to.
        /// </summary>
        public static double Angle(Vector2d from, Vector2d to)
        {
            return Mathd.Acos(Mathd.Clamp(Dot(from.normalized, to.normalized), -1d, 1d)) * Mathf.Rad2Deg;
        }

        /// <summary>
        /// Returns the distance between a and b.
        /// </summary>
        public static double Distance(Vector2d a, Vector2d b)
        {
            return (a - b).magnitude;
        }

        /// <summary>
        /// Returns a copy of vector with its magnitude clamped to maxLength.
        /// </summary>
        public static Vector2d ClampMagnitude(Vector2d vector, double maxLength)
        {
            return vector.sqrMagnitude > maxLength * maxLength
                ? vector.normalized * maxLength
                : vector;
        }

        /// <summary>
        /// Returns the squared length of this vector.
        /// </summary>
        public static double Magnitude(Vector2d a)
        {
            return a.magnitude;
        }

        /// <summary>
        /// Returns the squared length of this vector.
        /// </summary>
        public static double SqrMagnitude(Vector2d a)
        {
            return a.sqrMagnitude;
        }

        /// <summary>
        /// Returns a vector that is made from the smallest components of two vectors.
        /// </summary>
        public static Vector2d Min(Vector2d lhs, Vector2d rhs)
        {
            return new Vector2d(Mathd.Min(lhs.x, rhs.x), Mathd.Min(lhs.y, rhs.y));
        }

        /// <summary>
        /// Returns a vector that is made from the largest components of two vectors.
        /// </summary>
        public static Vector2d Max(Vector2d lhs, Vector2d rhs)
        {
            return new Vector2d(Mathd.Max(lhs.x, rhs.x), Mathd.Max(lhs.y, rhs.y));
        }

        /// <summary>
        /// Converts a Vector3d to a Vector2d.
        /// </summary>
        public static implicit operator Vector2d(Vector3d v)
        {
            return new Vector2d(v.x, v.y);
        }

        /// <summary>
        /// Converts a Vector2d to a Vector3d.
        /// </summary>
        public static implicit operator Vector3d(Vector2d v)
        {
            return new Vector3d(v.x, v.y, 0d);
        }

        /// <summary>
        /// Converts a Vector2 to a Vector2d.
        /// </summary>
        public static implicit operator Vector2d(Vector2 v)
        {
            return new Vector2d(v.x, v.y);
        }

        /// <summary>
        /// Converts a Vector2d to a Vector2.
        /// </summary>
        public static explicit operator Vector2(Vector2d v)
        {
            return new Vector2((float)v.x, (float)v.y);
        }

        /// <summary>
        /// Converts a Vector3 to a Vector2d.
        /// </summary>
        public static implicit operator Vector2d(Vector3 v)
        {
            return new Vector2d(v.x, v.y);
        }

        /// <summary>
        /// Converts a Vector2d to a Vector3.
        /// </summary>
        public static explicit operator Vector3(Vector2d v)
        {
            return new Vector3((float)v.x, (float)v.y, 0f);
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        public static Vector2d operator +(Vector2d a, Vector2d b)
        {
            return new Vector2d(a.x + b.x, a.y + b.y);
        }

        /// <summary>
        /// Subtracts one vector from another.
        /// </summary>
        public static Vector2d operator -(Vector2d a, Vector2d b)
        {
            return new Vector2d(a.x - b.x, a.y - b.y);
        }

        public static Vector2d operator -(Vector2d a)
        {
            return new Vector2d(-a.x, -a.y);
        }

        /// <summary>
        /// Multiplies a vector by a number.
        /// </summary>
        public static Vector2d operator *(Vector2d a, double d)
        {
            return new Vector2d(a.x * d, a.y * d);
        }

        /// <summary>
        /// Multiplies a vector by a number.
        /// </summary>
        public static Vector2d operator *(double d, Vector2d a)
        {
            return new Vector2d(a.x * d, a.y * d);
        }

        /// <summary>
        /// Divides a vector by a number.
        /// </summary>
        public static Vector2d operator /(Vector2d a, double d)
        {
            return new Vector2d(a.x / d, a.y / d);
        }

        public static bool operator ==(Vector2d lhs, Vector2d rhs)
        {
            return SqrMagnitude(lhs - rhs) < kEpsilonNormalSqrt;
        }

        public static bool operator !=(Vector2d lhs, Vector2d rhs)
        {
            return !(lhs == rhs);
        }
    }
}
