// Source: https://github.com/sldsmkd/vector3d
// Licence: The Unlicense
using System;

namespace UnityEngine
{
    /// <summary>
    /// Representation of 3D vectors and points using doubles.
    /// </summary>
    [Serializable]
    public struct Vector3d
    {
        public const double kEpsilon = 1E-05d;
        public const double kEpsilonNormalSqrt = 1E-15d;
        public double x;
        public double y;
        public double z;

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
                    case 2:
                        return z;
                    default:
                        throw new IndexOutOfRangeException("Invalid index!");
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
                    case 2:
                        z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3d index!");
                }
            }
        }

        /// <summary>
        /// Returns this vector with a magnitude of 1 (Read Only).
        /// </summary>
        public Vector3d normalized
        {
            get
            {
                return Normalize(this);
            }
        }

        /// <summary>
        /// Returns the length of this vector (Read Only).
        /// </summary>
        public double magnitude
        {
            get
            {
                return Math.Sqrt(sqrMagnitude);
            }
        }

        /// <summary>
        /// Returns the squared length of this vector (Read Only).
        /// </summary>
        public double sqrMagnitude
        {
            get
            {
                return x * x + y * y + z * z;
            }
        }

        /// <summary>
        /// Shorthand for writing Vector3d(0, 0, 0).
        /// </summary>
        public static Vector3d zero
        {
            get
            {
                return new Vector3d(0d, 0d, 0d);
            }
        }

        /// <summary>
        /// Shorthand for writing Vector3d(1, 1, 1).
        /// </summary>
        public static Vector3d one
        {
            get
            {
                return new Vector3d(1d, 1d, 1d);
            }
        }

        /// <summary>
        /// Shorthand for writing Vector3d(0, 0, 1).
        /// </summary>
        public static Vector3d forward
        {
            get
            {
                return new Vector3d(0d, 0d, 1d);
            }
        }

        /// <summary>
        /// Shorthand for writing Vector3d(0, 0, -1).
        /// </summary>
        public static Vector3d back
        {
            get
            {
                return new Vector3d(0d, 0d, -1d);
            }
        }

        /// <summary>
        /// Shorthand for writing Vector3d(0, 1, 0).
        /// </summary>
        public static Vector3d up
        {
            get
            {
                return new Vector3d(0d, 1d, 0d);
            }
        }

        /// <summary>
        /// Shorthand for writing Vector3d(0, -1, 0).
        /// </summary>
        public static Vector3d down
        {
            get
            {
                return new Vector3d(0d, -1d, 0d);
            }
        }

        /// <summary>
        /// Shorthand for writing Vector3d(-1, 0, 0).
        /// </summary>
        public static Vector3d left
        {
            get
            {
                return new Vector3d(-1d, 0d, 0d);
            }
        }

        /// <summary>
        /// Shorthand for writing Vector3d(1, 0, 0).
        /// </summary>
        public static Vector3d right
        {
            get
            {
                return new Vector3d(1d, 0d, 0d);
            }
        }

        /// <summary>
        /// Constructs a new vector with given x, y and z components.
        /// </summary>
        public Vector3d(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Constructs a new vector with given x, y components. The z is set to zero.
        /// </summary>
        public Vector3d(double x, double y)
        {
            this.x = x;
            this.y = y;
            z = 0d;
        }

        /// <summary>
        /// Set x, y and z components of an existing Vector3d.
        /// </summary>
        public void Set(double new_x, double new_y, double new_z)
        {
            x = new_x;
            y = new_y;
            z = new_z;
        }

        /// <summary>
        /// Multiplies two vectors component-wise.
        /// </summary>
        public void Scale(Vector3d scale)
        {
            x *= scale.x;
            y *= scale.y;
            z *= scale.z;
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
            return $"({x.ToString(format)}, {y.ToString(format)}, {z.ToString(format)})";
        }

        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() << 2 ^ z.GetHashCode() >> 2;
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
        public static Vector3d Lerp(Vector3d from, Vector3d to, double t)
        {
            t = Mathd.Clamp01(t);
            return new Vector3d(from.x + (to.x - from.x) * t, from.y + (to.y - from.y) * t, from.z + (to.z - from.z) * t);
        }

        //TODO : double precision instead of float
        ///// <summary>
        ///// Spherically interpolates between two vectors.
        ///// </summary>
        //public static Vector3d Slerp(Vector3d from, Vector3d to, double t)
        //{
        //    return Vector3.Slerp((Vector3)from, (Vector3)to, (float)t);
        //}

        //TODO : double precision instead of float
        ///// <summary>
        ///// Makes vectors normalized and orthogonal to each other.
        ///// </summary>
        //public static void OrthoNormalize(ref Vector3d normal, ref Vector3d tangent)
        //{
        //    var v3normal = (Vector3)normal;
        //    var v3tangent = (Vector3)tangent;
        //    Vector3.OrthoNormalize(ref v3normal, ref v3tangent);
        //    normal = v3normal;
        //    tangent = v3tangent;
        //}

        //TODO : double precision instead of float
        ///// <summary>
        ///// Makes vectors normalized and orthogonal to each other.
        ///// </summary>
        //public static void OrthoNormalize(ref Vector3d normal, ref Vector3d tangent, ref Vector3d binormal)
        //{
        //    var v3normal = (Vector3)normal;
        //    var v3tangent = (Vector3)tangent;
        //    var v3binormal = (Vector3)binormal;
        //    Vector3.OrthoNormalize(ref v3normal, ref v3tangent, ref v3binormal);
        //    normal = v3normal;
        //    tangent =v3tangent;
        //    binormal = v3binormal;
        //}

        /// <summary>
        /// Moves a point current towards target.
        /// </summary>
        public static Vector3d MoveTowards(Vector3d current, Vector3d target, double maxDistanceDelta)
        {
            var vector = target - current;
            var magnitude = vector.magnitude;
            return magnitude <= maxDistanceDelta || magnitude == 0d
                ? target
                : current + vector / magnitude * maxDistanceDelta;
        }

        //TODO : double precision instead of float
        ///// <summary>
        ///// Rotates a vector current towards target.
        ///// </summary>
        ///// <param name="current">The vector being managed.</param>
        ///// <param name="target">The vector.</param>
        ///// <param name="maxRadiansDelta">The maximum angle in radians allowed for this rotation.</param>
        ///// <param name="maxMagnitudeDelta">The maximum allowed change in vector magnitude for this rotation.</param>
        ///// <returns></returns>
        //public static Vector3d RotateTowards(Vector3d current, Vector3d target, double maxRadiansDelta, double maxMagnitudeDelta)
        //{
        //    return Vector3.RotateTowards((Vector3)current, (Vector3)target, (float)maxRadiansDelta, (float)maxMagnitudeDelta);
        //}

        /// <summary>
        /// Gradually changes a value towards a desired goal over time.
        /// </summary>
        /// <param name="current">The current position.</param>
        /// <param name="target">The position we are trying to reach.</param>
        /// <param name="currentVelocity">The current velocity, this value is modified by the function every time you call it.</param>
        /// <param name="smoothTime">Approximately the time it will take to reach the target. A smaller value will reach the target faster.</param>
        public static Vector3d SmoothDamp(Vector3d current, Vector3d target, ref Vector3d currentVelocity, double smoothTime)
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
        public static Vector3d SmoothDamp(Vector3d current, Vector3d target, ref Vector3d currentVelocity, double smoothTime, double maxSpeed)
        {
            var deltaTime = (double) Time.deltaTime;
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
        public static Vector3d SmoothDamp(Vector3d current, Vector3d target, ref Vector3d currentVelocity, double smoothTime, double maxSpeed, double deltaTime)
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
        public static Vector3d Scale(Vector3d a, Vector3d b)
        {
            return new Vector3d(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        /// <summary>
        /// Cross Product of two vectors.
        /// </summary>
        public static Vector3d Cross(Vector3d lhs, Vector3d rhs)
        {
            return new Vector3d(lhs.y * rhs.z - lhs.z * rhs.y, lhs.z * rhs.x - lhs.x * rhs.z, lhs.x * rhs.y - lhs.y * rhs.x);
        }

        /// <summary>
        /// Reflects a vector off the plane defined by a normal.
        /// </summary>
        public static Vector3d Reflect(Vector3d inDirection, Vector3d inNormal)
        {
            return -2d * Dot(inNormal, inDirection) * inNormal + inDirection;
        }

        /// <summary>
        /// Makes this vector have a magnitude of 1.
        /// </summary>
        public static Vector3d Normalize(Vector3d value)
        {
            var num = Magnitude(value);
            return num > kEpsilon
                ? value / num
                : zero;
        }

        /// <summary>
        /// Dot Product of two vectors.
        /// </summary>
        public static double Dot(Vector3d lhs, Vector3d rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
        }

        /// <summary>
        /// Projects a vector onto another vector.
        /// </summary>
        public static Vector3d Project(Vector3d vector, Vector3d onNormal)
        {
            var num = Dot(onNormal, onNormal);
            return num < Mathd.Epsilon
                ? zero
                : onNormal * Dot(vector, onNormal) / num;
        }

        public static Vector3d Exclude(Vector3d excludeThis, Vector3d fromThat)
        {
            return fromThat - Project(fromThat, excludeThis);
        }

        /// <summary>
        /// 	Returns the unsigned angle in degrees between from and to.
        /// </summary>
        public static double Angle(Vector3d from, Vector3d to)
        {
            return Mathd.Acos(Mathd.Clamp(Dot(from.normalized, to.normalized), -1d, 1d)) * Mathd.Rad2Deg;
        }

        /// <summary>
        /// Returns the distance between a and b.
        /// </summary>
        public static double Distance(Vector3d a, Vector3d b)
        {
            return (a - b).magnitude;
        }

        /// <summary>
        /// Returns a copy of vector with its magnitude clamped to maxLength.
        /// </summary>
        public static Vector3d ClampMagnitude(Vector3d vector, double maxLength)
        {
            return vector.sqrMagnitude > maxLength * maxLength
                ? vector.normalized * maxLength
                : vector;
        }

        /// <summary>
        /// Returns the squared length of this vector.
        /// </summary>
        public static double Magnitude(Vector3d a)
        {
            return a.magnitude;
        }

        /// <summary>
        /// Returns the squared length of this vector.
        /// </summary>
        public static double SqrMagnitude(Vector3d a)
        {
            return a.sqrMagnitude;
        }

        /// <summary>
        /// Returns a vector that is made from the smallest components of two vectors.
        /// </summary>
        public static Vector3d Min(Vector3d lhs, Vector3d rhs)
        {
            return new Vector3d(Mathd.Min(lhs.x, rhs.x), Mathd.Min(lhs.y, rhs.y), Mathd.Min(lhs.z, rhs.z));
        }

        /// <summary>
        /// Returns a vector that is made from the largest components of two vectors.
        /// </summary>
        public static Vector3d Max(Vector3d lhs, Vector3d rhs)
        {
            return new Vector3d(Mathd.Max(lhs.x, rhs.x), Mathd.Max(lhs.y, rhs.y), Mathd.Max(lhs.z, rhs.z));
        }

        /// <summary>
        /// Converts a Vector3 to a Vector3d.
        /// </summary>
        public static implicit operator Vector3d(Vector3 v)
        {
            return new Vector3d(v.x, v.y, v.z);
        }

        /// <summary>
        /// Converts a Vector3d to a Vector3.
        /// </summary>
        public static explicit operator Vector3(Vector3d vector3d)
        {
            return new Vector3((float)vector3d.x, (float)vector3d.y, (float)vector3d.z);
        }

        /// <summary>
        /// Converts a Vector2 to a Vector3d.
        /// </summary>
        public static implicit operator Vector3d(Vector2 v)
        {
            return new Vector3d(v.x, v.y);
        }

        /// <summary>
        /// Converts a Vector3d to a Vector2.
        /// </summary>
        public static explicit operator Vector2(Vector3d vector3d)
        {
            return new Vector2((float)vector3d.x, (float)vector3d.y);
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        public static Vector3d operator +(Vector3d a, Vector3d b)
        {
            return new Vector3d(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        /// <summary>
        /// Subtracts one vector from another.
        /// </summary>
        public static Vector3d operator -(Vector3d a, Vector3d b)
        {
            return new Vector3d(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3d operator -(Vector3d a)
        {
            return new Vector3d(-a.x, -a.y, -a.z);
        }

        /// <summary>
        /// Multiplies a vector by a number.
        /// </summary>
        public static Vector3d operator *(Vector3d a, double d)
        {
            return new Vector3d(a.x * d, a.y * d, a.z * d);
        }

        /// <summary>
        /// Multiplies a vector by a number.
        /// </summary>
        public static Vector3d operator *(double d, Vector3d a)
        {
            return new Vector3d(a.x * d, a.y * d, a.z * d);
        }

        /// <summary>
        /// Divides a vector by a number.
        /// </summary>
        public static Vector3d operator /(Vector3d a, double d)
        {
            return new Vector3d(a.x / d, a.y / d, a.z / d);
        }

        public static bool operator ==(Vector3d lhs, Vector3d rhs)
        {
            return SqrMagnitude(lhs - rhs) < kEpsilonNormalSqrt;
        }

        public static bool operator !=(Vector3d lhs, Vector3d rhs)
        {
            return !(lhs == rhs);
        }
    }
}
