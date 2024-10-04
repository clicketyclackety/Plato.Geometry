using System;
using System.Runtime.CompilerServices;

namespace Plato.DoublePrecision
{
    public partial struct Vector3D
    {
        public bool IsParallel(Vector3D v) 
            => Dot(v).Abs > 1 - 1e-10;
    }

    /// <summary>
    /// A structure encapsulating a 4x4 matrix.
    /// </summary>
    public partial struct Matrix4x4 
    {
        public Vector4D Row1 => (M11, M12, M13, M14);
        public Vector4D Row2 => (M21, M22, M23, M24);
        public Vector4D Row3 => (M31, M32, M33, M34);
        public Vector4D Row4 => (M41, M42, M43, M44);

        public Vector4D GetRow(int row)
            => row == 0 ? Row1 
                : row == 1 ? Row2 
                : row == 2 ? Row3 
                : row == 3 ? Row4 
                : throw new IndexOutOfRangeException();
        
        /// <summary>
        /// Returns the multiplicative identity matrix.
        /// </summary>
        public static Matrix4x4 Identity = (
            (1, 0, 0, 0),
            (0, 1, 0, 0),
            (0, 0, 1, 0),
            (0, 0, 0, 1));

        /// <summary>
        /// Returns whether the matrix is the identity matrix.
        /// </summary>
        public bool IsIdentity =>
            M11 == 1f && M22 == 1f && M33 == 1f && M44 == 1f && // Check diagonal element first for early out.
            M12 == 0f && M13 == 0f && M14 == 0f &&
            M21 == 0f && M23 == 0f && M24 == 0f &&
            M31 == 0f && M32 == 0f && M34 == 0f &&
            M41 == 0f && M42 == 0f && M43 == 0f;

        /// <summary>
        /// Gets the translation component of this matrix.
        /// </summary>
        public Vector3D Translation
            => (M41, M42, M43);

