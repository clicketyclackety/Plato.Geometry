﻿using Plato.DoublePrecision;

namespace Plato.Geometry
{
    public static class SurfaceFunctions
    {

        public static Vector3D Sphere(this Vector2D uv)
            => Sphere(uv.X.Turns, uv.Y.Turns);

        public static Vector3D Sphere(Angle u, Angle v)
            => (-u.Cos * v.Sin, v.Cos, u.Sin * v.Sin);

        // https://en.wikipedia.org/wiki/Torus#Geometry
        public static Vector3D Torus(this Vector2D uv, Number r1, Number r2)
            => Torus(uv.X.Turns, uv.Y.Turns, r1, r2);

        public static Vector3D Torus(Angle u, Angle v, Number r1, Number r2)
            => ((r1 + r2 * u.Cos) * v.Cos,
                (r1 + r2 * u.Cos) * v.Sin,
                r2 * u.Sin);

        public static Vector3D PlaneXY(this Vector2D uv)
            => uv;

        public static Vector2D Disc(this Vector2D uv)
            => uv.X.Turns.CircleFunction * uv.Y;

        public static Vector3D Disc3D(this Vector2D uv)
            => uv.Disc();

        public static Vector3D Cylinder(this Vector2D uv)
            => ((Vector3D)uv.X.Turns.CircleFunction).WithZ(uv.Y);

        public static Vector3D ConicalSection(this Vector2D uv, Number r1, Number r2)
            => (uv.X.CircleFunction * r1.Lerp(r2, uv.Y)).Vector3D.WithZ(uv.Y);

        public static Vector3D Capsule(this Vector2D uv)
        {
            uv *= (1, 2);
            if (uv.Y < 0.5) return Sphere((uv.Y, uv.X));
            if (uv.Y > 1.5) return Sphere((uv.Y - 1, uv.X)) + (0, 0, 1);
            return (uv + (0, -0.5f)).Cylinder();
        }

        public static Angle Turns(this int n)
            => ((Number)n).Turns;

        // https://commons.wikimedia.org/wiki/File:Parametric_surface_illustration_(trefoil_knot).png
      

        //===
        // Height fields converted into surface functions 
        //===

        /*
        public static Func<Vector2D, Vector3D> ToSurfaceFunction(this Func<Vector2D, float> f)
            => uv => (uv.X, uv.Y, f(uv));

        public static Vector3D MonkeySaddle(this Vector2D uv)
            => ToSurfaceFunction(HeightFieldFunctions.MonkeySaddle)(uv);

        public static Vector3D Handkerchief(this Vector2D uv)
            => ToSurfaceFunction(HeightFieldFunctions.Handkerchief)(uv);

        public static Vector3D CrossedTrough(this Vector2D uv)
            => ToSurfaceFunction(HeightFieldFunctions.CrossedTrough)(uv);

        public static Vector3D SinPlusCos(this Vector2D uv)
            => ToSurfaceFunction(HeightFieldFunctions.SinPlusCos)(uv);
        */
    }
}