        /// <summary>
        /// Sets the translation component of this matrix, returning a new Matrix
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix4x4 SetTranslation(Vector3D v)
            => CreateFromRows(Row1, Row2, Row3, v);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4x4 CreateFromRows(Vector4D row0, Vector4D row1, Vector4D row2)
            => CreateFromRows(row0, row1, row2, (0, 0, 0, 1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4x4 CreateFromRows(Vector4D row0, Vector4D row1, Vector4D row2, Vector4D row3)
            => ((row0.X, row1.X, row2.X, row3.X),
                (row0.Y, row1.Y, row2.Y, row3.Y),
                (row0.Z, row1.Z, row2.Z, row3.Z),
                (row0.W, row1.W, row2.W, row3.W));

        public Matrix4x4 WithTranslation(Vector3D v)
            => (Column1, Column2, Column3, (v.X, v.Y, v.Z, M44));

        /// <summary>
        /// Creates a translation matrix.
        /// </summary>
        /// <param name="position">The amount to translate in each axis.</param>
        /// <returns>The translation matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4x4 CreateTranslation(Vector3D position)
            => Identity.WithTranslation(position);

        /// <summary>
        /// Creates a scaling matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4x4 CreateScale(Vector3D v)
            => ((v.X, 0, 0, 0), (0, v.Y, 0, 0), (0, 0, v.Z, 0), (0, 0, 0, 1));

        /// <summary>
        /// Creates a matrix from a position and oriented to look towards a point .
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4x4 CreateLookAt(Vector3D pos, Vector3D target, Vector3D up)
        {
            var zaxis = (target - pos).Normalize;
            if (up.IsParallel(zaxis))
                up = zaxis.X.Abs < zaxis.Y.Abs 
                    ? (1, 0, 0) 
                    : (0, 1, 0);
            var xaxis = up.Cross(zaxis).Normalize;
            var yaxis = zaxis.Cross(xaxis);
            return CreateFromBasis(xaxis, yaxis, zaxis, pos);
        }

        public static Matrix4x4 CreateFromBasis(Vector3D xaxis, Vector3D yaxis, Vector3D zaxis, Vector3D pos)
        {
            var tx = -xaxis.Dot(pos);
            var ty = -yaxis.Dot(pos);
            var tz = -zaxis.Dot(pos);
            return (xaxis.Vector4D, yaxis.Vector4D, zaxis.Vector4D, (tx, ty, tz, 1));
        }

        /// <summary>
        /// Creates a rotation matrix from the given Quaternion rotation value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4x4 CreateFromQuaternion(Quaternion quaternion)
            => CreateRotation(quaternion);

        /// <summary>
        /// Creates a rotation matrix from the given Quaternion rotation value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4x4 CreateRotation(Quaternion q)
        {
            q = q.Normalize;

            var xx = q.X * q.X;
            var yy = q.Y * q.Y;
            var zz = q.Z * q.Z;

            var xy = q.X * q.Y;
            var wz = q.Z * q.W;
            var xz = q.Z * q.X;
            var wy = q.Y * q.W;
            var yz = q.Y * q.Z;
            var wx = q.X * q.W;

            return ((1 - 2 * (yy + zz), 2 * (xy + wz), 2 * (xz - wy), 0),
                (2 * (xy - wz), 1 - 2 * (zz + xx), 2 * (yz + wx), 0),
                (2 * (xz + wy), 2 * (yz - wx), 1 - 2 * (yy + xx), 0),
                (0, 0, 0, 1));
        }

        /// <summary>
        /// Calculates the determinant of the 3x3 rotational component of the matrix.
        /// </summary>
        /// <returns>The determinant of the 3x3 rotational component matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Get3x3RotationDeterminant()
        {
            // | a b c |
            // | d e f | = a | e f | - b | d f | + c | d e |
            // | g h i |     | h i |     | g i |     | g h |
            //
            // a | e f | = a ( ei - fh )
            //   | h i | 
            //
            // b | d f | = b ( di - gf )
            //   | g i |
            //
            // c | d e | = c ( dh - eg )
            //   | g h |

            double a = M11, b = M12, c = M13;
            double d = M21, e = M22, f = M23;
            double g = M31, h = M32, i = M33;

            var ei_fh = e * i - f * h;
            var di_gf = d * i - g * f;
            var dh_eg = d * h - e * g;

            return a * ei_fh -
                   b * di_gf +
                   c * dh_eg;
        }

        /// <summary>
        /// Returns true if the 3x3 rotation determinant of the matrix is less than 0. This assumes the matrix represents
        /// an affine transform.
        /// </summary>
        // From: https://math.stackexchange.com/a/1064759
        // "If your matrix is the augmented matrix representing an affine transformation in 3D, then yes,
        // the proper thing to do to see if it switches orientation is checking the sign of the top 3×3 determinant.
        // This is easy to see: if your transformation is Ax+b, then the +b part is a translation and does not
        // affect orientation, and x->Ax switches orientation iff detA < 0."
        public bool IsReflection
            => Get3x3RotationDeterminant() < 0;

        /// <summary>
        /// Calculates the determinant of the matrix.
        /// </summary>
        /// <returns>The determinant of the matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double GetDeterminant()
        {
            // | a b c d |     | f g h |     | e g h |     | e f h |     | e f g |
            // | e f g h | = a | j k l | - b | i k l | + c | i j l | - d | i j k |
            // | i j k l |     | n o p |     | m o p |     | m n p |     | m n o |
            // | m n o p |
            //
            //   | f g h |
            // a | j k l | = a ( f ( kp - lo ) - g ( jp - ln ) + h ( jo - kn ) )
            //   | n o p |
            //
            //   | e g h |     
            // b | i k l | = b ( e ( kp - lo ) - g ( ip - lm ) + h ( io - km ) )
            //   | m o p |     
            //
            //   | e f h |
            // c | i j l | = c ( e ( jp - ln ) - f ( ip - lm ) + h ( in - jm ) )
            //   | m n p |
            //
            //   | e f g |
            // d | i j k | = d ( e ( jo - kn ) - f ( io - km ) + g ( in - jm ) )
            //   | m n o |
            //
            // Cost of operation
            // 17 adds and 28 muls.
            //
            // add: 6 + 8 + 3 = 17
            // mul: 12 + 16 = 28

            double a = M11, b = M12, c = M13, d = M14;
            double e = M21, f = M22, g = M23, h = M24;
            double i = M31, j = M32, k = M33, l = M34;
            double m = M41, n = M42, o = M43, p = M44;

            var kp_lo = k * p - l * o;
            var jp_ln = j * p - l * n;
            var jo_kn = j * o - k * n;
            var ip_lm = i * p - l * m;
            var io_km = i * o - k * m;
            var in_jm = i * n - j * m;

            return a * (f * kp_lo - g * jp_ln + h * jo_kn) -
                   b * (e * kp_lo - g * ip_lm + h * io_km) +
                   c * (e * jp_ln - f * ip_lm + h * in_jm) -
                   d * (e * jo_kn - f * io_km + g * in_jm);
        }

        /// <summary>
        /// Attempts to calculate the inverse of the given matrix. If successful, result will contain the inverted matrix.
        /// </summary>
        /// <param name="matrix">The source matrix to invert.</param>
        /// <param name="result">If successful, contains the inverted matrix.</param>
        /// <returns>True if the source matrix could be inverted; False otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Invert(Matrix4x4 matrix, out Matrix4x4 result)
        {
            //                                       -1
            // If you have matrix M, inverse Matrix M   can compute
            //
            //     -1       1      
            //    M   = --------- A
            //            det(M)
            //
            // A is adjugate (adjoint) of M, where,
            //
            //      T
            // A = C
            //
            // C is Cofactor matrix of M, where,
            //           i + j
            // C   = (-1)      * det(M  )
            //  ij                    ij
            //
            //     [ a b c d ]
            // M = [ e f g h ]
            //     [ i j k l ]
            //     [ m n o p ]
            //
            // First Row
            //           2 | f g h |
            // C   = (-1)  | j k l | = + ( f ( kp - lo ) - g ( jp - ln ) + h ( jo - kn ) )
            //  11         | n o p |
            //
            //           3 | e g h |
            // C   = (-1)  | i k l | = - ( e ( kp - lo ) - g ( ip - lm ) + h ( io - km ) )
            //  12         | m o p |
            //
            //           4 | e f h |
            // C   = (-1)  | i j l | = + ( e ( jp - ln ) - f ( ip - lm ) + h ( in - jm ) )
            //  13         | m n p |
            //
            //           5 | e f g |
            // C   = (-1)  | i j k | = - ( e ( jo - kn ) - f ( io - km ) + g ( in - jm ) )
            //  14         | m n o |
            //
            // Second Row
            //           3 | b c d |
            // C   = (-1)  | j k l | = - ( b ( kp - lo ) - c ( jp - ln ) + d ( jo - kn ) )
            //  21         | n o p |
            //
            //           4 | a c d |
            // C   = (-1)  | i k l | = + ( a ( kp - lo ) - c ( ip - lm ) + d ( io - km ) )
            //  22         | m o p |
            //
            //           5 | a b d |
            // C   = (-1)  | i j l | = - ( a ( jp - ln ) - b ( ip - lm ) + d ( in - jm ) )
            //  23         | m n p |
            //
            //           6 | a b c |
            // C   = (-1)  | i j k | = + ( a ( jo - kn ) - b ( io - km ) + c ( in - jm ) )
            //  24         | m n o |
            //
            // Third Row
            //           4 | b c d |
            // C   = (-1)  | f g h | = + ( b ( gp - ho ) - c ( fp - hn ) + d ( fo - gn ) )
            //  31         | n o p |
            //
            //           5 | a c d |
            // C   = (-1)  | e g h | = - ( a ( gp - ho ) - c ( ep - hm ) + d ( eo - gm ) )
            //  32         | m o p |
            //
            //           6 | a b d |
            // C   = (-1)  | e f h | = + ( a ( fp - hn ) - b ( ep - hm ) + d ( en - fm ) )
            //  33         | m n p |
            //
            //           7 | a b c |
            // C   = (-1)  | e f g | = - ( a ( fo - gn ) - b ( eo - gm ) + c ( en - fm ) )
            //  34         | m n o |
            //
            // Fourth Row
            //           5 | b c d |
            // C   = (-1)  | f g h | = - ( b ( gl - hk ) - c ( fl - hj ) + d ( fk - gj ) )
            //  41         | j k l |
            //
            //           6 | a c d |
            // C   = (-1)  | e g h | = + ( a ( gl - hk ) - c ( el - hi ) + d ( ek - gi ) )
            //  42         | i k l |
            //
            //           7 | a b d |
            // C   = (-1)  | e f h | = - ( a ( fl - hj ) - b ( el - hi ) + d ( ej - fi ) )
            //  43         | i j l |
            //
            //           8 | a b c |
            // C   = (-1)  | e f g | = + ( a ( fk - gj ) - b ( ek - gi ) + c ( ej - fi ) )
            //  44         | i j k |
            //
            // Cost of operation
            // 53 adds, 104 muls, and 1 div.
            double a = matrix.M11, b = matrix.M12, c = matrix.M13, d = matrix.M14;
            double e = matrix.M21, f = matrix.M22, g = matrix.M23, h = matrix.M24;
            double i = matrix.M31, j = matrix.M32, k = matrix.M33, l = matrix.M34;
            double m = matrix.M41, n = matrix.M42, o = matrix.M43, p = matrix.M44;

            var kp_lo = k * p - l * o;
            var jp_ln = j * p - l * n;
            var jo_kn = j * o - k * n;
            var ip_lm = i * p - l * m;
            var io_km = i * o - k * m;
            var in_jm = i * n - j * m;

            var a11 = +(f * kp_lo - g * jp_ln + h * jo_kn);
            var a12 = -(e * kp_lo - g * ip_lm + h * io_km);
            var a13 = +(e * jp_ln - f * ip_lm + h * in_jm);
            var a14 = -(e * jo_kn - f * io_km + g * in_jm);

            var det = a * a11 + b * a12 + c * a13 + d * a14;

            if (Math.Abs(det) <= double.Epsilon)
            {
                result = new Matrix4x4((double.NaN, double.NaN, double.NaN, double.NaN),
                                       (double.NaN, double.NaN, double.NaN, double.NaN),
                                       (double.NaN, double.NaN, double.NaN, double.NaN),
                                       (double.NaN, double.NaN, double.NaN, double.NaN));
                return false;
            }

            var invDet = 1.0f / det;

            var M11 = a11 * invDet;
            var M21 = a12 * invDet;
            var M31 = a13 * invDet;
            var M41 = a14 * invDet;

            var M12 = -(b * kp_lo - c * jp_ln + d * jo_kn) * invDet;
            var M22 = +(a * kp_lo - c * ip_lm + d * io_km) * invDet;
            var M32 = -(a * jp_ln - b * ip_lm + d * in_jm) * invDet;
            var M42 = +(a * jo_kn - b * io_km + c * in_jm) * invDet;

            var gp_ho = g * p - h * o;
            var fp_hn = f * p - h * n;
            var fo_gn = f * o - g * n;
            var ep_hm = e * p - h * m;
            var eo_gm = e * o - g * m;
            var en_fm = e * n - f * m;

            var M13 = +(b * gp_ho - c * fp_hn + d * fo_gn) * invDet;
            var M23 = -(a * gp_ho - c * ep_hm + d * eo_gm) * invDet;
            var M33 = +(a * fp_hn - b * ep_hm + d * en_fm) * invDet;
            var M43 = -(a * fo_gn - b * eo_gm + c * en_fm) * invDet;

            var gl_hk = g * l - h * k;
            var fl_hj = f * l - h * j;
            var fk_gj = f * k - g * j;
            var el_hi = e * l - h * i;
            var ek_gi = e * k - g * i;
            var ej_fi = e * j - f * i;

            var M14 = -(b * gl_hk - c * fl_hj + d * fk_gj) * invDet;
            var M24 = +(a * gl_hk - c * el_hi + d * ek_gi) * invDet;
            var M34 = -(a * fl_hj - b * el_hi + d * ej_fi) * invDet;
            var M44 = +(a * fk_gj - b * ek_gi + c * ej_fi) * invDet;

            result = (
                (M11, M21, M31, M41),
                (M12, M22, M32, M42),
                (M13, M23, M33, M43),
                (M14, M24, M34, M44));

            return true;
        }

        /// <summary>
        /// Multiplies a matrix by another matrix.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4x4 operator *(Matrix4x4 a, Matrix4x4 b)
        {
            var M11 = a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41;
            var M12 = a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42;
            var M13 = a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43;
            var M14 = a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44;

            // Second row
            var M21 = a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41;
            var M22 = a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42;
            var M23 = a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43;
            var M24 = a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44;

            // Third row
            var M31 = a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41;
            var M32 = a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42;
            var M33 = a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43;
            var M34 = a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44;

            // Fourth row
            var M41 = a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41;
            var M42 = a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42;
            var M43 = a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43;
            var M44 = a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44;

            return (
                (M11, M21, M31, M41), 
                (M12, M22, M32, M42),
                (M13, M23, M33, M43),
                (M14, M24, M34, M44));
        }

        /// <summary>
        /// Multiplies a matrix by a scalar value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4x4 operator *(Matrix4x4 a, double scalar)
            => (a.Column1 * scalar,
                a.Column2 * scalar,
                a.Column3 * scalar,
                a.Column4 * scalar);

        public Vector3D TransformVector(Vector3D v)
            => (v.X * M11 + v.Y * M21 + v.Z * M31,
                v.X * M12 + v.Y * M22 + v.Z * M32,
                v.X * M13 + v.Y * M23 + v.Z * M33);

        public Vector3D TransformPoint(Vector3D v)
            => this * v;

        public static Matrix4x4 CreateTRS(Vector3D translation, Quaternion rotation, Vector3D scale)
            => CreateTranslation(translation) * CreateRotation(rotation) * CreateScale(scale);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4x4 CreateTranslationRotation(Vector3D translation, Quaternion rotation)
            => CreateTranslation(translation) * CreateRotation(rotation);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix4x4 ScaleTranslation(double amount)
            => SetTranslation(Translation * amount);

        public static implicit operator Matrix4x4(Quaternion q)
            => CreateRotation(q);

        public static implicit operator Matrix4x4(Vector3D v)
            => CreateTranslation(v);

        public static implicit operator Matrix4x4(Transform3D t)
            => CreateTRS(t.Translation, t.Rotation.Quaternion, t.Scale);

        public static implicit operator Matrix4x4(Pose3D p)
            => CreateTranslation(p.Position) * p.Orientation;

        public static implicit operator Matrix4x4(Rotation3D r)
            => r.Quaternion;

        public static implicit operator Matrix4x4(Orientation3D o)
            => o.IValue;

        public Matrix4x4 Transpose
            => (
                (M11, M12, M13, M14),
                (M21, M22, M23, M24),
                (M31, M32, M33, M34),
                (M41, M42, M43, M44));
    }
}