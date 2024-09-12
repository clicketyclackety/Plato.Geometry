namespace Plato.SinglePrecision
{
    public interface Any
    {
        Array<String> FieldNames { get; }
        Array<Dynamic> FieldValues { get; }
        String TypeName { get; }
    }
    public interface Value<Self>: Any, Equatable<Self>
    {
    }
    public interface Numerical<Self>: Value<Self>
    {
        Array<Number> Components { get; }
        Self FromComponents { get; }
    }
    public interface Real<Self>: Numerical<Self>, ScalarArithmetic<Self>, Comparable<Self>, Arithmetic<Self>
    {
        Number Value { get; }
    }
    public interface Measure<Self>: Numerical<Self>, ScalarArithmetic<Self>, Comparable<Self>, AdditiveArithmetic<Self>
    {
        Number Value { get; }
    }
    public interface Vector<Self>: Numerical<Self>, ScalarArithmetic<Self>, Arithmetic<Self>, Array<Number>
    {
    }
    public interface WholeNumber<Self>: Numerical<Self>, Comparable<Self>, Arithmetic<Self>
    {
        Integer Value { get; }
    }
    public interface Array<T>
    {
        Integer Count { get; }
        T At(Integer n);
    }
    public interface Array2D<T>: Array<T>
    {
        Integer RowCount { get; }
        Integer ColumnCount { get; }
        T At(Integer column, Integer row);
    }
    public interface Array3D<T>: Array<T>
    {
        Integer RowCount { get; }
        Integer ColumnCount { get; }
        Integer LayerCount { get; }
        T At(Integer column, Integer row, Integer layer);
    }
    public interface Coordinate<Self>: Value<Self>
    {
    }
    public interface Comparable<Self>
    {
        Integer Compare(Self y);
    }
    public interface Equatable<Self>
    {
        Boolean Equals(Self b);
        Boolean NotEquals(Self b);
    }
    public interface AdditiveInverse<Self>
    {
        Self Negative { get; }
    }
    public interface MultiplicativeInverse<Self>
    {
        Self Reciprocal { get; }
    }
    public interface AdditiveArithmetic<Self>: AdditiveInverse<Self>
    {
        Self Add(Self b);
        Self Subtract(Self b);
    }
    public interface MultiplicativeArithmetic<Self, T>
    {
        Self Multiply(T other);
        Self Multiply(Self self);
        Self Divide(T other);
        Self Modulo(T other);
    }
    public interface ScalarArithmetic<Self>: MultiplicativeArithmetic<Self, Number>
    {
    }
    public interface Arithmetic<Self>: AdditiveInverse<Self>, MultiplicativeInverse<Self>
    {
        Self Add(Self b);
        Self Subtract(Self b);
        Self Multiply(Self b);
        Self Divide(Self b);
        Self Modulo(Self b);
    }
    public interface BooleanOperations<Self>
    {
        Self And(Self b);
        Self Or(Self b);
        Self Not { get; }
    }
    public interface Interval<Self, T>: Equatable<Self>, Value<Self>
    {
        T Min { get; }
        T Max { get; }
        T Size { get; }
    }
    public interface Bounded2D
    {
        Bounds2D Bounds { get; }
    }
    public interface Bounded3D
    {
        Bounds3D Bounds { get; }
    }
    public interface Transformable2D<Self>
    {
        Self Transform(Matrix3x3 matrix);
    }
    public interface Transformable3D<Self>
    {
        Self Transform(Matrix4x4 matrix);
    }
    public interface Deformable2D<Self>
    {
        Self Deform(System.Func<Vector2D, Vector2D> f);
    }
    public interface OpenClosedShape
    {
        Boolean Closed { get; }
    }
    public interface Deformable3D<Self>: Transformable3D<Self>
    {
        Self Deform(System.Func<Vector3D, Vector3D> f);
    }
    public interface Geometry
    {
    }
    public interface Geometry2D: Geometry
    {
    }
    public interface Geometry3D: Geometry
    {
    }
    public interface Shape2D: Geometry2D
    {
    }
    public interface Shape3D: Geometry3D
    {
    }
    public interface OpenShape2D: Geometry2D, OpenClosedShape
    {
    }
    public interface ClosedShape2D: Geometry2D, OpenClosedShape
    {
    }
    public interface OpenShape3D: Geometry3D, OpenClosedShape
    {
    }
    public interface ClosedShape3D: Geometry3D, OpenClosedShape
    {
    }
    public interface Procedural<TDomain, TRange>
    {
        TRange Eval(TDomain amount);
    }
    public interface Curve<TRange>: Procedural<Number, TRange>, OpenClosedShape
    {
    }
    public interface Curve1D: Curve<Number>
    {
    }
    public interface Curve2D: Geometry2D, Curve<Vector2D>
    {
    }
    public interface Curve3D: Geometry3D, Curve<Vector3D>
    {
    }
    public interface Surface: Geometry3D
    {
    }
    public interface ParametricSurface: Procedural<Vector2D, Vector3D>, Surface
    {
        Boolean PeriodicU { get; }
        Boolean PeriodicV { get; }
    }
    public interface ExplicitSurface: Procedural<Vector2D, Number>, Surface
    {
    }
    public interface DistanceField<TDomain>: Procedural<TDomain, Number>
    {
    }
    public interface Field2D<T>: Geometry2D, Procedural<Vector2D, T>
    {
    }
    public interface Field3D<T>: Geometry3D, Procedural<Vector3D, T>
    {
    }
    public interface ScalarField2D: Field2D<Number>
    {
    }
    public interface ScalarField3D: Field3D<Number>
    {
    }
    public interface DistanceField2D: ScalarField2D
    {
    }
    public interface DistanceField3D: ScalarField3D
    {
    }
    public interface Vector3Field2D: Field2D<Vector3D>
    {
    }
    public interface Vector4Field2D: Field2D<Vector4D>
    {
    }
    public interface Vector2Field3D: Field3D<Vector2D>
    {
    }
    public interface Vector3Field3D: Field3D<Vector3D>
    {
    }
    public interface Vector4Field3D: Field3D<Vector4D>
    {
    }
    public interface ImplicitProcedural<TDomain>
    {
        Boolean Eval(TDomain amount, TDomain epsilon);
    }
    public interface ImplicitSurface: Surface, ImplicitProcedural<Vector3D>
    {
    }
    public interface ImplicitCurve2D: Geometry2D, ImplicitProcedural<Vector2D>
    {
    }
    public interface ImplicitVolume: Geometry3D, ImplicitProcedural<Vector3D>
    {
    }
    public interface Points2D: Geometry2D
    {
        Array<Vector2D> Points { get; }
    }
    public interface Points3D: Geometry3D
    {
        Array<Vector3D> Points { get; }
    }
    public interface BezierPatch: Points3D, Surface, Array2D<Vector3D>
    {
    }
    public interface PolyhederalFace
    {
        Integer FaceIndex { get; }
        Array<Integer> VertexIndices { get; }
        Polyhedron Polyhedron { get; }
    }
    public interface Polyhedron: Surface, Points3D
    {
        Array<PolyhederalFace> Faces { get; }
    }
    public interface ConvexPolyhedron: Polyhedron
    {
    }
    public interface SolidPolyhedron: Polyhedron
    {
    }
    public interface Mesh<FaceType, VertexType>: Geometry3D
    {
        Array<FaceType> Faces { get; }
        Array<VertexType> Vertices { get; }
    }
    public interface Grid2D: Array2D<Vector2D>
    {
    }
    public interface QuadGrid: Array2D<Vector3D>
    {
        Boolean ClosedX { get; }
        Boolean ClosedY { get; }
    }
    public interface PolyLine2D: Points2D, OpenClosedShape
    {
    }
    public interface PolyLine3D: Points3D, OpenClosedShape
    {
    }
    public interface ClosedPolyLine2D: PolyLine2D, ClosedShape2D
    {
    }
    public interface ClosedPolyLine3D: PolyLine3D
    {
    }
    public interface Polygon2D: PolyLine2D
    {
    }
    public interface Polygon3D: PolyLine3D
    {
    }
    public readonly partial struct LazyArray<T>: Array<T>
    {
        public readonly Integer Count;
        public readonly Function1<Integer, T> Function;
        public LazyArray<T> WithCount(Integer count) => (count, Function);
        public LazyArray<T> WithFunction(Function1<Integer, T> function) => (Count, function);
        public LazyArray(Integer count, Function1<Integer, T> function) => (Count, Function) = (count, function);
        public static LazyArray<T> Default = new LazyArray<T>();
        public static LazyArray<T> New(Integer count, Function1<Integer, T> function) => new LazyArray<T>(count, function);
        public static implicit operator (Integer, Function1<Integer, T>)(LazyArray<T> self) => (self.Count, self.Function);
        public static implicit operator LazyArray<T>((Integer, Function1<Integer, T>) value) => new LazyArray<T>(value.Item1, value.Item2);
        public void Deconstruct(out Integer count, out Function1<Integer, T> function) { count = Count; function = Function; }
        public override bool Equals(object obj) { if (!(obj is LazyArray<T>)) return false; var other = (LazyArray<T>)obj; return Count.Equals(other.Count) && Function.Equals(other.Function); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Count, Function);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(LazyArray<T> self) => new Dynamic(self);
        public static implicit operator LazyArray<T>(Dynamic value) => value.As<LazyArray<T>>();
        public String TypeName => "LazyArray<T>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Count", (String)"Function");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Count), new Dynamic(Function));
        Integer Array<T>.Count => Count;
        // Unimplemented concept functions
    }
    public readonly partial struct LazyArray2D<T>: Array2D<T>
    {
        public readonly Integer ColumnCount;
        public readonly Integer RowCount;
        public readonly Function2<Integer, Integer, T> Function;
        public LazyArray2D<T> WithColumnCount(Integer columnCount) => (columnCount, RowCount, Function);
        public LazyArray2D<T> WithRowCount(Integer rowCount) => (ColumnCount, rowCount, Function);
        public LazyArray2D<T> WithFunction(Function2<Integer, Integer, T> function) => (ColumnCount, RowCount, function);
        public LazyArray2D(Integer columnCount, Integer rowCount, Function2<Integer, Integer, T> function) => (ColumnCount, RowCount, Function) = (columnCount, rowCount, function);
        public static LazyArray2D<T> Default = new LazyArray2D<T>();
        public static LazyArray2D<T> New(Integer columnCount, Integer rowCount, Function2<Integer, Integer, T> function) => new LazyArray2D<T>(columnCount, rowCount, function);
        public static implicit operator (Integer, Integer, Function2<Integer, Integer, T>)(LazyArray2D<T> self) => (self.ColumnCount, self.RowCount, self.Function);
        public static implicit operator LazyArray2D<T>((Integer, Integer, Function2<Integer, Integer, T>) value) => new LazyArray2D<T>(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Integer columnCount, out Integer rowCount, out Function2<Integer, Integer, T> function) { columnCount = ColumnCount; rowCount = RowCount; function = Function; }
        public override bool Equals(object obj) { if (!(obj is LazyArray2D<T>)) return false; var other = (LazyArray2D<T>)obj; return ColumnCount.Equals(other.ColumnCount) && RowCount.Equals(other.RowCount) && Function.Equals(other.Function); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(ColumnCount, RowCount, Function);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(LazyArray2D<T> self) => new Dynamic(self);
        public static implicit operator LazyArray2D<T>(Dynamic value) => value.As<LazyArray2D<T>>();
        public String TypeName => "LazyArray2D<T>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"ColumnCount", (String)"RowCount", (String)"Function");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(ColumnCount), new Dynamic(RowCount), new Dynamic(Function));
        Integer Array2D<T>.RowCount => RowCount;
        Integer Array2D<T>.ColumnCount => ColumnCount;
        // Unimplemented concept functions
        public T At(Integer column, Integer row) => throw new NotImplementedException();
    }
    public readonly partial struct LazyArray3D<T>: Array3D<T>
    {
        public readonly Integer ColumnCount;
        public readonly Integer RowCount;
        public readonly Integer LayerCount;
        public readonly Function3<Integer, Integer, Integer, T> Function;
        public LazyArray3D<T> WithColumnCount(Integer columnCount) => (columnCount, RowCount, LayerCount, Function);
        public LazyArray3D<T> WithRowCount(Integer rowCount) => (ColumnCount, rowCount, LayerCount, Function);
        public LazyArray3D<T> WithLayerCount(Integer layerCount) => (ColumnCount, RowCount, layerCount, Function);
        public LazyArray3D<T> WithFunction(Function3<Integer, Integer, Integer, T> function) => (ColumnCount, RowCount, LayerCount, function);
        public LazyArray3D(Integer columnCount, Integer rowCount, Integer layerCount, Function3<Integer, Integer, Integer, T> function) => (ColumnCount, RowCount, LayerCount, Function) = (columnCount, rowCount, layerCount, function);
        public static LazyArray3D<T> Default = new LazyArray3D<T>();
        public static LazyArray3D<T> New(Integer columnCount, Integer rowCount, Integer layerCount, Function3<Integer, Integer, Integer, T> function) => new LazyArray3D<T>(columnCount, rowCount, layerCount, function);
        public static implicit operator (Integer, Integer, Integer, Function3<Integer, Integer, Integer, T>)(LazyArray3D<T> self) => (self.ColumnCount, self.RowCount, self.LayerCount, self.Function);
        public static implicit operator LazyArray3D<T>((Integer, Integer, Integer, Function3<Integer, Integer, Integer, T>) value) => new LazyArray3D<T>(value.Item1, value.Item2, value.Item3, value.Item4);
        public void Deconstruct(out Integer columnCount, out Integer rowCount, out Integer layerCount, out Function3<Integer, Integer, Integer, T> function) { columnCount = ColumnCount; rowCount = RowCount; layerCount = LayerCount; function = Function; }
        public override bool Equals(object obj) { if (!(obj is LazyArray3D<T>)) return false; var other = (LazyArray3D<T>)obj; return ColumnCount.Equals(other.ColumnCount) && RowCount.Equals(other.RowCount) && LayerCount.Equals(other.LayerCount) && Function.Equals(other.Function); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(ColumnCount, RowCount, LayerCount, Function);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(LazyArray3D<T> self) => new Dynamic(self);
        public static implicit operator LazyArray3D<T>(Dynamic value) => value.As<LazyArray3D<T>>();
        public String TypeName => "LazyArray3D<T>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"ColumnCount", (String)"RowCount", (String)"LayerCount", (String)"Function");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(ColumnCount), new Dynamic(RowCount), new Dynamic(LayerCount), new Dynamic(Function));
        Integer Array3D<T>.RowCount => RowCount;
        Integer Array3D<T>.ColumnCount => ColumnCount;
        Integer Array3D<T>.LayerCount => LayerCount;
        // Unimplemented concept functions
        public T At(Integer column, Integer row, Integer layer) => throw new NotImplementedException();
    }
    public readonly partial struct Transform2D: Value<Transform2D>
    {
        public readonly Vector2D Translation;
        public readonly Angle Rotation;
        public readonly Vector2D Scale;
        public Transform2D WithTranslation(Vector2D translation) => (translation, Rotation, Scale);
        public Transform2D WithRotation(Angle rotation) => (Translation, rotation, Scale);
        public Transform2D WithScale(Vector2D scale) => (Translation, Rotation, scale);
        public Transform2D(Vector2D translation, Angle rotation, Vector2D scale) => (Translation, Rotation, Scale) = (translation, rotation, scale);
        public static Transform2D Default = new Transform2D();
        public static Transform2D New(Vector2D translation, Angle rotation, Vector2D scale) => new Transform2D(translation, rotation, scale);
        public Plato.DoublePrecision.Transform2D ChangePrecision() => (Translation.ChangePrecision(), Rotation.ChangePrecision(), Scale.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Transform2D(Transform2D self) => self.ChangePrecision();
        public static implicit operator (Vector2D, Angle, Vector2D)(Transform2D self) => (self.Translation, self.Rotation, self.Scale);
        public static implicit operator Transform2D((Vector2D, Angle, Vector2D) value) => new Transform2D(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Vector2D translation, out Angle rotation, out Vector2D scale) { translation = Translation; rotation = Rotation; scale = Scale; }
        public override bool Equals(object obj) { if (!(obj is Transform2D)) return false; var other = (Transform2D)obj; return Translation.Equals(other.Translation) && Rotation.Equals(other.Rotation) && Scale.Equals(other.Scale); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Translation, Rotation, Scale);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Transform2D self) => new Dynamic(self);
        public static implicit operator Transform2D(Dynamic value) => value.As<Transform2D>();
        public String TypeName => "Transform2D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Translation", (String)"Rotation", (String)"Scale");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Translation), new Dynamic(Rotation), new Dynamic(Scale));
        // Unimplemented concept functions
        public Boolean Equals(Transform2D b) => (Translation.Equals(b.Translation) & Rotation.Equals(b.Rotation) & Scale.Equals(b.Scale));
        public static Boolean operator ==(Transform2D a, Transform2D b) => a.Equals(b);
        public Boolean NotEquals(Transform2D b) => (Translation.NotEquals(b.Translation) & Rotation.NotEquals(b.Rotation) & Scale.NotEquals(b.Scale));
        public static Boolean operator !=(Transform2D a, Transform2D b) => a.NotEquals(b);
    }
    public readonly partial struct Pose2D: Value<Pose2D>
    {
        public readonly Vector2D Position;
        public readonly Angle Orientation;
        public Pose2D WithPosition(Vector2D position) => (position, Orientation);
        public Pose2D WithOrientation(Angle orientation) => (Position, orientation);
        public Pose2D(Vector2D position, Angle orientation) => (Position, Orientation) = (position, orientation);
        public static Pose2D Default = new Pose2D();
        public static Pose2D New(Vector2D position, Angle orientation) => new Pose2D(position, orientation);
        public Plato.DoublePrecision.Pose2D ChangePrecision() => (Position.ChangePrecision(), Orientation.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Pose2D(Pose2D self) => self.ChangePrecision();
        public static implicit operator (Vector2D, Angle)(Pose2D self) => (self.Position, self.Orientation);
        public static implicit operator Pose2D((Vector2D, Angle) value) => new Pose2D(value.Item1, value.Item2);
        public void Deconstruct(out Vector2D position, out Angle orientation) { position = Position; orientation = Orientation; }
        public override bool Equals(object obj) { if (!(obj is Pose2D)) return false; var other = (Pose2D)obj; return Position.Equals(other.Position) && Orientation.Equals(other.Orientation); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Position, Orientation);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Pose2D self) => new Dynamic(self);
        public static implicit operator Pose2D(Dynamic value) => value.As<Pose2D>();
        public String TypeName => "Pose2D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Position", (String)"Orientation");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Position), new Dynamic(Orientation));
        // Unimplemented concept functions
        public Boolean Equals(Pose2D b) => (Position.Equals(b.Position) & Orientation.Equals(b.Orientation));
        public static Boolean operator ==(Pose2D a, Pose2D b) => a.Equals(b);
        public Boolean NotEquals(Pose2D b) => (Position.NotEquals(b.Position) & Orientation.NotEquals(b.Orientation));
        public static Boolean operator !=(Pose2D a, Pose2D b) => a.NotEquals(b);
    }
    public readonly partial struct Bounds2D: Interval<Bounds2D, Vector2D>
    {
        public readonly Vector2D Min;
        public readonly Vector2D Max;
        public Bounds2D WithMin(Vector2D min) => (min, Max);
        public Bounds2D WithMax(Vector2D max) => (Min, max);
        public Bounds2D(Vector2D min, Vector2D max) => (Min, Max) = (min, max);
        public static Bounds2D Default = new Bounds2D();
        public static Bounds2D New(Vector2D min, Vector2D max) => new Bounds2D(min, max);
        public Plato.DoublePrecision.Bounds2D ChangePrecision() => (Min.ChangePrecision(), Max.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Bounds2D(Bounds2D self) => self.ChangePrecision();
        public static implicit operator (Vector2D, Vector2D)(Bounds2D self) => (self.Min, self.Max);
        public static implicit operator Bounds2D((Vector2D, Vector2D) value) => new Bounds2D(value.Item1, value.Item2);
        public void Deconstruct(out Vector2D min, out Vector2D max) { min = Min; max = Max; }
        public override bool Equals(object obj) { if (!(obj is Bounds2D)) return false; var other = (Bounds2D)obj; return Min.Equals(other.Min) && Max.Equals(other.Max); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Min, Max);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Bounds2D self) => new Dynamic(self);
        public static implicit operator Bounds2D(Dynamic value) => value.As<Bounds2D>();
        public String TypeName => "Bounds2D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Min", (String)"Max");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Min), new Dynamic(Max));
        Vector2D Interval<Bounds2D, Vector2D>.Min => Min;
        Vector2D Interval<Bounds2D, Vector2D>.Max => Max;
        // Unimplemented concept functions
        public Boolean Equals(Bounds2D b) => (Min.Equals(b.Min) & Max.Equals(b.Max));
        public static Boolean operator ==(Bounds2D a, Bounds2D b) => a.Equals(b);
        public Boolean NotEquals(Bounds2D b) => (Min.NotEquals(b.Min) & Max.NotEquals(b.Max));
        public static Boolean operator !=(Bounds2D a, Bounds2D b) => a.NotEquals(b);
    }
    public readonly partial struct Ray2D: Value<Ray2D>
    {
        public readonly Vector2D Direction;
        public readonly Vector2D Position;
        public Ray2D WithDirection(Vector2D direction) => (direction, Position);
        public Ray2D WithPosition(Vector2D position) => (Direction, position);
        public Ray2D(Vector2D direction, Vector2D position) => (Direction, Position) = (direction, position);
        public static Ray2D Default = new Ray2D();
        public static Ray2D New(Vector2D direction, Vector2D position) => new Ray2D(direction, position);
        public Plato.DoublePrecision.Ray2D ChangePrecision() => (Direction.ChangePrecision(), Position.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Ray2D(Ray2D self) => self.ChangePrecision();
        public static implicit operator (Vector2D, Vector2D)(Ray2D self) => (self.Direction, self.Position);
        public static implicit operator Ray2D((Vector2D, Vector2D) value) => new Ray2D(value.Item1, value.Item2);
        public void Deconstruct(out Vector2D direction, out Vector2D position) { direction = Direction; position = Position; }
        public override bool Equals(object obj) { if (!(obj is Ray2D)) return false; var other = (Ray2D)obj; return Direction.Equals(other.Direction) && Position.Equals(other.Position); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Direction, Position);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Ray2D self) => new Dynamic(self);
        public static implicit operator Ray2D(Dynamic value) => value.As<Ray2D>();
        public String TypeName => "Ray2D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Direction", (String)"Position");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Direction), new Dynamic(Position));
        // Unimplemented concept functions
        public Boolean Equals(Ray2D b) => (Direction.Equals(b.Direction) & Position.Equals(b.Position));
        public static Boolean operator ==(Ray2D a, Ray2D b) => a.Equals(b);
        public Boolean NotEquals(Ray2D b) => (Direction.NotEquals(b.Direction) & Position.NotEquals(b.Position));
        public static Boolean operator !=(Ray2D a, Ray2D b) => a.NotEquals(b);
    }
    public readonly partial struct Triangle2D: Value<Triangle2D>, Array<Vector2D>
    {
        public readonly Vector2D A;
        public readonly Vector2D B;
        public readonly Vector2D C;
        public Triangle2D WithA(Vector2D a) => (a, B, C);
        public Triangle2D WithB(Vector2D b) => (A, b, C);
        public Triangle2D WithC(Vector2D c) => (A, B, c);
        public Triangle2D(Vector2D a, Vector2D b, Vector2D c) => (A, B, C) = (a, b, c);
        public static Triangle2D Default = new Triangle2D();
        public static Triangle2D New(Vector2D a, Vector2D b, Vector2D c) => new Triangle2D(a, b, c);
        public Plato.DoublePrecision.Triangle2D ChangePrecision() => (A.ChangePrecision(), B.ChangePrecision(), C.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Triangle2D(Triangle2D self) => self.ChangePrecision();
        public static implicit operator (Vector2D, Vector2D, Vector2D)(Triangle2D self) => (self.A, self.B, self.C);
        public static implicit operator Triangle2D((Vector2D, Vector2D, Vector2D) value) => new Triangle2D(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Vector2D a, out Vector2D b, out Vector2D c) { a = A; b = B; c = C; }
        public override bool Equals(object obj) { if (!(obj is Triangle2D)) return false; var other = (Triangle2D)obj; return A.Equals(other.A) && B.Equals(other.B) && C.Equals(other.C); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(A, B, C);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Triangle2D self) => new Dynamic(self);
        public static implicit operator Triangle2D(Dynamic value) => value.As<Triangle2D>();
        public String TypeName => "Triangle2D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"A", (String)"B", (String)"C");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(A), new Dynamic(B), new Dynamic(C));
        // Unimplemented concept functions
        public Boolean Equals(Triangle2D b) => (A.Equals(b.A) & B.Equals(b.B) & C.Equals(b.C));
        public static Boolean operator ==(Triangle2D a, Triangle2D b) => a.Equals(b);
        public Boolean NotEquals(Triangle2D b) => (A.NotEquals(b.A) & B.NotEquals(b.B) & C.NotEquals(b.C));
        public static Boolean operator !=(Triangle2D a, Triangle2D b) => a.NotEquals(b);
        public Integer Count => 3;
        public Vector2D At(Integer n) => n == 0 ? A : n == 1 ? B : n == 2 ? C : throw new System.IndexOutOfRangeException();
        public Vector2D this[Integer n] => At(n);
    }
    public readonly partial struct Quad2D: Value<Quad2D>, Array<Vector2D>
    {
        public readonly Vector2D A;
        public readonly Vector2D B;
        public readonly Vector2D C;
        public readonly Vector2D D;
        public Quad2D WithA(Vector2D a) => (a, B, C, D);
        public Quad2D WithB(Vector2D b) => (A, b, C, D);
        public Quad2D WithC(Vector2D c) => (A, B, c, D);
        public Quad2D WithD(Vector2D d) => (A, B, C, d);
        public Quad2D(Vector2D a, Vector2D b, Vector2D c, Vector2D d) => (A, B, C, D) = (a, b, c, d);
        public static Quad2D Default = new Quad2D();
        public static Quad2D New(Vector2D a, Vector2D b, Vector2D c, Vector2D d) => new Quad2D(a, b, c, d);
        public Plato.DoublePrecision.Quad2D ChangePrecision() => (A.ChangePrecision(), B.ChangePrecision(), C.ChangePrecision(), D.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Quad2D(Quad2D self) => self.ChangePrecision();
        public static implicit operator (Vector2D, Vector2D, Vector2D, Vector2D)(Quad2D self) => (self.A, self.B, self.C, self.D);
        public static implicit operator Quad2D((Vector2D, Vector2D, Vector2D, Vector2D) value) => new Quad2D(value.Item1, value.Item2, value.Item3, value.Item4);
        public void Deconstruct(out Vector2D a, out Vector2D b, out Vector2D c, out Vector2D d) { a = A; b = B; c = C; d = D; }
        public override bool Equals(object obj) { if (!(obj is Quad2D)) return false; var other = (Quad2D)obj; return A.Equals(other.A) && B.Equals(other.B) && C.Equals(other.C) && D.Equals(other.D); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(A, B, C, D);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Quad2D self) => new Dynamic(self);
        public static implicit operator Quad2D(Dynamic value) => value.As<Quad2D>();
        public String TypeName => "Quad2D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"A", (String)"B", (String)"C", (String)"D");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(A), new Dynamic(B), new Dynamic(C), new Dynamic(D));
        // Unimplemented concept functions
        public Boolean Equals(Quad2D b) => (A.Equals(b.A) & B.Equals(b.B) & C.Equals(b.C) & D.Equals(b.D));
        public static Boolean operator ==(Quad2D a, Quad2D b) => a.Equals(b);
        public Boolean NotEquals(Quad2D b) => (A.NotEquals(b.A) & B.NotEquals(b.B) & C.NotEquals(b.C) & D.NotEquals(b.D));
        public static Boolean operator !=(Quad2D a, Quad2D b) => a.NotEquals(b);
        public Integer Count => 4;
        public Vector2D At(Integer n) => n == 0 ? A : n == 1 ? B : n == 2 ? C : n == 3 ? D : throw new System.IndexOutOfRangeException();
        public Vector2D this[Integer n] => At(n);
    }
    public readonly partial struct Line2D: PolyLine2D, Array<Vector2D>
    {
        public readonly Vector2D A;
        public readonly Vector2D B;
        public Line2D WithA(Vector2D a) => (a, B);
        public Line2D WithB(Vector2D b) => (A, b);
        public Line2D(Vector2D a, Vector2D b) => (A, B) = (a, b);
        public static Line2D Default = new Line2D();
        public static Line2D New(Vector2D a, Vector2D b) => new Line2D(a, b);
        public Plato.DoublePrecision.Line2D ChangePrecision() => (A.ChangePrecision(), B.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Line2D(Line2D self) => self.ChangePrecision();
        public static implicit operator (Vector2D, Vector2D)(Line2D self) => (self.A, self.B);
        public static implicit operator Line2D((Vector2D, Vector2D) value) => new Line2D(value.Item1, value.Item2);
        public void Deconstruct(out Vector2D a, out Vector2D b) { a = A; b = B; }
        public override bool Equals(object obj) { if (!(obj is Line2D)) return false; var other = (Line2D)obj; return A.Equals(other.A) && B.Equals(other.B); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(A, B);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Line2D self) => new Dynamic(self);
        public static implicit operator Line2D(Dynamic value) => value.As<Line2D>();
        public String TypeName => "Line2D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"A", (String)"B");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(A), new Dynamic(B));
        // Unimplemented concept functions
        public Integer Count => 2;
        public Vector2D At(Integer n) => n == 0 ? A : n == 1 ? B : throw new System.IndexOutOfRangeException();
        public Vector2D this[Integer n] => At(n);
    }
    public readonly partial struct Circle: ClosedShape2D
    {
        public readonly Vector2D Center;
        public readonly Number Radius;
        public Circle WithCenter(Vector2D center) => (center, Radius);
        public Circle WithRadius(Number radius) => (Center, radius);
        public Circle(Vector2D center, Number radius) => (Center, Radius) = (center, radius);
        public static Circle Default = new Circle();
        public static Circle New(Vector2D center, Number radius) => new Circle(center, radius);
        public Plato.DoublePrecision.Circle ChangePrecision() => (Center.ChangePrecision(), Radius.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Circle(Circle self) => self.ChangePrecision();
        public static implicit operator (Vector2D, Number)(Circle self) => (self.Center, self.Radius);
        public static implicit operator Circle((Vector2D, Number) value) => new Circle(value.Item1, value.Item2);
        public void Deconstruct(out Vector2D center, out Number radius) { center = Center; radius = Radius; }
        public override bool Equals(object obj) { if (!(obj is Circle)) return false; var other = (Circle)obj; return Center.Equals(other.Center) && Radius.Equals(other.Radius); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Center, Radius);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Circle self) => new Dynamic(self);
        public static implicit operator Circle(Dynamic value) => value.As<Circle>();
        public String TypeName => "Circle";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Center", (String)"Radius");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Center), new Dynamic(Radius));
        // Unimplemented concept functions
    }
    public readonly partial struct Lens: ClosedShape2D
    {
        public readonly Circle A;
        public readonly Circle B;
        public Lens WithA(Circle a) => (a, B);
        public Lens WithB(Circle b) => (A, b);
        public Lens(Circle a, Circle b) => (A, B) = (a, b);
        public static Lens Default = new Lens();
        public static Lens New(Circle a, Circle b) => new Lens(a, b);
        public Plato.DoublePrecision.Lens ChangePrecision() => (A.ChangePrecision(), B.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Lens(Lens self) => self.ChangePrecision();
        public static implicit operator (Circle, Circle)(Lens self) => (self.A, self.B);
        public static implicit operator Lens((Circle, Circle) value) => new Lens(value.Item1, value.Item2);
        public void Deconstruct(out Circle a, out Circle b) { a = A; b = B; }
        public override bool Equals(object obj) { if (!(obj is Lens)) return false; var other = (Lens)obj; return A.Equals(other.A) && B.Equals(other.B); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(A, B);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Lens self) => new Dynamic(self);
        public static implicit operator Lens(Dynamic value) => value.As<Lens>();
        public String TypeName => "Lens";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"A", (String)"B");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(A), new Dynamic(B));
        // Unimplemented concept functions
    }
    public readonly partial struct Rect2D: Polygon2D
    {
        public readonly Vector2D Center;
        public readonly Size2D Size;
        public Rect2D WithCenter(Vector2D center) => (center, Size);
        public Rect2D WithSize(Size2D size) => (Center, size);
        public Rect2D(Vector2D center, Size2D size) => (Center, Size) = (center, size);
        public static Rect2D Default = new Rect2D();
        public static Rect2D New(Vector2D center, Size2D size) => new Rect2D(center, size);
        public Plato.DoublePrecision.Rect2D ChangePrecision() => (Center.ChangePrecision(), Size.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Rect2D(Rect2D self) => self.ChangePrecision();
        public static implicit operator (Vector2D, Size2D)(Rect2D self) => (self.Center, self.Size);
        public static implicit operator Rect2D((Vector2D, Size2D) value) => new Rect2D(value.Item1, value.Item2);
        public void Deconstruct(out Vector2D center, out Size2D size) { center = Center; size = Size; }
        public override bool Equals(object obj) { if (!(obj is Rect2D)) return false; var other = (Rect2D)obj; return Center.Equals(other.Center) && Size.Equals(other.Size); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Center, Size);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Rect2D self) => new Dynamic(self);
        public static implicit operator Rect2D(Dynamic value) => value.As<Rect2D>();
        public String TypeName => "Rect2D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Center", (String)"Size");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Center), new Dynamic(Size));
        // Unimplemented concept functions
    }
    public readonly partial struct Ellipse: Curve2D
    {
        public readonly Vector2D Center;
        public readonly Size2D Size;
        public Ellipse WithCenter(Vector2D center) => (center, Size);
        public Ellipse WithSize(Size2D size) => (Center, size);
        public Ellipse(Vector2D center, Size2D size) => (Center, Size) = (center, size);
        public static Ellipse Default = new Ellipse();
        public static Ellipse New(Vector2D center, Size2D size) => new Ellipse(center, size);
        public Plato.DoublePrecision.Ellipse ChangePrecision() => (Center.ChangePrecision(), Size.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Ellipse(Ellipse self) => self.ChangePrecision();
        public static implicit operator (Vector2D, Size2D)(Ellipse self) => (self.Center, self.Size);
        public static implicit operator Ellipse((Vector2D, Size2D) value) => new Ellipse(value.Item1, value.Item2);
        public void Deconstruct(out Vector2D center, out Size2D size) { center = Center; size = Size; }
        public override bool Equals(object obj) { if (!(obj is Ellipse)) return false; var other = (Ellipse)obj; return Center.Equals(other.Center) && Size.Equals(other.Size); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Center, Size);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Ellipse self) => new Dynamic(self);
        public static implicit operator Ellipse(Dynamic value) => value.As<Ellipse>();
        public String TypeName => "Ellipse";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Center", (String)"Size");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Center), new Dynamic(Size));
        // Unimplemented concept functions
    }
    public readonly partial struct Ring: ClosedShape2D
    {
        public readonly Vector2D Center;
        public readonly Number InnerRadius;
        public readonly Number OuterRadius;
        public Ring WithCenter(Vector2D center) => (center, InnerRadius, OuterRadius);
        public Ring WithInnerRadius(Number innerRadius) => (Center, innerRadius, OuterRadius);
        public Ring WithOuterRadius(Number outerRadius) => (Center, InnerRadius, outerRadius);
        public Ring(Vector2D center, Number innerRadius, Number outerRadius) => (Center, InnerRadius, OuterRadius) = (center, innerRadius, outerRadius);
        public static Ring Default = new Ring();
        public static Ring New(Vector2D center, Number innerRadius, Number outerRadius) => new Ring(center, innerRadius, outerRadius);
        public Plato.DoublePrecision.Ring ChangePrecision() => (Center.ChangePrecision(), InnerRadius.ChangePrecision(), OuterRadius.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Ring(Ring self) => self.ChangePrecision();
        public static implicit operator (Vector2D, Number, Number)(Ring self) => (self.Center, self.InnerRadius, self.OuterRadius);
        public static implicit operator Ring((Vector2D, Number, Number) value) => new Ring(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Vector2D center, out Number innerRadius, out Number outerRadius) { center = Center; innerRadius = InnerRadius; outerRadius = OuterRadius; }
        public override bool Equals(object obj) { if (!(obj is Ring)) return false; var other = (Ring)obj; return Center.Equals(other.Center) && InnerRadius.Equals(other.InnerRadius) && OuterRadius.Equals(other.OuterRadius); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Center, InnerRadius, OuterRadius);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Ring self) => new Dynamic(self);
        public static implicit operator Ring(Dynamic value) => value.As<Ring>();
        public String TypeName => "Ring";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Center", (String)"InnerRadius", (String)"OuterRadius");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Center), new Dynamic(InnerRadius), new Dynamic(OuterRadius));
        // Unimplemented concept functions
    }
    public readonly partial struct Arc: OpenShape2D
    {
        public readonly AnglePair Angles;
        public readonly Circle Circle;
        public Arc WithAngles(AnglePair angles) => (angles, Circle);
        public Arc WithCircle(Circle circle) => (Angles, circle);
        public Arc(AnglePair angles, Circle circle) => (Angles, Circle) = (angles, circle);
        public static Arc Default = new Arc();
        public static Arc New(AnglePair angles, Circle circle) => new Arc(angles, circle);
        public Plato.DoublePrecision.Arc ChangePrecision() => (Angles.ChangePrecision(), Circle.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Arc(Arc self) => self.ChangePrecision();
        public static implicit operator (AnglePair, Circle)(Arc self) => (self.Angles, self.Circle);
        public static implicit operator Arc((AnglePair, Circle) value) => new Arc(value.Item1, value.Item2);
        public void Deconstruct(out AnglePair angles, out Circle circle) { angles = Angles; circle = Circle; }
        public override bool Equals(object obj) { if (!(obj is Arc)) return false; var other = (Arc)obj; return Angles.Equals(other.Angles) && Circle.Equals(other.Circle); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Angles, Circle);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Arc self) => new Dynamic(self);
        public static implicit operator Arc(Dynamic value) => value.As<Arc>();
        public String TypeName => "Arc";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Angles", (String)"Circle");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Angles), new Dynamic(Circle));
        // Unimplemented concept functions
    }
    public readonly partial struct Sector: ClosedShape2D
    {
        public readonly Arc Arc;
        public Sector WithArc(Arc arc) => (arc);
        public Sector(Arc arc) => (Arc) = (arc);
        public static Sector Default = new Sector();
        public static Sector New(Arc arc) => new Sector(arc);
        public Plato.DoublePrecision.Sector ChangePrecision() => (Arc.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Sector(Sector self) => self.ChangePrecision();
        public static implicit operator Arc(Sector self) => self.Arc;
        public static implicit operator Sector(Arc value) => new Sector(value);
        public override bool Equals(object obj) { if (!(obj is Sector)) return false; var other = (Sector)obj; return Arc.Equals(other.Arc); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Arc);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Sector self) => new Dynamic(self);
        public static implicit operator Sector(Dynamic value) => value.As<Sector>();
        public String TypeName => "Sector";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Arc");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Arc));
        // Unimplemented concept functions
    }
    public readonly partial struct Chord: ClosedShape2D
    {
        public readonly Arc Arc;
        public Chord WithArc(Arc arc) => (arc);
        public Chord(Arc arc) => (Arc) = (arc);
        public static Chord Default = new Chord();
        public static Chord New(Arc arc) => new Chord(arc);
        public Plato.DoublePrecision.Chord ChangePrecision() => (Arc.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Chord(Chord self) => self.ChangePrecision();
        public static implicit operator Arc(Chord self) => self.Arc;
        public static implicit operator Chord(Arc value) => new Chord(value);
        public override bool Equals(object obj) { if (!(obj is Chord)) return false; var other = (Chord)obj; return Arc.Equals(other.Arc); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Arc);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Chord self) => new Dynamic(self);
        public static implicit operator Chord(Dynamic value) => value.As<Chord>();
        public String TypeName => "Chord";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Arc");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Arc));
        // Unimplemented concept functions
    }
    public readonly partial struct Segment: ClosedShape2D
    {
        public readonly Arc Arc;
        public Segment WithArc(Arc arc) => (arc);
        public Segment(Arc arc) => (Arc) = (arc);
        public static Segment Default = new Segment();
        public static Segment New(Arc arc) => new Segment(arc);
        public Plato.DoublePrecision.Segment ChangePrecision() => (Arc.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Segment(Segment self) => self.ChangePrecision();
        public static implicit operator Arc(Segment self) => self.Arc;
        public static implicit operator Segment(Arc value) => new Segment(value);
        public override bool Equals(object obj) { if (!(obj is Segment)) return false; var other = (Segment)obj; return Arc.Equals(other.Arc); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Arc);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Segment self) => new Dynamic(self);
        public static implicit operator Segment(Dynamic value) => value.As<Segment>();
        public String TypeName => "Segment";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Arc");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Arc));
        // Unimplemented concept functions
    }
    public readonly partial struct RegularPolygon: Polygon2D
    {
        public readonly Integer NumPoints;
        public RegularPolygon WithNumPoints(Integer numPoints) => (numPoints);
        public RegularPolygon(Integer numPoints) => (NumPoints) = (numPoints);
        public static RegularPolygon Default = new RegularPolygon();
        public static RegularPolygon New(Integer numPoints) => new RegularPolygon(numPoints);
        public Plato.DoublePrecision.RegularPolygon ChangePrecision() => (NumPoints.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.RegularPolygon(RegularPolygon self) => self.ChangePrecision();
        public static implicit operator Integer(RegularPolygon self) => self.NumPoints;
        public static implicit operator RegularPolygon(Integer value) => new RegularPolygon(value);
        public override bool Equals(object obj) { if (!(obj is RegularPolygon)) return false; var other = (RegularPolygon)obj; return NumPoints.Equals(other.NumPoints); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(NumPoints);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(RegularPolygon self) => new Dynamic(self);
        public static implicit operator RegularPolygon(Dynamic value) => value.As<RegularPolygon>();
        public String TypeName => "RegularPolygon";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"NumPoints");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(NumPoints));
        // Unimplemented concept functions
    }
    public readonly partial struct Box2D: Shape2D
    {
        public readonly Vector2D Center;
        public readonly Angle Rotation;
        public readonly Size2D Extent;
        public Box2D WithCenter(Vector2D center) => (center, Rotation, Extent);
        public Box2D WithRotation(Angle rotation) => (Center, rotation, Extent);
        public Box2D WithExtent(Size2D extent) => (Center, Rotation, extent);
        public Box2D(Vector2D center, Angle rotation, Size2D extent) => (Center, Rotation, Extent) = (center, rotation, extent);
        public static Box2D Default = new Box2D();
        public static Box2D New(Vector2D center, Angle rotation, Size2D extent) => new Box2D(center, rotation, extent);
        public Plato.DoublePrecision.Box2D ChangePrecision() => (Center.ChangePrecision(), Rotation.ChangePrecision(), Extent.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Box2D(Box2D self) => self.ChangePrecision();
        public static implicit operator (Vector2D, Angle, Size2D)(Box2D self) => (self.Center, self.Rotation, self.Extent);
        public static implicit operator Box2D((Vector2D, Angle, Size2D) value) => new Box2D(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Vector2D center, out Angle rotation, out Size2D extent) { center = Center; rotation = Rotation; extent = Extent; }
        public override bool Equals(object obj) { if (!(obj is Box2D)) return false; var other = (Box2D)obj; return Center.Equals(other.Center) && Rotation.Equals(other.Rotation) && Extent.Equals(other.Extent); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Center, Rotation, Extent);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Box2D self) => new Dynamic(self);
        public static implicit operator Box2D(Dynamic value) => value.As<Box2D>();
        public String TypeName => "Box2D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Center", (String)"Rotation", (String)"Extent");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Center), new Dynamic(Rotation), new Dynamic(Extent));
        // Unimplemented concept functions
    }
    public readonly partial struct Sphere: Value<Sphere>
    {
        public readonly Vector3D Center;
        public readonly Number Radius;
        public Sphere WithCenter(Vector3D center) => (center, Radius);
        public Sphere WithRadius(Number radius) => (Center, radius);
        public Sphere(Vector3D center, Number radius) => (Center, Radius) = (center, radius);
        public static Sphere Default = new Sphere();
        public static Sphere New(Vector3D center, Number radius) => new Sphere(center, radius);
        public Plato.DoublePrecision.Sphere ChangePrecision() => (Center.ChangePrecision(), Radius.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Sphere(Sphere self) => self.ChangePrecision();
        public static implicit operator (Vector3D, Number)(Sphere self) => (self.Center, self.Radius);
        public static implicit operator Sphere((Vector3D, Number) value) => new Sphere(value.Item1, value.Item2);
        public void Deconstruct(out Vector3D center, out Number radius) { center = Center; radius = Radius; }
        public override bool Equals(object obj) { if (!(obj is Sphere)) return false; var other = (Sphere)obj; return Center.Equals(other.Center) && Radius.Equals(other.Radius); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Center, Radius);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Sphere self) => new Dynamic(self);
        public static implicit operator Sphere(Dynamic value) => value.As<Sphere>();
        public String TypeName => "Sphere";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Center", (String)"Radius");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Center), new Dynamic(Radius));
        // Unimplemented concept functions
        public Boolean Equals(Sphere b) => (Center.Equals(b.Center) & Radius.Equals(b.Radius));
        public static Boolean operator ==(Sphere a, Sphere b) => a.Equals(b);
        public Boolean NotEquals(Sphere b) => (Center.NotEquals(b.Center) & Radius.NotEquals(b.Radius));
        public static Boolean operator !=(Sphere a, Sphere b) => a.NotEquals(b);
    }
    public readonly partial struct Plane: Value<Plane>
    {
        public readonly Vector3D Normal;
        public readonly Number D;
        public Plane WithNormal(Vector3D normal) => (normal, D);
        public Plane WithD(Number d) => (Normal, d);
        public Plane(Vector3D normal, Number d) => (Normal, D) = (normal, d);
        public static Plane Default = new Plane();
        public static Plane New(Vector3D normal, Number d) => new Plane(normal, d);
        public Plato.DoublePrecision.Plane ChangePrecision() => (Normal.ChangePrecision(), D.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Plane(Plane self) => self.ChangePrecision();
        public static implicit operator (Vector3D, Number)(Plane self) => (self.Normal, self.D);
        public static implicit operator Plane((Vector3D, Number) value) => new Plane(value.Item1, value.Item2);
        public void Deconstruct(out Vector3D normal, out Number d) { normal = Normal; d = D; }
        public override bool Equals(object obj) { if (!(obj is Plane)) return false; var other = (Plane)obj; return Normal.Equals(other.Normal) && D.Equals(other.D); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Normal, D);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Plane self) => new Dynamic(self);
        public static implicit operator Plane(Dynamic value) => value.As<Plane>();
        public String TypeName => "Plane";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Normal", (String)"D");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Normal), new Dynamic(D));
        // Unimplemented concept functions
        public Boolean Equals(Plane b) => (Normal.Equals(b.Normal) & D.Equals(b.D));
        public static Boolean operator ==(Plane a, Plane b) => a.Equals(b);
        public Boolean NotEquals(Plane b) => (Normal.NotEquals(b.Normal) & D.NotEquals(b.D));
        public static Boolean operator !=(Plane a, Plane b) => a.NotEquals(b);
    }
    public readonly partial struct Transform3D: Value<Transform3D>
    {
        public readonly Vector3D Translation;
        public readonly Rotation3D Rotation;
        public readonly Vector3D Scale;
        public Transform3D WithTranslation(Vector3D translation) => (translation, Rotation, Scale);
        public Transform3D WithRotation(Rotation3D rotation) => (Translation, rotation, Scale);
        public Transform3D WithScale(Vector3D scale) => (Translation, Rotation, scale);
        public Transform3D(Vector3D translation, Rotation3D rotation, Vector3D scale) => (Translation, Rotation, Scale) = (translation, rotation, scale);
        public static Transform3D Default = new Transform3D();
        public static Transform3D New(Vector3D translation, Rotation3D rotation, Vector3D scale) => new Transform3D(translation, rotation, scale);
        public Plato.DoublePrecision.Transform3D ChangePrecision() => (Translation.ChangePrecision(), Rotation.ChangePrecision(), Scale.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Transform3D(Transform3D self) => self.ChangePrecision();
        public static implicit operator (Vector3D, Rotation3D, Vector3D)(Transform3D self) => (self.Translation, self.Rotation, self.Scale);
        public static implicit operator Transform3D((Vector3D, Rotation3D, Vector3D) value) => new Transform3D(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Vector3D translation, out Rotation3D rotation, out Vector3D scale) { translation = Translation; rotation = Rotation; scale = Scale; }
        public override bool Equals(object obj) { if (!(obj is Transform3D)) return false; var other = (Transform3D)obj; return Translation.Equals(other.Translation) && Rotation.Equals(other.Rotation) && Scale.Equals(other.Scale); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Translation, Rotation, Scale);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Transform3D self) => new Dynamic(self);
        public static implicit operator Transform3D(Dynamic value) => value.As<Transform3D>();
        public String TypeName => "Transform3D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Translation", (String)"Rotation", (String)"Scale");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Translation), new Dynamic(Rotation), new Dynamic(Scale));
        // Unimplemented concept functions
        public Boolean Equals(Transform3D b) => (Translation.Equals(b.Translation) & Rotation.Equals(b.Rotation) & Scale.Equals(b.Scale));
        public static Boolean operator ==(Transform3D a, Transform3D b) => a.Equals(b);
        public Boolean NotEquals(Transform3D b) => (Translation.NotEquals(b.Translation) & Rotation.NotEquals(b.Rotation) & Scale.NotEquals(b.Scale));
        public static Boolean operator !=(Transform3D a, Transform3D b) => a.NotEquals(b);
    }
    public readonly partial struct Pose3D: Value<Pose3D>
    {
        public readonly Vector3D Position;
        public readonly Orientation3D Orientation;
        public Pose3D WithPosition(Vector3D position) => (position, Orientation);
        public Pose3D WithOrientation(Orientation3D orientation) => (Position, orientation);
        public Pose3D(Vector3D position, Orientation3D orientation) => (Position, Orientation) = (position, orientation);
        public static Pose3D Default = new Pose3D();
        public static Pose3D New(Vector3D position, Orientation3D orientation) => new Pose3D(position, orientation);
        public Plato.DoublePrecision.Pose3D ChangePrecision() => (Position.ChangePrecision(), Orientation.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Pose3D(Pose3D self) => self.ChangePrecision();
        public static implicit operator (Vector3D, Orientation3D)(Pose3D self) => (self.Position, self.Orientation);
        public static implicit operator Pose3D((Vector3D, Orientation3D) value) => new Pose3D(value.Item1, value.Item2);
        public void Deconstruct(out Vector3D position, out Orientation3D orientation) { position = Position; orientation = Orientation; }
        public override bool Equals(object obj) { if (!(obj is Pose3D)) return false; var other = (Pose3D)obj; return Position.Equals(other.Position) && Orientation.Equals(other.Orientation); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Position, Orientation);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Pose3D self) => new Dynamic(self);
        public static implicit operator Pose3D(Dynamic value) => value.As<Pose3D>();
        public String TypeName => "Pose3D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Position", (String)"Orientation");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Position), new Dynamic(Orientation));
        // Unimplemented concept functions
        public Boolean Equals(Pose3D b) => (Position.Equals(b.Position) & Orientation.Equals(b.Orientation));
        public static Boolean operator ==(Pose3D a, Pose3D b) => a.Equals(b);
        public Boolean NotEquals(Pose3D b) => (Position.NotEquals(b.Position) & Orientation.NotEquals(b.Orientation));
        public static Boolean operator !=(Pose3D a, Pose3D b) => a.NotEquals(b);
    }
    public readonly partial struct Frame3D
    {
        public readonly Vector3D Forward;
        public readonly Vector3D Up;
        public readonly Vector3D Right;
        public Frame3D WithForward(Vector3D forward) => (forward, Up, Right);
        public Frame3D WithUp(Vector3D up) => (Forward, up, Right);
        public Frame3D WithRight(Vector3D right) => (Forward, Up, right);
        public Frame3D(Vector3D forward, Vector3D up, Vector3D right) => (Forward, Up, Right) = (forward, up, right);
        public static Frame3D Default = new Frame3D();
        public static Frame3D New(Vector3D forward, Vector3D up, Vector3D right) => new Frame3D(forward, up, right);
        public Plato.DoublePrecision.Frame3D ChangePrecision() => (Forward.ChangePrecision(), Up.ChangePrecision(), Right.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Frame3D(Frame3D self) => self.ChangePrecision();
        public static implicit operator (Vector3D, Vector3D, Vector3D)(Frame3D self) => (self.Forward, self.Up, self.Right);
        public static implicit operator Frame3D((Vector3D, Vector3D, Vector3D) value) => new Frame3D(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Vector3D forward, out Vector3D up, out Vector3D right) { forward = Forward; up = Up; right = Right; }
        public override bool Equals(object obj) { if (!(obj is Frame3D)) return false; var other = (Frame3D)obj; return Forward.Equals(other.Forward) && Up.Equals(other.Up) && Right.Equals(other.Right); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Forward, Up, Right);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Frame3D self) => new Dynamic(self);
        public static implicit operator Frame3D(Dynamic value) => value.As<Frame3D>();
        public String TypeName => "Frame3D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Forward", (String)"Up", (String)"Right");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Forward), new Dynamic(Up), new Dynamic(Right));
        // Unimplemented concept functions
    }
    public readonly partial struct Bounds3D: Interval<Bounds3D, Vector3D>
    {
        public readonly Vector3D Min;
        public readonly Vector3D Max;
        public Bounds3D WithMin(Vector3D min) => (min, Max);
        public Bounds3D WithMax(Vector3D max) => (Min, max);
        public Bounds3D(Vector3D min, Vector3D max) => (Min, Max) = (min, max);
        public static Bounds3D Default = new Bounds3D();
        public static Bounds3D New(Vector3D min, Vector3D max) => new Bounds3D(min, max);
        public Plato.DoublePrecision.Bounds3D ChangePrecision() => (Min.ChangePrecision(), Max.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Bounds3D(Bounds3D self) => self.ChangePrecision();
        public static implicit operator (Vector3D, Vector3D)(Bounds3D self) => (self.Min, self.Max);
        public static implicit operator Bounds3D((Vector3D, Vector3D) value) => new Bounds3D(value.Item1, value.Item2);
        public void Deconstruct(out Vector3D min, out Vector3D max) { min = Min; max = Max; }
        public override bool Equals(object obj) { if (!(obj is Bounds3D)) return false; var other = (Bounds3D)obj; return Min.Equals(other.Min) && Max.Equals(other.Max); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Min, Max);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Bounds3D self) => new Dynamic(self);
        public static implicit operator Bounds3D(Dynamic value) => value.As<Bounds3D>();
        public String TypeName => "Bounds3D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Min", (String)"Max");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Min), new Dynamic(Max));
        Vector3D Interval<Bounds3D, Vector3D>.Min => Min;
        Vector3D Interval<Bounds3D, Vector3D>.Max => Max;
        // Unimplemented concept functions
        public Boolean Equals(Bounds3D b) => (Min.Equals(b.Min) & Max.Equals(b.Max));
        public static Boolean operator ==(Bounds3D a, Bounds3D b) => a.Equals(b);
        public Boolean NotEquals(Bounds3D b) => (Min.NotEquals(b.Min) & Max.NotEquals(b.Max));
        public static Boolean operator !=(Bounds3D a, Bounds3D b) => a.NotEquals(b);
    }
    public readonly partial struct Line3D: PolyLine3D, Array<Vector3D>
    {
        public readonly Vector3D A;
        public readonly Vector3D B;
        public Line3D WithA(Vector3D a) => (a, B);
        public Line3D WithB(Vector3D b) => (A, b);
        public Line3D(Vector3D a, Vector3D b) => (A, B) = (a, b);
        public static Line3D Default = new Line3D();
        public static Line3D New(Vector3D a, Vector3D b) => new Line3D(a, b);
        public Plato.DoublePrecision.Line3D ChangePrecision() => (A.ChangePrecision(), B.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Line3D(Line3D self) => self.ChangePrecision();
        public static implicit operator (Vector3D, Vector3D)(Line3D self) => (self.A, self.B);
        public static implicit operator Line3D((Vector3D, Vector3D) value) => new Line3D(value.Item1, value.Item2);
        public void Deconstruct(out Vector3D a, out Vector3D b) { a = A; b = B; }
        public override bool Equals(object obj) { if (!(obj is Line3D)) return false; var other = (Line3D)obj; return A.Equals(other.A) && B.Equals(other.B); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(A, B);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Line3D self) => new Dynamic(self);
        public static implicit operator Line3D(Dynamic value) => value.As<Line3D>();
        public String TypeName => "Line3D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"A", (String)"B");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(A), new Dynamic(B));
        // Unimplemented concept functions
        public Integer Count => 2;
        public Vector3D At(Integer n) => n == 0 ? A : n == 1 ? B : throw new System.IndexOutOfRangeException();
        public Vector3D this[Integer n] => At(n);
    }
    public readonly partial struct Ray3D: Value<Ray3D>
    {
        public readonly Vector3D Direction;
        public readonly Vector3D Position;
        public Ray3D WithDirection(Vector3D direction) => (direction, Position);
        public Ray3D WithPosition(Vector3D position) => (Direction, position);
        public Ray3D(Vector3D direction, Vector3D position) => (Direction, Position) = (direction, position);
        public static Ray3D Default = new Ray3D();
        public static Ray3D New(Vector3D direction, Vector3D position) => new Ray3D(direction, position);
        public Plato.DoublePrecision.Ray3D ChangePrecision() => (Direction.ChangePrecision(), Position.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Ray3D(Ray3D self) => self.ChangePrecision();
        public static implicit operator (Vector3D, Vector3D)(Ray3D self) => (self.Direction, self.Position);
        public static implicit operator Ray3D((Vector3D, Vector3D) value) => new Ray3D(value.Item1, value.Item2);
        public void Deconstruct(out Vector3D direction, out Vector3D position) { direction = Direction; position = Position; }
        public override bool Equals(object obj) { if (!(obj is Ray3D)) return false; var other = (Ray3D)obj; return Direction.Equals(other.Direction) && Position.Equals(other.Position); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Direction, Position);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Ray3D self) => new Dynamic(self);
        public static implicit operator Ray3D(Dynamic value) => value.As<Ray3D>();
        public String TypeName => "Ray3D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Direction", (String)"Position");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Direction), new Dynamic(Position));
        // Unimplemented concept functions
        public Boolean Equals(Ray3D b) => (Direction.Equals(b.Direction) & Position.Equals(b.Position));
        public static Boolean operator ==(Ray3D a, Ray3D b) => a.Equals(b);
        public Boolean NotEquals(Ray3D b) => (Direction.NotEquals(b.Direction) & Position.NotEquals(b.Position));
        public static Boolean operator !=(Ray3D a, Ray3D b) => a.NotEquals(b);
    }
    public readonly partial struct Triangle3D: Value<Triangle3D>, Array<Vector3D>
    {
        public readonly Vector3D A;
        public readonly Vector3D B;
        public readonly Vector3D C;
        public Triangle3D WithA(Vector3D a) => (a, B, C);
        public Triangle3D WithB(Vector3D b) => (A, b, C);
        public Triangle3D WithC(Vector3D c) => (A, B, c);
        public Triangle3D(Vector3D a, Vector3D b, Vector3D c) => (A, B, C) = (a, b, c);
        public static Triangle3D Default = new Triangle3D();
        public static Triangle3D New(Vector3D a, Vector3D b, Vector3D c) => new Triangle3D(a, b, c);
        public Plato.DoublePrecision.Triangle3D ChangePrecision() => (A.ChangePrecision(), B.ChangePrecision(), C.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Triangle3D(Triangle3D self) => self.ChangePrecision();
        public static implicit operator (Vector3D, Vector3D, Vector3D)(Triangle3D self) => (self.A, self.B, self.C);
        public static implicit operator Triangle3D((Vector3D, Vector3D, Vector3D) value) => new Triangle3D(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Vector3D a, out Vector3D b, out Vector3D c) { a = A; b = B; c = C; }
        public override bool Equals(object obj) { if (!(obj is Triangle3D)) return false; var other = (Triangle3D)obj; return A.Equals(other.A) && B.Equals(other.B) && C.Equals(other.C); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(A, B, C);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Triangle3D self) => new Dynamic(self);
        public static implicit operator Triangle3D(Dynamic value) => value.As<Triangle3D>();
        public String TypeName => "Triangle3D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"A", (String)"B", (String)"C");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(A), new Dynamic(B), new Dynamic(C));
        // Unimplemented concept functions
        public Boolean Equals(Triangle3D b) => (A.Equals(b.A) & B.Equals(b.B) & C.Equals(b.C));
        public static Boolean operator ==(Triangle3D a, Triangle3D b) => a.Equals(b);
        public Boolean NotEquals(Triangle3D b) => (A.NotEquals(b.A) & B.NotEquals(b.B) & C.NotEquals(b.C));
        public static Boolean operator !=(Triangle3D a, Triangle3D b) => a.NotEquals(b);
        public Integer Count => 3;
        public Vector3D At(Integer n) => n == 0 ? A : n == 1 ? B : n == 2 ? C : throw new System.IndexOutOfRangeException();
        public Vector3D this[Integer n] => At(n);
    }
    public readonly partial struct Quad3D: Value<Quad3D>, Array<Vector3D>
    {
        public readonly Vector3D A;
        public readonly Vector3D B;
        public readonly Vector3D C;
        public readonly Vector3D D;
        public Quad3D WithA(Vector3D a) => (a, B, C, D);
        public Quad3D WithB(Vector3D b) => (A, b, C, D);
        public Quad3D WithC(Vector3D c) => (A, B, c, D);
        public Quad3D WithD(Vector3D d) => (A, B, C, d);
        public Quad3D(Vector3D a, Vector3D b, Vector3D c, Vector3D d) => (A, B, C, D) = (a, b, c, d);
        public static Quad3D Default = new Quad3D();
        public static Quad3D New(Vector3D a, Vector3D b, Vector3D c, Vector3D d) => new Quad3D(a, b, c, d);
        public Plato.DoublePrecision.Quad3D ChangePrecision() => (A.ChangePrecision(), B.ChangePrecision(), C.ChangePrecision(), D.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Quad3D(Quad3D self) => self.ChangePrecision();
        public static implicit operator (Vector3D, Vector3D, Vector3D, Vector3D)(Quad3D self) => (self.A, self.B, self.C, self.D);
        public static implicit operator Quad3D((Vector3D, Vector3D, Vector3D, Vector3D) value) => new Quad3D(value.Item1, value.Item2, value.Item3, value.Item4);
        public void Deconstruct(out Vector3D a, out Vector3D b, out Vector3D c, out Vector3D d) { a = A; b = B; c = C; d = D; }
        public override bool Equals(object obj) { if (!(obj is Quad3D)) return false; var other = (Quad3D)obj; return A.Equals(other.A) && B.Equals(other.B) && C.Equals(other.C) && D.Equals(other.D); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(A, B, C, D);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Quad3D self) => new Dynamic(self);
        public static implicit operator Quad3D(Dynamic value) => value.As<Quad3D>();
        public String TypeName => "Quad3D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"A", (String)"B", (String)"C", (String)"D");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(A), new Dynamic(B), new Dynamic(C), new Dynamic(D));
        // Unimplemented concept functions
        public Boolean Equals(Quad3D b) => (A.Equals(b.A) & B.Equals(b.B) & C.Equals(b.C) & D.Equals(b.D));
        public static Boolean operator ==(Quad3D a, Quad3D b) => a.Equals(b);
        public Boolean NotEquals(Quad3D b) => (A.NotEquals(b.A) & B.NotEquals(b.B) & C.NotEquals(b.C) & D.NotEquals(b.D));
        public static Boolean operator !=(Quad3D a, Quad3D b) => a.NotEquals(b);
        public Integer Count => 4;
        public Vector3D At(Integer n) => n == 0 ? A : n == 1 ? B : n == 2 ? C : n == 3 ? D : throw new System.IndexOutOfRangeException();
        public Vector3D this[Integer n] => At(n);
    }
    public readonly partial struct Capsule: Shape3D
    {
        public readonly Line3D Line;
        public readonly Number Radius;
        public Capsule WithLine(Line3D line) => (line, Radius);
        public Capsule WithRadius(Number radius) => (Line, radius);
        public Capsule(Line3D line, Number radius) => (Line, Radius) = (line, radius);
        public static Capsule Default = new Capsule();
        public static Capsule New(Line3D line, Number radius) => new Capsule(line, radius);
        public Plato.DoublePrecision.Capsule ChangePrecision() => (Line.ChangePrecision(), Radius.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Capsule(Capsule self) => self.ChangePrecision();
        public static implicit operator (Line3D, Number)(Capsule self) => (self.Line, self.Radius);
        public static implicit operator Capsule((Line3D, Number) value) => new Capsule(value.Item1, value.Item2);
        public void Deconstruct(out Line3D line, out Number radius) { line = Line; radius = Radius; }
        public override bool Equals(object obj) { if (!(obj is Capsule)) return false; var other = (Capsule)obj; return Line.Equals(other.Line) && Radius.Equals(other.Radius); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Line, Radius);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Capsule self) => new Dynamic(self);
        public static implicit operator Capsule(Dynamic value) => value.As<Capsule>();
        public String TypeName => "Capsule";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Line", (String)"Radius");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Line), new Dynamic(Radius));
        // Unimplemented concept functions
    }
    public readonly partial struct Cylinder: Shape3D
    {
        public readonly Line3D Line;
        public readonly Number Radius;
        public Cylinder WithLine(Line3D line) => (line, Radius);
        public Cylinder WithRadius(Number radius) => (Line, radius);
        public Cylinder(Line3D line, Number radius) => (Line, Radius) = (line, radius);
        public static Cylinder Default = new Cylinder();
        public static Cylinder New(Line3D line, Number radius) => new Cylinder(line, radius);
        public Plato.DoublePrecision.Cylinder ChangePrecision() => (Line.ChangePrecision(), Radius.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Cylinder(Cylinder self) => self.ChangePrecision();
        public static implicit operator (Line3D, Number)(Cylinder self) => (self.Line, self.Radius);
        public static implicit operator Cylinder((Line3D, Number) value) => new Cylinder(value.Item1, value.Item2);
        public void Deconstruct(out Line3D line, out Number radius) { line = Line; radius = Radius; }
        public override bool Equals(object obj) { if (!(obj is Cylinder)) return false; var other = (Cylinder)obj; return Line.Equals(other.Line) && Radius.Equals(other.Radius); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Line, Radius);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Cylinder self) => new Dynamic(self);
        public static implicit operator Cylinder(Dynamic value) => value.As<Cylinder>();
        public String TypeName => "Cylinder";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Line", (String)"Radius");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Line), new Dynamic(Radius));
        // Unimplemented concept functions
    }
    public readonly partial struct Cone: Shape3D
    {
        public readonly Line3D Line;
        public readonly Number Radius;
        public Cone WithLine(Line3D line) => (line, Radius);
        public Cone WithRadius(Number radius) => (Line, radius);
        public Cone(Line3D line, Number radius) => (Line, Radius) = (line, radius);
        public static Cone Default = new Cone();
        public static Cone New(Line3D line, Number radius) => new Cone(line, radius);
        public Plato.DoublePrecision.Cone ChangePrecision() => (Line.ChangePrecision(), Radius.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Cone(Cone self) => self.ChangePrecision();
        public static implicit operator (Line3D, Number)(Cone self) => (self.Line, self.Radius);
        public static implicit operator Cone((Line3D, Number) value) => new Cone(value.Item1, value.Item2);
        public void Deconstruct(out Line3D line, out Number radius) { line = Line; radius = Radius; }
        public override bool Equals(object obj) { if (!(obj is Cone)) return false; var other = (Cone)obj; return Line.Equals(other.Line) && Radius.Equals(other.Radius); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Line, Radius);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Cone self) => new Dynamic(self);
        public static implicit operator Cone(Dynamic value) => value.As<Cone>();
        public String TypeName => "Cone";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Line", (String)"Radius");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Line), new Dynamic(Radius));
        // Unimplemented concept functions
    }
    public readonly partial struct Tube: Shape3D
    {
        public readonly Line3D Line;
        public readonly Number InnerRadius;
        public readonly Number OuterRadius;
        public Tube WithLine(Line3D line) => (line, InnerRadius, OuterRadius);
        public Tube WithInnerRadius(Number innerRadius) => (Line, innerRadius, OuterRadius);
        public Tube WithOuterRadius(Number outerRadius) => (Line, InnerRadius, outerRadius);
        public Tube(Line3D line, Number innerRadius, Number outerRadius) => (Line, InnerRadius, OuterRadius) = (line, innerRadius, outerRadius);
        public static Tube Default = new Tube();
        public static Tube New(Line3D line, Number innerRadius, Number outerRadius) => new Tube(line, innerRadius, outerRadius);
        public Plato.DoublePrecision.Tube ChangePrecision() => (Line.ChangePrecision(), InnerRadius.ChangePrecision(), OuterRadius.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Tube(Tube self) => self.ChangePrecision();
        public static implicit operator (Line3D, Number, Number)(Tube self) => (self.Line, self.InnerRadius, self.OuterRadius);
        public static implicit operator Tube((Line3D, Number, Number) value) => new Tube(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Line3D line, out Number innerRadius, out Number outerRadius) { line = Line; innerRadius = InnerRadius; outerRadius = OuterRadius; }
        public override bool Equals(object obj) { if (!(obj is Tube)) return false; var other = (Tube)obj; return Line.Equals(other.Line) && InnerRadius.Equals(other.InnerRadius) && OuterRadius.Equals(other.OuterRadius); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Line, InnerRadius, OuterRadius);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Tube self) => new Dynamic(self);
        public static implicit operator Tube(Dynamic value) => value.As<Tube>();
        public String TypeName => "Tube";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Line", (String)"InnerRadius", (String)"OuterRadius");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Line), new Dynamic(InnerRadius), new Dynamic(OuterRadius));
        // Unimplemented concept functions
    }
    public readonly partial struct ConeSegment: Shape3D
    {
        public readonly Line3D Line;
        public readonly Number Radius1;
        public readonly Number Radius2;
        public ConeSegment WithLine(Line3D line) => (line, Radius1, Radius2);
        public ConeSegment WithRadius1(Number radius1) => (Line, radius1, Radius2);
        public ConeSegment WithRadius2(Number radius2) => (Line, Radius1, radius2);
        public ConeSegment(Line3D line, Number radius1, Number radius2) => (Line, Radius1, Radius2) = (line, radius1, radius2);
        public static ConeSegment Default = new ConeSegment();
        public static ConeSegment New(Line3D line, Number radius1, Number radius2) => new ConeSegment(line, radius1, radius2);
        public Plato.DoublePrecision.ConeSegment ChangePrecision() => (Line.ChangePrecision(), Radius1.ChangePrecision(), Radius2.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.ConeSegment(ConeSegment self) => self.ChangePrecision();
        public static implicit operator (Line3D, Number, Number)(ConeSegment self) => (self.Line, self.Radius1, self.Radius2);
        public static implicit operator ConeSegment((Line3D, Number, Number) value) => new ConeSegment(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Line3D line, out Number radius1, out Number radius2) { line = Line; radius1 = Radius1; radius2 = Radius2; }
        public override bool Equals(object obj) { if (!(obj is ConeSegment)) return false; var other = (ConeSegment)obj; return Line.Equals(other.Line) && Radius1.Equals(other.Radius1) && Radius2.Equals(other.Radius2); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Line, Radius1, Radius2);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(ConeSegment self) => new Dynamic(self);
        public static implicit operator ConeSegment(Dynamic value) => value.As<ConeSegment>();
        public String TypeName => "ConeSegment";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Line", (String)"Radius1", (String)"Radius2");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Line), new Dynamic(Radius1), new Dynamic(Radius2));
        // Unimplemented concept functions
    }
    public readonly partial struct Box3D: Shape3D
    {
        public readonly Vector3D Center;
        public readonly Rotation3D Rotation;
        public readonly Size3D Extent;
        public Box3D WithCenter(Vector3D center) => (center, Rotation, Extent);
        public Box3D WithRotation(Rotation3D rotation) => (Center, rotation, Extent);
        public Box3D WithExtent(Size3D extent) => (Center, Rotation, extent);
        public Box3D(Vector3D center, Rotation3D rotation, Size3D extent) => (Center, Rotation, Extent) = (center, rotation, extent);
        public static Box3D Default = new Box3D();
        public static Box3D New(Vector3D center, Rotation3D rotation, Size3D extent) => new Box3D(center, rotation, extent);
        public Plato.DoublePrecision.Box3D ChangePrecision() => (Center.ChangePrecision(), Rotation.ChangePrecision(), Extent.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Box3D(Box3D self) => self.ChangePrecision();
        public static implicit operator (Vector3D, Rotation3D, Size3D)(Box3D self) => (self.Center, self.Rotation, self.Extent);
        public static implicit operator Box3D((Vector3D, Rotation3D, Size3D) value) => new Box3D(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Vector3D center, out Rotation3D rotation, out Size3D extent) { center = Center; rotation = Rotation; extent = Extent; }
        public override bool Equals(object obj) { if (!(obj is Box3D)) return false; var other = (Box3D)obj; return Center.Equals(other.Center) && Rotation.Equals(other.Rotation) && Extent.Equals(other.Extent); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Center, Rotation, Extent);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Box3D self) => new Dynamic(self);
        public static implicit operator Box3D(Dynamic value) => value.As<Box3D>();
        public String TypeName => "Box3D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Center", (String)"Rotation", (String)"Extent");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Center), new Dynamic(Rotation), new Dynamic(Extent));
        // Unimplemented concept functions
    }
    public readonly partial struct CubicBezier2D: Array<Vector2D>
    {
        public readonly Vector2D A;
        public readonly Vector2D B;
        public readonly Vector2D C;
        public readonly Vector2D D;
        public CubicBezier2D WithA(Vector2D a) => (a, B, C, D);
        public CubicBezier2D WithB(Vector2D b) => (A, b, C, D);
        public CubicBezier2D WithC(Vector2D c) => (A, B, c, D);
        public CubicBezier2D WithD(Vector2D d) => (A, B, C, d);
        public CubicBezier2D(Vector2D a, Vector2D b, Vector2D c, Vector2D d) => (A, B, C, D) = (a, b, c, d);
        public static CubicBezier2D Default = new CubicBezier2D();
        public static CubicBezier2D New(Vector2D a, Vector2D b, Vector2D c, Vector2D d) => new CubicBezier2D(a, b, c, d);
        public Plato.DoublePrecision.CubicBezier2D ChangePrecision() => (A.ChangePrecision(), B.ChangePrecision(), C.ChangePrecision(), D.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.CubicBezier2D(CubicBezier2D self) => self.ChangePrecision();
        public static implicit operator (Vector2D, Vector2D, Vector2D, Vector2D)(CubicBezier2D self) => (self.A, self.B, self.C, self.D);
        public static implicit operator CubicBezier2D((Vector2D, Vector2D, Vector2D, Vector2D) value) => new CubicBezier2D(value.Item1, value.Item2, value.Item3, value.Item4);
        public void Deconstruct(out Vector2D a, out Vector2D b, out Vector2D c, out Vector2D d) { a = A; b = B; c = C; d = D; }
        public override bool Equals(object obj) { if (!(obj is CubicBezier2D)) return false; var other = (CubicBezier2D)obj; return A.Equals(other.A) && B.Equals(other.B) && C.Equals(other.C) && D.Equals(other.D); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(A, B, C, D);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(CubicBezier2D self) => new Dynamic(self);
        public static implicit operator CubicBezier2D(Dynamic value) => value.As<CubicBezier2D>();
        public String TypeName => "CubicBezier2D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"A", (String)"B", (String)"C", (String)"D");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(A), new Dynamic(B), new Dynamic(C), new Dynamic(D));
        // Unimplemented concept functions
        public Integer Count => 4;
        public Vector2D At(Integer n) => n == 0 ? A : n == 1 ? B : n == 2 ? C : n == 3 ? D : throw new System.IndexOutOfRangeException();
        public Vector2D this[Integer n] => At(n);
    }
    public readonly partial struct CubicBezier3D: Array<Vector3D>
    {
        public readonly Vector3D A;
        public readonly Vector3D B;
        public readonly Vector3D C;
        public readonly Vector3D D;
        public CubicBezier3D WithA(Vector3D a) => (a, B, C, D);
        public CubicBezier3D WithB(Vector3D b) => (A, b, C, D);
        public CubicBezier3D WithC(Vector3D c) => (A, B, c, D);
        public CubicBezier3D WithD(Vector3D d) => (A, B, C, d);
        public CubicBezier3D(Vector3D a, Vector3D b, Vector3D c, Vector3D d) => (A, B, C, D) = (a, b, c, d);
        public static CubicBezier3D Default = new CubicBezier3D();
        public static CubicBezier3D New(Vector3D a, Vector3D b, Vector3D c, Vector3D d) => new CubicBezier3D(a, b, c, d);
        public Plato.DoublePrecision.CubicBezier3D ChangePrecision() => (A.ChangePrecision(), B.ChangePrecision(), C.ChangePrecision(), D.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.CubicBezier3D(CubicBezier3D self) => self.ChangePrecision();
        public static implicit operator (Vector3D, Vector3D, Vector3D, Vector3D)(CubicBezier3D self) => (self.A, self.B, self.C, self.D);
        public static implicit operator CubicBezier3D((Vector3D, Vector3D, Vector3D, Vector3D) value) => new CubicBezier3D(value.Item1, value.Item2, value.Item3, value.Item4);
        public void Deconstruct(out Vector3D a, out Vector3D b, out Vector3D c, out Vector3D d) { a = A; b = B; c = C; d = D; }
        public override bool Equals(object obj) { if (!(obj is CubicBezier3D)) return false; var other = (CubicBezier3D)obj; return A.Equals(other.A) && B.Equals(other.B) && C.Equals(other.C) && D.Equals(other.D); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(A, B, C, D);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(CubicBezier3D self) => new Dynamic(self);
        public static implicit operator CubicBezier3D(Dynamic value) => value.As<CubicBezier3D>();
        public String TypeName => "CubicBezier3D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"A", (String)"B", (String)"C", (String)"D");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(A), new Dynamic(B), new Dynamic(C), new Dynamic(D));
        // Unimplemented concept functions
        public Integer Count => 4;
        public Vector3D At(Integer n) => n == 0 ? A : n == 1 ? B : n == 2 ? C : n == 3 ? D : throw new System.IndexOutOfRangeException();
        public Vector3D this[Integer n] => At(n);
    }
    public readonly partial struct QuadraticBezier2D: Array<Vector2D>
    {
        public readonly Vector2D A;
        public readonly Vector2D B;
        public readonly Vector2D C;
        public QuadraticBezier2D WithA(Vector2D a) => (a, B, C);
        public QuadraticBezier2D WithB(Vector2D b) => (A, b, C);
        public QuadraticBezier2D WithC(Vector2D c) => (A, B, c);
        public QuadraticBezier2D(Vector2D a, Vector2D b, Vector2D c) => (A, B, C) = (a, b, c);
        public static QuadraticBezier2D Default = new QuadraticBezier2D();
        public static QuadraticBezier2D New(Vector2D a, Vector2D b, Vector2D c) => new QuadraticBezier2D(a, b, c);
        public Plato.DoublePrecision.QuadraticBezier2D ChangePrecision() => (A.ChangePrecision(), B.ChangePrecision(), C.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.QuadraticBezier2D(QuadraticBezier2D self) => self.ChangePrecision();
        public static implicit operator (Vector2D, Vector2D, Vector2D)(QuadraticBezier2D self) => (self.A, self.B, self.C);
        public static implicit operator QuadraticBezier2D((Vector2D, Vector2D, Vector2D) value) => new QuadraticBezier2D(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Vector2D a, out Vector2D b, out Vector2D c) { a = A; b = B; c = C; }
        public override bool Equals(object obj) { if (!(obj is QuadraticBezier2D)) return false; var other = (QuadraticBezier2D)obj; return A.Equals(other.A) && B.Equals(other.B) && C.Equals(other.C); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(A, B, C);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(QuadraticBezier2D self) => new Dynamic(self);
        public static implicit operator QuadraticBezier2D(Dynamic value) => value.As<QuadraticBezier2D>();
        public String TypeName => "QuadraticBezier2D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"A", (String)"B", (String)"C");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(A), new Dynamic(B), new Dynamic(C));
        // Unimplemented concept functions
        public Integer Count => 3;
        public Vector2D At(Integer n) => n == 0 ? A : n == 1 ? B : n == 2 ? C : throw new System.IndexOutOfRangeException();
        public Vector2D this[Integer n] => At(n);
    }
    public readonly partial struct QuadraticBezier3D: Array<Vector3D>
    {
        public readonly Vector3D A;
        public readonly Vector3D B;
        public readonly Vector3D C;
        public QuadraticBezier3D WithA(Vector3D a) => (a, B, C);
        public QuadraticBezier3D WithB(Vector3D b) => (A, b, C);
        public QuadraticBezier3D WithC(Vector3D c) => (A, B, c);
        public QuadraticBezier3D(Vector3D a, Vector3D b, Vector3D c) => (A, B, C) = (a, b, c);
        public static QuadraticBezier3D Default = new QuadraticBezier3D();
        public static QuadraticBezier3D New(Vector3D a, Vector3D b, Vector3D c) => new QuadraticBezier3D(a, b, c);
        public Plato.DoublePrecision.QuadraticBezier3D ChangePrecision() => (A.ChangePrecision(), B.ChangePrecision(), C.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.QuadraticBezier3D(QuadraticBezier3D self) => self.ChangePrecision();
        public static implicit operator (Vector3D, Vector3D, Vector3D)(QuadraticBezier3D self) => (self.A, self.B, self.C);
        public static implicit operator QuadraticBezier3D((Vector3D, Vector3D, Vector3D) value) => new QuadraticBezier3D(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Vector3D a, out Vector3D b, out Vector3D c) { a = A; b = B; c = C; }
        public override bool Equals(object obj) { if (!(obj is QuadraticBezier3D)) return false; var other = (QuadraticBezier3D)obj; return A.Equals(other.A) && B.Equals(other.B) && C.Equals(other.C); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(A, B, C);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(QuadraticBezier3D self) => new Dynamic(self);
        public static implicit operator QuadraticBezier3D(Dynamic value) => value.As<QuadraticBezier3D>();
        public String TypeName => "QuadraticBezier3D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"A", (String)"B", (String)"C");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(A), new Dynamic(B), new Dynamic(C));
        // Unimplemented concept functions
        public Integer Count => 3;
        public Vector3D At(Integer n) => n == 0 ? A : n == 1 ? B : n == 2 ? C : throw new System.IndexOutOfRangeException();
        public Vector3D this[Integer n] => At(n);
    }
    public readonly partial struct Quaternion: Value<Quaternion>
    {
        public readonly Number X;
        public readonly Number Y;
        public readonly Number Z;
        public readonly Number W;
        public Quaternion WithX(Number x) => (x, Y, Z, W);
        public Quaternion WithY(Number y) => (X, y, Z, W);
        public Quaternion WithZ(Number z) => (X, Y, z, W);
        public Quaternion WithW(Number w) => (X, Y, Z, w);
        public Quaternion(Number x, Number y, Number z, Number w) => (X, Y, Z, W) = (x, y, z, w);
        public static Quaternion Default = new Quaternion();
        public static Quaternion New(Number x, Number y, Number z, Number w) => new Quaternion(x, y, z, w);
        public Plato.DoublePrecision.Quaternion ChangePrecision() => (X.ChangePrecision(), Y.ChangePrecision(), Z.ChangePrecision(), W.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Quaternion(Quaternion self) => self.ChangePrecision();
        public static implicit operator (Number, Number, Number, Number)(Quaternion self) => (self.X, self.Y, self.Z, self.W);
        public static implicit operator Quaternion((Number, Number, Number, Number) value) => new Quaternion(value.Item1, value.Item2, value.Item3, value.Item4);
        public void Deconstruct(out Number x, out Number y, out Number z, out Number w) { x = X; y = Y; z = Z; w = W; }
        public override bool Equals(object obj) { if (!(obj is Quaternion)) return false; var other = (Quaternion)obj; return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(X, Y, Z, W);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Quaternion self) => new Dynamic(self);
        public static implicit operator Quaternion(Dynamic value) => value.As<Quaternion>();
        public String TypeName => "Quaternion";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"X", (String)"Y", (String)"Z", (String)"W");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(X), new Dynamic(Y), new Dynamic(Z), new Dynamic(W));
        // Unimplemented concept functions
        public Boolean Equals(Quaternion b) => (X.Equals(b.X) & Y.Equals(b.Y) & Z.Equals(b.Z) & W.Equals(b.W));
        public static Boolean operator ==(Quaternion a, Quaternion b) => a.Equals(b);
        public Boolean NotEquals(Quaternion b) => (X.NotEquals(b.X) & Y.NotEquals(b.Y) & Z.NotEquals(b.Z) & W.NotEquals(b.W));
        public static Boolean operator !=(Quaternion a, Quaternion b) => a.NotEquals(b);
    }
    public readonly partial struct AxisAngle: Value<AxisAngle>
    {
        public readonly Vector3D Axis;
        public readonly Angle Angle;
        public AxisAngle WithAxis(Vector3D axis) => (axis, Angle);
        public AxisAngle WithAngle(Angle angle) => (Axis, angle);
        public AxisAngle(Vector3D axis, Angle angle) => (Axis, Angle) = (axis, angle);
        public static AxisAngle Default = new AxisAngle();
        public static AxisAngle New(Vector3D axis, Angle angle) => new AxisAngle(axis, angle);
        public Plato.DoublePrecision.AxisAngle ChangePrecision() => (Axis.ChangePrecision(), Angle.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.AxisAngle(AxisAngle self) => self.ChangePrecision();
        public static implicit operator (Vector3D, Angle)(AxisAngle self) => (self.Axis, self.Angle);
        public static implicit operator AxisAngle((Vector3D, Angle) value) => new AxisAngle(value.Item1, value.Item2);
        public void Deconstruct(out Vector3D axis, out Angle angle) { axis = Axis; angle = Angle; }
        public override bool Equals(object obj) { if (!(obj is AxisAngle)) return false; var other = (AxisAngle)obj; return Axis.Equals(other.Axis) && Angle.Equals(other.Angle); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Axis, Angle);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(AxisAngle self) => new Dynamic(self);
        public static implicit operator AxisAngle(Dynamic value) => value.As<AxisAngle>();
        public String TypeName => "AxisAngle";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Axis", (String)"Angle");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Axis), new Dynamic(Angle));
        // Unimplemented concept functions
        public Boolean Equals(AxisAngle b) => (Axis.Equals(b.Axis) & Angle.Equals(b.Angle));
        public static Boolean operator ==(AxisAngle a, AxisAngle b) => a.Equals(b);
        public Boolean NotEquals(AxisAngle b) => (Axis.NotEquals(b.Axis) & Angle.NotEquals(b.Angle));
        public static Boolean operator !=(AxisAngle a, AxisAngle b) => a.NotEquals(b);
    }
    public readonly partial struct EulerAngles: Value<EulerAngles>
    {
        public readonly Angle Yaw;
        public readonly Angle Pitch;
        public readonly Angle Roll;
        public EulerAngles WithYaw(Angle yaw) => (yaw, Pitch, Roll);
        public EulerAngles WithPitch(Angle pitch) => (Yaw, pitch, Roll);
        public EulerAngles WithRoll(Angle roll) => (Yaw, Pitch, roll);
        public EulerAngles(Angle yaw, Angle pitch, Angle roll) => (Yaw, Pitch, Roll) = (yaw, pitch, roll);
        public static EulerAngles Default = new EulerAngles();
        public static EulerAngles New(Angle yaw, Angle pitch, Angle roll) => new EulerAngles(yaw, pitch, roll);
        public Plato.DoublePrecision.EulerAngles ChangePrecision() => (Yaw.ChangePrecision(), Pitch.ChangePrecision(), Roll.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.EulerAngles(EulerAngles self) => self.ChangePrecision();
        public static implicit operator (Angle, Angle, Angle)(EulerAngles self) => (self.Yaw, self.Pitch, self.Roll);
        public static implicit operator EulerAngles((Angle, Angle, Angle) value) => new EulerAngles(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Angle yaw, out Angle pitch, out Angle roll) { yaw = Yaw; pitch = Pitch; roll = Roll; }
        public override bool Equals(object obj) { if (!(obj is EulerAngles)) return false; var other = (EulerAngles)obj; return Yaw.Equals(other.Yaw) && Pitch.Equals(other.Pitch) && Roll.Equals(other.Roll); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Yaw, Pitch, Roll);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(EulerAngles self) => new Dynamic(self);
        public static implicit operator EulerAngles(Dynamic value) => value.As<EulerAngles>();
        public String TypeName => "EulerAngles";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Yaw", (String)"Pitch", (String)"Roll");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Yaw), new Dynamic(Pitch), new Dynamic(Roll));
        // Unimplemented concept functions
        public Boolean Equals(EulerAngles b) => (Yaw.Equals(b.Yaw) & Pitch.Equals(b.Pitch) & Roll.Equals(b.Roll));
        public static Boolean operator ==(EulerAngles a, EulerAngles b) => a.Equals(b);
        public Boolean NotEquals(EulerAngles b) => (Yaw.NotEquals(b.Yaw) & Pitch.NotEquals(b.Pitch) & Roll.NotEquals(b.Roll));
        public static Boolean operator !=(EulerAngles a, EulerAngles b) => a.NotEquals(b);
    }
    public readonly partial struct Rotation3D: Value<Rotation3D>
    {
        public readonly Quaternion Quaternion;
        public Rotation3D WithQuaternion(Quaternion quaternion) => (quaternion);
        public Rotation3D(Quaternion quaternion) => (Quaternion) = (quaternion);
        public static Rotation3D Default = new Rotation3D();
        public static Rotation3D New(Quaternion quaternion) => new Rotation3D(quaternion);
        public Plato.DoublePrecision.Rotation3D ChangePrecision() => (Quaternion.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Rotation3D(Rotation3D self) => self.ChangePrecision();
        public static implicit operator Quaternion(Rotation3D self) => self.Quaternion;
        public static implicit operator Rotation3D(Quaternion value) => new Rotation3D(value);
        public override bool Equals(object obj) { if (!(obj is Rotation3D)) return false; var other = (Rotation3D)obj; return Quaternion.Equals(other.Quaternion); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Quaternion);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Rotation3D self) => new Dynamic(self);
        public static implicit operator Rotation3D(Dynamic value) => value.As<Rotation3D>();
        public String TypeName => "Rotation3D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Quaternion");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Quaternion));
        // Unimplemented concept functions
        public Boolean Equals(Rotation3D b) => (Quaternion.Equals(b.Quaternion));
        public static Boolean operator ==(Rotation3D a, Rotation3D b) => a.Equals(b);
        public Boolean NotEquals(Rotation3D b) => (Quaternion.NotEquals(b.Quaternion));
        public static Boolean operator !=(Rotation3D a, Rotation3D b) => a.NotEquals(b);
    }
    public readonly partial struct Orientation3D: Value<Orientation3D>
    {
        public readonly Rotation3D Value;
        public Orientation3D WithValue(Rotation3D value) => (value);
        public Orientation3D(Rotation3D value) => (Value) = (value);
        public static Orientation3D Default = new Orientation3D();
        public static Orientation3D New(Rotation3D value) => new Orientation3D(value);
        public Plato.DoublePrecision.Orientation3D ChangePrecision() => (Value.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Orientation3D(Orientation3D self) => self.ChangePrecision();
        public static implicit operator Rotation3D(Orientation3D self) => self.Value;
        public static implicit operator Orientation3D(Rotation3D value) => new Orientation3D(value);
        public override bool Equals(object obj) { if (!(obj is Orientation3D)) return false; var other = (Orientation3D)obj; return Value.Equals(other.Value); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Value);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Orientation3D self) => new Dynamic(self);
        public static implicit operator Orientation3D(Dynamic value) => value.As<Orientation3D>();
        public String TypeName => "Orientation3D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Value");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Value));
        // Unimplemented concept functions
        public Boolean Equals(Orientation3D b) => (Value.Equals(b.Value));
        public static Boolean operator ==(Orientation3D a, Orientation3D b) => a.Equals(b);
        public Boolean NotEquals(Orientation3D b) => (Value.NotEquals(b.Value));
        public static Boolean operator !=(Orientation3D a, Orientation3D b) => a.NotEquals(b);
    }
    public readonly partial struct Line4D: Value<Line4D>, Array<Vector4D>
    {
        public readonly Vector4D A;
        public readonly Vector4D B;
        public Line4D WithA(Vector4D a) => (a, B);
        public Line4D WithB(Vector4D b) => (A, b);
        public Line4D(Vector4D a, Vector4D b) => (A, B) = (a, b);
        public static Line4D Default = new Line4D();
        public static Line4D New(Vector4D a, Vector4D b) => new Line4D(a, b);
        public Plato.DoublePrecision.Line4D ChangePrecision() => (A.ChangePrecision(), B.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Line4D(Line4D self) => self.ChangePrecision();
        public static implicit operator (Vector4D, Vector4D)(Line4D self) => (self.A, self.B);
        public static implicit operator Line4D((Vector4D, Vector4D) value) => new Line4D(value.Item1, value.Item2);
        public void Deconstruct(out Vector4D a, out Vector4D b) { a = A; b = B; }
        public override bool Equals(object obj) { if (!(obj is Line4D)) return false; var other = (Line4D)obj; return A.Equals(other.A) && B.Equals(other.B); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(A, B);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Line4D self) => new Dynamic(self);
        public static implicit operator Line4D(Dynamic value) => value.As<Line4D>();
        public String TypeName => "Line4D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"A", (String)"B");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(A), new Dynamic(B));
        // Unimplemented concept functions
        public Boolean Equals(Line4D b) => (A.Equals(b.A) & B.Equals(b.B));
        public static Boolean operator ==(Line4D a, Line4D b) => a.Equals(b);
        public Boolean NotEquals(Line4D b) => (A.NotEquals(b.A) & B.NotEquals(b.B));
        public static Boolean operator !=(Line4D a, Line4D b) => a.NotEquals(b);
        public Integer Count => 2;
        public Vector4D At(Integer n) => n == 0 ? A : n == 1 ? B : throw new System.IndexOutOfRangeException();
        public Vector4D this[Integer n] => At(n);
    }
    public readonly partial struct Vertex
    {
        public readonly Vector3D Position;
        public readonly Vector3D Normal;
        public readonly Vector2D UV;
        public Vertex WithPosition(Vector3D position) => (position, Normal, UV);
        public Vertex WithNormal(Vector3D normal) => (Position, normal, UV);
        public Vertex WithUV(Vector2D uV) => (Position, Normal, uV);
        public Vertex(Vector3D position, Vector3D normal, Vector2D uV) => (Position, Normal, UV) = (position, normal, uV);
        public static Vertex Default = new Vertex();
        public static Vertex New(Vector3D position, Vector3D normal, Vector2D uV) => new Vertex(position, normal, uV);
        public Plato.DoublePrecision.Vertex ChangePrecision() => (Position.ChangePrecision(), Normal.ChangePrecision(), UV.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Vertex(Vertex self) => self.ChangePrecision();
        public static implicit operator (Vector3D, Vector3D, Vector2D)(Vertex self) => (self.Position, self.Normal, self.UV);
        public static implicit operator Vertex((Vector3D, Vector3D, Vector2D) value) => new Vertex(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Vector3D position, out Vector3D normal, out Vector2D uV) { position = Position; normal = Normal; uV = UV; }
        public override bool Equals(object obj) { if (!(obj is Vertex)) return false; var other = (Vertex)obj; return Position.Equals(other.Position) && Normal.Equals(other.Normal) && UV.Equals(other.UV); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Position, Normal, UV);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Vertex self) => new Dynamic(self);
        public static implicit operator Vertex(Dynamic value) => value.As<Vertex>();
        public String TypeName => "Vertex";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Position", (String)"Normal", (String)"UV");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Position), new Dynamic(Normal), new Dynamic(UV));
        // Unimplemented concept functions
    }
    public readonly partial struct TriMesh: Mesh<Integer3, Vertex>
    {
        public readonly Array<Vertex> Vertices;
        public readonly Array<Integer3> Faces;
        public TriMesh WithVertices(Array<Vertex> vertices) => (vertices, Faces);
        public TriMesh WithFaces(Array<Integer3> faces) => (Vertices, faces);
        public TriMesh(Array<Vertex> vertices, Array<Integer3> faces) => (Vertices, Faces) = (vertices, faces);
        public static TriMesh Default = new TriMesh();
        public static TriMesh New(Array<Vertex> vertices, Array<Integer3> faces) => new TriMesh(vertices, faces);
        public static implicit operator (Array<Vertex>, Array<Integer3>)(TriMesh self) => (self.Vertices, self.Faces);
        public static implicit operator TriMesh((Array<Vertex>, Array<Integer3>) value) => new TriMesh(value.Item1, value.Item2);
        public void Deconstruct(out Array<Vertex> vertices, out Array<Integer3> faces) { vertices = Vertices; faces = Faces; }
        public override bool Equals(object obj) { if (!(obj is TriMesh)) return false; var other = (TriMesh)obj; return Vertices.Equals(other.Vertices) && Faces.Equals(other.Faces); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Vertices, Faces);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(TriMesh self) => new Dynamic(self);
        public static implicit operator TriMesh(Dynamic value) => value.As<TriMesh>();
        public String TypeName => "TriMesh";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Vertices", (String)"Faces");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Vertices), new Dynamic(Faces));
        Array<Integer3> Mesh<Integer3, Vertex>.Faces => Faces;
        Array<Vertex> Mesh<Integer3, Vertex>.Vertices => Vertices;
        // Unimplemented concept functions
    }
    public readonly partial struct QuadMesh: Mesh<Integer4, Vertex>
    {
        public readonly Array<Vertex> Vertices;
        public readonly Array<Integer4> Faces;
        public QuadMesh WithVertices(Array<Vertex> vertices) => (vertices, Faces);
        public QuadMesh WithFaces(Array<Integer4> faces) => (Vertices, faces);
        public QuadMesh(Array<Vertex> vertices, Array<Integer4> faces) => (Vertices, Faces) = (vertices, faces);
        public static QuadMesh Default = new QuadMesh();
        public static QuadMesh New(Array<Vertex> vertices, Array<Integer4> faces) => new QuadMesh(vertices, faces);
        public static implicit operator (Array<Vertex>, Array<Integer4>)(QuadMesh self) => (self.Vertices, self.Faces);
        public static implicit operator QuadMesh((Array<Vertex>, Array<Integer4>) value) => new QuadMesh(value.Item1, value.Item2);
        public void Deconstruct(out Array<Vertex> vertices, out Array<Integer4> faces) { vertices = Vertices; faces = Faces; }
        public override bool Equals(object obj) { if (!(obj is QuadMesh)) return false; var other = (QuadMesh)obj; return Vertices.Equals(other.Vertices) && Faces.Equals(other.Faces); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Vertices, Faces);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(QuadMesh self) => new Dynamic(self);
        public static implicit operator QuadMesh(Dynamic value) => value.As<QuadMesh>();
        public String TypeName => "QuadMesh";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Vertices", (String)"Faces");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Vertices), new Dynamic(Faces));
        Array<Integer4> Mesh<Integer4, Vertex>.Faces => Faces;
        Array<Vertex> Mesh<Integer4, Vertex>.Vertices => Vertices;
        // Unimplemented concept functions
    }
    public readonly partial struct Number: Real<Number>, Numerical<Number>, Arithmetic<Number>, Comparable<Number>
    {
        public readonly float Value;
        public Number WithValue(float value) => (value);
        public Number(float value) => (Value) = (value);
        public static Number Default = new Number();
        public static Number New(float value) => new Number(value);
        public Plato.DoublePrecision.Number ChangePrecision() => (Value.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Number(Number self) => self.ChangePrecision();
        public static implicit operator float(Number self) => self.Value;
        public static implicit operator Number(float value) => new Number(value);
        public override bool Equals(object obj) { if (!(obj is Number)) return false; var other = (Number)obj; return Value.Equals(other.Value); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Value);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Number self) => new Dynamic(self);
        public static implicit operator Number(Dynamic value) => value.As<Number>();
        public String TypeName => "Number";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Value");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Value));
        Number Real<Number>.Value => Value;
        public Integer NumComponents => 1;
        public Number Component(Integer n) => n == 0 ? Value : throw new System.IndexOutOfRangeException();
    }
    public readonly partial struct Integer: WholeNumber<Integer>
    {
        public readonly int Value;
        public Integer WithValue(int value) => (value);
        public Integer(int value) => (Value) = (value);
        public static Integer Default = new Integer();
        public static Integer New(int value) => new Integer(value);
        public Plato.DoublePrecision.Integer ChangePrecision() => (Value.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Integer(Integer self) => self.ChangePrecision();
        public static implicit operator int(Integer self) => self.Value;
        public static implicit operator Integer(int value) => new Integer(value);
        public override bool Equals(object obj) { if (!(obj is Integer)) return false; var other = (Integer)obj; return Value.Equals(other.Value); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Value);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Integer self) => new Dynamic(self);
        public static implicit operator Integer(Dynamic value) => value.As<Integer>();
        public String TypeName => "Integer";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Value");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Value));
        Integer WholeNumber<Integer>.Value => Value;
        public Integer NumComponents => 1;
        public Number Component(Integer n) => n == 0 ? Value : throw new System.IndexOutOfRangeException();
    }
    public readonly partial struct String: Array<Character>, Comparable<String>, Equatable<String>
    {
        public readonly string Value;
        public String WithValue(string value) => (value);
        public String(string value) => (Value) = (value);
        public static String Default = new String();
        public static String New(string value) => new String(value);
        public Plato.DoublePrecision.String ChangePrecision() => (Value.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.String(String self) => self.ChangePrecision();
        public static implicit operator string(String self) => self.Value;
        public static implicit operator String(string value) => new String(value);
        public override bool Equals(object obj) { if (!(obj is String)) return false; var other = (String)obj; return Value.Equals(other.Value); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Value);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(String self) => new Dynamic(self);
        public static implicit operator String(Dynamic value) => value.As<String>();
        public String TypeName => "String";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Value");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Value));
    }
    public readonly partial struct Boolean: BooleanOperations<Boolean>
    {
        public readonly bool Value;
        public Boolean WithValue(bool value) => (value);
        public Boolean(bool value) => (Value) = (value);
        public static Boolean Default = new Boolean();
        public static Boolean New(bool value) => new Boolean(value);
        public Plato.DoublePrecision.Boolean ChangePrecision() => (Value.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Boolean(Boolean self) => self.ChangePrecision();
        public static implicit operator bool(Boolean self) => self.Value;
        public static implicit operator Boolean(bool value) => new Boolean(value);
        public override bool Equals(object obj) { if (!(obj is Boolean)) return false; var other = (Boolean)obj; return Value.Equals(other.Value); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Value);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Boolean self) => new Dynamic(self);
        public static implicit operator Boolean(Dynamic value) => value.As<Boolean>();
        public String TypeName => "Boolean";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Value");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Value));
    }
    public readonly partial struct Character: Value<Character>
    {
        public readonly char Value;
        public Character WithValue(char value) => (value);
        public Character(char value) => (Value) = (value);
        public static Character Default = new Character();
        public static Character New(char value) => new Character(value);
        public Plato.DoublePrecision.Character ChangePrecision() => (Value.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Character(Character self) => self.ChangePrecision();
        public static implicit operator char(Character self) => self.Value;
        public static implicit operator Character(char value) => new Character(value);
        public override bool Equals(object obj) { if (!(obj is Character)) return false; var other = (Character)obj; return Value.Equals(other.Value); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Value);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Character self) => new Dynamic(self);
        public static implicit operator Character(Dynamic value) => value.As<Character>();
        public String TypeName => "Character";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Value");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Value));
    }
    public readonly partial struct Type
    {
        public readonly System.Type Value;
        public Type WithValue(System.Type value) => (value);
        public Type(System.Type value) => (Value) = (value);
        public static Type Default = new Type();
        public static Type New(System.Type value) => new Type(value);
        public Plato.DoublePrecision.Type ChangePrecision() => (Value.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Type(Type self) => self.ChangePrecision();
        public static implicit operator System.Type(Type self) => self.Value;
        public static implicit operator Type(System.Type value) => new Type(value);
        public override bool Equals(object obj) { if (!(obj is Type)) return false; var other = (Type)obj; return Value.Equals(other.Value); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Value);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Type self) => new Dynamic(self);
        public static implicit operator Type(Dynamic value) => value.As<Type>();
        public String TypeName => "Type";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Value");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Value));
    }
    public readonly partial struct Error
    {
        public static Error Default = new Error();
        public static Error New() => new Error();
        public override bool Equals(object obj) => true;public override int GetHashCode() => Intrinsics.CombineHashCodes();
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Error self) => new Dynamic(self);
        public static implicit operator Error(Dynamic value) => value.As<Error>();
        public String TypeName => "Error";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>();
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>();
        // Unimplemented concept functions
    }
    public readonly partial struct Tuple2<T0, T1>
    {
        public readonly T0 X0;
        public readonly T1 X1;
        public Tuple2<T0, T1> WithX0(T0 x0) => (x0, X1);
        public Tuple2<T0, T1> WithX1(T1 x1) => (X0, x1);
        public Tuple2(T0 x0, T1 x1) => (X0, X1) = (x0, x1);
        public static Tuple2<T0, T1> Default = new Tuple2<T0, T1>();
        public static Tuple2<T0, T1> New(T0 x0, T1 x1) => new Tuple2<T0, T1>(x0, x1);
        public static implicit operator (T0, T1)(Tuple2<T0, T1> self) => (self.X0, self.X1);
        public static implicit operator Tuple2<T0, T1>((T0, T1) value) => new Tuple2<T0, T1>(value.Item1, value.Item2);
        public void Deconstruct(out T0 x0, out T1 x1) { x0 = X0; x1 = X1; }
        public override bool Equals(object obj) { if (!(obj is Tuple2<T0, T1>)) return false; var other = (Tuple2<T0, T1>)obj; return X0.Equals(other.X0) && X1.Equals(other.X1); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(X0, X1);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Tuple2<T0, T1> self) => new Dynamic(self);
        public static implicit operator Tuple2<T0, T1>(Dynamic value) => value.As<Tuple2<T0, T1>>();
        public String TypeName => "Tuple2<T0, T1>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"X0", (String)"X1");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(X0), new Dynamic(X1));
        // Unimplemented concept functions
    }
    public readonly partial struct Tuple3<T0, T1, T2>
    {
        public readonly T0 X0;
        public readonly T1 X1;
        public readonly T2 X2;
        public Tuple3<T0, T1, T2> WithX0(T0 x0) => (x0, X1, X2);
        public Tuple3<T0, T1, T2> WithX1(T1 x1) => (X0, x1, X2);
        public Tuple3<T0, T1, T2> WithX2(T2 x2) => (X0, X1, x2);
        public Tuple3(T0 x0, T1 x1, T2 x2) => (X0, X1, X2) = (x0, x1, x2);
        public static Tuple3<T0, T1, T2> Default = new Tuple3<T0, T1, T2>();
        public static Tuple3<T0, T1, T2> New(T0 x0, T1 x1, T2 x2) => new Tuple3<T0, T1, T2>(x0, x1, x2);
        public static implicit operator (T0, T1, T2)(Tuple3<T0, T1, T2> self) => (self.X0, self.X1, self.X2);
        public static implicit operator Tuple3<T0, T1, T2>((T0, T1, T2) value) => new Tuple3<T0, T1, T2>(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out T0 x0, out T1 x1, out T2 x2) { x0 = X0; x1 = X1; x2 = X2; }
        public override bool Equals(object obj) { if (!(obj is Tuple3<T0, T1, T2>)) return false; var other = (Tuple3<T0, T1, T2>)obj; return X0.Equals(other.X0) && X1.Equals(other.X1) && X2.Equals(other.X2); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(X0, X1, X2);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Tuple3<T0, T1, T2> self) => new Dynamic(self);
        public static implicit operator Tuple3<T0, T1, T2>(Dynamic value) => value.As<Tuple3<T0, T1, T2>>();
        public String TypeName => "Tuple3<T0, T1, T2>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"X0", (String)"X1", (String)"X2");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(X0), new Dynamic(X1), new Dynamic(X2));
        // Unimplemented concept functions
    }
    public readonly partial struct Tuple4<T0, T1, T2, T3>
    {
        public readonly T0 X0;
        public readonly T1 X1;
        public readonly T2 X2;
        public readonly T3 X3;
        public Tuple4<T0, T1, T2, T3> WithX0(T0 x0) => (x0, X1, X2, X3);
        public Tuple4<T0, T1, T2, T3> WithX1(T1 x1) => (X0, x1, X2, X3);
        public Tuple4<T0, T1, T2, T3> WithX2(T2 x2) => (X0, X1, x2, X3);
        public Tuple4<T0, T1, T2, T3> WithX3(T3 x3) => (X0, X1, X2, x3);
        public Tuple4(T0 x0, T1 x1, T2 x2, T3 x3) => (X0, X1, X2, X3) = (x0, x1, x2, x3);
        public static Tuple4<T0, T1, T2, T3> Default = new Tuple4<T0, T1, T2, T3>();
        public static Tuple4<T0, T1, T2, T3> New(T0 x0, T1 x1, T2 x2, T3 x3) => new Tuple4<T0, T1, T2, T3>(x0, x1, x2, x3);
        public static implicit operator (T0, T1, T2, T3)(Tuple4<T0, T1, T2, T3> self) => (self.X0, self.X1, self.X2, self.X3);
        public static implicit operator Tuple4<T0, T1, T2, T3>((T0, T1, T2, T3) value) => new Tuple4<T0, T1, T2, T3>(value.Item1, value.Item2, value.Item3, value.Item4);
        public void Deconstruct(out T0 x0, out T1 x1, out T2 x2, out T3 x3) { x0 = X0; x1 = X1; x2 = X2; x3 = X3; }
        public override bool Equals(object obj) { if (!(obj is Tuple4<T0, T1, T2, T3>)) return false; var other = (Tuple4<T0, T1, T2, T3>)obj; return X0.Equals(other.X0) && X1.Equals(other.X1) && X2.Equals(other.X2) && X3.Equals(other.X3); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(X0, X1, X2, X3);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Tuple4<T0, T1, T2, T3> self) => new Dynamic(self);
        public static implicit operator Tuple4<T0, T1, T2, T3>(Dynamic value) => value.As<Tuple4<T0, T1, T2, T3>>();
        public String TypeName => "Tuple4<T0, T1, T2, T3>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"X0", (String)"X1", (String)"X2", (String)"X3");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(X0), new Dynamic(X1), new Dynamic(X2), new Dynamic(X3));
        // Unimplemented concept functions
    }
    public readonly partial struct Tuple5<T0, T1, T2, T3, T4>
    {
        public readonly T0 X0;
        public readonly T1 X1;
        public readonly T2 X2;
        public readonly T3 X3;
        public readonly T4 X4;
        public Tuple5<T0, T1, T2, T3, T4> WithX0(T0 x0) => (x0, X1, X2, X3, X4);
        public Tuple5<T0, T1, T2, T3, T4> WithX1(T1 x1) => (X0, x1, X2, X3, X4);
        public Tuple5<T0, T1, T2, T3, T4> WithX2(T2 x2) => (X0, X1, x2, X3, X4);
        public Tuple5<T0, T1, T2, T3, T4> WithX3(T3 x3) => (X0, X1, X2, x3, X4);
        public Tuple5<T0, T1, T2, T3, T4> WithX4(T4 x4) => (X0, X1, X2, X3, x4);
        public Tuple5(T0 x0, T1 x1, T2 x2, T3 x3, T4 x4) => (X0, X1, X2, X3, X4) = (x0, x1, x2, x3, x4);
        public static Tuple5<T0, T1, T2, T3, T4> Default = new Tuple5<T0, T1, T2, T3, T4>();
        public static Tuple5<T0, T1, T2, T3, T4> New(T0 x0, T1 x1, T2 x2, T3 x3, T4 x4) => new Tuple5<T0, T1, T2, T3, T4>(x0, x1, x2, x3, x4);
        public static implicit operator (T0, T1, T2, T3, T4)(Tuple5<T0, T1, T2, T3, T4> self) => (self.X0, self.X1, self.X2, self.X3, self.X4);
        public static implicit operator Tuple5<T0, T1, T2, T3, T4>((T0, T1, T2, T3, T4) value) => new Tuple5<T0, T1, T2, T3, T4>(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5);
        public void Deconstruct(out T0 x0, out T1 x1, out T2 x2, out T3 x3, out T4 x4) { x0 = X0; x1 = X1; x2 = X2; x3 = X3; x4 = X4; }
        public override bool Equals(object obj) { if (!(obj is Tuple5<T0, T1, T2, T3, T4>)) return false; var other = (Tuple5<T0, T1, T2, T3, T4>)obj; return X0.Equals(other.X0) && X1.Equals(other.X1) && X2.Equals(other.X2) && X3.Equals(other.X3) && X4.Equals(other.X4); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(X0, X1, X2, X3, X4);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Tuple5<T0, T1, T2, T3, T4> self) => new Dynamic(self);
        public static implicit operator Tuple5<T0, T1, T2, T3, T4>(Dynamic value) => value.As<Tuple5<T0, T1, T2, T3, T4>>();
        public String TypeName => "Tuple5<T0, T1, T2, T3, T4>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"X0", (String)"X1", (String)"X2", (String)"X3", (String)"X4");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(X0), new Dynamic(X1), new Dynamic(X2), new Dynamic(X3), new Dynamic(X4));
        // Unimplemented concept functions
    }
    public readonly partial struct Tuple6<T0, T1, T2, T3, T4, T5>
    {
        public readonly T0 X0;
        public readonly T1 X1;
        public readonly T2 X2;
        public readonly T3 X3;
        public readonly T4 X4;
        public readonly T5 X5;
        public Tuple6<T0, T1, T2, T3, T4, T5> WithX0(T0 x0) => (x0, X1, X2, X3, X4, X5);
        public Tuple6<T0, T1, T2, T3, T4, T5> WithX1(T1 x1) => (X0, x1, X2, X3, X4, X5);
        public Tuple6<T0, T1, T2, T3, T4, T5> WithX2(T2 x2) => (X0, X1, x2, X3, X4, X5);
        public Tuple6<T0, T1, T2, T3, T4, T5> WithX3(T3 x3) => (X0, X1, X2, x3, X4, X5);
        public Tuple6<T0, T1, T2, T3, T4, T5> WithX4(T4 x4) => (X0, X1, X2, X3, x4, X5);
        public Tuple6<T0, T1, T2, T3, T4, T5> WithX5(T5 x5) => (X0, X1, X2, X3, X4, x5);
        public Tuple6(T0 x0, T1 x1, T2 x2, T3 x3, T4 x4, T5 x5) => (X0, X1, X2, X3, X4, X5) = (x0, x1, x2, x3, x4, x5);
        public static Tuple6<T0, T1, T2, T3, T4, T5> Default = new Tuple6<T0, T1, T2, T3, T4, T5>();
        public static Tuple6<T0, T1, T2, T3, T4, T5> New(T0 x0, T1 x1, T2 x2, T3 x3, T4 x4, T5 x5) => new Tuple6<T0, T1, T2, T3, T4, T5>(x0, x1, x2, x3, x4, x5);
        public static implicit operator (T0, T1, T2, T3, T4, T5)(Tuple6<T0, T1, T2, T3, T4, T5> self) => (self.X0, self.X1, self.X2, self.X3, self.X4, self.X5);
        public static implicit operator Tuple6<T0, T1, T2, T3, T4, T5>((T0, T1, T2, T3, T4, T5) value) => new Tuple6<T0, T1, T2, T3, T4, T5>(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6);
        public void Deconstruct(out T0 x0, out T1 x1, out T2 x2, out T3 x3, out T4 x4, out T5 x5) { x0 = X0; x1 = X1; x2 = X2; x3 = X3; x4 = X4; x5 = X5; }
        public override bool Equals(object obj) { if (!(obj is Tuple6<T0, T1, T2, T3, T4, T5>)) return false; var other = (Tuple6<T0, T1, T2, T3, T4, T5>)obj; return X0.Equals(other.X0) && X1.Equals(other.X1) && X2.Equals(other.X2) && X3.Equals(other.X3) && X4.Equals(other.X4) && X5.Equals(other.X5); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(X0, X1, X2, X3, X4, X5);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Tuple6<T0, T1, T2, T3, T4, T5> self) => new Dynamic(self);
        public static implicit operator Tuple6<T0, T1, T2, T3, T4, T5>(Dynamic value) => value.As<Tuple6<T0, T1, T2, T3, T4, T5>>();
        public String TypeName => "Tuple6<T0, T1, T2, T3, T4, T5>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"X0", (String)"X1", (String)"X2", (String)"X3", (String)"X4", (String)"X5");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(X0), new Dynamic(X1), new Dynamic(X2), new Dynamic(X3), new Dynamic(X4), new Dynamic(X5));
        // Unimplemented concept functions
    }
    public readonly partial struct Tuple7<T0, T1, T2, T3, T4, T5, T6>
    {
        public readonly T0 X0;
        public readonly T1 X1;
        public readonly T2 X2;
        public readonly T3 X3;
        public readonly T4 X4;
        public readonly T5 X5;
        public readonly T6 X6;
        public Tuple7<T0, T1, T2, T3, T4, T5, T6> WithX0(T0 x0) => (x0, X1, X2, X3, X4, X5, X6);
        public Tuple7<T0, T1, T2, T3, T4, T5, T6> WithX1(T1 x1) => (X0, x1, X2, X3, X4, X5, X6);
        public Tuple7<T0, T1, T2, T3, T4, T5, T6> WithX2(T2 x2) => (X0, X1, x2, X3, X4, X5, X6);
        public Tuple7<T0, T1, T2, T3, T4, T5, T6> WithX3(T3 x3) => (X0, X1, X2, x3, X4, X5, X6);
        public Tuple7<T0, T1, T2, T3, T4, T5, T6> WithX4(T4 x4) => (X0, X1, X2, X3, x4, X5, X6);
        public Tuple7<T0, T1, T2, T3, T4, T5, T6> WithX5(T5 x5) => (X0, X1, X2, X3, X4, x5, X6);
        public Tuple7<T0, T1, T2, T3, T4, T5, T6> WithX6(T6 x6) => (X0, X1, X2, X3, X4, X5, x6);
        public Tuple7(T0 x0, T1 x1, T2 x2, T3 x3, T4 x4, T5 x5, T6 x6) => (X0, X1, X2, X3, X4, X5, X6) = (x0, x1, x2, x3, x4, x5, x6);
        public static Tuple7<T0, T1, T2, T3, T4, T5, T6> Default = new Tuple7<T0, T1, T2, T3, T4, T5, T6>();
        public static Tuple7<T0, T1, T2, T3, T4, T5, T6> New(T0 x0, T1 x1, T2 x2, T3 x3, T4 x4, T5 x5, T6 x6) => new Tuple7<T0, T1, T2, T3, T4, T5, T6>(x0, x1, x2, x3, x4, x5, x6);
        public static implicit operator (T0, T1, T2, T3, T4, T5, T6)(Tuple7<T0, T1, T2, T3, T4, T5, T6> self) => (self.X0, self.X1, self.X2, self.X3, self.X4, self.X5, self.X6);
        public static implicit operator Tuple7<T0, T1, T2, T3, T4, T5, T6>((T0, T1, T2, T3, T4, T5, T6) value) => new Tuple7<T0, T1, T2, T3, T4, T5, T6>(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7);
        public void Deconstruct(out T0 x0, out T1 x1, out T2 x2, out T3 x3, out T4 x4, out T5 x5, out T6 x6) { x0 = X0; x1 = X1; x2 = X2; x3 = X3; x4 = X4; x5 = X5; x6 = X6; }
        public override bool Equals(object obj) { if (!(obj is Tuple7<T0, T1, T2, T3, T4, T5, T6>)) return false; var other = (Tuple7<T0, T1, T2, T3, T4, T5, T6>)obj; return X0.Equals(other.X0) && X1.Equals(other.X1) && X2.Equals(other.X2) && X3.Equals(other.X3) && X4.Equals(other.X4) && X5.Equals(other.X5) && X6.Equals(other.X6); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(X0, X1, X2, X3, X4, X5, X6);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Tuple7<T0, T1, T2, T3, T4, T5, T6> self) => new Dynamic(self);
        public static implicit operator Tuple7<T0, T1, T2, T3, T4, T5, T6>(Dynamic value) => value.As<Tuple7<T0, T1, T2, T3, T4, T5, T6>>();
        public String TypeName => "Tuple7<T0, T1, T2, T3, T4, T5, T6>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"X0", (String)"X1", (String)"X2", (String)"X3", (String)"X4", (String)"X5", (String)"X6");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(X0), new Dynamic(X1), new Dynamic(X2), new Dynamic(X3), new Dynamic(X4), new Dynamic(X5), new Dynamic(X6));
        // Unimplemented concept functions
    }
    public readonly partial struct Tuple8<T0, T1, T2, T3, T4, T5, T6, T7>
    {
        public readonly T0 X0;
        public readonly T1 X1;
        public readonly T2 X2;
        public readonly T3 X3;
        public readonly T4 X4;
        public readonly T5 X5;
        public readonly T6 X6;
        public readonly T7 X7;
        public Tuple8<T0, T1, T2, T3, T4, T5, T6, T7> WithX0(T0 x0) => (x0, X1, X2, X3, X4, X5, X6, X7);
        public Tuple8<T0, T1, T2, T3, T4, T5, T6, T7> WithX1(T1 x1) => (X0, x1, X2, X3, X4, X5, X6, X7);
        public Tuple8<T0, T1, T2, T3, T4, T5, T6, T7> WithX2(T2 x2) => (X0, X1, x2, X3, X4, X5, X6, X7);
        public Tuple8<T0, T1, T2, T3, T4, T5, T6, T7> WithX3(T3 x3) => (X0, X1, X2, x3, X4, X5, X6, X7);
        public Tuple8<T0, T1, T2, T3, T4, T5, T6, T7> WithX4(T4 x4) => (X0, X1, X2, X3, x4, X5, X6, X7);
        public Tuple8<T0, T1, T2, T3, T4, T5, T6, T7> WithX5(T5 x5) => (X0, X1, X2, X3, X4, x5, X6, X7);
        public Tuple8<T0, T1, T2, T3, T4, T5, T6, T7> WithX6(T6 x6) => (X0, X1, X2, X3, X4, X5, x6, X7);
        public Tuple8<T0, T1, T2, T3, T4, T5, T6, T7> WithX7(T7 x7) => (X0, X1, X2, X3, X4, X5, X6, x7);
        public Tuple8(T0 x0, T1 x1, T2 x2, T3 x3, T4 x4, T5 x5, T6 x6, T7 x7) => (X0, X1, X2, X3, X4, X5, X6, X7) = (x0, x1, x2, x3, x4, x5, x6, x7);
        public static Tuple8<T0, T1, T2, T3, T4, T5, T6, T7> Default = new Tuple8<T0, T1, T2, T3, T4, T5, T6, T7>();
        public static Tuple8<T0, T1, T2, T3, T4, T5, T6, T7> New(T0 x0, T1 x1, T2 x2, T3 x3, T4 x4, T5 x5, T6 x6, T7 x7) => new Tuple8<T0, T1, T2, T3, T4, T5, T6, T7>(x0, x1, x2, x3, x4, x5, x6, x7);
        public static implicit operator (T0, T1, T2, T3, T4, T5, T6, T7)(Tuple8<T0, T1, T2, T3, T4, T5, T6, T7> self) => (self.X0, self.X1, self.X2, self.X3, self.X4, self.X5, self.X6, self.X7);
        public static implicit operator Tuple8<T0, T1, T2, T3, T4, T5, T6, T7>((T0, T1, T2, T3, T4, T5, T6, T7) value) => new Tuple8<T0, T1, T2, T3, T4, T5, T6, T7>(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7, value.Item8);
        public void Deconstruct(out T0 x0, out T1 x1, out T2 x2, out T3 x3, out T4 x4, out T5 x5, out T6 x6, out T7 x7) { x0 = X0; x1 = X1; x2 = X2; x3 = X3; x4 = X4; x5 = X5; x6 = X6; x7 = X7; }
        public override bool Equals(object obj) { if (!(obj is Tuple8<T0, T1, T2, T3, T4, T5, T6, T7>)) return false; var other = (Tuple8<T0, T1, T2, T3, T4, T5, T6, T7>)obj; return X0.Equals(other.X0) && X1.Equals(other.X1) && X2.Equals(other.X2) && X3.Equals(other.X3) && X4.Equals(other.X4) && X5.Equals(other.X5) && X6.Equals(other.X6) && X7.Equals(other.X7); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(X0, X1, X2, X3, X4, X5, X6, X7);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Tuple8<T0, T1, T2, T3, T4, T5, T6, T7> self) => new Dynamic(self);
        public static implicit operator Tuple8<T0, T1, T2, T3, T4, T5, T6, T7>(Dynamic value) => value.As<Tuple8<T0, T1, T2, T3, T4, T5, T6, T7>>();
        public String TypeName => "Tuple8<T0, T1, T2, T3, T4, T5, T6, T7>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"X0", (String)"X1", (String)"X2", (String)"X3", (String)"X4", (String)"X5", (String)"X6", (String)"X7");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(X0), new Dynamic(X1), new Dynamic(X2), new Dynamic(X3), new Dynamic(X4), new Dynamic(X5), new Dynamic(X6), new Dynamic(X7));
        // Unimplemented concept functions
    }
    public readonly partial struct Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8>
    {
        public readonly T0 X0;
        public readonly T1 X1;
        public readonly T2 X2;
        public readonly T3 X3;
        public readonly T4 X4;
        public readonly T5 X5;
        public readonly T6 X6;
        public readonly T7 X7;
        public readonly T8 X8;
        public Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8> WithX0(T0 x0) => (x0, X1, X2, X3, X4, X5, X6, X7, X8);
        public Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8> WithX1(T1 x1) => (X0, x1, X2, X3, X4, X5, X6, X7, X8);
        public Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8> WithX2(T2 x2) => (X0, X1, x2, X3, X4, X5, X6, X7, X8);
        public Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8> WithX3(T3 x3) => (X0, X1, X2, x3, X4, X5, X6, X7, X8);
        public Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8> WithX4(T4 x4) => (X0, X1, X2, X3, x4, X5, X6, X7, X8);
        public Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8> WithX5(T5 x5) => (X0, X1, X2, X3, X4, x5, X6, X7, X8);
        public Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8> WithX6(T6 x6) => (X0, X1, X2, X3, X4, X5, x6, X7, X8);
        public Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8> WithX7(T7 x7) => (X0, X1, X2, X3, X4, X5, X6, x7, X8);
        public Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8> WithX8(T8 x8) => (X0, X1, X2, X3, X4, X5, X6, X7, x8);
        public Tuple9(T0 x0, T1 x1, T2 x2, T3 x3, T4 x4, T5 x5, T6 x6, T7 x7, T8 x8) => (X0, X1, X2, X3, X4, X5, X6, X7, X8) = (x0, x1, x2, x3, x4, x5, x6, x7, x8);
        public static Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8> Default = new Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8>();
        public static Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8> New(T0 x0, T1 x1, T2 x2, T3 x3, T4 x4, T5 x5, T6 x6, T7 x7, T8 x8) => new Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8>(x0, x1, x2, x3, x4, x5, x6, x7, x8);
        public static implicit operator (T0, T1, T2, T3, T4, T5, T6, T7, T8)(Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8> self) => (self.X0, self.X1, self.X2, self.X3, self.X4, self.X5, self.X6, self.X7, self.X8);
        public static implicit operator Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8>((T0, T1, T2, T3, T4, T5, T6, T7, T8) value) => new Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8>(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7, value.Item8, value.Item9);
        public void Deconstruct(out T0 x0, out T1 x1, out T2 x2, out T3 x3, out T4 x4, out T5 x5, out T6 x6, out T7 x7, out T8 x8) { x0 = X0; x1 = X1; x2 = X2; x3 = X3; x4 = X4; x5 = X5; x6 = X6; x7 = X7; x8 = X8; }
        public override bool Equals(object obj) { if (!(obj is Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8>)) return false; var other = (Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8>)obj; return X0.Equals(other.X0) && X1.Equals(other.X1) && X2.Equals(other.X2) && X3.Equals(other.X3) && X4.Equals(other.X4) && X5.Equals(other.X5) && X6.Equals(other.X6) && X7.Equals(other.X7) && X8.Equals(other.X8); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(X0, X1, X2, X3, X4, X5, X6, X7, X8);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8> self) => new Dynamic(self);
        public static implicit operator Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8>(Dynamic value) => value.As<Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8>>();
        public String TypeName => "Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"X0", (String)"X1", (String)"X2", (String)"X3", (String)"X4", (String)"X5", (String)"X6", (String)"X7", (String)"X8");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(X0), new Dynamic(X1), new Dynamic(X2), new Dynamic(X3), new Dynamic(X4), new Dynamic(X5), new Dynamic(X6), new Dynamic(X7), new Dynamic(X8));
        // Unimplemented concept functions
    }
    public readonly partial struct Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        public readonly T0 X0;
        public readonly T1 X1;
        public readonly T2 X2;
        public readonly T3 X3;
        public readonly T4 X4;
        public readonly T5 X5;
        public readonly T6 X6;
        public readonly T7 X7;
        public readonly T8 X8;
        public readonly T9 X9;
        public Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> WithX0(T0 x0) => (x0, X1, X2, X3, X4, X5, X6, X7, X8, X9);
        public Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> WithX1(T1 x1) => (X0, x1, X2, X3, X4, X5, X6, X7, X8, X9);
        public Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> WithX2(T2 x2) => (X0, X1, x2, X3, X4, X5, X6, X7, X8, X9);
        public Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> WithX3(T3 x3) => (X0, X1, X2, x3, X4, X5, X6, X7, X8, X9);
        public Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> WithX4(T4 x4) => (X0, X1, X2, X3, x4, X5, X6, X7, X8, X9);
        public Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> WithX5(T5 x5) => (X0, X1, X2, X3, X4, x5, X6, X7, X8, X9);
        public Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> WithX6(T6 x6) => (X0, X1, X2, X3, X4, X5, x6, X7, X8, X9);
        public Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> WithX7(T7 x7) => (X0, X1, X2, X3, X4, X5, X6, x7, X8, X9);
        public Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> WithX8(T8 x8) => (X0, X1, X2, X3, X4, X5, X6, X7, x8, X9);
        public Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> WithX9(T9 x9) => (X0, X1, X2, X3, X4, X5, X6, X7, X8, x9);
        public Tuple10(T0 x0, T1 x1, T2 x2, T3 x3, T4 x4, T5 x5, T6 x6, T7 x7, T8 x8, T9 x9) => (X0, X1, X2, X3, X4, X5, X6, X7, X8, X9) = (x0, x1, x2, x3, x4, x5, x6, x7, x8, x9);
        public static Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> Default = new Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>();
        public static Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> New(T0 x0, T1 x1, T2 x2, T3 x3, T4 x4, T5 x5, T6 x6, T7 x7, T8 x8, T9 x9) => new Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(x0, x1, x2, x3, x4, x5, x6, x7, x8, x9);
        public static implicit operator (T0, T1, T2, T3, T4, T5, T6, T7, T8, T9)(Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> self) => (self.X0, self.X1, self.X2, self.X3, self.X4, self.X5, self.X6, self.X7, self.X8, self.X9);
        public static implicit operator Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>((T0, T1, T2, T3, T4, T5, T6, T7, T8, T9) value) => new Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7, value.Item8, value.Item9, value.Item10);
        public void Deconstruct(out T0 x0, out T1 x1, out T2 x2, out T3 x3, out T4 x4, out T5 x5, out T6 x6, out T7 x7, out T8 x8, out T9 x9) { x0 = X0; x1 = X1; x2 = X2; x3 = X3; x4 = X4; x5 = X5; x6 = X6; x7 = X7; x8 = X8; x9 = X9; }
        public override bool Equals(object obj) { if (!(obj is Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)) return false; var other = (Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)obj; return X0.Equals(other.X0) && X1.Equals(other.X1) && X2.Equals(other.X2) && X3.Equals(other.X3) && X4.Equals(other.X4) && X5.Equals(other.X5) && X6.Equals(other.X6) && X7.Equals(other.X7) && X8.Equals(other.X8) && X9.Equals(other.X9); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(X0, X1, X2, X3, X4, X5, X6, X7, X8, X9);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> self) => new Dynamic(self);
        public static implicit operator Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Dynamic value) => value.As<Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>();
        public String TypeName => "Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"X0", (String)"X1", (String)"X2", (String)"X3", (String)"X4", (String)"X5", (String)"X6", (String)"X7", (String)"X8", (String)"X9");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(X0), new Dynamic(X1), new Dynamic(X2), new Dynamic(X3), new Dynamic(X4), new Dynamic(X5), new Dynamic(X6), new Dynamic(X7), new Dynamic(X8), new Dynamic(X9));
        // Unimplemented concept functions
    }
    public readonly partial struct Function4<T0, T1, T2, T3, TR>
    {
        public static Function4<T0, T1, T2, T3, TR> Default = new Function4<T0, T1, T2, T3, TR>();
        public static Function4<T0, T1, T2, T3, TR> New() => new Function4<T0, T1, T2, T3, TR>();
        public override bool Equals(object obj) => true;public override int GetHashCode() => Intrinsics.CombineHashCodes();
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Function4<T0, T1, T2, T3, TR> self) => new Dynamic(self);
        public static implicit operator Function4<T0, T1, T2, T3, TR>(Dynamic value) => value.As<Function4<T0, T1, T2, T3, TR>>();
        public String TypeName => "Function4<T0, T1, T2, T3, TR>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>();
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>();
        // Unimplemented concept functions
    }
    public readonly partial struct Function5<T0, T1, T2, T3, T4, TR>
    {
        public static Function5<T0, T1, T2, T3, T4, TR> Default = new Function5<T0, T1, T2, T3, T4, TR>();
        public static Function5<T0, T1, T2, T3, T4, TR> New() => new Function5<T0, T1, T2, T3, T4, TR>();
        public override bool Equals(object obj) => true;public override int GetHashCode() => Intrinsics.CombineHashCodes();
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Function5<T0, T1, T2, T3, T4, TR> self) => new Dynamic(self);
        public static implicit operator Function5<T0, T1, T2, T3, T4, TR>(Dynamic value) => value.As<Function5<T0, T1, T2, T3, T4, TR>>();
        public String TypeName => "Function5<T0, T1, T2, T3, T4, TR>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>();
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>();
        // Unimplemented concept functions
    }
    public readonly partial struct Function6<T0, T1, T2, T3, T4, T5, TR>
    {
        public static Function6<T0, T1, T2, T3, T4, T5, TR> Default = new Function6<T0, T1, T2, T3, T4, T5, TR>();
        public static Function6<T0, T1, T2, T3, T4, T5, TR> New() => new Function6<T0, T1, T2, T3, T4, T5, TR>();
        public override bool Equals(object obj) => true;public override int GetHashCode() => Intrinsics.CombineHashCodes();
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Function6<T0, T1, T2, T3, T4, T5, TR> self) => new Dynamic(self);
        public static implicit operator Function6<T0, T1, T2, T3, T4, T5, TR>(Dynamic value) => value.As<Function6<T0, T1, T2, T3, T4, T5, TR>>();
        public String TypeName => "Function6<T0, T1, T2, T3, T4, T5, TR>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>();
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>();
        // Unimplemented concept functions
    }
    public readonly partial struct Function7<T0, T1, T2, T3, T4, T5, T6, TR>
    {
        public static Function7<T0, T1, T2, T3, T4, T5, T6, TR> Default = new Function7<T0, T1, T2, T3, T4, T5, T6, TR>();
        public static Function7<T0, T1, T2, T3, T4, T5, T6, TR> New() => new Function7<T0, T1, T2, T3, T4, T5, T6, TR>();
        public override bool Equals(object obj) => true;public override int GetHashCode() => Intrinsics.CombineHashCodes();
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Function7<T0, T1, T2, T3, T4, T5, T6, TR> self) => new Dynamic(self);
        public static implicit operator Function7<T0, T1, T2, T3, T4, T5, T6, TR>(Dynamic value) => value.As<Function7<T0, T1, T2, T3, T4, T5, T6, TR>>();
        public String TypeName => "Function7<T0, T1, T2, T3, T4, T5, T6, TR>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>();
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>();
        // Unimplemented concept functions
    }
    public readonly partial struct Function8<T0, T1, T2, T3, T4, T5, T6, T7, TR>
    {
        public static Function8<T0, T1, T2, T3, T4, T5, T6, T7, TR> Default = new Function8<T0, T1, T2, T3, T4, T5, T6, T7, TR>();
        public static Function8<T0, T1, T2, T3, T4, T5, T6, T7, TR> New() => new Function8<T0, T1, T2, T3, T4, T5, T6, T7, TR>();
        public override bool Equals(object obj) => true;public override int GetHashCode() => Intrinsics.CombineHashCodes();
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Function8<T0, T1, T2, T3, T4, T5, T6, T7, TR> self) => new Dynamic(self);
        public static implicit operator Function8<T0, T1, T2, T3, T4, T5, T6, T7, TR>(Dynamic value) => value.As<Function8<T0, T1, T2, T3, T4, T5, T6, T7, TR>>();
        public String TypeName => "Function8<T0, T1, T2, T3, T4, T5, T6, T7, TR>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>();
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>();
        // Unimplemented concept functions
    }
    public readonly partial struct Function9<T0, T1, T2, T3, T4, T5, T6, T7, T8, TR>
    {
        public static Function9<T0, T1, T2, T3, T4, T5, T6, T7, T8, TR> Default = new Function9<T0, T1, T2, T3, T4, T5, T6, T7, T8, TR>();
        public static Function9<T0, T1, T2, T3, T4, T5, T6, T7, T8, TR> New() => new Function9<T0, T1, T2, T3, T4, T5, T6, T7, T8, TR>();
        public override bool Equals(object obj) => true;public override int GetHashCode() => Intrinsics.CombineHashCodes();
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Function9<T0, T1, T2, T3, T4, T5, T6, T7, T8, TR> self) => new Dynamic(self);
        public static implicit operator Function9<T0, T1, T2, T3, T4, T5, T6, T7, T8, TR>(Dynamic value) => value.As<Function9<T0, T1, T2, T3, T4, T5, T6, T7, T8, TR>>();
        public String TypeName => "Function9<T0, T1, T2, T3, T4, T5, T6, T7, T8, TR>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>();
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>();
        // Unimplemented concept functions
    }
    public readonly partial struct Function10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TR>
    {
        public static Function10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TR> Default = new Function10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TR>();
        public static Function10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TR> New() => new Function10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TR>();
        public override bool Equals(object obj) => true;public override int GetHashCode() => Intrinsics.CombineHashCodes();
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Function10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TR> self) => new Dynamic(self);
        public static implicit operator Function10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TR>(Dynamic value) => value.As<Function10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TR>>();
        public String TypeName => "Function10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TR>";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>();
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>();
        // Unimplemented concept functions
    }
    public readonly partial struct Unit: Real<Unit>
    {
        public readonly Number Value;
        public Unit WithValue(Number value) => (value);
        public Unit(Number value) => (Value) = (value);
        public static Unit Default = new Unit();
        public static Unit New(Number value) => new Unit(value);
        public Plato.DoublePrecision.Unit ChangePrecision() => (Value.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Unit(Unit self) => self.ChangePrecision();
        public static implicit operator Number(Unit self) => self.Value;
        public static implicit operator Unit(Number value) => new Unit(value);
        public static implicit operator Unit(Integer value) => new Unit(value);
        public override bool Equals(object obj) { if (!(obj is Unit)) return false; var other = (Unit)obj; return Value.Equals(other.Value); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Value);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Unit self) => new Dynamic(self);
        public static implicit operator Unit(Dynamic value) => value.As<Unit>();
        public String TypeName => "Unit";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Value");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Value));
        Number Real<Unit>.Value => Value;
        // Unimplemented concept functions
        public Unit Add(Unit b) => (Value.Add(b.Value));
        public static Unit operator +(Unit a, Unit b) => a.Add(b);
        public Unit Subtract(Unit b) => (Value.Subtract(b.Value));
        public static Unit operator -(Unit a, Unit b) => a.Subtract(b);
        public Unit Multiply(Unit b) => (Value.Multiply(b.Value));
        public static Unit operator *(Unit a, Unit b) => a.Multiply(b);
        public Unit Divide(Unit b) => (Value.Divide(b.Value));
        public static Unit operator /(Unit a, Unit b) => a.Divide(b);
        public Unit Modulo(Unit b) => (Value.Modulo(b.Value));
        public static Unit operator %(Unit a, Unit b) => a.Modulo(b);
        public Unit Reciprocal => (Value.Reciprocal);
        public Unit Negative => (Value.Negative);
        public static Unit operator -(Unit self) => self.Negative;
        public Integer Compare(Unit y) => (Value.Compare(y.Value));
        public Unit Multiply(Number other) => (Value.Multiply(other));
        public static Unit operator *(Unit self, Number other) => self.Multiply(other);
        public Unit Multiply(Unit self) => (Value.Multiply(self.Value));
        public static Unit operator *(Number other, Unit self) => other.Multiply(self);
        public Unit Divide(Number other) => (Value.Divide(other));
        public static Unit operator /(Unit self, Number other) => self.Divide(other);
        public Unit Modulo(Number other) => (Value.Modulo(other));
        public static Unit operator %(Unit self, Number other) => self.Modulo(other);
        public Array<Number> Components => (Value.Components);
        public Unit FromComponents => (Value.FromComponents);
        public Integer NumComponents => 1;
        public Number Component(Integer n) => n == 0 ? Value : throw new System.IndexOutOfRangeException();
    }
    public readonly partial struct Probability: Measure<Probability>
    {
        public readonly Number Value;
        public Probability WithValue(Number value) => (value);
        public Probability(Number value) => (Value) = (value);
        public static Probability Default = new Probability();
        public static Probability New(Number value) => new Probability(value);
        public Plato.DoublePrecision.Probability ChangePrecision() => (Value.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Probability(Probability self) => self.ChangePrecision();
        public static implicit operator Number(Probability self) => self.Value;
        public static implicit operator Probability(Number value) => new Probability(value);
        public static implicit operator Probability(Integer value) => new Probability(value);
        public override bool Equals(object obj) { if (!(obj is Probability)) return false; var other = (Probability)obj; return Value.Equals(other.Value); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Value);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Probability self) => new Dynamic(self);
        public static implicit operator Probability(Dynamic value) => value.As<Probability>();
        public String TypeName => "Probability";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Value");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Value));
        Number Measure<Probability>.Value => Value;
        // Unimplemented concept functions
        public Probability Add(Probability b) => (Value.Add(b.Value));
        public static Probability operator +(Probability a, Probability b) => a.Add(b);
        public Probability Subtract(Probability b) => (Value.Subtract(b.Value));
        public static Probability operator -(Probability a, Probability b) => a.Subtract(b);
        public Probability Negative => (Value.Negative);
        public static Probability operator -(Probability self) => self.Negative;
        public Integer Compare(Probability y) => (Value.Compare(y.Value));
        public Probability Multiply(Number other) => (Value.Multiply(other));
        public static Probability operator *(Probability self, Number other) => self.Multiply(other);
        public Probability Multiply(Probability self) => (Value.Multiply(self.Value));
        public static Probability operator *(Number other, Probability self) => other.Multiply(self);
        public Probability Divide(Number other) => (Value.Divide(other));
        public static Probability operator /(Probability self, Number other) => self.Divide(other);
        public Probability Modulo(Number other) => (Value.Modulo(other));
        public static Probability operator %(Probability self, Number other) => self.Modulo(other);
        public Array<Number> Components => (Value.Components);
        public Probability FromComponents => (Value.FromComponents);
        public Integer NumComponents => 1;
        public Number Component(Integer n) => n == 0 ? Value : throw new System.IndexOutOfRangeException();
    }
    public readonly partial struct Complex: Vector<Complex>
    {
        public readonly Number Real;
        public readonly Number Imaginary;
        public Complex WithReal(Number real) => (real, Imaginary);
        public Complex WithImaginary(Number imaginary) => (Real, imaginary);
        public Complex(Number real, Number imaginary) => (Real, Imaginary) = (real, imaginary);
        public static Complex Default = new Complex();
        public static Complex New(Number real, Number imaginary) => new Complex(real, imaginary);
        public Plato.DoublePrecision.Complex ChangePrecision() => (Real.ChangePrecision(), Imaginary.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Complex(Complex self) => self.ChangePrecision();
        public static implicit operator (Number, Number)(Complex self) => (self.Real, self.Imaginary);
        public static implicit operator Complex((Number, Number) value) => new Complex(value.Item1, value.Item2);
        public void Deconstruct(out Number real, out Number imaginary) { real = Real; imaginary = Imaginary; }
        public override bool Equals(object obj) { if (!(obj is Complex)) return false; var other = (Complex)obj; return Real.Equals(other.Real) && Imaginary.Equals(other.Imaginary); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Real, Imaginary);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Complex self) => new Dynamic(self);
        public static implicit operator Complex(Dynamic value) => value.As<Complex>();
        public String TypeName => "Complex";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Real", (String)"Imaginary");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Real), new Dynamic(Imaginary));
        // Unimplemented concept functions
        public Complex Add(Complex b) => (Real.Add(b.Real), Imaginary.Add(b.Imaginary));
        public static Complex operator +(Complex a, Complex b) => a.Add(b);
        public Complex Subtract(Complex b) => (Real.Subtract(b.Real), Imaginary.Subtract(b.Imaginary));
        public static Complex operator -(Complex a, Complex b) => a.Subtract(b);
        public Complex Multiply(Complex b) => (Real.Multiply(b.Real), Imaginary.Multiply(b.Imaginary));
        public static Complex operator *(Complex a, Complex b) => a.Multiply(b);
        public Complex Divide(Complex b) => (Real.Divide(b.Real), Imaginary.Divide(b.Imaginary));
        public static Complex operator /(Complex a, Complex b) => a.Divide(b);
        public Complex Modulo(Complex b) => (Real.Modulo(b.Real), Imaginary.Modulo(b.Imaginary));
        public static Complex operator %(Complex a, Complex b) => a.Modulo(b);
        public Complex Reciprocal => (Real.Reciprocal, Imaginary.Reciprocal);
        public Complex Negative => (Real.Negative, Imaginary.Negative);
        public static Complex operator -(Complex self) => self.Negative;
        public Complex Multiply(Number other) => (Real.Multiply(other), Imaginary.Multiply(other));
        public static Complex operator *(Complex self, Number other) => self.Multiply(other);
        public Complex Multiply(Complex self) => (Real.Multiply(self.Real), Imaginary.Multiply(self.Imaginary));
        public static Complex operator *(Number other, Complex self) => other.Multiply(self);
        public Complex Divide(Number other) => (Real.Divide(other), Imaginary.Divide(other));
        public static Complex operator /(Complex self, Number other) => self.Divide(other);
        public Complex Modulo(Number other) => (Real.Modulo(other), Imaginary.Modulo(other));
        public static Complex operator %(Complex self, Number other) => self.Modulo(other);
        public Array<Number> Components => throw new NotImplementedException();
        public Complex FromComponents => (Real.FromComponents, Imaginary.FromComponents);
        public Boolean Equals(Complex b) => (Real.Equals(b.Real) & Imaginary.Equals(b.Imaginary));
        public static Boolean operator ==(Complex a, Complex b) => a.Equals(b);
        public Boolean NotEquals(Complex b) => (Real.NotEquals(b.Real) & Imaginary.NotEquals(b.Imaginary));
        public static Boolean operator !=(Complex a, Complex b) => a.NotEquals(b);
        public Integer NumComponents => 2;
        public Number Component(Integer n) => n == 0 ? Real : n == 1 ? Imaginary : throw new System.IndexOutOfRangeException();
    }
    public readonly partial struct Integer2: Array<Integer>
    {
        public readonly Integer A;
        public readonly Integer B;
        public Integer2 WithA(Integer a) => (a, B);
        public Integer2 WithB(Integer b) => (A, b);
        public Integer2(Integer a, Integer b) => (A, B) = (a, b);
        public static Integer2 Default = new Integer2();
        public static Integer2 New(Integer a, Integer b) => new Integer2(a, b);
        public Plato.DoublePrecision.Integer2 ChangePrecision() => (A.ChangePrecision(), B.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Integer2(Integer2 self) => self.ChangePrecision();
        public static implicit operator (Integer, Integer)(Integer2 self) => (self.A, self.B);
        public static implicit operator Integer2((Integer, Integer) value) => new Integer2(value.Item1, value.Item2);
        public void Deconstruct(out Integer a, out Integer b) { a = A; b = B; }
        public override bool Equals(object obj) { if (!(obj is Integer2)) return false; var other = (Integer2)obj; return A.Equals(other.A) && B.Equals(other.B); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(A, B);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Integer2 self) => new Dynamic(self);
        public static implicit operator Integer2(Dynamic value) => value.As<Integer2>();
        public String TypeName => "Integer2";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"A", (String)"B");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(A), new Dynamic(B));
        // Unimplemented concept functions
        public Integer Count => 2;
        public Integer At(Integer n) => n == 0 ? A : n == 1 ? B : throw new System.IndexOutOfRangeException();
        public Integer this[Integer n] => At(n);
    }
    public readonly partial struct Integer3: Array<Integer>
    {
        public readonly Integer A;
        public readonly Integer B;
        public readonly Integer C;
        public Integer3 WithA(Integer a) => (a, B, C);
        public Integer3 WithB(Integer b) => (A, b, C);
        public Integer3 WithC(Integer c) => (A, B, c);
        public Integer3(Integer a, Integer b, Integer c) => (A, B, C) = (a, b, c);
        public static Integer3 Default = new Integer3();
        public static Integer3 New(Integer a, Integer b, Integer c) => new Integer3(a, b, c);
        public Plato.DoublePrecision.Integer3 ChangePrecision() => (A.ChangePrecision(), B.ChangePrecision(), C.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Integer3(Integer3 self) => self.ChangePrecision();
        public static implicit operator (Integer, Integer, Integer)(Integer3 self) => (self.A, self.B, self.C);
        public static implicit operator Integer3((Integer, Integer, Integer) value) => new Integer3(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Integer a, out Integer b, out Integer c) { a = A; b = B; c = C; }
        public override bool Equals(object obj) { if (!(obj is Integer3)) return false; var other = (Integer3)obj; return A.Equals(other.A) && B.Equals(other.B) && C.Equals(other.C); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(A, B, C);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Integer3 self) => new Dynamic(self);
        public static implicit operator Integer3(Dynamic value) => value.As<Integer3>();
        public String TypeName => "Integer3";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"A", (String)"B", (String)"C");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(A), new Dynamic(B), new Dynamic(C));
        // Unimplemented concept functions
        public Integer Count => 3;
        public Integer At(Integer n) => n == 0 ? A : n == 1 ? B : n == 2 ? C : throw new System.IndexOutOfRangeException();
        public Integer this[Integer n] => At(n);
    }
    public readonly partial struct Integer4: Array<Integer>
    {
        public readonly Integer A;
        public readonly Integer B;
        public readonly Integer C;
        public readonly Integer D;
        public Integer4 WithA(Integer a) => (a, B, C, D);
        public Integer4 WithB(Integer b) => (A, b, C, D);
        public Integer4 WithC(Integer c) => (A, B, c, D);
        public Integer4 WithD(Integer d) => (A, B, C, d);
        public Integer4(Integer a, Integer b, Integer c, Integer d) => (A, B, C, D) = (a, b, c, d);
        public static Integer4 Default = new Integer4();
        public static Integer4 New(Integer a, Integer b, Integer c, Integer d) => new Integer4(a, b, c, d);
        public Plato.DoublePrecision.Integer4 ChangePrecision() => (A.ChangePrecision(), B.ChangePrecision(), C.ChangePrecision(), D.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Integer4(Integer4 self) => self.ChangePrecision();
        public static implicit operator (Integer, Integer, Integer, Integer)(Integer4 self) => (self.A, self.B, self.C, self.D);
        public static implicit operator Integer4((Integer, Integer, Integer, Integer) value) => new Integer4(value.Item1, value.Item2, value.Item3, value.Item4);
        public void Deconstruct(out Integer a, out Integer b, out Integer c, out Integer d) { a = A; b = B; c = C; d = D; }
        public override bool Equals(object obj) { if (!(obj is Integer4)) return false; var other = (Integer4)obj; return A.Equals(other.A) && B.Equals(other.B) && C.Equals(other.C) && D.Equals(other.D); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(A, B, C, D);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Integer4 self) => new Dynamic(self);
        public static implicit operator Integer4(Dynamic value) => value.As<Integer4>();
        public String TypeName => "Integer4";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"A", (String)"B", (String)"C", (String)"D");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(A), new Dynamic(B), new Dynamic(C), new Dynamic(D));
        // Unimplemented concept functions
        public Integer Count => 4;
        public Integer At(Integer n) => n == 0 ? A : n == 1 ? B : n == 2 ? C : n == 3 ? D : throw new System.IndexOutOfRangeException();
        public Integer this[Integer n] => At(n);
    }
    public readonly partial struct Color: Coordinate<Color>
    {
        public readonly Unit R;
        public readonly Unit G;
        public readonly Unit B;
        public readonly Unit A;
        public Color WithR(Unit r) => (r, G, B, A);
        public Color WithG(Unit g) => (R, g, B, A);
        public Color WithB(Unit b) => (R, G, b, A);
        public Color WithA(Unit a) => (R, G, B, a);
        public Color(Unit r, Unit g, Unit b, Unit a) => (R, G, B, A) = (r, g, b, a);
        public static Color Default = new Color();
        public static Color New(Unit r, Unit g, Unit b, Unit a) => new Color(r, g, b, a);
        public Plato.DoublePrecision.Color ChangePrecision() => (R.ChangePrecision(), G.ChangePrecision(), B.ChangePrecision(), A.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Color(Color self) => self.ChangePrecision();
        public static implicit operator (Unit, Unit, Unit, Unit)(Color self) => (self.R, self.G, self.B, self.A);
        public static implicit operator Color((Unit, Unit, Unit, Unit) value) => new Color(value.Item1, value.Item2, value.Item3, value.Item4);
        public void Deconstruct(out Unit r, out Unit g, out Unit b, out Unit a) { r = R; g = G; b = B; a = A; }
        public override bool Equals(object obj) { if (!(obj is Color)) return false; var other = (Color)obj; return R.Equals(other.R) && G.Equals(other.G) && B.Equals(other.B) && A.Equals(other.A); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(R, G, B, A);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Color self) => new Dynamic(self);
        public static implicit operator Color(Dynamic value) => value.As<Color>();
        public String TypeName => "Color";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"R", (String)"G", (String)"B", (String)"A");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(R), new Dynamic(G), new Dynamic(B), new Dynamic(A));
        // Unimplemented concept functions
        public Boolean Equals(Color b) => (R.Equals(b.R) & G.Equals(b.G) & B.Equals(b.B) & A.Equals(b.A));
        public static Boolean operator ==(Color a, Color b) => a.Equals(b);
        public Boolean NotEquals(Color b) => (R.NotEquals(b.R) & G.NotEquals(b.G) & B.NotEquals(b.B) & A.NotEquals(b.A));
        public static Boolean operator !=(Color a, Color b) => a.NotEquals(b);
    }
    public readonly partial struct ColorLUV: Coordinate<ColorLUV>
    {
        public readonly Unit Lightness;
        public readonly Unit U;
        public readonly Unit V;
        public ColorLUV WithLightness(Unit lightness) => (lightness, U, V);
        public ColorLUV WithU(Unit u) => (Lightness, u, V);
        public ColorLUV WithV(Unit v) => (Lightness, U, v);
        public ColorLUV(Unit lightness, Unit u, Unit v) => (Lightness, U, V) = (lightness, u, v);
        public static ColorLUV Default = new ColorLUV();
        public static ColorLUV New(Unit lightness, Unit u, Unit v) => new ColorLUV(lightness, u, v);
        public Plato.DoublePrecision.ColorLUV ChangePrecision() => (Lightness.ChangePrecision(), U.ChangePrecision(), V.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.ColorLUV(ColorLUV self) => self.ChangePrecision();
        public static implicit operator (Unit, Unit, Unit)(ColorLUV self) => (self.Lightness, self.U, self.V);
        public static implicit operator ColorLUV((Unit, Unit, Unit) value) => new ColorLUV(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Unit lightness, out Unit u, out Unit v) { lightness = Lightness; u = U; v = V; }
        public override bool Equals(object obj) { if (!(obj is ColorLUV)) return false; var other = (ColorLUV)obj; return Lightness.Equals(other.Lightness) && U.Equals(other.U) && V.Equals(other.V); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Lightness, U, V);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(ColorLUV self) => new Dynamic(self);
        public static implicit operator ColorLUV(Dynamic value) => value.As<ColorLUV>();
        public String TypeName => "ColorLUV";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Lightness", (String)"U", (String)"V");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Lightness), new Dynamic(U), new Dynamic(V));
        // Unimplemented concept functions
        public Boolean Equals(ColorLUV b) => (Lightness.Equals(b.Lightness) & U.Equals(b.U) & V.Equals(b.V));
        public static Boolean operator ==(ColorLUV a, ColorLUV b) => a.Equals(b);
        public Boolean NotEquals(ColorLUV b) => (Lightness.NotEquals(b.Lightness) & U.NotEquals(b.U) & V.NotEquals(b.V));
        public static Boolean operator !=(ColorLUV a, ColorLUV b) => a.NotEquals(b);
    }
    public readonly partial struct ColorLAB: Coordinate<ColorLAB>
    {
        public readonly Unit Lightness;
        public readonly Number A;
        public readonly Number B;
        public ColorLAB WithLightness(Unit lightness) => (lightness, A, B);
        public ColorLAB WithA(Number a) => (Lightness, a, B);
        public ColorLAB WithB(Number b) => (Lightness, A, b);
        public ColorLAB(Unit lightness, Number a, Number b) => (Lightness, A, B) = (lightness, a, b);
        public static ColorLAB Default = new ColorLAB();
        public static ColorLAB New(Unit lightness, Number a, Number b) => new ColorLAB(lightness, a, b);
        public Plato.DoublePrecision.ColorLAB ChangePrecision() => (Lightness.ChangePrecision(), A.ChangePrecision(), B.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.ColorLAB(ColorLAB self) => self.ChangePrecision();
        public static implicit operator (Unit, Number, Number)(ColorLAB self) => (self.Lightness, self.A, self.B);
        public static implicit operator ColorLAB((Unit, Number, Number) value) => new ColorLAB(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Unit lightness, out Number a, out Number b) { lightness = Lightness; a = A; b = B; }
        public override bool Equals(object obj) { if (!(obj is ColorLAB)) return false; var other = (ColorLAB)obj; return Lightness.Equals(other.Lightness) && A.Equals(other.A) && B.Equals(other.B); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Lightness, A, B);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(ColorLAB self) => new Dynamic(self);
        public static implicit operator ColorLAB(Dynamic value) => value.As<ColorLAB>();
        public String TypeName => "ColorLAB";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Lightness", (String)"A", (String)"B");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Lightness), new Dynamic(A), new Dynamic(B));
        // Unimplemented concept functions
        public Boolean Equals(ColorLAB b) => (Lightness.Equals(b.Lightness) & A.Equals(b.A) & B.Equals(b.B));
        public static Boolean operator ==(ColorLAB a, ColorLAB b) => a.Equals(b);
        public Boolean NotEquals(ColorLAB b) => (Lightness.NotEquals(b.Lightness) & A.NotEquals(b.A) & B.NotEquals(b.B));
        public static Boolean operator !=(ColorLAB a, ColorLAB b) => a.NotEquals(b);
    }
    public readonly partial struct ColorLCh: Coordinate<ColorLCh>
    {
        public readonly Unit Lightness;
        public readonly PolarCoordinate ChromaHue;
        public ColorLCh WithLightness(Unit lightness) => (lightness, ChromaHue);
        public ColorLCh WithChromaHue(PolarCoordinate chromaHue) => (Lightness, chromaHue);
        public ColorLCh(Unit lightness, PolarCoordinate chromaHue) => (Lightness, ChromaHue) = (lightness, chromaHue);
        public static ColorLCh Default = new ColorLCh();
        public static ColorLCh New(Unit lightness, PolarCoordinate chromaHue) => new ColorLCh(lightness, chromaHue);
        public Plato.DoublePrecision.ColorLCh ChangePrecision() => (Lightness.ChangePrecision(), ChromaHue.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.ColorLCh(ColorLCh self) => self.ChangePrecision();
        public static implicit operator (Unit, PolarCoordinate)(ColorLCh self) => (self.Lightness, self.ChromaHue);
        public static implicit operator ColorLCh((Unit, PolarCoordinate) value) => new ColorLCh(value.Item1, value.Item2);
        public void Deconstruct(out Unit lightness, out PolarCoordinate chromaHue) { lightness = Lightness; chromaHue = ChromaHue; }
        public override bool Equals(object obj) { if (!(obj is ColorLCh)) return false; var other = (ColorLCh)obj; return Lightness.Equals(other.Lightness) && ChromaHue.Equals(other.ChromaHue); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Lightness, ChromaHue);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(ColorLCh self) => new Dynamic(self);
        public static implicit operator ColorLCh(Dynamic value) => value.As<ColorLCh>();
        public String TypeName => "ColorLCh";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Lightness", (String)"ChromaHue");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Lightness), new Dynamic(ChromaHue));
        // Unimplemented concept functions
        public Boolean Equals(ColorLCh b) => (Lightness.Equals(b.Lightness) & ChromaHue.Equals(b.ChromaHue));
        public static Boolean operator ==(ColorLCh a, ColorLCh b) => a.Equals(b);
        public Boolean NotEquals(ColorLCh b) => (Lightness.NotEquals(b.Lightness) & ChromaHue.NotEquals(b.ChromaHue));
        public static Boolean operator !=(ColorLCh a, ColorLCh b) => a.NotEquals(b);
    }
    public readonly partial struct ColorHSV: Coordinate<ColorHSV>
    {
        public readonly Angle Hue;
        public readonly Unit S;
        public readonly Unit V;
        public ColorHSV WithHue(Angle hue) => (hue, S, V);
        public ColorHSV WithS(Unit s) => (Hue, s, V);
        public ColorHSV WithV(Unit v) => (Hue, S, v);
        public ColorHSV(Angle hue, Unit s, Unit v) => (Hue, S, V) = (hue, s, v);
        public static ColorHSV Default = new ColorHSV();
        public static ColorHSV New(Angle hue, Unit s, Unit v) => new ColorHSV(hue, s, v);
        public Plato.DoublePrecision.ColorHSV ChangePrecision() => (Hue.ChangePrecision(), S.ChangePrecision(), V.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.ColorHSV(ColorHSV self) => self.ChangePrecision();
        public static implicit operator (Angle, Unit, Unit)(ColorHSV self) => (self.Hue, self.S, self.V);
        public static implicit operator ColorHSV((Angle, Unit, Unit) value) => new ColorHSV(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Angle hue, out Unit s, out Unit v) { hue = Hue; s = S; v = V; }
        public override bool Equals(object obj) { if (!(obj is ColorHSV)) return false; var other = (ColorHSV)obj; return Hue.Equals(other.Hue) && S.Equals(other.S) && V.Equals(other.V); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Hue, S, V);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(ColorHSV self) => new Dynamic(self);
        public static implicit operator ColorHSV(Dynamic value) => value.As<ColorHSV>();
        public String TypeName => "ColorHSV";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Hue", (String)"S", (String)"V");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Hue), new Dynamic(S), new Dynamic(V));
        // Unimplemented concept functions
        public Boolean Equals(ColorHSV b) => (Hue.Equals(b.Hue) & S.Equals(b.S) & V.Equals(b.V));
        public static Boolean operator ==(ColorHSV a, ColorHSV b) => a.Equals(b);
        public Boolean NotEquals(ColorHSV b) => (Hue.NotEquals(b.Hue) & S.NotEquals(b.S) & V.NotEquals(b.V));
        public static Boolean operator !=(ColorHSV a, ColorHSV b) => a.NotEquals(b);
    }
    public readonly partial struct ColorHSL: Coordinate<ColorHSL>
    {
        public readonly Angle Hue;
        public readonly Unit Saturation;
        public readonly Unit Luminance;
        public ColorHSL WithHue(Angle hue) => (hue, Saturation, Luminance);
        public ColorHSL WithSaturation(Unit saturation) => (Hue, saturation, Luminance);
        public ColorHSL WithLuminance(Unit luminance) => (Hue, Saturation, luminance);
        public ColorHSL(Angle hue, Unit saturation, Unit luminance) => (Hue, Saturation, Luminance) = (hue, saturation, luminance);
        public static ColorHSL Default = new ColorHSL();
        public static ColorHSL New(Angle hue, Unit saturation, Unit luminance) => new ColorHSL(hue, saturation, luminance);
        public Plato.DoublePrecision.ColorHSL ChangePrecision() => (Hue.ChangePrecision(), Saturation.ChangePrecision(), Luminance.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.ColorHSL(ColorHSL self) => self.ChangePrecision();
        public static implicit operator (Angle, Unit, Unit)(ColorHSL self) => (self.Hue, self.Saturation, self.Luminance);
        public static implicit operator ColorHSL((Angle, Unit, Unit) value) => new ColorHSL(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Angle hue, out Unit saturation, out Unit luminance) { hue = Hue; saturation = Saturation; luminance = Luminance; }
        public override bool Equals(object obj) { if (!(obj is ColorHSL)) return false; var other = (ColorHSL)obj; return Hue.Equals(other.Hue) && Saturation.Equals(other.Saturation) && Luminance.Equals(other.Luminance); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Hue, Saturation, Luminance);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(ColorHSL self) => new Dynamic(self);
        public static implicit operator ColorHSL(Dynamic value) => value.As<ColorHSL>();
        public String TypeName => "ColorHSL";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Hue", (String)"Saturation", (String)"Luminance");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Hue), new Dynamic(Saturation), new Dynamic(Luminance));
        // Unimplemented concept functions
        public Boolean Equals(ColorHSL b) => (Hue.Equals(b.Hue) & Saturation.Equals(b.Saturation) & Luminance.Equals(b.Luminance));
        public static Boolean operator ==(ColorHSL a, ColorHSL b) => a.Equals(b);
        public Boolean NotEquals(ColorHSL b) => (Hue.NotEquals(b.Hue) & Saturation.NotEquals(b.Saturation) & Luminance.NotEquals(b.Luminance));
        public static Boolean operator !=(ColorHSL a, ColorHSL b) => a.NotEquals(b);
    }
    public readonly partial struct ColorYCbCr: Coordinate<ColorYCbCr>
    {
        public readonly Unit Y;
        public readonly Unit Cb;
        public readonly Unit Cr;
        public ColorYCbCr WithY(Unit y) => (y, Cb, Cr);
        public ColorYCbCr WithCb(Unit cb) => (Y, cb, Cr);
        public ColorYCbCr WithCr(Unit cr) => (Y, Cb, cr);
        public ColorYCbCr(Unit y, Unit cb, Unit cr) => (Y, Cb, Cr) = (y, cb, cr);
        public static ColorYCbCr Default = new ColorYCbCr();
        public static ColorYCbCr New(Unit y, Unit cb, Unit cr) => new ColorYCbCr(y, cb, cr);
        public Plato.DoublePrecision.ColorYCbCr ChangePrecision() => (Y.ChangePrecision(), Cb.ChangePrecision(), Cr.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.ColorYCbCr(ColorYCbCr self) => self.ChangePrecision();
        public static implicit operator (Unit, Unit, Unit)(ColorYCbCr self) => (self.Y, self.Cb, self.Cr);
        public static implicit operator ColorYCbCr((Unit, Unit, Unit) value) => new ColorYCbCr(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Unit y, out Unit cb, out Unit cr) { y = Y; cb = Cb; cr = Cr; }
        public override bool Equals(object obj) { if (!(obj is ColorYCbCr)) return false; var other = (ColorYCbCr)obj; return Y.Equals(other.Y) && Cb.Equals(other.Cb) && Cr.Equals(other.Cr); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Y, Cb, Cr);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(ColorYCbCr self) => new Dynamic(self);
        public static implicit operator ColorYCbCr(Dynamic value) => value.As<ColorYCbCr>();
        public String TypeName => "ColorYCbCr";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Y", (String)"Cb", (String)"Cr");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Y), new Dynamic(Cb), new Dynamic(Cr));
        // Unimplemented concept functions
        public Boolean Equals(ColorYCbCr b) => (Y.Equals(b.Y) & Cb.Equals(b.Cb) & Cr.Equals(b.Cr));
        public static Boolean operator ==(ColorYCbCr a, ColorYCbCr b) => a.Equals(b);
        public Boolean NotEquals(ColorYCbCr b) => (Y.NotEquals(b.Y) & Cb.NotEquals(b.Cb) & Cr.NotEquals(b.Cr));
        public static Boolean operator !=(ColorYCbCr a, ColorYCbCr b) => a.NotEquals(b);
    }
    public readonly partial struct SphericalCoordinate: Coordinate<SphericalCoordinate>
    {
        public readonly Number Radius;
        public readonly Angle Azimuth;
        public readonly Angle Polar;
        public SphericalCoordinate WithRadius(Number radius) => (radius, Azimuth, Polar);
        public SphericalCoordinate WithAzimuth(Angle azimuth) => (Radius, azimuth, Polar);
        public SphericalCoordinate WithPolar(Angle polar) => (Radius, Azimuth, polar);
        public SphericalCoordinate(Number radius, Angle azimuth, Angle polar) => (Radius, Azimuth, Polar) = (radius, azimuth, polar);
        public static SphericalCoordinate Default = new SphericalCoordinate();
        public static SphericalCoordinate New(Number radius, Angle azimuth, Angle polar) => new SphericalCoordinate(radius, azimuth, polar);
        public Plato.DoublePrecision.SphericalCoordinate ChangePrecision() => (Radius.ChangePrecision(), Azimuth.ChangePrecision(), Polar.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.SphericalCoordinate(SphericalCoordinate self) => self.ChangePrecision();
        public static implicit operator (Number, Angle, Angle)(SphericalCoordinate self) => (self.Radius, self.Azimuth, self.Polar);
        public static implicit operator SphericalCoordinate((Number, Angle, Angle) value) => new SphericalCoordinate(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Number radius, out Angle azimuth, out Angle polar) { radius = Radius; azimuth = Azimuth; polar = Polar; }
        public override bool Equals(object obj) { if (!(obj is SphericalCoordinate)) return false; var other = (SphericalCoordinate)obj; return Radius.Equals(other.Radius) && Azimuth.Equals(other.Azimuth) && Polar.Equals(other.Polar); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Radius, Azimuth, Polar);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(SphericalCoordinate self) => new Dynamic(self);
        public static implicit operator SphericalCoordinate(Dynamic value) => value.As<SphericalCoordinate>();
        public String TypeName => "SphericalCoordinate";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Radius", (String)"Azimuth", (String)"Polar");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Radius), new Dynamic(Azimuth), new Dynamic(Polar));
        // Unimplemented concept functions
        public Boolean Equals(SphericalCoordinate b) => (Radius.Equals(b.Radius) & Azimuth.Equals(b.Azimuth) & Polar.Equals(b.Polar));
        public static Boolean operator ==(SphericalCoordinate a, SphericalCoordinate b) => a.Equals(b);
        public Boolean NotEquals(SphericalCoordinate b) => (Radius.NotEquals(b.Radius) & Azimuth.NotEquals(b.Azimuth) & Polar.NotEquals(b.Polar));
        public static Boolean operator !=(SphericalCoordinate a, SphericalCoordinate b) => a.NotEquals(b);
    }
    public readonly partial struct PolarCoordinate: Coordinate<PolarCoordinate>
    {
        public readonly Number Radius;
        public readonly Angle Angle;
        public PolarCoordinate WithRadius(Number radius) => (radius, Angle);
        public PolarCoordinate WithAngle(Angle angle) => (Radius, angle);
        public PolarCoordinate(Number radius, Angle angle) => (Radius, Angle) = (radius, angle);
        public static PolarCoordinate Default = new PolarCoordinate();
        public static PolarCoordinate New(Number radius, Angle angle) => new PolarCoordinate(radius, angle);
        public Plato.DoublePrecision.PolarCoordinate ChangePrecision() => (Radius.ChangePrecision(), Angle.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.PolarCoordinate(PolarCoordinate self) => self.ChangePrecision();
        public static implicit operator (Number, Angle)(PolarCoordinate self) => (self.Radius, self.Angle);
        public static implicit operator PolarCoordinate((Number, Angle) value) => new PolarCoordinate(value.Item1, value.Item2);
        public void Deconstruct(out Number radius, out Angle angle) { radius = Radius; angle = Angle; }
        public override bool Equals(object obj) { if (!(obj is PolarCoordinate)) return false; var other = (PolarCoordinate)obj; return Radius.Equals(other.Radius) && Angle.Equals(other.Angle); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Radius, Angle);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(PolarCoordinate self) => new Dynamic(self);
        public static implicit operator PolarCoordinate(Dynamic value) => value.As<PolarCoordinate>();
        public String TypeName => "PolarCoordinate";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Radius", (String)"Angle");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Radius), new Dynamic(Angle));
        // Unimplemented concept functions
        public Boolean Equals(PolarCoordinate b) => (Radius.Equals(b.Radius) & Angle.Equals(b.Angle));
        public static Boolean operator ==(PolarCoordinate a, PolarCoordinate b) => a.Equals(b);
        public Boolean NotEquals(PolarCoordinate b) => (Radius.NotEquals(b.Radius) & Angle.NotEquals(b.Angle));
        public static Boolean operator !=(PolarCoordinate a, PolarCoordinate b) => a.NotEquals(b);
    }
    public readonly partial struct LogPolarCoordinate: Coordinate<LogPolarCoordinate>
    {
        public readonly Number Rho;
        public readonly Angle Azimuth;
        public LogPolarCoordinate WithRho(Number rho) => (rho, Azimuth);
        public LogPolarCoordinate WithAzimuth(Angle azimuth) => (Rho, azimuth);
        public LogPolarCoordinate(Number rho, Angle azimuth) => (Rho, Azimuth) = (rho, azimuth);
        public static LogPolarCoordinate Default = new LogPolarCoordinate();
        public static LogPolarCoordinate New(Number rho, Angle azimuth) => new LogPolarCoordinate(rho, azimuth);
        public Plato.DoublePrecision.LogPolarCoordinate ChangePrecision() => (Rho.ChangePrecision(), Azimuth.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.LogPolarCoordinate(LogPolarCoordinate self) => self.ChangePrecision();
        public static implicit operator (Number, Angle)(LogPolarCoordinate self) => (self.Rho, self.Azimuth);
        public static implicit operator LogPolarCoordinate((Number, Angle) value) => new LogPolarCoordinate(value.Item1, value.Item2);
        public void Deconstruct(out Number rho, out Angle azimuth) { rho = Rho; azimuth = Azimuth; }
        public override bool Equals(object obj) { if (!(obj is LogPolarCoordinate)) return false; var other = (LogPolarCoordinate)obj; return Rho.Equals(other.Rho) && Azimuth.Equals(other.Azimuth); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Rho, Azimuth);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(LogPolarCoordinate self) => new Dynamic(self);
        public static implicit operator LogPolarCoordinate(Dynamic value) => value.As<LogPolarCoordinate>();
        public String TypeName => "LogPolarCoordinate";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Rho", (String)"Azimuth");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Rho), new Dynamic(Azimuth));
        // Unimplemented concept functions
        public Boolean Equals(LogPolarCoordinate b) => (Rho.Equals(b.Rho) & Azimuth.Equals(b.Azimuth));
        public static Boolean operator ==(LogPolarCoordinate a, LogPolarCoordinate b) => a.Equals(b);
        public Boolean NotEquals(LogPolarCoordinate b) => (Rho.NotEquals(b.Rho) & Azimuth.NotEquals(b.Azimuth));
        public static Boolean operator !=(LogPolarCoordinate a, LogPolarCoordinate b) => a.NotEquals(b);
    }
    public readonly partial struct CylindricalCoordinate: Coordinate<CylindricalCoordinate>
    {
        public readonly Number RadialDistance;
        public readonly Angle Azimuth;
        public readonly Number Height;
        public CylindricalCoordinate WithRadialDistance(Number radialDistance) => (radialDistance, Azimuth, Height);
        public CylindricalCoordinate WithAzimuth(Angle azimuth) => (RadialDistance, azimuth, Height);
        public CylindricalCoordinate WithHeight(Number height) => (RadialDistance, Azimuth, height);
        public CylindricalCoordinate(Number radialDistance, Angle azimuth, Number height) => (RadialDistance, Azimuth, Height) = (radialDistance, azimuth, height);
        public static CylindricalCoordinate Default = new CylindricalCoordinate();
        public static CylindricalCoordinate New(Number radialDistance, Angle azimuth, Number height) => new CylindricalCoordinate(radialDistance, azimuth, height);
        public Plato.DoublePrecision.CylindricalCoordinate ChangePrecision() => (RadialDistance.ChangePrecision(), Azimuth.ChangePrecision(), Height.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.CylindricalCoordinate(CylindricalCoordinate self) => self.ChangePrecision();
        public static implicit operator (Number, Angle, Number)(CylindricalCoordinate self) => (self.RadialDistance, self.Azimuth, self.Height);
        public static implicit operator CylindricalCoordinate((Number, Angle, Number) value) => new CylindricalCoordinate(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Number radialDistance, out Angle azimuth, out Number height) { radialDistance = RadialDistance; azimuth = Azimuth; height = Height; }
        public override bool Equals(object obj) { if (!(obj is CylindricalCoordinate)) return false; var other = (CylindricalCoordinate)obj; return RadialDistance.Equals(other.RadialDistance) && Azimuth.Equals(other.Azimuth) && Height.Equals(other.Height); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(RadialDistance, Azimuth, Height);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(CylindricalCoordinate self) => new Dynamic(self);
        public static implicit operator CylindricalCoordinate(Dynamic value) => value.As<CylindricalCoordinate>();
        public String TypeName => "CylindricalCoordinate";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"RadialDistance", (String)"Azimuth", (String)"Height");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(RadialDistance), new Dynamic(Azimuth), new Dynamic(Height));
        // Unimplemented concept functions
        public Boolean Equals(CylindricalCoordinate b) => (RadialDistance.Equals(b.RadialDistance) & Azimuth.Equals(b.Azimuth) & Height.Equals(b.Height));
        public static Boolean operator ==(CylindricalCoordinate a, CylindricalCoordinate b) => a.Equals(b);
        public Boolean NotEquals(CylindricalCoordinate b) => (RadialDistance.NotEquals(b.RadialDistance) & Azimuth.NotEquals(b.Azimuth) & Height.NotEquals(b.Height));
        public static Boolean operator !=(CylindricalCoordinate a, CylindricalCoordinate b) => a.NotEquals(b);
    }
    public readonly partial struct HorizontalCoordinate: Coordinate<HorizontalCoordinate>
    {
        public readonly Number Radius;
        public readonly Angle Azimuth;
        public readonly Number Height;
        public HorizontalCoordinate WithRadius(Number radius) => (radius, Azimuth, Height);
        public HorizontalCoordinate WithAzimuth(Angle azimuth) => (Radius, azimuth, Height);
        public HorizontalCoordinate WithHeight(Number height) => (Radius, Azimuth, height);
        public HorizontalCoordinate(Number radius, Angle azimuth, Number height) => (Radius, Azimuth, Height) = (radius, azimuth, height);
        public static HorizontalCoordinate Default = new HorizontalCoordinate();
        public static HorizontalCoordinate New(Number radius, Angle azimuth, Number height) => new HorizontalCoordinate(radius, azimuth, height);
        public Plato.DoublePrecision.HorizontalCoordinate ChangePrecision() => (Radius.ChangePrecision(), Azimuth.ChangePrecision(), Height.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.HorizontalCoordinate(HorizontalCoordinate self) => self.ChangePrecision();
        public static implicit operator (Number, Angle, Number)(HorizontalCoordinate self) => (self.Radius, self.Azimuth, self.Height);
        public static implicit operator HorizontalCoordinate((Number, Angle, Number) value) => new HorizontalCoordinate(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Number radius, out Angle azimuth, out Number height) { radius = Radius; azimuth = Azimuth; height = Height; }
        public override bool Equals(object obj) { if (!(obj is HorizontalCoordinate)) return false; var other = (HorizontalCoordinate)obj; return Radius.Equals(other.Radius) && Azimuth.Equals(other.Azimuth) && Height.Equals(other.Height); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Radius, Azimuth, Height);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(HorizontalCoordinate self) => new Dynamic(self);
        public static implicit operator HorizontalCoordinate(Dynamic value) => value.As<HorizontalCoordinate>();
        public String TypeName => "HorizontalCoordinate";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Radius", (String)"Azimuth", (String)"Height");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Radius), new Dynamic(Azimuth), new Dynamic(Height));
        // Unimplemented concept functions
        public Boolean Equals(HorizontalCoordinate b) => (Radius.Equals(b.Radius) & Azimuth.Equals(b.Azimuth) & Height.Equals(b.Height));
        public static Boolean operator ==(HorizontalCoordinate a, HorizontalCoordinate b) => a.Equals(b);
        public Boolean NotEquals(HorizontalCoordinate b) => (Radius.NotEquals(b.Radius) & Azimuth.NotEquals(b.Azimuth) & Height.NotEquals(b.Height));
        public static Boolean operator !=(HorizontalCoordinate a, HorizontalCoordinate b) => a.NotEquals(b);
    }
    public readonly partial struct GeoCoordinate: Coordinate<GeoCoordinate>
    {
        public readonly Angle Latitude;
        public readonly Angle Longitude;
        public GeoCoordinate WithLatitude(Angle latitude) => (latitude, Longitude);
        public GeoCoordinate WithLongitude(Angle longitude) => (Latitude, longitude);
        public GeoCoordinate(Angle latitude, Angle longitude) => (Latitude, Longitude) = (latitude, longitude);
        public static GeoCoordinate Default = new GeoCoordinate();
        public static GeoCoordinate New(Angle latitude, Angle longitude) => new GeoCoordinate(latitude, longitude);
        public Plato.DoublePrecision.GeoCoordinate ChangePrecision() => (Latitude.ChangePrecision(), Longitude.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.GeoCoordinate(GeoCoordinate self) => self.ChangePrecision();
        public static implicit operator (Angle, Angle)(GeoCoordinate self) => (self.Latitude, self.Longitude);
        public static implicit operator GeoCoordinate((Angle, Angle) value) => new GeoCoordinate(value.Item1, value.Item2);
        public void Deconstruct(out Angle latitude, out Angle longitude) { latitude = Latitude; longitude = Longitude; }
        public override bool Equals(object obj) { if (!(obj is GeoCoordinate)) return false; var other = (GeoCoordinate)obj; return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Latitude, Longitude);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(GeoCoordinate self) => new Dynamic(self);
        public static implicit operator GeoCoordinate(Dynamic value) => value.As<GeoCoordinate>();
        public String TypeName => "GeoCoordinate";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Latitude", (String)"Longitude");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Latitude), new Dynamic(Longitude));
        // Unimplemented concept functions
        public Boolean Equals(GeoCoordinate b) => (Latitude.Equals(b.Latitude) & Longitude.Equals(b.Longitude));
        public static Boolean operator ==(GeoCoordinate a, GeoCoordinate b) => a.Equals(b);
        public Boolean NotEquals(GeoCoordinate b) => (Latitude.NotEquals(b.Latitude) & Longitude.NotEquals(b.Longitude));
        public static Boolean operator !=(GeoCoordinate a, GeoCoordinate b) => a.NotEquals(b);
    }
    public readonly partial struct GeoCoordinateWithAltitude: Coordinate<GeoCoordinateWithAltitude>
    {
        public readonly GeoCoordinate Coordinate;
        public readonly Number Altitude;
        public GeoCoordinateWithAltitude WithCoordinate(GeoCoordinate coordinate) => (coordinate, Altitude);
        public GeoCoordinateWithAltitude WithAltitude(Number altitude) => (Coordinate, altitude);
        public GeoCoordinateWithAltitude(GeoCoordinate coordinate, Number altitude) => (Coordinate, Altitude) = (coordinate, altitude);
        public static GeoCoordinateWithAltitude Default = new GeoCoordinateWithAltitude();
        public static GeoCoordinateWithAltitude New(GeoCoordinate coordinate, Number altitude) => new GeoCoordinateWithAltitude(coordinate, altitude);
        public Plato.DoublePrecision.GeoCoordinateWithAltitude ChangePrecision() => (Coordinate.ChangePrecision(), Altitude.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.GeoCoordinateWithAltitude(GeoCoordinateWithAltitude self) => self.ChangePrecision();
        public static implicit operator (GeoCoordinate, Number)(GeoCoordinateWithAltitude self) => (self.Coordinate, self.Altitude);
        public static implicit operator GeoCoordinateWithAltitude((GeoCoordinate, Number) value) => new GeoCoordinateWithAltitude(value.Item1, value.Item2);
        public void Deconstruct(out GeoCoordinate coordinate, out Number altitude) { coordinate = Coordinate; altitude = Altitude; }
        public override bool Equals(object obj) { if (!(obj is GeoCoordinateWithAltitude)) return false; var other = (GeoCoordinateWithAltitude)obj; return Coordinate.Equals(other.Coordinate) && Altitude.Equals(other.Altitude); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Coordinate, Altitude);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(GeoCoordinateWithAltitude self) => new Dynamic(self);
        public static implicit operator GeoCoordinateWithAltitude(Dynamic value) => value.As<GeoCoordinateWithAltitude>();
        public String TypeName => "GeoCoordinateWithAltitude";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Coordinate", (String)"Altitude");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Coordinate), new Dynamic(Altitude));
        // Unimplemented concept functions
        public Boolean Equals(GeoCoordinateWithAltitude b) => (Coordinate.Equals(b.Coordinate) & Altitude.Equals(b.Altitude));
        public static Boolean operator ==(GeoCoordinateWithAltitude a, GeoCoordinateWithAltitude b) => a.Equals(b);
        public Boolean NotEquals(GeoCoordinateWithAltitude b) => (Coordinate.NotEquals(b.Coordinate) & Altitude.NotEquals(b.Altitude));
        public static Boolean operator !=(GeoCoordinateWithAltitude a, GeoCoordinateWithAltitude b) => a.NotEquals(b);
    }
    public readonly partial struct Size2D: Value<Size2D>
    {
        public readonly Number Width;
        public readonly Number Height;
        public Size2D WithWidth(Number width) => (width, Height);
        public Size2D WithHeight(Number height) => (Width, height);
        public Size2D(Number width, Number height) => (Width, Height) = (width, height);
        public static Size2D Default = new Size2D();
        public static Size2D New(Number width, Number height) => new Size2D(width, height);
        public Plato.DoublePrecision.Size2D ChangePrecision() => (Width.ChangePrecision(), Height.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Size2D(Size2D self) => self.ChangePrecision();
        public static implicit operator (Number, Number)(Size2D self) => (self.Width, self.Height);
        public static implicit operator Size2D((Number, Number) value) => new Size2D(value.Item1, value.Item2);
        public void Deconstruct(out Number width, out Number height) { width = Width; height = Height; }
        public override bool Equals(object obj) { if (!(obj is Size2D)) return false; var other = (Size2D)obj; return Width.Equals(other.Width) && Height.Equals(other.Height); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Width, Height);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Size2D self) => new Dynamic(self);
        public static implicit operator Size2D(Dynamic value) => value.As<Size2D>();
        public String TypeName => "Size2D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Width", (String)"Height");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Width), new Dynamic(Height));
        // Unimplemented concept functions
        public Boolean Equals(Size2D b) => (Width.Equals(b.Width) & Height.Equals(b.Height));
        public static Boolean operator ==(Size2D a, Size2D b) => a.Equals(b);
        public Boolean NotEquals(Size2D b) => (Width.NotEquals(b.Width) & Height.NotEquals(b.Height));
        public static Boolean operator !=(Size2D a, Size2D b) => a.NotEquals(b);
    }
    public readonly partial struct Size3D: Value<Size3D>
    {
        public readonly Number Width;
        public readonly Number Height;
        public readonly Number Depth;
        public Size3D WithWidth(Number width) => (width, Height, Depth);
        public Size3D WithHeight(Number height) => (Width, height, Depth);
        public Size3D WithDepth(Number depth) => (Width, Height, depth);
        public Size3D(Number width, Number height, Number depth) => (Width, Height, Depth) = (width, height, depth);
        public static Size3D Default = new Size3D();
        public static Size3D New(Number width, Number height, Number depth) => new Size3D(width, height, depth);
        public Plato.DoublePrecision.Size3D ChangePrecision() => (Width.ChangePrecision(), Height.ChangePrecision(), Depth.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Size3D(Size3D self) => self.ChangePrecision();
        public static implicit operator (Number, Number, Number)(Size3D self) => (self.Width, self.Height, self.Depth);
        public static implicit operator Size3D((Number, Number, Number) value) => new Size3D(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Number width, out Number height, out Number depth) { width = Width; height = Height; depth = Depth; }
        public override bool Equals(object obj) { if (!(obj is Size3D)) return false; var other = (Size3D)obj; return Width.Equals(other.Width) && Height.Equals(other.Height) && Depth.Equals(other.Depth); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Width, Height, Depth);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Size3D self) => new Dynamic(self);
        public static implicit operator Size3D(Dynamic value) => value.As<Size3D>();
        public String TypeName => "Size3D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Width", (String)"Height", (String)"Depth");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Width), new Dynamic(Height), new Dynamic(Depth));
        // Unimplemented concept functions
        public Boolean Equals(Size3D b) => (Width.Equals(b.Width) & Height.Equals(b.Height) & Depth.Equals(b.Depth));
        public static Boolean operator ==(Size3D a, Size3D b) => a.Equals(b);
        public Boolean NotEquals(Size3D b) => (Width.NotEquals(b.Width) & Height.NotEquals(b.Height) & Depth.NotEquals(b.Depth));
        public static Boolean operator !=(Size3D a, Size3D b) => a.NotEquals(b);
    }
    public readonly partial struct Rational: Value<Rational>
    {
        public readonly Integer Numerator;
        public readonly Integer Denominator;
        public Rational WithNumerator(Integer numerator) => (numerator, Denominator);
        public Rational WithDenominator(Integer denominator) => (Numerator, denominator);
        public Rational(Integer numerator, Integer denominator) => (Numerator, Denominator) = (numerator, denominator);
        public static Rational Default = new Rational();
        public static Rational New(Integer numerator, Integer denominator) => new Rational(numerator, denominator);
        public Plato.DoublePrecision.Rational ChangePrecision() => (Numerator.ChangePrecision(), Denominator.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Rational(Rational self) => self.ChangePrecision();
        public static implicit operator (Integer, Integer)(Rational self) => (self.Numerator, self.Denominator);
        public static implicit operator Rational((Integer, Integer) value) => new Rational(value.Item1, value.Item2);
        public void Deconstruct(out Integer numerator, out Integer denominator) { numerator = Numerator; denominator = Denominator; }
        public override bool Equals(object obj) { if (!(obj is Rational)) return false; var other = (Rational)obj; return Numerator.Equals(other.Numerator) && Denominator.Equals(other.Denominator); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Numerator, Denominator);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Rational self) => new Dynamic(self);
        public static implicit operator Rational(Dynamic value) => value.As<Rational>();
        public String TypeName => "Rational";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Numerator", (String)"Denominator");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Numerator), new Dynamic(Denominator));
        // Unimplemented concept functions
        public Boolean Equals(Rational b) => (Numerator.Equals(b.Numerator) & Denominator.Equals(b.Denominator));
        public static Boolean operator ==(Rational a, Rational b) => a.Equals(b);
        public Boolean NotEquals(Rational b) => (Numerator.NotEquals(b.Numerator) & Denominator.NotEquals(b.Denominator));
        public static Boolean operator !=(Rational a, Rational b) => a.NotEquals(b);
    }
    public readonly partial struct Fraction: Value<Fraction>
    {
        public readonly Number Numerator;
        public readonly Number Denominator;
        public Fraction WithNumerator(Number numerator) => (numerator, Denominator);
        public Fraction WithDenominator(Number denominator) => (Numerator, denominator);
        public Fraction(Number numerator, Number denominator) => (Numerator, Denominator) = (numerator, denominator);
        public static Fraction Default = new Fraction();
        public static Fraction New(Number numerator, Number denominator) => new Fraction(numerator, denominator);
        public Plato.DoublePrecision.Fraction ChangePrecision() => (Numerator.ChangePrecision(), Denominator.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Fraction(Fraction self) => self.ChangePrecision();
        public static implicit operator (Number, Number)(Fraction self) => (self.Numerator, self.Denominator);
        public static implicit operator Fraction((Number, Number) value) => new Fraction(value.Item1, value.Item2);
        public void Deconstruct(out Number numerator, out Number denominator) { numerator = Numerator; denominator = Denominator; }
        public override bool Equals(object obj) { if (!(obj is Fraction)) return false; var other = (Fraction)obj; return Numerator.Equals(other.Numerator) && Denominator.Equals(other.Denominator); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Numerator, Denominator);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Fraction self) => new Dynamic(self);
        public static implicit operator Fraction(Dynamic value) => value.As<Fraction>();
        public String TypeName => "Fraction";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Numerator", (String)"Denominator");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Numerator), new Dynamic(Denominator));
        // Unimplemented concept functions
        public Boolean Equals(Fraction b) => (Numerator.Equals(b.Numerator) & Denominator.Equals(b.Denominator));
        public static Boolean operator ==(Fraction a, Fraction b) => a.Equals(b);
        public Boolean NotEquals(Fraction b) => (Numerator.NotEquals(b.Numerator) & Denominator.NotEquals(b.Denominator));
        public static Boolean operator !=(Fraction a, Fraction b) => a.NotEquals(b);
    }
    public readonly partial struct Angle: Measure<Angle>
    {
        public readonly Number Radians;
        public Angle WithRadians(Number radians) => (radians);
        public Angle(Number radians) => (Radians) = (radians);
        public static Angle Default = new Angle();
        public static Angle New(Number radians) => new Angle(radians);
        public Plato.DoublePrecision.Angle ChangePrecision() => (Radians.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Angle(Angle self) => self.ChangePrecision();
        public static implicit operator Number(Angle self) => self.Radians;
        public static implicit operator Angle(Number value) => new Angle(value);
        public static implicit operator Angle(Integer value) => new Angle(value);
        public override bool Equals(object obj) { if (!(obj is Angle)) return false; var other = (Angle)obj; return Radians.Equals(other.Radians); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Radians);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Angle self) => new Dynamic(self);
        public static implicit operator Angle(Dynamic value) => value.As<Angle>();
        public String TypeName => "Angle";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Radians");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Radians));
        // Unimplemented concept functions
        public Number Value => (Radians.Value);
        public Angle Add(Angle b) => (Radians.Add(b.Radians));
        public static Angle operator +(Angle a, Angle b) => a.Add(b);
        public Angle Subtract(Angle b) => (Radians.Subtract(b.Radians));
        public static Angle operator -(Angle a, Angle b) => a.Subtract(b);
        public Angle Negative => (Radians.Negative);
        public static Angle operator -(Angle self) => self.Negative;
        public Integer Compare(Angle y) => (Radians.Compare(y.Radians));
        public Angle Multiply(Number other) => (Radians.Multiply(other));
        public static Angle operator *(Angle self, Number other) => self.Multiply(other);
        public Angle Multiply(Angle self) => (Radians.Multiply(self.Radians));
        public static Angle operator *(Number other, Angle self) => other.Multiply(self);
        public Angle Divide(Number other) => (Radians.Divide(other));
        public static Angle operator /(Angle self, Number other) => self.Divide(other);
        public Angle Modulo(Number other) => (Radians.Modulo(other));
        public static Angle operator %(Angle self, Number other) => self.Modulo(other);
        public Array<Number> Components => (Radians.Components);
        public Angle FromComponents => (Radians.FromComponents);
        public Integer NumComponents => 1;
        public Number Component(Integer n) => n == 0 ? Radians : throw new System.IndexOutOfRangeException();
    }
    public readonly partial struct Length: Measure<Length>
    {
        public readonly Number Meters;
        public Length WithMeters(Number meters) => (meters);
        public Length(Number meters) => (Meters) = (meters);
        public static Length Default = new Length();
        public static Length New(Number meters) => new Length(meters);
        public Plato.DoublePrecision.Length ChangePrecision() => (Meters.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Length(Length self) => self.ChangePrecision();
        public static implicit operator Number(Length self) => self.Meters;
        public static implicit operator Length(Number value) => new Length(value);
        public static implicit operator Length(Integer value) => new Length(value);
        public override bool Equals(object obj) { if (!(obj is Length)) return false; var other = (Length)obj; return Meters.Equals(other.Meters); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Meters);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Length self) => new Dynamic(self);
        public static implicit operator Length(Dynamic value) => value.As<Length>();
        public String TypeName => "Length";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Meters");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Meters));
        // Unimplemented concept functions
        public Number Value => (Meters.Value);
        public Length Add(Length b) => (Meters.Add(b.Meters));
        public static Length operator +(Length a, Length b) => a.Add(b);
        public Length Subtract(Length b) => (Meters.Subtract(b.Meters));
        public static Length operator -(Length a, Length b) => a.Subtract(b);
        public Length Negative => (Meters.Negative);
        public static Length operator -(Length self) => self.Negative;
        public Integer Compare(Length y) => (Meters.Compare(y.Meters));
        public Length Multiply(Number other) => (Meters.Multiply(other));
        public static Length operator *(Length self, Number other) => self.Multiply(other);
        public Length Multiply(Length self) => (Meters.Multiply(self.Meters));
        public static Length operator *(Number other, Length self) => other.Multiply(self);
        public Length Divide(Number other) => (Meters.Divide(other));
        public static Length operator /(Length self, Number other) => self.Divide(other);
        public Length Modulo(Number other) => (Meters.Modulo(other));
        public static Length operator %(Length self, Number other) => self.Modulo(other);
        public Array<Number> Components => (Meters.Components);
        public Length FromComponents => (Meters.FromComponents);
        public Integer NumComponents => 1;
        public Number Component(Integer n) => n == 0 ? Meters : throw new System.IndexOutOfRangeException();
    }
    public readonly partial struct Mass: Measure<Mass>
    {
        public readonly Number Kilograms;
        public Mass WithKilograms(Number kilograms) => (kilograms);
        public Mass(Number kilograms) => (Kilograms) = (kilograms);
        public static Mass Default = new Mass();
        public static Mass New(Number kilograms) => new Mass(kilograms);
        public Plato.DoublePrecision.Mass ChangePrecision() => (Kilograms.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Mass(Mass self) => self.ChangePrecision();
        public static implicit operator Number(Mass self) => self.Kilograms;
        public static implicit operator Mass(Number value) => new Mass(value);
        public static implicit operator Mass(Integer value) => new Mass(value);
        public override bool Equals(object obj) { if (!(obj is Mass)) return false; var other = (Mass)obj; return Kilograms.Equals(other.Kilograms); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Kilograms);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Mass self) => new Dynamic(self);
        public static implicit operator Mass(Dynamic value) => value.As<Mass>();
        public String TypeName => "Mass";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Kilograms");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Kilograms));
        // Unimplemented concept functions
        public Number Value => (Kilograms.Value);
        public Mass Add(Mass b) => (Kilograms.Add(b.Kilograms));
        public static Mass operator +(Mass a, Mass b) => a.Add(b);
        public Mass Subtract(Mass b) => (Kilograms.Subtract(b.Kilograms));
        public static Mass operator -(Mass a, Mass b) => a.Subtract(b);
        public Mass Negative => (Kilograms.Negative);
        public static Mass operator -(Mass self) => self.Negative;
        public Integer Compare(Mass y) => (Kilograms.Compare(y.Kilograms));
        public Mass Multiply(Number other) => (Kilograms.Multiply(other));
        public static Mass operator *(Mass self, Number other) => self.Multiply(other);
        public Mass Multiply(Mass self) => (Kilograms.Multiply(self.Kilograms));
        public static Mass operator *(Number other, Mass self) => other.Multiply(self);
        public Mass Divide(Number other) => (Kilograms.Divide(other));
        public static Mass operator /(Mass self, Number other) => self.Divide(other);
        public Mass Modulo(Number other) => (Kilograms.Modulo(other));
        public static Mass operator %(Mass self, Number other) => self.Modulo(other);
        public Array<Number> Components => (Kilograms.Components);
        public Mass FromComponents => (Kilograms.FromComponents);
        public Integer NumComponents => 1;
        public Number Component(Integer n) => n == 0 ? Kilograms : throw new System.IndexOutOfRangeException();
    }
    public readonly partial struct Temperature: Measure<Temperature>
    {
        public readonly Number Celsius;
        public Temperature WithCelsius(Number celsius) => (celsius);
        public Temperature(Number celsius) => (Celsius) = (celsius);
        public static Temperature Default = new Temperature();
        public static Temperature New(Number celsius) => new Temperature(celsius);
        public Plato.DoublePrecision.Temperature ChangePrecision() => (Celsius.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Temperature(Temperature self) => self.ChangePrecision();
        public static implicit operator Number(Temperature self) => self.Celsius;
        public static implicit operator Temperature(Number value) => new Temperature(value);
        public static implicit operator Temperature(Integer value) => new Temperature(value);
        public override bool Equals(object obj) { if (!(obj is Temperature)) return false; var other = (Temperature)obj; return Celsius.Equals(other.Celsius); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Celsius);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Temperature self) => new Dynamic(self);
        public static implicit operator Temperature(Dynamic value) => value.As<Temperature>();
        public String TypeName => "Temperature";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Celsius");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Celsius));
        // Unimplemented concept functions
        public Number Value => (Celsius.Value);
        public Temperature Add(Temperature b) => (Celsius.Add(b.Celsius));
        public static Temperature operator +(Temperature a, Temperature b) => a.Add(b);
        public Temperature Subtract(Temperature b) => (Celsius.Subtract(b.Celsius));
        public static Temperature operator -(Temperature a, Temperature b) => a.Subtract(b);
        public Temperature Negative => (Celsius.Negative);
        public static Temperature operator -(Temperature self) => self.Negative;
        public Integer Compare(Temperature y) => (Celsius.Compare(y.Celsius));
        public Temperature Multiply(Number other) => (Celsius.Multiply(other));
        public static Temperature operator *(Temperature self, Number other) => self.Multiply(other);
        public Temperature Multiply(Temperature self) => (Celsius.Multiply(self.Celsius));
        public static Temperature operator *(Number other, Temperature self) => other.Multiply(self);
        public Temperature Divide(Number other) => (Celsius.Divide(other));
        public static Temperature operator /(Temperature self, Number other) => self.Divide(other);
        public Temperature Modulo(Number other) => (Celsius.Modulo(other));
        public static Temperature operator %(Temperature self, Number other) => self.Modulo(other);
        public Array<Number> Components => (Celsius.Components);
        public Temperature FromComponents => (Celsius.FromComponents);
        public Integer NumComponents => 1;
        public Number Component(Integer n) => n == 0 ? Celsius : throw new System.IndexOutOfRangeException();
    }
    public readonly partial struct Time: Measure<Time>
    {
        public readonly Number Seconds;
        public Time WithSeconds(Number seconds) => (seconds);
        public Time(Number seconds) => (Seconds) = (seconds);
        public static Time Default = new Time();
        public static Time New(Number seconds) => new Time(seconds);
        public Plato.DoublePrecision.Time ChangePrecision() => (Seconds.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Time(Time self) => self.ChangePrecision();
        public static implicit operator Number(Time self) => self.Seconds;
        public static implicit operator Time(Number value) => new Time(value);
        public static implicit operator Time(Integer value) => new Time(value);
        public override bool Equals(object obj) { if (!(obj is Time)) return false; var other = (Time)obj; return Seconds.Equals(other.Seconds); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Seconds);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Time self) => new Dynamic(self);
        public static implicit operator Time(Dynamic value) => value.As<Time>();
        public String TypeName => "Time";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Seconds");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Seconds));
        // Unimplemented concept functions
        public Number Value => (Seconds.Value);
        public Time Add(Time b) => (Seconds.Add(b.Seconds));
        public static Time operator +(Time a, Time b) => a.Add(b);
        public Time Subtract(Time b) => (Seconds.Subtract(b.Seconds));
        public static Time operator -(Time a, Time b) => a.Subtract(b);
        public Time Negative => (Seconds.Negative);
        public static Time operator -(Time self) => self.Negative;
        public Integer Compare(Time y) => (Seconds.Compare(y.Seconds));
        public Time Multiply(Number other) => (Seconds.Multiply(other));
        public static Time operator *(Time self, Number other) => self.Multiply(other);
        public Time Multiply(Time self) => (Seconds.Multiply(self.Seconds));
        public static Time operator *(Number other, Time self) => other.Multiply(self);
        public Time Divide(Number other) => (Seconds.Divide(other));
        public static Time operator /(Time self, Number other) => self.Divide(other);
        public Time Modulo(Number other) => (Seconds.Modulo(other));
        public static Time operator %(Time self, Number other) => self.Modulo(other);
        public Array<Number> Components => (Seconds.Components);
        public Time FromComponents => (Seconds.FromComponents);
        public Integer NumComponents => 1;
        public Number Component(Integer n) => n == 0 ? Seconds : throw new System.IndexOutOfRangeException();
    }
    public readonly partial struct DateTime: Coordinate<DateTime>
    {
        public readonly Number Value;
        public DateTime WithValue(Number value) => (value);
        public DateTime(Number value) => (Value) = (value);
        public static DateTime Default = new DateTime();
        public static DateTime New(Number value) => new DateTime(value);
        public Plato.DoublePrecision.DateTime ChangePrecision() => (Value.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.DateTime(DateTime self) => self.ChangePrecision();
        public static implicit operator Number(DateTime self) => self.Value;
        public static implicit operator DateTime(Number value) => new DateTime(value);
        public static implicit operator DateTime(Integer value) => new DateTime(value);
        public override bool Equals(object obj) { if (!(obj is DateTime)) return false; var other = (DateTime)obj; return Value.Equals(other.Value); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Value);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(DateTime self) => new Dynamic(self);
        public static implicit operator DateTime(Dynamic value) => value.As<DateTime>();
        public String TypeName => "DateTime";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Value");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Value));
        // Unimplemented concept functions
        public Boolean Equals(DateTime b) => (Value.Equals(b.Value));
        public static Boolean operator ==(DateTime a, DateTime b) => a.Equals(b);
        public Boolean NotEquals(DateTime b) => (Value.NotEquals(b.Value));
        public static Boolean operator !=(DateTime a, DateTime b) => a.NotEquals(b);
    }
    public readonly partial struct AnglePair: Interval<AnglePair, Angle>
    {
        public readonly Angle Min;
        public readonly Angle Max;
        public AnglePair WithMin(Angle min) => (min, Max);
        public AnglePair WithMax(Angle max) => (Min, max);
        public AnglePair(Angle min, Angle max) => (Min, Max) = (min, max);
        public static AnglePair Default = new AnglePair();
        public static AnglePair New(Angle min, Angle max) => new AnglePair(min, max);
        public Plato.DoublePrecision.AnglePair ChangePrecision() => (Min.ChangePrecision(), Max.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.AnglePair(AnglePair self) => self.ChangePrecision();
        public static implicit operator (Angle, Angle)(AnglePair self) => (self.Min, self.Max);
        public static implicit operator AnglePair((Angle, Angle) value) => new AnglePair(value.Item1, value.Item2);
        public void Deconstruct(out Angle min, out Angle max) { min = Min; max = Max; }
        public override bool Equals(object obj) { if (!(obj is AnglePair)) return false; var other = (AnglePair)obj; return Min.Equals(other.Min) && Max.Equals(other.Max); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Min, Max);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(AnglePair self) => new Dynamic(self);
        public static implicit operator AnglePair(Dynamic value) => value.As<AnglePair>();
        public String TypeName => "AnglePair";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Min", (String)"Max");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Min), new Dynamic(Max));
        Angle Interval<AnglePair, Angle>.Min => Min;
        Angle Interval<AnglePair, Angle>.Max => Max;
        // Unimplemented concept functions
        public Boolean Equals(AnglePair b) => (Min.Equals(b.Min) & Max.Equals(b.Max));
        public static Boolean operator ==(AnglePair a, AnglePair b) => a.Equals(b);
        public Boolean NotEquals(AnglePair b) => (Min.NotEquals(b.Min) & Max.NotEquals(b.Max));
        public static Boolean operator !=(AnglePair a, AnglePair b) => a.NotEquals(b);
    }
    public readonly partial struct NumberInterval: Interval<NumberInterval, Number>
    {
        public readonly Number Min;
        public readonly Number Max;
        public NumberInterval WithMin(Number min) => (min, Max);
        public NumberInterval WithMax(Number max) => (Min, max);
        public NumberInterval(Number min, Number max) => (Min, Max) = (min, max);
        public static NumberInterval Default = new NumberInterval();
        public static NumberInterval New(Number min, Number max) => new NumberInterval(min, max);
        public Plato.DoublePrecision.NumberInterval ChangePrecision() => (Min.ChangePrecision(), Max.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.NumberInterval(NumberInterval self) => self.ChangePrecision();
        public static implicit operator (Number, Number)(NumberInterval self) => (self.Min, self.Max);
        public static implicit operator NumberInterval((Number, Number) value) => new NumberInterval(value.Item1, value.Item2);
        public void Deconstruct(out Number min, out Number max) { min = Min; max = Max; }
        public override bool Equals(object obj) { if (!(obj is NumberInterval)) return false; var other = (NumberInterval)obj; return Min.Equals(other.Min) && Max.Equals(other.Max); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Min, Max);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(NumberInterval self) => new Dynamic(self);
        public static implicit operator NumberInterval(Dynamic value) => value.As<NumberInterval>();
        public String TypeName => "NumberInterval";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Min", (String)"Max");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Min), new Dynamic(Max));
        Number Interval<NumberInterval, Number>.Min => Min;
        Number Interval<NumberInterval, Number>.Max => Max;
        // Unimplemented concept functions
        public Boolean Equals(NumberInterval b) => (Min.Equals(b.Min) & Max.Equals(b.Max));
        public static Boolean operator ==(NumberInterval a, NumberInterval b) => a.Equals(b);
        public Boolean NotEquals(NumberInterval b) => (Min.NotEquals(b.Min) & Max.NotEquals(b.Max));
        public static Boolean operator !=(NumberInterval a, NumberInterval b) => a.NotEquals(b);
    }
    public readonly partial struct Vector2D: Vector<Vector2D>
    {
        public readonly Number X;
        public readonly Number Y;
        public Vector2D WithX(Number x) => (x, Y);
        public Vector2D WithY(Number y) => (X, y);
        public Vector2D(Number x, Number y) => (X, Y) = (x, y);
        public static Vector2D Default = new Vector2D();
        public static Vector2D New(Number x, Number y) => new Vector2D(x, y);
        public Plato.DoublePrecision.Vector2D ChangePrecision() => (X.ChangePrecision(), Y.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Vector2D(Vector2D self) => self.ChangePrecision();
        public static implicit operator (Number, Number)(Vector2D self) => (self.X, self.Y);
        public static implicit operator Vector2D((Number, Number) value) => new Vector2D(value.Item1, value.Item2);
        public void Deconstruct(out Number x, out Number y) { x = X; y = Y; }
        public override bool Equals(object obj) { if (!(obj is Vector2D)) return false; var other = (Vector2D)obj; return X.Equals(other.X) && Y.Equals(other.Y); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(X, Y);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Vector2D self) => new Dynamic(self);
        public static implicit operator Vector2D(Dynamic value) => value.As<Vector2D>();
        public String TypeName => "Vector2D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"X", (String)"Y");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(X), new Dynamic(Y));
        // Unimplemented concept functions
        public Vector2D Add(Vector2D b) => (X.Add(b.X), Y.Add(b.Y));
        public static Vector2D operator +(Vector2D a, Vector2D b) => a.Add(b);
        public Vector2D Subtract(Vector2D b) => (X.Subtract(b.X), Y.Subtract(b.Y));
        public static Vector2D operator -(Vector2D a, Vector2D b) => a.Subtract(b);
        public Vector2D Multiply(Vector2D b) => (X.Multiply(b.X), Y.Multiply(b.Y));
        public static Vector2D operator *(Vector2D a, Vector2D b) => a.Multiply(b);
        public Vector2D Divide(Vector2D b) => (X.Divide(b.X), Y.Divide(b.Y));
        public static Vector2D operator /(Vector2D a, Vector2D b) => a.Divide(b);
        public Vector2D Modulo(Vector2D b) => (X.Modulo(b.X), Y.Modulo(b.Y));
        public static Vector2D operator %(Vector2D a, Vector2D b) => a.Modulo(b);
        public Vector2D Reciprocal => (X.Reciprocal, Y.Reciprocal);
        public Vector2D Negative => (X.Negative, Y.Negative);
        public static Vector2D operator -(Vector2D self) => self.Negative;
        public Vector2D Multiply(Number other) => (X.Multiply(other), Y.Multiply(other));
        public static Vector2D operator *(Vector2D self, Number other) => self.Multiply(other);
        public Vector2D Multiply(Vector2D self) => (X.Multiply(self.X), Y.Multiply(self.Y));
        public static Vector2D operator *(Number other, Vector2D self) => other.Multiply(self);
        public Vector2D Divide(Number other) => (X.Divide(other), Y.Divide(other));
        public static Vector2D operator /(Vector2D self, Number other) => self.Divide(other);
        public Vector2D Modulo(Number other) => (X.Modulo(other), Y.Modulo(other));
        public static Vector2D operator %(Vector2D self, Number other) => self.Modulo(other);
        public Array<Number> Components => throw new NotImplementedException();
        public Vector2D FromComponents => (X.FromComponents, Y.FromComponents);
        public Boolean Equals(Vector2D b) => (X.Equals(b.X) & Y.Equals(b.Y));
        public static Boolean operator ==(Vector2D a, Vector2D b) => a.Equals(b);
        public Boolean NotEquals(Vector2D b) => (X.NotEquals(b.X) & Y.NotEquals(b.Y));
        public static Boolean operator !=(Vector2D a, Vector2D b) => a.NotEquals(b);
        public Integer NumComponents => 2;
        public Number Component(Integer n) => n == 0 ? X : n == 1 ? Y : throw new System.IndexOutOfRangeException();
    }
    public readonly partial struct Vector3D: Vector<Vector3D>
    {
        public readonly Number X;
        public readonly Number Y;
        public readonly Number Z;
        public Vector3D WithX(Number x) => (x, Y, Z);
        public Vector3D WithY(Number y) => (X, y, Z);
        public Vector3D WithZ(Number z) => (X, Y, z);
        public Vector3D(Number x, Number y, Number z) => (X, Y, Z) = (x, y, z);
        public static Vector3D Default = new Vector3D();
        public static Vector3D New(Number x, Number y, Number z) => new Vector3D(x, y, z);
        public Plato.DoublePrecision.Vector3D ChangePrecision() => (X.ChangePrecision(), Y.ChangePrecision(), Z.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Vector3D(Vector3D self) => self.ChangePrecision();
        public static implicit operator (Number, Number, Number)(Vector3D self) => (self.X, self.Y, self.Z);
        public static implicit operator Vector3D((Number, Number, Number) value) => new Vector3D(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Number x, out Number y, out Number z) { x = X; y = Y; z = Z; }
        public override bool Equals(object obj) { if (!(obj is Vector3D)) return false; var other = (Vector3D)obj; return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(X, Y, Z);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Vector3D self) => new Dynamic(self);
        public static implicit operator Vector3D(Dynamic value) => value.As<Vector3D>();
        public String TypeName => "Vector3D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"X", (String)"Y", (String)"Z");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(X), new Dynamic(Y), new Dynamic(Z));
        // Unimplemented concept functions
        public Vector3D Add(Vector3D b) => (X.Add(b.X), Y.Add(b.Y), Z.Add(b.Z));
        public static Vector3D operator +(Vector3D a, Vector3D b) => a.Add(b);
        public Vector3D Subtract(Vector3D b) => (X.Subtract(b.X), Y.Subtract(b.Y), Z.Subtract(b.Z));
        public static Vector3D operator -(Vector3D a, Vector3D b) => a.Subtract(b);
        public Vector3D Multiply(Vector3D b) => (X.Multiply(b.X), Y.Multiply(b.Y), Z.Multiply(b.Z));
        public static Vector3D operator *(Vector3D a, Vector3D b) => a.Multiply(b);
        public Vector3D Divide(Vector3D b) => (X.Divide(b.X), Y.Divide(b.Y), Z.Divide(b.Z));
        public static Vector3D operator /(Vector3D a, Vector3D b) => a.Divide(b);
        public Vector3D Modulo(Vector3D b) => (X.Modulo(b.X), Y.Modulo(b.Y), Z.Modulo(b.Z));
        public static Vector3D operator %(Vector3D a, Vector3D b) => a.Modulo(b);
        public Vector3D Reciprocal => (X.Reciprocal, Y.Reciprocal, Z.Reciprocal);
        public Vector3D Negative => (X.Negative, Y.Negative, Z.Negative);
        public static Vector3D operator -(Vector3D self) => self.Negative;
        public Vector3D Multiply(Number other) => (X.Multiply(other), Y.Multiply(other), Z.Multiply(other));
        public static Vector3D operator *(Vector3D self, Number other) => self.Multiply(other);
        public Vector3D Multiply(Vector3D self) => (X.Multiply(self.X), Y.Multiply(self.Y), Z.Multiply(self.Z));
        public static Vector3D operator *(Number other, Vector3D self) => other.Multiply(self);
        public Vector3D Divide(Number other) => (X.Divide(other), Y.Divide(other), Z.Divide(other));
        public static Vector3D operator /(Vector3D self, Number other) => self.Divide(other);
        public Vector3D Modulo(Number other) => (X.Modulo(other), Y.Modulo(other), Z.Modulo(other));
        public static Vector3D operator %(Vector3D self, Number other) => self.Modulo(other);
        public Array<Number> Components => throw new NotImplementedException();
        public Vector3D FromComponents => (X.FromComponents, Y.FromComponents, Z.FromComponents);
        public Boolean Equals(Vector3D b) => (X.Equals(b.X) & Y.Equals(b.Y) & Z.Equals(b.Z));
        public static Boolean operator ==(Vector3D a, Vector3D b) => a.Equals(b);
        public Boolean NotEquals(Vector3D b) => (X.NotEquals(b.X) & Y.NotEquals(b.Y) & Z.NotEquals(b.Z));
        public static Boolean operator !=(Vector3D a, Vector3D b) => a.NotEquals(b);
        public Integer NumComponents => 3;
        public Number Component(Integer n) => n == 0 ? X : n == 1 ? Y : n == 2 ? Z : throw new System.IndexOutOfRangeException();
    }
    public readonly partial struct Vector4D: Vector<Vector4D>
    {
        public readonly Number X;
        public readonly Number Y;
        public readonly Number Z;
        public readonly Number W;
        public Vector4D WithX(Number x) => (x, Y, Z, W);
        public Vector4D WithY(Number y) => (X, y, Z, W);
        public Vector4D WithZ(Number z) => (X, Y, z, W);
        public Vector4D WithW(Number w) => (X, Y, Z, w);
        public Vector4D(Number x, Number y, Number z, Number w) => (X, Y, Z, W) = (x, y, z, w);
        public static Vector4D Default = new Vector4D();
        public static Vector4D New(Number x, Number y, Number z, Number w) => new Vector4D(x, y, z, w);
        public Plato.DoublePrecision.Vector4D ChangePrecision() => (X.ChangePrecision(), Y.ChangePrecision(), Z.ChangePrecision(), W.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Vector4D(Vector4D self) => self.ChangePrecision();
        public static implicit operator (Number, Number, Number, Number)(Vector4D self) => (self.X, self.Y, self.Z, self.W);
        public static implicit operator Vector4D((Number, Number, Number, Number) value) => new Vector4D(value.Item1, value.Item2, value.Item3, value.Item4);
        public void Deconstruct(out Number x, out Number y, out Number z, out Number w) { x = X; y = Y; z = Z; w = W; }
        public override bool Equals(object obj) { if (!(obj is Vector4D)) return false; var other = (Vector4D)obj; return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(X, Y, Z, W);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Vector4D self) => new Dynamic(self);
        public static implicit operator Vector4D(Dynamic value) => value.As<Vector4D>();
        public String TypeName => "Vector4D";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"X", (String)"Y", (String)"Z", (String)"W");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(X), new Dynamic(Y), new Dynamic(Z), new Dynamic(W));
        // Unimplemented concept functions
        public Vector4D Add(Vector4D b) => (X.Add(b.X), Y.Add(b.Y), Z.Add(b.Z), W.Add(b.W));
        public static Vector4D operator +(Vector4D a, Vector4D b) => a.Add(b);
        public Vector4D Subtract(Vector4D b) => (X.Subtract(b.X), Y.Subtract(b.Y), Z.Subtract(b.Z), W.Subtract(b.W));
        public static Vector4D operator -(Vector4D a, Vector4D b) => a.Subtract(b);
        public Vector4D Multiply(Vector4D b) => (X.Multiply(b.X), Y.Multiply(b.Y), Z.Multiply(b.Z), W.Multiply(b.W));
        public static Vector4D operator *(Vector4D a, Vector4D b) => a.Multiply(b);
        public Vector4D Divide(Vector4D b) => (X.Divide(b.X), Y.Divide(b.Y), Z.Divide(b.Z), W.Divide(b.W));
        public static Vector4D operator /(Vector4D a, Vector4D b) => a.Divide(b);
        public Vector4D Modulo(Vector4D b) => (X.Modulo(b.X), Y.Modulo(b.Y), Z.Modulo(b.Z), W.Modulo(b.W));
        public static Vector4D operator %(Vector4D a, Vector4D b) => a.Modulo(b);
        public Vector4D Reciprocal => (X.Reciprocal, Y.Reciprocal, Z.Reciprocal, W.Reciprocal);
        public Vector4D Negative => (X.Negative, Y.Negative, Z.Negative, W.Negative);
        public static Vector4D operator -(Vector4D self) => self.Negative;
        public Vector4D Multiply(Number other) => (X.Multiply(other), Y.Multiply(other), Z.Multiply(other), W.Multiply(other));
        public static Vector4D operator *(Vector4D self, Number other) => self.Multiply(other);
        public Vector4D Multiply(Vector4D self) => (X.Multiply(self.X), Y.Multiply(self.Y), Z.Multiply(self.Z), W.Multiply(self.W));
        public static Vector4D operator *(Number other, Vector4D self) => other.Multiply(self);
        public Vector4D Divide(Number other) => (X.Divide(other), Y.Divide(other), Z.Divide(other), W.Divide(other));
        public static Vector4D operator /(Vector4D self, Number other) => self.Divide(other);
        public Vector4D Modulo(Number other) => (X.Modulo(other), Y.Modulo(other), Z.Modulo(other), W.Modulo(other));
        public static Vector4D operator %(Vector4D self, Number other) => self.Modulo(other);
        public Array<Number> Components => throw new NotImplementedException();
        public Vector4D FromComponents => (X.FromComponents, Y.FromComponents, Z.FromComponents, W.FromComponents);
        public Boolean Equals(Vector4D b) => (X.Equals(b.X) & Y.Equals(b.Y) & Z.Equals(b.Z) & W.Equals(b.W));
        public static Boolean operator ==(Vector4D a, Vector4D b) => a.Equals(b);
        public Boolean NotEquals(Vector4D b) => (X.NotEquals(b.X) & Y.NotEquals(b.Y) & Z.NotEquals(b.Z) & W.NotEquals(b.W));
        public static Boolean operator !=(Vector4D a, Vector4D b) => a.NotEquals(b);
        public Integer NumComponents => 4;
        public Number Component(Integer n) => n == 0 ? X : n == 1 ? Y : n == 2 ? Z : n == 3 ? W : throw new System.IndexOutOfRangeException();
    }
    public readonly partial struct Matrix3x3: Value<Matrix3x3>, Array<Vector3D>
    {
        public readonly Vector3D Column1;
        public readonly Vector3D Column2;
        public readonly Vector3D Column3;
        public Matrix3x3 WithColumn1(Vector3D column1) => (column1, Column2, Column3);
        public Matrix3x3 WithColumn2(Vector3D column2) => (Column1, column2, Column3);
        public Matrix3x3 WithColumn3(Vector3D column3) => (Column1, Column2, column3);
        public Matrix3x3(Vector3D column1, Vector3D column2, Vector3D column3) => (Column1, Column2, Column3) = (column1, column2, column3);
        public static Matrix3x3 Default = new Matrix3x3();
        public static Matrix3x3 New(Vector3D column1, Vector3D column2, Vector3D column3) => new Matrix3x3(column1, column2, column3);
        public Plato.DoublePrecision.Matrix3x3 ChangePrecision() => (Column1.ChangePrecision(), Column2.ChangePrecision(), Column3.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Matrix3x3(Matrix3x3 self) => self.ChangePrecision();
        public static implicit operator (Vector3D, Vector3D, Vector3D)(Matrix3x3 self) => (self.Column1, self.Column2, self.Column3);
        public static implicit operator Matrix3x3((Vector3D, Vector3D, Vector3D) value) => new Matrix3x3(value.Item1, value.Item2, value.Item3);
        public void Deconstruct(out Vector3D column1, out Vector3D column2, out Vector3D column3) { column1 = Column1; column2 = Column2; column3 = Column3; }
        public override bool Equals(object obj) { if (!(obj is Matrix3x3)) return false; var other = (Matrix3x3)obj; return Column1.Equals(other.Column1) && Column2.Equals(other.Column2) && Column3.Equals(other.Column3); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Column1, Column2, Column3);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Matrix3x3 self) => new Dynamic(self);
        public static implicit operator Matrix3x3(Dynamic value) => value.As<Matrix3x3>();
        public String TypeName => "Matrix3x3";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Column1", (String)"Column2", (String)"Column3");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Column1), new Dynamic(Column2), new Dynamic(Column3));
        // Unimplemented concept functions
        public Boolean Equals(Matrix3x3 b) => (Column1.Equals(b.Column1) & Column2.Equals(b.Column2) & Column3.Equals(b.Column3));
        public static Boolean operator ==(Matrix3x3 a, Matrix3x3 b) => a.Equals(b);
        public Boolean NotEquals(Matrix3x3 b) => (Column1.NotEquals(b.Column1) & Column2.NotEquals(b.Column2) & Column3.NotEquals(b.Column3));
        public static Boolean operator !=(Matrix3x3 a, Matrix3x3 b) => a.NotEquals(b);
        public Integer Count => 3;
        public Vector3D At(Integer n) => n == 0 ? Column1 : n == 1 ? Column2 : n == 2 ? Column3 : throw new System.IndexOutOfRangeException();
        public Vector3D this[Integer n] => At(n);
    }
    public readonly partial struct Matrix4x4: Value<Matrix4x4>, Array<Vector4D>
    {
        public readonly Vector4D Column1;
        public readonly Vector4D Column2;
        public readonly Vector4D Column3;
        public readonly Vector4D Column4;
        public Matrix4x4 WithColumn1(Vector4D column1) => (column1, Column2, Column3, Column4);
        public Matrix4x4 WithColumn2(Vector4D column2) => (Column1, column2, Column3, Column4);
        public Matrix4x4 WithColumn3(Vector4D column3) => (Column1, Column2, column3, Column4);
        public Matrix4x4 WithColumn4(Vector4D column4) => (Column1, Column2, Column3, column4);
        public Matrix4x4(Vector4D column1, Vector4D column2, Vector4D column3, Vector4D column4) => (Column1, Column2, Column3, Column4) = (column1, column2, column3, column4);
        public static Matrix4x4 Default = new Matrix4x4();
        public static Matrix4x4 New(Vector4D column1, Vector4D column2, Vector4D column3, Vector4D column4) => new Matrix4x4(column1, column2, column3, column4);
        public Plato.DoublePrecision.Matrix4x4 ChangePrecision() => (Column1.ChangePrecision(), Column2.ChangePrecision(), Column3.ChangePrecision(), Column4.ChangePrecision());
        public static implicit operator Plato.DoublePrecision.Matrix4x4(Matrix4x4 self) => self.ChangePrecision();
        public static implicit operator (Vector4D, Vector4D, Vector4D, Vector4D)(Matrix4x4 self) => (self.Column1, self.Column2, self.Column3, self.Column4);
        public static implicit operator Matrix4x4((Vector4D, Vector4D, Vector4D, Vector4D) value) => new Matrix4x4(value.Item1, value.Item2, value.Item3, value.Item4);
        public void Deconstruct(out Vector4D column1, out Vector4D column2, out Vector4D column3, out Vector4D column4) { column1 = Column1; column2 = Column2; column3 = Column3; column4 = Column4; }
        public override bool Equals(object obj) { if (!(obj is Matrix4x4)) return false; var other = (Matrix4x4)obj; return Column1.Equals(other.Column1) && Column2.Equals(other.Column2) && Column3.Equals(other.Column3) && Column4.Equals(other.Column4); }
        public override int GetHashCode() => Intrinsics.CombineHashCodes(Column1, Column2, Column3, Column4);
        public override string ToString() => Intrinsics.MakeString(TypeName, FieldNames, FieldValues);
        public static implicit operator Dynamic(Matrix4x4 self) => new Dynamic(self);
        public static implicit operator Matrix4x4(Dynamic value) => value.As<Matrix4x4>();
        public String TypeName => "Matrix4x4";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>((String)"Column1", (String)"Column2", (String)"Column3", (String)"Column4");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Column1), new Dynamic(Column2), new Dynamic(Column3), new Dynamic(Column4));
        // Unimplemented concept functions
        public Boolean Equals(Matrix4x4 b) => (Column1.Equals(b.Column1) & Column2.Equals(b.Column2) & Column3.Equals(b.Column3) & Column4.Equals(b.Column4));
        public static Boolean operator ==(Matrix4x4 a, Matrix4x4 b) => a.Equals(b);
        public Boolean NotEquals(Matrix4x4 b) => (Column1.NotEquals(b.Column1) & Column2.NotEquals(b.Column2) & Column3.NotEquals(b.Column3) & Column4.NotEquals(b.Column4));
        public static Boolean operator !=(Matrix4x4 a, Matrix4x4 b) => a.NotEquals(b);
        public Integer Count => 4;
        public Vector4D At(Integer n) => n == 0 ? Column1 : n == 1 ? Column2 : n == 2 ? Column3 : n == 3 ? Column4 : throw new System.IndexOutOfRangeException();
        public Vector4D this[Integer n] => At(n);
    }
    public static class Constants
    {
        public static Number MinNumber => Intrinsics.MinNumber;
        public static Number MaxNumber => Intrinsics.MaxNumber;
        public static Number Pi => ((Number)3.1415926535897);
        public static Number TwoPi => Constants.Pi.Twice;
        public static Number HalfPi => Constants.Pi.Half;
        public static Number Epsilon => ((Number)1E-15);
        public static Number FeetPerMeter => ((Number)3.280839895);
        public static Number FeetPerMile => ((Integer)5280);
        public static Number MetersPerLightyear => ((Number)9460730472580000);
        public static Number MetersPerAU => ((Number)149597870691);
        public static Number DaltonPerKilogram => ((Number)1.66053E-27);
        public static Number PoundPerKilogram => ((Number)0.45359237);
        public static Number PoundPerTon => ((Integer)2000);
        public static Number KilogramPerSolarMass => ((Number)1.9889200011446E+30);
        public static Number JulianYearSeconds => ((Integer)31557600);
        public static Number GregorianYearDays => ((Number)365.2425);
        public static Number RadiansPerDegree => Constants.Pi.Divide(((Number)180));
        public static Number DegreesPerRadian => ((Number)180).Divide(Constants.Pi);
    }
    public readonly partial struct LazyArray<T>
    {
        public T At(Integer n) => this.Function(n);
        public T this[Integer n] => At(n);
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public T First => this.At(((Integer)0));
        public T Last => this.At(this.Count.Subtract(((Integer)1)));
        public T Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public LazyArray<T> Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public LazyArray<T> Subarray(Integer from, Integer count)
        {
            var _var1 = from;
            {
                var _var0 = this;
                return count.Map((i) => _var0.At(i.Add(_var1)));
            }
        }
        public LazyArray<T> Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public LazyArray<T> Take(Integer n) => this.Subarray(((Integer)0), n);
        public LazyArray<T> Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public LazyArray<T> SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public LazyArray<T> Rest => this.Skip(((Integer)1));
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public LazyArray<T> PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var4 = this;
            {
                var _var3 = this;
                {
                    var _var2 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var3.At(i)._var2(_var4.At(i.Add(((Integer)1)))));
                }
            }
        }
        public LazyArray<T> PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var8 = this;
            {
                var _var7 = this;
                {
                    var _var6 = this;
                    {
                        var _var5 = f;
                        return this.Count.Map((i) => _var6.At(i)._var5(_var7.At(i.Add(((Integer)1).Modulo(_var8.Count)))));
                    }
                }
            }
        }
        public LazyArray<T> Zip<T0, T1, TR>(LazyArray<T> ys, System.Func<T0, T1, TR> f)
        {
            var _var11 = ys;
            {
                var _var10 = this;
                {
                    var _var9 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var10.At(i)._var9(_var11.At(i)));
                }
            }
        }
    }
    public readonly partial struct LazyArray2D<T>
    {
        public T At(Integer i) => this.At(i.Modulo(this.ColumnCount), i.Divide(this.ColumnCount));
        public T this[Integer i] => At(i);
        public Integer Count => this.RowCount.Multiply(this.ColumnCount);
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public T First => this.At(((Integer)0));
        public T Last => this.At(this.Count.Subtract(((Integer)1)));
        public T Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public LazyArray2D<T> Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public LazyArray2D<T> Subarray(Integer from, Integer count)
        {
            var _var13 = from;
            {
                var _var12 = this;
                return count.Map((i) => _var12.At(i.Add(_var13)));
            }
        }
        public LazyArray2D<T> Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public LazyArray2D<T> Take(Integer n) => this.Subarray(((Integer)0), n);
        public LazyArray2D<T> Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public LazyArray2D<T> SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public LazyArray2D<T> Rest => this.Skip(((Integer)1));
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public LazyArray2D<T> PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var16 = this;
            {
                var _var15 = this;
                {
                    var _var14 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var15.At(i)._var14(_var16.At(i.Add(((Integer)1)))));
                }
            }
        }
        public LazyArray2D<T> PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var20 = this;
            {
                var _var19 = this;
                {
                    var _var18 = this;
                    {
                        var _var17 = f;
                        return this.Count.Map((i) => _var18.At(i)._var17(_var19.At(i.Add(((Integer)1).Modulo(_var20.Count)))));
                    }
                }
            }
        }
        public LazyArray2D<T> Zip<T0, T1, TR>(LazyArray2D<T> ys, System.Func<T0, T1, TR> f)
        {
            var _var23 = ys;
            {
                var _var22 = this;
                {
                    var _var21 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var22.At(i)._var21(_var23.At(i)));
                }
            }
        }
    }
    public readonly partial struct LazyArray3D<T>
    {
        public T At(Integer i) => this.At(i.Modulo(this.ColumnCount), i.Divide(this.ColumnCount), i.Divide(this.LayerCount));
        public T this[Integer i] => At(i);
        public Integer Count => this.RowCount.Multiply(this.ColumnCount.Multiply(this.LayerCount));
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public T First => this.At(((Integer)0));
        public T Last => this.At(this.Count.Subtract(((Integer)1)));
        public T Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public LazyArray3D<T> Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public LazyArray3D<T> Subarray(Integer from, Integer count)
        {
            var _var25 = from;
            {
                var _var24 = this;
                return count.Map((i) => _var24.At(i.Add(_var25)));
            }
        }
        public LazyArray3D<T> Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public LazyArray3D<T> Take(Integer n) => this.Subarray(((Integer)0), n);
        public LazyArray3D<T> Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public LazyArray3D<T> SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public LazyArray3D<T> Rest => this.Skip(((Integer)1));
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public LazyArray3D<T> PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var28 = this;
            {
                var _var27 = this;
                {
                    var _var26 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var27.At(i)._var26(_var28.At(i.Add(((Integer)1)))));
                }
            }
        }
        public LazyArray3D<T> PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var32 = this;
            {
                var _var31 = this;
                {
                    var _var30 = this;
                    {
                        var _var29 = f;
                        return this.Count.Map((i) => _var30.At(i)._var29(_var31.At(i.Add(((Integer)1).Modulo(_var32.Count)))));
                    }
                }
            }
        }
        public LazyArray3D<T> Zip<T0, T1, TR>(LazyArray3D<T> ys, System.Func<T0, T1, TR> f)
        {
            var _var35 = ys;
            {
                var _var34 = this;
                {
                    var _var33 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var34.At(i)._var33(_var35.At(i)));
                }
            }
        }
    }
    public readonly partial struct Transform2D
    {
    }
    public readonly partial struct Pose2D
    {
    }
    public readonly partial struct Bounds2D
    {
        public Vector2D Size => this.Max.Subtract(this.Min);
        public Vector2D Lerp(Number amount) => this.Min.Lerp(this.Max, amount);
        public Bounds2D Reverse => this.Max.Tuple2(this.Min);
        public Vector2D Center => this.Lerp(((Number)0.5));
        public Boolean Contains(Vector2D value) => value.Between(this.Min, this.Max);
        public Boolean Contains(Bounds2D y) => this.Contains(y.Min).And(this.Contains(y.Max));
        public Boolean Overlaps(Bounds2D y) => this.Contains(y.Min).Or(this.Contains(y.Max).Or(y.Contains(this.Min).Or(y.Contains(this.Max))));
        public Tuple2<Bounds2D, Bounds2D> SplitAt(Number t) => this.Left(t).Tuple2(this.Right(t));
        public Tuple2<Bounds2D, Bounds2D> Split => this.SplitAt(((Number)0.5));
        public Bounds2D Left(Number t) => this.Min.Tuple2(this.Lerp(t));
        public Bounds2D Right(Number t) => this.Lerp(t).Tuple2(this.Max);
        public Bounds2D MoveTo(Vector2D v) => v.Tuple2(v.Add(this.Size));
        public Bounds2D LeftHalf => this.Left(((Number)0.5));
        public Bounds2D RightHalf => this.Right(((Number)0.5));
        public Bounds2D Recenter(Vector2D c) => c.Subtract(this.Size.Half).Tuple2(c.Add(this.Size.Half));
        public Bounds2D Clamp(Bounds2D y) => this.Clamp(y.Min).Tuple2(this.Clamp(y.Max));
        public Vector2D Clamp(Vector2D value) => value.Clamp(this.Min, this.Max);
    }
    public readonly partial struct Ray2D
    {
    }
    public readonly partial struct Triangle2D
    {
        public Array<Vector2D> Points => Intrinsics.MakeArray(this.A, this.B, this.C);
        public Number Area => this.A.X.Multiply(this.C.Y.Subtract(this.B.Y)).Add(this.B.X.Multiply(this.A.Y.Subtract(this.C.Y)).Add(this.C.X.Multiply(this.B.Y.Subtract(this.A.Y)))).Half;
        public Triangle2D Flip => this.C.Tuple3(this.B, this.A);
        public Vector2D Center => this.A.Add(this.B.Add(this.C)).Divide(((Number)3));
        public Vector2D Barycentric(Vector2D uv) => this.A.Barycentric(this.B, this.C, uv);
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Vector2D First => this.At(((Integer)0));
        public Vector2D Last => this.At(this.Count.Subtract(((Integer)1)));
        public Vector2D Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public Triangle2D Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public Triangle2D Subarray(Integer from, Integer count)
        {
            var _var37 = from;
            {
                var _var36 = this;
                return count.Map((i) => _var36.At(i.Add(_var37)));
            }
        }
        public Triangle2D Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public Triangle2D Take(Integer n) => this.Subarray(((Integer)0), n);
        public Triangle2D Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public Triangle2D SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public Triangle2D Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Vector2D, TAcc> f) => f(f(f(init, A), B), C);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public Triangle2D PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var40 = this;
            {
                var _var39 = this;
                {
                    var _var38 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var39.At(i)._var38(_var40.At(i.Add(((Integer)1)))));
                }
            }
        }
        public Triangle2D PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var44 = this;
            {
                var _var43 = this;
                {
                    var _var42 = this;
                    {
                        var _var41 = f;
                        return this.Count.Map((i) => _var42.At(i)._var41(_var43.At(i.Add(((Integer)1).Modulo(_var44.Count)))));
                    }
                }
            }
        }
        public Triangle2D Zip<T0, T1, TR>(Triangle2D ys, System.Func<T0, T1, TR> f)
        {
            var _var47 = ys;
            {
                var _var46 = this;
                {
                    var _var45 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var46.At(i)._var45(_var47.At(i)));
                }
            }
        }
    }
    public readonly partial struct Quad2D
    {
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Vector2D First => this.At(((Integer)0));
        public Vector2D Last => this.At(this.Count.Subtract(((Integer)1)));
        public Vector2D Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public Quad2D Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public Quad2D Subarray(Integer from, Integer count)
        {
            var _var49 = from;
            {
                var _var48 = this;
                return count.Map((i) => _var48.At(i.Add(_var49)));
            }
        }
        public Quad2D Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public Quad2D Take(Integer n) => this.Subarray(((Integer)0), n);
        public Quad2D Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public Quad2D SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public Quad2D Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Vector2D, TAcc> f) => f(f(f(f(init, A), B), C), D);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public Quad2D PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var52 = this;
            {
                var _var51 = this;
                {
                    var _var50 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var51.At(i)._var50(_var52.At(i.Add(((Integer)1)))));
                }
            }
        }
        public Quad2D PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var56 = this;
            {
                var _var55 = this;
                {
                    var _var54 = this;
                    {
                        var _var53 = f;
                        return this.Count.Map((i) => _var54.At(i)._var53(_var55.At(i.Add(((Integer)1).Modulo(_var56.Count)))));
                    }
                }
            }
        }
        public Quad2D Zip<T0, T1, TR>(Quad2D ys, System.Func<T0, T1, TR> f)
        {
            var _var59 = ys;
            {
                var _var58 = this;
                {
                    var _var57 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var58.At(i)._var57(_var59.At(i)));
                }
            }
        }
    }
    public readonly partial struct Line2D
    {
        public Boolean Closed => ((Boolean)false);
        public Array<Vector2D> Points => this;
        public Number Length => this.B.Subtract(this.A).Length;
        public Vector2D Direction => this.B.Subtract(this.A);
        public static implicit operator Ray2D(Line2D x) => x.A.Tuple2(x.Direction);
        public Ray2D Ray2D => this.A.Tuple2(this.Direction);
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Vector2D First => this.At(((Integer)0));
        public Vector2D Last => this.At(this.Count.Subtract(((Integer)1)));
        public Vector2D Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public Line2D Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public Line2D Subarray(Integer from, Integer count)
        {
            var _var61 = from;
            {
                var _var60 = this;
                return count.Map((i) => _var60.At(i.Add(_var61)));
            }
        }
        public Line2D Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public Line2D Take(Integer n) => this.Subarray(((Integer)0), n);
        public Line2D Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public Line2D SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public Line2D Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Vector2D, TAcc> f) => f(f(init, A), B);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public Line2D PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var64 = this;
            {
                var _var63 = this;
                {
                    var _var62 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var63.At(i)._var62(_var64.At(i.Add(((Integer)1)))));
                }
            }
        }
        public Line2D PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var68 = this;
            {
                var _var67 = this;
                {
                    var _var66 = this;
                    {
                        var _var65 = f;
                        return this.Count.Map((i) => _var66.At(i)._var65(_var67.At(i.Add(((Integer)1).Modulo(_var68.Count)))));
                    }
                }
            }
        }
        public Line2D Zip<T0, T1, TR>(Line2D ys, System.Func<T0, T1, TR> f)
        {
            var _var71 = ys;
            {
                var _var70 = this;
                {
                    var _var69 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var70.At(i)._var69(_var71.At(i)));
                }
            }
        }
    }
    public readonly partial struct Circle
    {
        public Boolean Closed => ((Boolean)true);
    }
    public readonly partial struct Lens
    {
        public Boolean Closed => ((Boolean)true);
    }
    public readonly partial struct Rect2D
    {
        public Number Width => this.Size.Width;
        public Number Height => this.Size.Height;
        public Number HalfWidth => this.Width.Half;
        public Number HalfHeight => this.Height.Half;
        public Number Top => this.Center.Y.Add(HalfHeight);
        public Number Bottom => this.Top.Add(this.Height);
        public Number Left => this.Center.X.Subtract(HalfWidth);
        public Number Right => this.Left.Add(this.Width);
        public Vector2D TopLeft => this.Left.Tuple2(this.Top);
        public Vector2D TopRight => this.Right.Tuple2(this.Top);
        public Vector2D BottomRight => this.Right.Tuple2(this.Bottom);
        public Vector2D BottomLeft => this.Left.Tuple2(this.Bottom);
        public Array<Vector2D> Points => Intrinsics.MakeArray(this.TopLeft, this.TopRight, this.BottomRight, this.BottomLeft);
        public Boolean Closed => ((Boolean)true);
    }
    public readonly partial struct Ellipse
    {
        public Boolean Closed => ((Boolean)true);
        public Vector2D Eval(Number t) => t.Circle.Multiply(this.Size).Add(this.Center);
    }
    public readonly partial struct Ring
    {
        public Boolean Closed => ((Boolean)true);
    }
    public readonly partial struct Arc
    {
        public Boolean Closed => ((Boolean)false);
    }
    public readonly partial struct Sector
    {
        public Boolean Closed => ((Boolean)true);
    }
    public readonly partial struct Chord
    {
        public Boolean Closed => ((Boolean)true);
    }
    public readonly partial struct Segment
    {
        public Boolean Closed => ((Boolean)true);
    }
    public readonly partial struct RegularPolygon
    {
        public Array<Vector2D> Points => this.NumPoints.CirclePoints;
        public Boolean Closed => ((Boolean)true);
    }
    public readonly partial struct Box2D
    {
    }
    public readonly partial struct Sphere
    {
    }
    public readonly partial struct Plane
    {
        public Vector3D Project(Vector3D v) => v.Subtract(this.Normal.Multiply(this.Normal.Dot(v)));
    }
    public readonly partial struct Transform3D
    {
    }
    public readonly partial struct Pose3D
    {
    }
    public readonly partial struct Frame3D
    {
    }
    public readonly partial struct Bounds3D
    {
        public Vector3D Size => this.Max.Subtract(this.Min);
        public Vector3D Lerp(Number amount) => this.Min.Lerp(this.Max, amount);
        public Bounds3D Reverse => this.Max.Tuple2(this.Min);
        public Vector3D Center => this.Lerp(((Number)0.5));
        public Boolean Contains(Vector3D value) => value.Between(this.Min, this.Max);
        public Boolean Contains(Bounds3D y) => this.Contains(y.Min).And(this.Contains(y.Max));
        public Boolean Overlaps(Bounds3D y) => this.Contains(y.Min).Or(this.Contains(y.Max).Or(y.Contains(this.Min).Or(y.Contains(this.Max))));
        public Tuple2<Bounds3D, Bounds3D> SplitAt(Number t) => this.Left(t).Tuple2(this.Right(t));
        public Tuple2<Bounds3D, Bounds3D> Split => this.SplitAt(((Number)0.5));
        public Bounds3D Left(Number t) => this.Min.Tuple2(this.Lerp(t));
        public Bounds3D Right(Number t) => this.Lerp(t).Tuple2(this.Max);
        public Bounds3D MoveTo(Vector3D v) => v.Tuple2(v.Add(this.Size));
        public Bounds3D LeftHalf => this.Left(((Number)0.5));
        public Bounds3D RightHalf => this.Right(((Number)0.5));
        public Bounds3D Recenter(Vector3D c) => c.Subtract(this.Size.Half).Tuple2(c.Add(this.Size.Half));
        public Bounds3D Clamp(Bounds3D y) => this.Clamp(y.Min).Tuple2(this.Clamp(y.Max));
        public Vector3D Clamp(Vector3D value) => value.Clamp(this.Min, this.Max);
    }
    public readonly partial struct Line3D
    {
        public Boolean Closed => ((Boolean)false);
        public Array<Vector3D> Points => this;
        public Number Length => this.B.Subtract(this.A).Length;
        public Vector3D Direction => this.B.Subtract(this.A);
        public static implicit operator Ray3D(Line3D x) => x.A.Tuple2(x.Direction);
        public Ray3D Ray3D => this.A.Tuple2(this.Direction);
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Vector3D First => this.At(((Integer)0));
        public Vector3D Last => this.At(this.Count.Subtract(((Integer)1)));
        public Vector3D Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public Line3D Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public Line3D Subarray(Integer from, Integer count)
        {
            var _var73 = from;
            {
                var _var72 = this;
                return count.Map((i) => _var72.At(i.Add(_var73)));
            }
        }
        public Line3D Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public Line3D Take(Integer n) => this.Subarray(((Integer)0), n);
        public Line3D Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public Line3D SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public Line3D Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Vector3D, TAcc> f) => f(f(init, A), B);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public Line3D PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var76 = this;
            {
                var _var75 = this;
                {
                    var _var74 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var75.At(i)._var74(_var76.At(i.Add(((Integer)1)))));
                }
            }
        }
        public Line3D PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var80 = this;
            {
                var _var79 = this;
                {
                    var _var78 = this;
                    {
                        var _var77 = f;
                        return this.Count.Map((i) => _var78.At(i)._var77(_var79.At(i.Add(((Integer)1).Modulo(_var80.Count)))));
                    }
                }
            }
        }
        public Line3D Zip<T0, T1, TR>(Line3D ys, System.Func<T0, T1, TR> f)
        {
            var _var83 = ys;
            {
                var _var82 = this;
                {
                    var _var81 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var82.At(i)._var81(_var83.At(i)));
                }
            }
        }
    }
    public readonly partial struct Ray3D
    {
        public Angle Angle(Ray3D b) => this.Direction.Angle(b.Direction);
    }
    public readonly partial struct Triangle3D
    {
        public Triangle3D Flip => this.C.Tuple3(this.B, this.A);
        public Vector3D Normal => this.B.Subtract(this.A).Cross(this.C.Subtract(this.A)).Normalize;
        public Vector3D Center => this.A.Add(this.B.Add(this.C)).Divide(((Number)3));
        public static implicit operator Plane(Triangle3D t) => t.Normal.Tuple2(t.Normal.Dot(t.A));
        public Plane Plane => this.Normal.Tuple2(this.Normal.Dot(this.A));
        public Vector3D Barycentric(Vector2D uv) => this.A.Barycentric(this.B, this.C, uv);
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Vector3D First => this.At(((Integer)0));
        public Vector3D Last => this.At(this.Count.Subtract(((Integer)1)));
        public Vector3D Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public Triangle3D Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public Triangle3D Subarray(Integer from, Integer count)
        {
            var _var85 = from;
            {
                var _var84 = this;
                return count.Map((i) => _var84.At(i.Add(_var85)));
            }
        }
        public Triangle3D Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public Triangle3D Take(Integer n) => this.Subarray(((Integer)0), n);
        public Triangle3D Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public Triangle3D SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public Triangle3D Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Vector3D, TAcc> f) => f(f(f(init, A), B), C);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public Triangle3D PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var88 = this;
            {
                var _var87 = this;
                {
                    var _var86 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var87.At(i)._var86(_var88.At(i.Add(((Integer)1)))));
                }
            }
        }
        public Triangle3D PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var92 = this;
            {
                var _var91 = this;
                {
                    var _var90 = this;
                    {
                        var _var89 = f;
                        return this.Count.Map((i) => _var90.At(i)._var89(_var91.At(i.Add(((Integer)1).Modulo(_var92.Count)))));
                    }
                }
            }
        }
        public Triangle3D Zip<T0, T1, TR>(Triangle3D ys, System.Func<T0, T1, TR> f)
        {
            var _var95 = ys;
            {
                var _var94 = this;
                {
                    var _var93 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var94.At(i)._var93(_var95.At(i)));
                }
            }
        }
    }
    public readonly partial struct Quad3D
    {
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Vector3D First => this.At(((Integer)0));
        public Vector3D Last => this.At(this.Count.Subtract(((Integer)1)));
        public Vector3D Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public Quad3D Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public Quad3D Subarray(Integer from, Integer count)
        {
            var _var97 = from;
            {
                var _var96 = this;
                return count.Map((i) => _var96.At(i.Add(_var97)));
            }
        }
        public Quad3D Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public Quad3D Take(Integer n) => this.Subarray(((Integer)0), n);
        public Quad3D Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public Quad3D SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public Quad3D Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Vector3D, TAcc> f) => f(f(f(f(init, A), B), C), D);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public Quad3D PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var100 = this;
            {
                var _var99 = this;
                {
                    var _var98 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var99.At(i)._var98(_var100.At(i.Add(((Integer)1)))));
                }
            }
        }
        public Quad3D PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var104 = this;
            {
                var _var103 = this;
                {
                    var _var102 = this;
                    {
                        var _var101 = f;
                        return this.Count.Map((i) => _var102.At(i)._var101(_var103.At(i.Add(((Integer)1).Modulo(_var104.Count)))));
                    }
                }
            }
        }
        public Quad3D Zip<T0, T1, TR>(Quad3D ys, System.Func<T0, T1, TR> f)
        {
            var _var107 = ys;
            {
                var _var106 = this;
                {
                    var _var105 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var106.At(i)._var105(_var107.At(i)));
                }
            }
        }
    }
    public readonly partial struct Capsule
    {
    }
    public readonly partial struct Cylinder
    {
    }
    public readonly partial struct Cone
    {
    }
    public readonly partial struct Tube
    {
    }
    public readonly partial struct ConeSegment
    {
    }
    public readonly partial struct Box3D
    {
    }
    public readonly partial struct CubicBezier2D
    {
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Vector2D First => this.At(((Integer)0));
        public Vector2D Last => this.At(this.Count.Subtract(((Integer)1)));
        public Vector2D Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public CubicBezier2D Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public CubicBezier2D Subarray(Integer from, Integer count)
        {
            var _var109 = from;
            {
                var _var108 = this;
                return count.Map((i) => _var108.At(i.Add(_var109)));
            }
        }
        public CubicBezier2D Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public CubicBezier2D Take(Integer n) => this.Subarray(((Integer)0), n);
        public CubicBezier2D Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public CubicBezier2D SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public CubicBezier2D Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Vector2D, TAcc> f) => f(f(f(f(init, A), B), C), D);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public CubicBezier2D PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var112 = this;
            {
                var _var111 = this;
                {
                    var _var110 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var111.At(i)._var110(_var112.At(i.Add(((Integer)1)))));
                }
            }
        }
        public CubicBezier2D PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var116 = this;
            {
                var _var115 = this;
                {
                    var _var114 = this;
                    {
                        var _var113 = f;
                        return this.Count.Map((i) => _var114.At(i)._var113(_var115.At(i.Add(((Integer)1).Modulo(_var116.Count)))));
                    }
                }
            }
        }
        public CubicBezier2D Zip<T0, T1, TR>(CubicBezier2D ys, System.Func<T0, T1, TR> f)
        {
            var _var119 = ys;
            {
                var _var118 = this;
                {
                    var _var117 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var118.At(i)._var117(_var119.At(i)));
                }
            }
        }
    }
    public readonly partial struct CubicBezier3D
    {
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Vector3D First => this.At(((Integer)0));
        public Vector3D Last => this.At(this.Count.Subtract(((Integer)1)));
        public Vector3D Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public CubicBezier3D Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public CubicBezier3D Subarray(Integer from, Integer count)
        {
            var _var121 = from;
            {
                var _var120 = this;
                return count.Map((i) => _var120.At(i.Add(_var121)));
            }
        }
        public CubicBezier3D Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public CubicBezier3D Take(Integer n) => this.Subarray(((Integer)0), n);
        public CubicBezier3D Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public CubicBezier3D SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public CubicBezier3D Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Vector3D, TAcc> f) => f(f(f(f(init, A), B), C), D);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public CubicBezier3D PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var124 = this;
            {
                var _var123 = this;
                {
                    var _var122 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var123.At(i)._var122(_var124.At(i.Add(((Integer)1)))));
                }
            }
        }
        public CubicBezier3D PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var128 = this;
            {
                var _var127 = this;
                {
                    var _var126 = this;
                    {
                        var _var125 = f;
                        return this.Count.Map((i) => _var126.At(i)._var125(_var127.At(i.Add(((Integer)1).Modulo(_var128.Count)))));
                    }
                }
            }
        }
        public CubicBezier3D Zip<T0, T1, TR>(CubicBezier3D ys, System.Func<T0, T1, TR> f)
        {
            var _var131 = ys;
            {
                var _var130 = this;
                {
                    var _var129 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var130.At(i)._var129(_var131.At(i)));
                }
            }
        }
    }
    public readonly partial struct QuadraticBezier2D
    {
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Vector2D First => this.At(((Integer)0));
        public Vector2D Last => this.At(this.Count.Subtract(((Integer)1)));
        public Vector2D Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public QuadraticBezier2D Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public QuadraticBezier2D Subarray(Integer from, Integer count)
        {
            var _var133 = from;
            {
                var _var132 = this;
                return count.Map((i) => _var132.At(i.Add(_var133)));
            }
        }
        public QuadraticBezier2D Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public QuadraticBezier2D Take(Integer n) => this.Subarray(((Integer)0), n);
        public QuadraticBezier2D Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public QuadraticBezier2D SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public QuadraticBezier2D Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Vector2D, TAcc> f) => f(f(f(init, A), B), C);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public QuadraticBezier2D PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var136 = this;
            {
                var _var135 = this;
                {
                    var _var134 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var135.At(i)._var134(_var136.At(i.Add(((Integer)1)))));
                }
            }
        }
        public QuadraticBezier2D PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var140 = this;
            {
                var _var139 = this;
                {
                    var _var138 = this;
                    {
                        var _var137 = f;
                        return this.Count.Map((i) => _var138.At(i)._var137(_var139.At(i.Add(((Integer)1).Modulo(_var140.Count)))));
                    }
                }
            }
        }
        public QuadraticBezier2D Zip<T0, T1, TR>(QuadraticBezier2D ys, System.Func<T0, T1, TR> f)
        {
            var _var143 = ys;
            {
                var _var142 = this;
                {
                    var _var141 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var142.At(i)._var141(_var143.At(i)));
                }
            }
        }
    }
    public readonly partial struct QuadraticBezier3D
    {
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Vector3D First => this.At(((Integer)0));
        public Vector3D Last => this.At(this.Count.Subtract(((Integer)1)));
        public Vector3D Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public QuadraticBezier3D Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public QuadraticBezier3D Subarray(Integer from, Integer count)
        {
            var _var145 = from;
            {
                var _var144 = this;
                return count.Map((i) => _var144.At(i.Add(_var145)));
            }
        }
        public QuadraticBezier3D Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public QuadraticBezier3D Take(Integer n) => this.Subarray(((Integer)0), n);
        public QuadraticBezier3D Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public QuadraticBezier3D SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public QuadraticBezier3D Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Vector3D, TAcc> f) => f(f(f(init, A), B), C);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public QuadraticBezier3D PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var148 = this;
            {
                var _var147 = this;
                {
                    var _var146 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var147.At(i)._var146(_var148.At(i.Add(((Integer)1)))));
                }
            }
        }
        public QuadraticBezier3D PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var152 = this;
            {
                var _var151 = this;
                {
                    var _var150 = this;
                    {
                        var _var149 = f;
                        return this.Count.Map((i) => _var150.At(i)._var149(_var151.At(i.Add(((Integer)1).Modulo(_var152.Count)))));
                    }
                }
            }
        }
        public QuadraticBezier3D Zip<T0, T1, TR>(QuadraticBezier3D ys, System.Func<T0, T1, TR> f)
        {
            var _var155 = ys;
            {
                var _var154 = this;
                {
                    var _var153 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var154.At(i)._var153(_var155.At(i)));
                }
            }
        }
    }
    public readonly partial struct Quaternion
    {
    }
    public readonly partial struct AxisAngle
    {
    }
    public readonly partial struct EulerAngles
    {
    }
    public readonly partial struct Rotation3D
    {
    }
    public readonly partial struct Orientation3D
    {
    }
    public readonly partial struct Line4D
    {
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Vector4D First => this.At(((Integer)0));
        public Vector4D Last => this.At(this.Count.Subtract(((Integer)1)));
        public Vector4D Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public Line4D Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public Line4D Subarray(Integer from, Integer count)
        {
            var _var157 = from;
            {
                var _var156 = this;
                return count.Map((i) => _var156.At(i.Add(_var157)));
            }
        }
        public Line4D Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public Line4D Take(Integer n) => this.Subarray(((Integer)0), n);
        public Line4D Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public Line4D SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public Line4D Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Vector4D, TAcc> f) => f(f(init, A), B);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public Line4D PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var160 = this;
            {
                var _var159 = this;
                {
                    var _var158 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var159.At(i)._var158(_var160.At(i.Add(((Integer)1)))));
                }
            }
        }
        public Line4D PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var164 = this;
            {
                var _var163 = this;
                {
                    var _var162 = this;
                    {
                        var _var161 = f;
                        return this.Count.Map((i) => _var162.At(i)._var161(_var163.At(i.Add(((Integer)1).Modulo(_var164.Count)))));
                    }
                }
            }
        }
        public Line4D Zip<T0, T1, TR>(Line4D ys, System.Func<T0, T1, TR> f)
        {
            var _var167 = ys;
            {
                var _var166 = this;
                {
                    var _var165 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var166.At(i)._var165(_var167.At(i)));
                }
            }
        }
    }
    public readonly partial struct Vertex
    {
    }
    public readonly partial struct TriMesh
    {
    }
    public readonly partial struct QuadMesh
    {
    }
    public readonly partial struct Number
    {
        public Number Line(Number m, Number b) => m.Multiply(this).Add(b);
        public Number Quadratic(Number a, Number b, Number c) => a.Multiply(this.Square).Add(b.Multiply(this).Add(c));
        public Number Cubic(Number a, Number b, Number c, Number d) => a.Multiply(this.Cube).Add(b.Multiply(this.Square).Add(c.Multiply(this).Add(d)));
        public Number Parabola => this.Square;
        public Number StaircaseFloor(Integer steps) => this.Multiply(steps).Floor.Divide(steps);
        public Number StaircaseCeiling(Integer steps) => this.Multiply(steps).Ceiling.Divide(steps);
        public Number StaircaseRound(Integer steps) => this.Multiply(steps).Round.Divide(steps);
        public Vector2D Circle => this.Turns.Circle;
        public Vector2D Lissajous(Number kx, Number ky) => this.Turns.Lissajous(kx, ky);
        public Vector2D ButterflyCurve => this.Turns.Divide(((Number)6)).ButterflyCurve;
        public Vector2D Parabola2D => this.Tuple2(this.Parabola);
        public Vector2D Line2D(Number m, Number b) => this.Tuple2(this.Line(m, b));
        public Vector2D SinCurve => this.Tuple2(this.Turns.Sin);
        public Vector2D CosCurve => this.Tuple2(this.Turns.Cos);
        public Vector2D TanCurve => this.Tuple2(this.Turns.Tan);
        public Vector3D Helix(Number revs) => this.Multiply(revs).Turns.Sin.Tuple3(this.Multiply(revs).Turns.Cos, this);
        public Angle Acos => Intrinsics.Acos(this);
        public Angle Asin => Intrinsics.Asin(this);
        public Angle Atan => Intrinsics.Atan(this);
        public Number Pow(Number y) => Intrinsics.Pow(this, y);
        public Number Log(Number y) => Intrinsics.Log(this, y);
        public Number Ln => Intrinsics.Ln(this);
        public Number Exp => Intrinsics.Exp(this);
        public Number Floor => Intrinsics.Floor(this);
        public Number Ceiling => Intrinsics.Ceiling(this);
        public Number Round => Intrinsics.Round(this);
        public Number Truncate => Intrinsics.Truncate(this);
        public Number Add(Number y) => Intrinsics.Add(this, y);
        public static Number operator +(Number x, Number y) => x.Add(y);
        public Number Subtract(Number y) => Intrinsics.Subtract(this, y);
        public static Number operator -(Number x, Number y) => x.Subtract(y);
        public Number Divide(Number y) => Intrinsics.Divide(this, y);
        public static Number operator /(Number x, Number y) => x.Divide(y);
        public Number Multiply(Number y) => Intrinsics.Multiply(this, y);
        public static Number operator *(Number x, Number y) => x.Multiply(y);
        public Number Modulo(Number y) => Intrinsics.Modulo(this, y);
        public static Number operator %(Number x, Number y) => x.Modulo(y);
        public Number Negative => Intrinsics.Negative(this);
        public static Number operator -(Number x) => x.Negative;
        public Number OunceToGram => this.Multiply(((Number)28.349523125));
        public Number TroyOunceToGram => this.Multiply(((Number)31.1034768));
        public Number GrainToMilligram => this.Multiply(((Number)64.79891));
        public Number Mole => this.Multiply(((Number)6.02214076E+23));
        public Number Hundred => this.Multiply(((Integer)100));
        public Number Thousand => this.Multiply(((Integer)1000));
        public Number Million => this.Thousand.Thousand;
        public Number Billion => this.Thousand.Million;
        public Number Inverse => ((Number)1).Divide(this);
        public Number Reciprocal => this.Inverse;
        public Number SquareRoot => this.Pow(((Number)0.5));
        public Number Sqrt => this.SquareRoot;
        public Number SmoothStep => this.Square.Multiply(((Number)3).Subtract(this.Twice));
        public Number MultiplyEpsilon(Number y) => this.Abs.Greater(y.Abs).Multiply(Constants.Epsilon);
        public Boolean AlmostEqual(Number y) => this.Subtract(y).Abs.LessThanOrEquals(this.MultiplyEpsilon(y));
        public Boolean AlmostZero => this.Abs.LessThan(Constants.Epsilon);
        public Boolean AlmostZeroOrOne => this.AlmostEqual(((Integer)0)).Or(this.AlmostEqual(((Integer)1)));
        public Boolean Between(Number min, Number max) => this.GreaterThanOrEquals(min).And(this.LessThanOrEquals(max));
        public Angle Turns => this.Multiply(Constants.TwoPi).Radians;
        public Angle Degrees => this.Divide(((Number)360)).Turns;
        public Angle Gradians => this.Divide(((Number)400)).Turns;
        public Angle Radians => this;
        public Number Magnitude => this.Value;
        public Number ClampOne => this.Clamp(this.Zero, this.One);
        public Boolean GtZ => this.GreaterThan(this.Zero);
        public Boolean LtZ => this.LessThan(this.Zero);
        public Boolean GtEqZ => this.GreaterThanOrEquals(this.Zero);
        public Boolean LtEqZ => this.LessThanOrEquals(this.Zero);
        public Boolean IsPositive => this.GtEqZ;
        public Boolean IsNegative => this.LtZ;
        public Integer Sign => this.LtZ ? ((Integer)1).Negative : this.GtZ ? ((Integer)1) : ((Integer)0);
        public Number Abs => this.LtZ ? this.Negative : this;
        public Number PlusOne => this.Add(this.One);
        public Number MinusOne => this.Subtract(this.One);
        public Number FromOne => this.One.Subtract(this);
        public Number Component(Integer n) => this.Components.At(n);
        public Integer NumComponents => this.Components.Count;
        public Number MapComponents(System.Func<Number, Number> f) => this.FromComponents(this.Components.Map(f));
        public Number Zero => this.MapComponents((i) => ((Number)0));
        public Number One => this.MapComponents((i) => ((Number)1));
        public Number MinValue => this.MapComponents((x) => x.Constants.MinNumber);
        public Number MaxValue => this.MapComponents((x) => x.Constants.MaxNumber);
        public Boolean AllComponents(System.Func<Number, Boolean> predicate) => this.Components.All(predicate);
        public Boolean AnyComponent(System.Func<Number, Boolean> predicate) => this.Components.Any(predicate);
        public Number Half => this.Divide(((Number)2));
        public Number Quarter => this.Divide(((Number)4));
        public Number Tenth => this.Divide(((Number)10));
        public Number Twice => this.Multiply(((Number)2));
        public Number Lerp(Number b, Number t) => this.Multiply(t.FromOne).Add(b.Multiply(t));
        public Number Barycentric(Number v2, Number v3, Vector2D uv) => this.Add(v2.Subtract(this).Multiply(uv.X).Add(v3.Subtract(this).Multiply(uv.Y)));
        public Number Clamp(Number a, Number b) => this.Greater(a).Lesser(b);
        public Boolean Equals(Number b) => this.Compare(b).Equals(((Integer)0));
        public static Boolean operator ==(Number a, Number b) => a.Equals(b);
        public Boolean NotEquals(Number b) => this.Compare(b).NotEquals(((Integer)0));
        public static Boolean operator !=(Number a, Number b) => a.NotEquals(b);
        public Boolean LessThan(Number b) => this.Compare(b).LessThan(((Integer)0));
        public static Boolean operator <(Number a, Number b) => a.LessThan(b);
        public Boolean LessThanOrEquals(Number b) => this.Compare(b).LessThanOrEquals(((Integer)0));
        public static Boolean operator <=(Number a, Number b) => a.LessThanOrEquals(b);
        public Boolean GreaterThan(Number b) => this.Compare(b).GreaterThan(((Integer)0));
        public static Boolean operator >(Number a, Number b) => a.GreaterThan(b);
        public Boolean GreaterThanOrEquals(Number b) => this.Compare(b).GreaterThanOrEquals(((Integer)0));
        public static Boolean operator >=(Number a, Number b) => a.GreaterThanOrEquals(b);
        public Number Lesser(Number b) => this.LessThanOrEquals(b) ? this : b;
        public Number Greater(Number b) => this.GreaterThanOrEquals(b) ? this : b;
        public Number Pow2 => this.Multiply(this);
        public Number Pow3 => this.Pow2.Multiply(this);
        public Number Pow4 => this.Pow3.Multiply(this);
        public Number Pow5 => this.Pow4.Multiply(this);
        public Number Square => this.Pow2;
        public Number Cube => this.Pow3;
    }
    public readonly partial struct Integer
    {
        public Array<Integer> Range => this.Map((i) => i);
        public Array<Vector2D> CirclePoints => this.Fractions.Map((x) => x.Turns.Circle);
        public Integer Add(Integer y) => Intrinsics.Add(this, y);
        public static Integer operator +(Integer x, Integer y) => x.Add(y);
        public Integer Subtract(Integer y) => Intrinsics.Subtract(this, y);
        public static Integer operator -(Integer x, Integer y) => x.Subtract(y);
        public Integer Divide(Integer y) => Intrinsics.Divide(this, y);
        public static Integer operator /(Integer x, Integer y) => x.Divide(y);
        public Integer Multiply(Integer y) => Intrinsics.Multiply(this, y);
        public static Integer operator *(Integer x, Integer y) => x.Multiply(y);
        public Integer Modulo(Integer y) => Intrinsics.Modulo(this, y);
        public static Integer operator %(Integer x, Integer y) => x.Modulo(y);
        public Integer Negative => Intrinsics.Negative(this);
        public static Integer operator -(Integer x) => x.Negative;
        public Integer Reciprocal => Intrinsics.Reciprocal(this);
        public Number ToNumber => Intrinsics.ToNumber(this);
        public Number FloatDivision(Integer y) => this.ToNumber.Divide(y.ToNumber);
        public Array<Number> Fractions
        {
            get
            {
                var _var168 = this;
                return this.Range.Map((i) => i.FloatDivision(_var168));
            }
        }
        public Integer PlusOne => this.Add(this.One);
        public Integer MinusOne => this.Subtract(this.One);
        public Integer FromOne => this.One.Subtract(this);
        public Number Component(Integer n) => this.Components.At(n);
        public Integer NumComponents => this.Components.Count;
        public Integer MapComponents(System.Func<Number, Number> f) => this.FromComponents(this.Components.Map(f));
        public Integer Zero => this.MapComponents((i) => ((Number)0));
        public Integer One => this.MapComponents((i) => ((Number)1));
        public Integer MinValue => this.MapComponents((x) => x.Constants.MinNumber);
        public Integer MaxValue => this.MapComponents((x) => x.Constants.MaxNumber);
        public Boolean AllComponents(System.Func<Number, Boolean> predicate) => this.Components.All(predicate);
        public Boolean AnyComponent(System.Func<Number, Boolean> predicate) => this.Components.Any(predicate);
        public Integer Clamp(Integer a, Integer b) => this.Greater(a).Lesser(b);
        public Boolean Equals(Integer b) => this.Compare(b).Equals(((Integer)0));
        public static Boolean operator ==(Integer a, Integer b) => a.Equals(b);
        public Boolean NotEquals(Integer b) => this.Compare(b).NotEquals(((Integer)0));
        public static Boolean operator !=(Integer a, Integer b) => a.NotEquals(b);
        public Boolean LessThan(Integer b) => this.Compare(b).LessThan(((Integer)0));
        public static Boolean operator <(Integer a, Integer b) => a.LessThan(b);
        public Boolean LessThanOrEquals(Integer b) => this.Compare(b).LessThanOrEquals(((Integer)0));
        public static Boolean operator <=(Integer a, Integer b) => a.LessThanOrEquals(b);
        public Boolean GreaterThan(Integer b) => this.Compare(b).GreaterThan(((Integer)0));
        public static Boolean operator >(Integer a, Integer b) => a.GreaterThan(b);
        public Boolean GreaterThanOrEquals(Integer b) => this.Compare(b).GreaterThanOrEquals(((Integer)0));
        public static Boolean operator >=(Integer a, Integer b) => a.GreaterThanOrEquals(b);
        public Integer Lesser(Integer b) => this.LessThanOrEquals(b) ? this : b;
        public Integer Greater(Integer b) => this.GreaterThanOrEquals(b) ? this : b;
        public Integer Pow2 => this.Multiply(this);
        public Integer Pow3 => this.Pow2.Multiply(this);
        public Integer Pow4 => this.Pow3.Multiply(this);
        public Integer Pow5 => this.Pow4.Multiply(this);
        public Integer Square => this.Pow2;
        public Integer Cube => this.Pow3;
    }
    public readonly partial struct String
    {
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Character First => this.At(((Integer)0));
        public Character Last => this.At(this.Count.Subtract(((Integer)1)));
        public Character Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public String Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public String Subarray(Integer from, Integer count)
        {
            var _var170 = from;
            {
                var _var169 = this;
                return count.Map((i) => _var169.At(i.Add(_var170)));
            }
        }
        public String Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public String Take(Integer n) => this.Subarray(((Integer)0), n);
        public String Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public String SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public String Rest => this.Skip(((Integer)1));
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public String PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var173 = this;
            {
                var _var172 = this;
                {
                    var _var171 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var172.At(i)._var171(_var173.At(i.Add(((Integer)1)))));
                }
            }
        }
        public String PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var177 = this;
            {
                var _var176 = this;
                {
                    var _var175 = this;
                    {
                        var _var174 = f;
                        return this.Count.Map((i) => _var175.At(i)._var174(_var176.At(i.Add(((Integer)1).Modulo(_var177.Count)))));
                    }
                }
            }
        }
        public String Zip<T0, T1, TR>(String ys, System.Func<T0, T1, TR> f)
        {
            var _var180 = ys;
            {
                var _var179 = this;
                {
                    var _var178 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var179.At(i)._var178(_var180.At(i)));
                }
            }
        }
        public String Clamp(String a, String b) => this.Greater(a).Lesser(b);
        public Boolean Equals(String b) => this.Compare(b).Equals(((Integer)0));
        public static Boolean operator ==(String a, String b) => a.Equals(b);
        public Boolean NotEquals(String b) => this.Compare(b).NotEquals(((Integer)0));
        public static Boolean operator !=(String a, String b) => a.NotEquals(b);
        public Boolean LessThan(String b) => this.Compare(b).LessThan(((Integer)0));
        public static Boolean operator <(String a, String b) => a.LessThan(b);
        public Boolean LessThanOrEquals(String b) => this.Compare(b).LessThanOrEquals(((Integer)0));
        public static Boolean operator <=(String a, String b) => a.LessThanOrEquals(b);
        public Boolean GreaterThan(String b) => this.Compare(b).GreaterThan(((Integer)0));
        public static Boolean operator >(String a, String b) => a.GreaterThan(b);
        public Boolean GreaterThanOrEquals(String b) => this.Compare(b).GreaterThanOrEquals(((Integer)0));
        public static Boolean operator >=(String a, String b) => a.GreaterThanOrEquals(b);
        public String Lesser(String b) => this.LessThanOrEquals(b) ? this : b;
        public String Greater(String b) => this.GreaterThanOrEquals(b) ? this : b;
    }
    public readonly partial struct Boolean
    {
        public Boolean And(Boolean y) => Intrinsics.And(this, y);
        public static Boolean operator &(Boolean x, Boolean y) => x.And(y);
        public Boolean Or(Boolean y) => Intrinsics.Or(this, y);
        public static Boolean operator |(Boolean x, Boolean y) => x.Or(y);
        public Boolean Not => Intrinsics.Not(this);
        public static Boolean operator !(Boolean x) => x.Not;
    }
    public readonly partial struct Character
    {
    }
    public readonly partial struct Dynamic
    {
    }
    public readonly partial struct Type
    {
        public Any New(Array<Any> args) => Intrinsics.New(this, args);
    }
    public readonly partial struct Error
    {
    }
    public readonly partial struct Tuple2<T0, T1>
    {
    }
    public readonly partial struct Tuple3<T0, T1, T2>
    {
    }
    public readonly partial struct Tuple4<T0, T1, T2, T3>
    {
    }
    public readonly partial struct Tuple5<T0, T1, T2, T3, T4>
    {
    }
    public readonly partial struct Tuple6<T0, T1, T2, T3, T4, T5>
    {
    }
    public readonly partial struct Tuple7<T0, T1, T2, T3, T4, T5, T6>
    {
    }
    public readonly partial struct Tuple8<T0, T1, T2, T3, T4, T5, T6, T7>
    {
    }
    public readonly partial struct Tuple9<T0, T1, T2, T3, T4, T5, T6, T7, T8>
    {
    }
    public readonly partial struct Tuple10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
    }
    public readonly partial struct Function0<TR>
    {
        public TR Invoke => Intrinsics.Invoke(this);
    }
    public readonly partial struct Function1<T0, TR>
    {
        public TR Invoke(T0 a0) => Intrinsics.Invoke(this, a0);
    }
    public readonly partial struct Function2<T0, T1, TR>
    {
        public TR Invoke(T0 a0, T1 a1) => Intrinsics.Invoke(this, a0, a1);
    }
    public readonly partial struct Function3<T0, T1, T2, TR>
    {
        public TR Invoke(T0 a0, T1 a1, T2 a2) => Intrinsics.Invoke(this, a0, a1, a2);
    }
    public readonly partial struct Function4<T0, T1, T2, T3, TR>
    {
        public TR Invoke(T0 a0, T1 a1, T2 a2, T3 a3) => Intrinsics.Invoke(this, a0, a1, a2, a3);
    }
    public readonly partial struct Function5<T0, T1, T2, T3, T4, TR>
    {
    }
    public readonly partial struct Function6<T0, T1, T2, T3, T4, T5, TR>
    {
    }
    public readonly partial struct Function7<T0, T1, T2, T3, T4, T5, T6, TR>
    {
    }
    public readonly partial struct Function8<T0, T1, T2, T3, T4, T5, T6, T7, TR>
    {
    }
    public readonly partial struct Function9<T0, T1, T2, T3, T4, T5, T6, T7, T8, TR>
    {
    }
    public readonly partial struct Function10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TR>
    {
    }
    public readonly partial struct Unit
    {
        public Number Magnitude => this.Value;
        public Unit ClampOne => this.Clamp(this.Zero, this.One);
        public Boolean GtZ => this.GreaterThan(this.Zero);
        public Boolean LtZ => this.LessThan(this.Zero);
        public Boolean GtEqZ => this.GreaterThanOrEquals(this.Zero);
        public Boolean LtEqZ => this.LessThanOrEquals(this.Zero);
        public Boolean IsPositive => this.GtEqZ;
        public Boolean IsNegative => this.LtZ;
        public Integer Sign => this.LtZ ? ((Integer)1).Negative : this.GtZ ? ((Integer)1) : ((Integer)0);
        public Unit Abs => this.LtZ ? this.Negative : this;
        public Unit PlusOne => this.Add(this.One);
        public Unit MinusOne => this.Subtract(this.One);
        public Unit FromOne => this.One.Subtract(this);
        public Number Component(Integer n) => this.Components.At(n);
        public Integer NumComponents => this.Components.Count;
        public Unit MapComponents(System.Func<Number, Number> f) => this.FromComponents(this.Components.Map(f));
        public Unit Zero => this.MapComponents((i) => ((Number)0));
        public Unit One => this.MapComponents((i) => ((Number)1));
        public Unit MinValue => this.MapComponents((x) => x.Constants.MinNumber);
        public Unit MaxValue => this.MapComponents((x) => x.Constants.MaxNumber);
        public Boolean AllComponents(System.Func<Number, Boolean> predicate) => this.Components.All(predicate);
        public Boolean AnyComponent(System.Func<Number, Boolean> predicate) => this.Components.Any(predicate);
        public Unit Half => this.Divide(((Number)2));
        public Unit Quarter => this.Divide(((Number)4));
        public Unit Tenth => this.Divide(((Number)10));
        public Unit Twice => this.Multiply(((Number)2));
        public Unit Lerp(Unit b, Number t) => this.Multiply(t.FromOne).Add(b.Multiply(t));
        public Unit Barycentric(Unit v2, Unit v3, Vector2D uv) => this.Add(v2.Subtract(this).Multiply(uv.X).Add(v3.Subtract(this).Multiply(uv.Y)));
        public Unit Clamp(Unit a, Unit b) => this.Greater(a).Lesser(b);
        public Boolean Equals(Unit b) => this.Compare(b).Equals(((Integer)0));
        public static Boolean operator ==(Unit a, Unit b) => a.Equals(b);
        public Boolean NotEquals(Unit b) => this.Compare(b).NotEquals(((Integer)0));
        public static Boolean operator !=(Unit a, Unit b) => a.NotEquals(b);
        public Boolean LessThan(Unit b) => this.Compare(b).LessThan(((Integer)0));
        public static Boolean operator <(Unit a, Unit b) => a.LessThan(b);
        public Boolean LessThanOrEquals(Unit b) => this.Compare(b).LessThanOrEquals(((Integer)0));
        public static Boolean operator <=(Unit a, Unit b) => a.LessThanOrEquals(b);
        public Boolean GreaterThan(Unit b) => this.Compare(b).GreaterThan(((Integer)0));
        public static Boolean operator >(Unit a, Unit b) => a.GreaterThan(b);
        public Boolean GreaterThanOrEquals(Unit b) => this.Compare(b).GreaterThanOrEquals(((Integer)0));
        public static Boolean operator >=(Unit a, Unit b) => a.GreaterThanOrEquals(b);
        public Unit Lesser(Unit b) => this.LessThanOrEquals(b) ? this : b;
        public Unit Greater(Unit b) => this.GreaterThanOrEquals(b) ? this : b;
        public Unit Pow2 => this.Multiply(this);
        public Unit Pow3 => this.Pow2.Multiply(this);
        public Unit Pow4 => this.Pow3.Multiply(this);
        public Unit Pow5 => this.Pow4.Multiply(this);
        public Unit Square => this.Pow2;
        public Unit Cube => this.Pow3;
    }
    public readonly partial struct Probability
    {
        public Probability PlusOne => this.Add(this.One);
        public Probability MinusOne => this.Subtract(this.One);
        public Probability FromOne => this.One.Subtract(this);
        public Number Component(Integer n) => this.Components.At(n);
        public Integer NumComponents => this.Components.Count;
        public Probability MapComponents(System.Func<Number, Number> f) => this.FromComponents(this.Components.Map(f));
        public Probability Zero => this.MapComponents((i) => ((Number)0));
        public Probability One => this.MapComponents((i) => ((Number)1));
        public Probability MinValue => this.MapComponents((x) => x.Constants.MinNumber);
        public Probability MaxValue => this.MapComponents((x) => x.Constants.MaxNumber);
        public Boolean AllComponents(System.Func<Number, Boolean> predicate) => this.Components.All(predicate);
        public Boolean AnyComponent(System.Func<Number, Boolean> predicate) => this.Components.Any(predicate);
        public Probability Half => this.Divide(((Number)2));
        public Probability Quarter => this.Divide(((Number)4));
        public Probability Tenth => this.Divide(((Number)10));
        public Probability Twice => this.Multiply(((Number)2));
        public Probability Lerp(Probability b, Number t) => this.Multiply(t.FromOne).Add(b.Multiply(t));
        public Probability Barycentric(Probability v2, Probability v3, Vector2D uv) => this.Add(v2.Subtract(this).Multiply(uv.X).Add(v3.Subtract(this).Multiply(uv.Y)));
        public Probability Clamp(Probability a, Probability b) => this.Greater(a).Lesser(b);
        public Boolean Equals(Probability b) => this.Compare(b).Equals(((Integer)0));
        public static Boolean operator ==(Probability a, Probability b) => a.Equals(b);
        public Boolean NotEquals(Probability b) => this.Compare(b).NotEquals(((Integer)0));
        public static Boolean operator !=(Probability a, Probability b) => a.NotEquals(b);
        public Boolean LessThan(Probability b) => this.Compare(b).LessThan(((Integer)0));
        public static Boolean operator <(Probability a, Probability b) => a.LessThan(b);
        public Boolean LessThanOrEquals(Probability b) => this.Compare(b).LessThanOrEquals(((Integer)0));
        public static Boolean operator <=(Probability a, Probability b) => a.LessThanOrEquals(b);
        public Boolean GreaterThan(Probability b) => this.Compare(b).GreaterThan(((Integer)0));
        public static Boolean operator >(Probability a, Probability b) => a.GreaterThan(b);
        public Boolean GreaterThanOrEquals(Probability b) => this.Compare(b).GreaterThanOrEquals(((Integer)0));
        public static Boolean operator >=(Probability a, Probability b) => a.GreaterThanOrEquals(b);
        public Probability Lesser(Probability b) => this.LessThanOrEquals(b) ? this : b;
        public Probability Greater(Probability b) => this.GreaterThanOrEquals(b) ? this : b;
    }
    public readonly partial struct Complex
    {
        public Integer Count => ((Integer)2);
        public Number At(Integer n) => n.Equals(((Integer)0)) ? this.Real : this.Imaginary;
        public Number this[Integer n] => At(n);
        public Number Length => this.Magnitude;
        public Number LengthSquared => this.MagnitudeSquared;
        public Number Sum => this.Reduce(((Number)0), (a, b) => a.Add(b));
        public Number SumSquares => this.Square.Sum;
        public Number MagnitudeSquared => this.SumSquares;
        public Number Magnitude => this.MagnitudeSquared.SquareRoot;
        public Number Dot(Complex v2) => this.Multiply(v2).Sum;
        public Number Average => this.Sum.Divide(this.Count);
        public Complex Normalize => this.MagnitudeSquared.GreaterThan(((Integer)0)) ? this.Divide(this.Magnitude) : this.Zero;
        public Complex Reflect(Complex normal) => this.Subtract(normal.Multiply(this.Dot(normal).Multiply(((Number)2))));
        public Complex Project(Complex other) => other.Multiply(this.Dot(other));
        public Number Distance(Complex b) => b.Subtract(this).Magnitude;
        public Number DistanceSquared(Complex b) => b.Subtract(this).Magnitude;
        public Angle Angle(Complex b) => this.Dot(b).Divide(this.Magnitude.Multiply(b.Magnitude)).Acos;
        public Complex PlusOne => this.Add(this.One);
        public Complex MinusOne => this.Subtract(this.One);
        public Complex FromOne => this.One.Subtract(this);
        public Number Component(Integer n) => this.Components.At(n);
        public Integer NumComponents => this.Components.Count;
        public Complex MapComponents(System.Func<Number, Number> f) => this.FromComponents(this.Components.Map(f));
        public Complex Zero => this.MapComponents((i) => ((Number)0));
        public Complex One => this.MapComponents((i) => ((Number)1));
        public Complex MinValue => this.MapComponents((x) => x.Constants.MinNumber);
        public Complex MaxValue => this.MapComponents((x) => x.Constants.MaxNumber);
        public Boolean AllComponents(System.Func<Number, Boolean> predicate) => this.Components.All(predicate);
        public Boolean AnyComponent(System.Func<Number, Boolean> predicate) => this.Components.Any(predicate);
        public Complex Half => this.Divide(((Number)2));
        public Complex Quarter => this.Divide(((Number)4));
        public Complex Tenth => this.Divide(((Number)10));
        public Complex Twice => this.Multiply(((Number)2));
        public Complex Lerp(Complex b, Number t) => this.Multiply(t.FromOne).Add(b.Multiply(t));
        public Complex Barycentric(Complex v2, Complex v3, Vector2D uv) => this.Add(v2.Subtract(this).Multiply(uv.X).Add(v3.Subtract(this).Multiply(uv.Y)));
        public Complex Pow2 => this.Multiply(this);
        public Complex Pow3 => this.Pow2.Multiply(this);
        public Complex Pow4 => this.Pow3.Multiply(this);
        public Complex Pow5 => this.Pow4.Multiply(this);
        public Complex Square => this.Pow2;
        public Complex Cube => this.Pow3;
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Number First => this.At(((Integer)0));
        public Number Last => this.At(this.Count.Subtract(((Integer)1)));
        public Number Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public Complex Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public Complex Subarray(Integer from, Integer count)
        {
            var _var182 = from;
            {
                var _var181 = this;
                return count.Map((i) => _var181.At(i.Add(_var182)));
            }
        }
        public Complex Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public Complex Take(Integer n) => this.Subarray(((Integer)0), n);
        public Complex Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public Complex SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public Complex Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Number, TAcc> f) => f(f(init, Real), Imaginary);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public Complex PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var185 = this;
            {
                var _var184 = this;
                {
                    var _var183 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var184.At(i)._var183(_var185.At(i.Add(((Integer)1)))));
                }
            }
        }
        public Complex PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var189 = this;
            {
                var _var188 = this;
                {
                    var _var187 = this;
                    {
                        var _var186 = f;
                        return this.Count.Map((i) => _var187.At(i)._var186(_var188.At(i.Add(((Integer)1).Modulo(_var189.Count)))));
                    }
                }
            }
        }
        public Complex Zip<T0, T1, TR>(Complex ys, System.Func<T0, T1, TR> f)
        {
            var _var192 = ys;
            {
                var _var191 = this;
                {
                    var _var190 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var191.At(i)._var190(_var192.At(i)));
                }
            }
        }
    }
    public readonly partial struct Integer2
    {
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Integer First => this.At(((Integer)0));
        public Integer Last => this.At(this.Count.Subtract(((Integer)1)));
        public Integer Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public Integer2 Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public Integer2 Subarray(Integer from, Integer count)
        {
            var _var194 = from;
            {
                var _var193 = this;
                return count.Map((i) => _var193.At(i.Add(_var194)));
            }
        }
        public Integer2 Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public Integer2 Take(Integer n) => this.Subarray(((Integer)0), n);
        public Integer2 Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public Integer2 SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public Integer2 Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Integer, TAcc> f) => f(f(init, A), B);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public Integer2 PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var197 = this;
            {
                var _var196 = this;
                {
                    var _var195 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var196.At(i)._var195(_var197.At(i.Add(((Integer)1)))));
                }
            }
        }
        public Integer2 PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var201 = this;
            {
                var _var200 = this;
                {
                    var _var199 = this;
                    {
                        var _var198 = f;
                        return this.Count.Map((i) => _var199.At(i)._var198(_var200.At(i.Add(((Integer)1).Modulo(_var201.Count)))));
                    }
                }
            }
        }
        public Integer2 Zip<T0, T1, TR>(Integer2 ys, System.Func<T0, T1, TR> f)
        {
            var _var204 = ys;
            {
                var _var203 = this;
                {
                    var _var202 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var203.At(i)._var202(_var204.At(i)));
                }
            }
        }
    }
    public readonly partial struct Integer3
    {
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Integer First => this.At(((Integer)0));
        public Integer Last => this.At(this.Count.Subtract(((Integer)1)));
        public Integer Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public Integer3 Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public Integer3 Subarray(Integer from, Integer count)
        {
            var _var206 = from;
            {
                var _var205 = this;
                return count.Map((i) => _var205.At(i.Add(_var206)));
            }
        }
        public Integer3 Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public Integer3 Take(Integer n) => this.Subarray(((Integer)0), n);
        public Integer3 Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public Integer3 SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public Integer3 Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Integer, TAcc> f) => f(f(f(init, A), B), C);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public Integer3 PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var209 = this;
            {
                var _var208 = this;
                {
                    var _var207 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var208.At(i)._var207(_var209.At(i.Add(((Integer)1)))));
                }
            }
        }
        public Integer3 PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var213 = this;
            {
                var _var212 = this;
                {
                    var _var211 = this;
                    {
                        var _var210 = f;
                        return this.Count.Map((i) => _var211.At(i)._var210(_var212.At(i.Add(((Integer)1).Modulo(_var213.Count)))));
                    }
                }
            }
        }
        public Integer3 Zip<T0, T1, TR>(Integer3 ys, System.Func<T0, T1, TR> f)
        {
            var _var216 = ys;
            {
                var _var215 = this;
                {
                    var _var214 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var215.At(i)._var214(_var216.At(i)));
                }
            }
        }
    }
    public readonly partial struct Integer4
    {
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Integer First => this.At(((Integer)0));
        public Integer Last => this.At(this.Count.Subtract(((Integer)1)));
        public Integer Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public Integer4 Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public Integer4 Subarray(Integer from, Integer count)
        {
            var _var218 = from;
            {
                var _var217 = this;
                return count.Map((i) => _var217.At(i.Add(_var218)));
            }
        }
        public Integer4 Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public Integer4 Take(Integer n) => this.Subarray(((Integer)0), n);
        public Integer4 Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public Integer4 SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public Integer4 Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Integer, TAcc> f) => f(f(f(f(init, A), B), C), D);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public Integer4 PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var221 = this;
            {
                var _var220 = this;
                {
                    var _var219 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var220.At(i)._var219(_var221.At(i.Add(((Integer)1)))));
                }
            }
        }
        public Integer4 PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var225 = this;
            {
                var _var224 = this;
                {
                    var _var223 = this;
                    {
                        var _var222 = f;
                        return this.Count.Map((i) => _var223.At(i)._var222(_var224.At(i.Add(((Integer)1).Modulo(_var225.Count)))));
                    }
                }
            }
        }
        public Integer4 Zip<T0, T1, TR>(Integer4 ys, System.Func<T0, T1, TR> f)
        {
            var _var228 = ys;
            {
                var _var227 = this;
                {
                    var _var226 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var227.At(i)._var226(_var228.At(i)));
                }
            }
        }
    }
    public readonly partial struct Color
    {
    }
    public readonly partial struct ColorLUV
    {
    }
    public readonly partial struct ColorLAB
    {
    }
    public readonly partial struct ColorLCh
    {
    }
    public readonly partial struct ColorHSV
    {
    }
    public readonly partial struct ColorHSL
    {
    }
    public readonly partial struct ColorYCbCr
    {
    }
    public readonly partial struct SphericalCoordinate
    {
    }
    public readonly partial struct PolarCoordinate
    {
    }
    public readonly partial struct LogPolarCoordinate
    {
    }
    public readonly partial struct CylindricalCoordinate
    {
    }
    public readonly partial struct HorizontalCoordinate
    {
    }
    public readonly partial struct GeoCoordinate
    {
    }
    public readonly partial struct GeoCoordinateWithAltitude
    {
    }
    public readonly partial struct Size2D
    {
        public static implicit operator Vector2D(Size2D a) => a.Width.Tuple2(a.Height);
        public Vector2D Vector2D => this.Width.Tuple2(this.Height);
    }
    public readonly partial struct Size3D
    {
    }
    public readonly partial struct Rational
    {
    }
    public readonly partial struct Fraction
    {
    }
    public readonly partial struct Angle
    {
        public Vector2D Circle => this.Sin.Tuple2(this.Cos);
        public Vector2D Lissajous(Number kx, Number ky) => this.Multiply(kx).Cos.Tuple2(this.Multiply(ky).Sin);
        public Vector2D ButterflyCurve => this.Multiply(this.Cos.Exp.Subtract(((Number)2).Multiply(this.Multiply(((Number)4)).Cos).Subtract(this.Divide(((Number)12)).Sin.Pow(((Number)5))))).Sin.Tuple2(this.Multiply(this.Cos.Exp.Subtract(((Number)2).Multiply(this.Multiply(((Number)4)).Cos).Subtract(this.Divide(((Number)12)).Sin.Pow(((Number)5))))).Cos);
        public Vector3D TorusKnot(Number p, Number q)
        {
            var r = this.Multiply(q).Cos.Add(((Number)2));
            var x = r.Multiply(this.Multiply(p).Cos);
            var y = r.Multiply(this.Multiply(p).Sin);
            var z = this.Multiply(q).Sin.Negative;
            return x.Tuple3(y, z);
        }
        public Vector3D TrefoilKnot => this.Sin.Add(this.Multiply(((Number)2)).Sin.Multiply(((Number)2))).Tuple3(this.Cos.Add(this.Multiply(((Number)2)).Cos.Multiply(((Number)2))), this.Multiply(((Number)3)).Sin.Negative);
        public Vector3D FigureEightKnot => ((Number)2).Add(this.Multiply(((Number)2)).Cos).Multiply(this.Multiply(((Number)3)).Cos).Tuple3(((Number)2).Add(this.Multiply(((Number)2)).Cos).Multiply(this.Multiply(((Number)3)).Sin), this.Multiply(((Number)4)).Sin);
        public Number Cos => Intrinsics.Cos(this);
        public Number Sin => Intrinsics.Sin(this);
        public Number Tan => Intrinsics.Tan(this);
        public Number Turns => this.Radians.Divide(Constants.TwoPi);
        public Number Degrees => this.Turns.Multiply(((Number)360));
        public Number Gradians => this.Turns.Multiply(((Number)400));
        public Angle PlusOne => this.Add(this.One);
        public Angle MinusOne => this.Subtract(this.One);
        public Angle FromOne => this.One.Subtract(this);
        public Number Component(Integer n) => this.Components.At(n);
        public Integer NumComponents => this.Components.Count;
        public Angle MapComponents(System.Func<Number, Number> f) => this.FromComponents(this.Components.Map(f));
        public Angle Zero => this.MapComponents((i) => ((Number)0));
        public Angle One => this.MapComponents((i) => ((Number)1));
        public Angle MinValue => this.MapComponents((x) => x.Constants.MinNumber);
        public Angle MaxValue => this.MapComponents((x) => x.Constants.MaxNumber);
        public Boolean AllComponents(System.Func<Number, Boolean> predicate) => this.Components.All(predicate);
        public Boolean AnyComponent(System.Func<Number, Boolean> predicate) => this.Components.Any(predicate);
        public Angle Half => this.Divide(((Number)2));
        public Angle Quarter => this.Divide(((Number)4));
        public Angle Tenth => this.Divide(((Number)10));
        public Angle Twice => this.Multiply(((Number)2));
        public Angle Lerp(Angle b, Number t) => this.Multiply(t.FromOne).Add(b.Multiply(t));
        public Angle Barycentric(Angle v2, Angle v3, Vector2D uv) => this.Add(v2.Subtract(this).Multiply(uv.X).Add(v3.Subtract(this).Multiply(uv.Y)));
        public Angle Clamp(Angle a, Angle b) => this.Greater(a).Lesser(b);
        public Boolean Equals(Angle b) => this.Compare(b).Equals(((Integer)0));
        public static Boolean operator ==(Angle a, Angle b) => a.Equals(b);
        public Boolean NotEquals(Angle b) => this.Compare(b).NotEquals(((Integer)0));
        public static Boolean operator !=(Angle a, Angle b) => a.NotEquals(b);
        public Boolean LessThan(Angle b) => this.Compare(b).LessThan(((Integer)0));
        public static Boolean operator <(Angle a, Angle b) => a.LessThan(b);
        public Boolean LessThanOrEquals(Angle b) => this.Compare(b).LessThanOrEquals(((Integer)0));
        public static Boolean operator <=(Angle a, Angle b) => a.LessThanOrEquals(b);
        public Boolean GreaterThan(Angle b) => this.Compare(b).GreaterThan(((Integer)0));
        public static Boolean operator >(Angle a, Angle b) => a.GreaterThan(b);
        public Boolean GreaterThanOrEquals(Angle b) => this.Compare(b).GreaterThanOrEquals(((Integer)0));
        public static Boolean operator >=(Angle a, Angle b) => a.GreaterThanOrEquals(b);
        public Angle Lesser(Angle b) => this.LessThanOrEquals(b) ? this : b;
        public Angle Greater(Angle b) => this.GreaterThanOrEquals(b) ? this : b;
    }
    public readonly partial struct Length
    {
        public Length PlusOne => this.Add(this.One);
        public Length MinusOne => this.Subtract(this.One);
        public Length FromOne => this.One.Subtract(this);
        public Number Component(Integer n) => this.Components.At(n);
        public Integer NumComponents => this.Components.Count;
        public Length MapComponents(System.Func<Number, Number> f) => this.FromComponents(this.Components.Map(f));
        public Length Zero => this.MapComponents((i) => ((Number)0));
        public Length One => this.MapComponents((i) => ((Number)1));
        public Length MinValue => this.MapComponents((x) => x.Constants.MinNumber);
        public Length MaxValue => this.MapComponents((x) => x.Constants.MaxNumber);
        public Boolean AllComponents(System.Func<Number, Boolean> predicate) => this.Components.All(predicate);
        public Boolean AnyComponent(System.Func<Number, Boolean> predicate) => this.Components.Any(predicate);
        public Length Half => this.Divide(((Number)2));
        public Length Quarter => this.Divide(((Number)4));
        public Length Tenth => this.Divide(((Number)10));
        public Length Twice => this.Multiply(((Number)2));
        public Length Lerp(Length b, Number t) => this.Multiply(t.FromOne).Add(b.Multiply(t));
        public Length Barycentric(Length v2, Length v3, Vector2D uv) => this.Add(v2.Subtract(this).Multiply(uv.X).Add(v3.Subtract(this).Multiply(uv.Y)));
        public Length Clamp(Length a, Length b) => this.Greater(a).Lesser(b);
        public Boolean Equals(Length b) => this.Compare(b).Equals(((Integer)0));
        public static Boolean operator ==(Length a, Length b) => a.Equals(b);
        public Boolean NotEquals(Length b) => this.Compare(b).NotEquals(((Integer)0));
        public static Boolean operator !=(Length a, Length b) => a.NotEquals(b);
        public Boolean LessThan(Length b) => this.Compare(b).LessThan(((Integer)0));
        public static Boolean operator <(Length a, Length b) => a.LessThan(b);
        public Boolean LessThanOrEquals(Length b) => this.Compare(b).LessThanOrEquals(((Integer)0));
        public static Boolean operator <=(Length a, Length b) => a.LessThanOrEquals(b);
        public Boolean GreaterThan(Length b) => this.Compare(b).GreaterThan(((Integer)0));
        public static Boolean operator >(Length a, Length b) => a.GreaterThan(b);
        public Boolean GreaterThanOrEquals(Length b) => this.Compare(b).GreaterThanOrEquals(((Integer)0));
        public static Boolean operator >=(Length a, Length b) => a.GreaterThanOrEquals(b);
        public Length Lesser(Length b) => this.LessThanOrEquals(b) ? this : b;
        public Length Greater(Length b) => this.GreaterThanOrEquals(b) ? this : b;
    }
    public readonly partial struct Mass
    {
        public Mass PlusOne => this.Add(this.One);
        public Mass MinusOne => this.Subtract(this.One);
        public Mass FromOne => this.One.Subtract(this);
        public Number Component(Integer n) => this.Components.At(n);
        public Integer NumComponents => this.Components.Count;
        public Mass MapComponents(System.Func<Number, Number> f) => this.FromComponents(this.Components.Map(f));
        public Mass Zero => this.MapComponents((i) => ((Number)0));
        public Mass One => this.MapComponents((i) => ((Number)1));
        public Mass MinValue => this.MapComponents((x) => x.Constants.MinNumber);
        public Mass MaxValue => this.MapComponents((x) => x.Constants.MaxNumber);
        public Boolean AllComponents(System.Func<Number, Boolean> predicate) => this.Components.All(predicate);
        public Boolean AnyComponent(System.Func<Number, Boolean> predicate) => this.Components.Any(predicate);
        public Mass Half => this.Divide(((Number)2));
        public Mass Quarter => this.Divide(((Number)4));
        public Mass Tenth => this.Divide(((Number)10));
        public Mass Twice => this.Multiply(((Number)2));
        public Mass Lerp(Mass b, Number t) => this.Multiply(t.FromOne).Add(b.Multiply(t));
        public Mass Barycentric(Mass v2, Mass v3, Vector2D uv) => this.Add(v2.Subtract(this).Multiply(uv.X).Add(v3.Subtract(this).Multiply(uv.Y)));
        public Mass Clamp(Mass a, Mass b) => this.Greater(a).Lesser(b);
        public Boolean Equals(Mass b) => this.Compare(b).Equals(((Integer)0));
        public static Boolean operator ==(Mass a, Mass b) => a.Equals(b);
        public Boolean NotEquals(Mass b) => this.Compare(b).NotEquals(((Integer)0));
        public static Boolean operator !=(Mass a, Mass b) => a.NotEquals(b);
        public Boolean LessThan(Mass b) => this.Compare(b).LessThan(((Integer)0));
        public static Boolean operator <(Mass a, Mass b) => a.LessThan(b);
        public Boolean LessThanOrEquals(Mass b) => this.Compare(b).LessThanOrEquals(((Integer)0));
        public static Boolean operator <=(Mass a, Mass b) => a.LessThanOrEquals(b);
        public Boolean GreaterThan(Mass b) => this.Compare(b).GreaterThan(((Integer)0));
        public static Boolean operator >(Mass a, Mass b) => a.GreaterThan(b);
        public Boolean GreaterThanOrEquals(Mass b) => this.Compare(b).GreaterThanOrEquals(((Integer)0));
        public static Boolean operator >=(Mass a, Mass b) => a.GreaterThanOrEquals(b);
        public Mass Lesser(Mass b) => this.LessThanOrEquals(b) ? this : b;
        public Mass Greater(Mass b) => this.GreaterThanOrEquals(b) ? this : b;
    }
    public readonly partial struct Temperature
    {
        public Temperature PlusOne => this.Add(this.One);
        public Temperature MinusOne => this.Subtract(this.One);
        public Temperature FromOne => this.One.Subtract(this);
        public Number Component(Integer n) => this.Components.At(n);
        public Integer NumComponents => this.Components.Count;
        public Temperature MapComponents(System.Func<Number, Number> f) => this.FromComponents(this.Components.Map(f));
        public Temperature Zero => this.MapComponents((i) => ((Number)0));
        public Temperature One => this.MapComponents((i) => ((Number)1));
        public Temperature MinValue => this.MapComponents((x) => x.Constants.MinNumber);
        public Temperature MaxValue => this.MapComponents((x) => x.Constants.MaxNumber);
        public Boolean AllComponents(System.Func<Number, Boolean> predicate) => this.Components.All(predicate);
        public Boolean AnyComponent(System.Func<Number, Boolean> predicate) => this.Components.Any(predicate);
        public Temperature Half => this.Divide(((Number)2));
        public Temperature Quarter => this.Divide(((Number)4));
        public Temperature Tenth => this.Divide(((Number)10));
        public Temperature Twice => this.Multiply(((Number)2));
        public Temperature Lerp(Temperature b, Number t) => this.Multiply(t.FromOne).Add(b.Multiply(t));
        public Temperature Barycentric(Temperature v2, Temperature v3, Vector2D uv) => this.Add(v2.Subtract(this).Multiply(uv.X).Add(v3.Subtract(this).Multiply(uv.Y)));
        public Temperature Clamp(Temperature a, Temperature b) => this.Greater(a).Lesser(b);
        public Boolean Equals(Temperature b) => this.Compare(b).Equals(((Integer)0));
        public static Boolean operator ==(Temperature a, Temperature b) => a.Equals(b);
        public Boolean NotEquals(Temperature b) => this.Compare(b).NotEquals(((Integer)0));
        public static Boolean operator !=(Temperature a, Temperature b) => a.NotEquals(b);
        public Boolean LessThan(Temperature b) => this.Compare(b).LessThan(((Integer)0));
        public static Boolean operator <(Temperature a, Temperature b) => a.LessThan(b);
        public Boolean LessThanOrEquals(Temperature b) => this.Compare(b).LessThanOrEquals(((Integer)0));
        public static Boolean operator <=(Temperature a, Temperature b) => a.LessThanOrEquals(b);
        public Boolean GreaterThan(Temperature b) => this.Compare(b).GreaterThan(((Integer)0));
        public static Boolean operator >(Temperature a, Temperature b) => a.GreaterThan(b);
        public Boolean GreaterThanOrEquals(Temperature b) => this.Compare(b).GreaterThanOrEquals(((Integer)0));
        public static Boolean operator >=(Temperature a, Temperature b) => a.GreaterThanOrEquals(b);
        public Temperature Lesser(Temperature b) => this.LessThanOrEquals(b) ? this : b;
        public Temperature Greater(Temperature b) => this.GreaterThanOrEquals(b) ? this : b;
    }
    public readonly partial struct Time
    {
        public Time PlusOne => this.Add(this.One);
        public Time MinusOne => this.Subtract(this.One);
        public Time FromOne => this.One.Subtract(this);
        public Number Component(Integer n) => this.Components.At(n);
        public Integer NumComponents => this.Components.Count;
        public Time MapComponents(System.Func<Number, Number> f) => this.FromComponents(this.Components.Map(f));
        public Time Zero => this.MapComponents((i) => ((Number)0));
        public Time One => this.MapComponents((i) => ((Number)1));
        public Time MinValue => this.MapComponents((x) => x.Constants.MinNumber);
        public Time MaxValue => this.MapComponents((x) => x.Constants.MaxNumber);
        public Boolean AllComponents(System.Func<Number, Boolean> predicate) => this.Components.All(predicate);
        public Boolean AnyComponent(System.Func<Number, Boolean> predicate) => this.Components.Any(predicate);
        public Time Half => this.Divide(((Number)2));
        public Time Quarter => this.Divide(((Number)4));
        public Time Tenth => this.Divide(((Number)10));
        public Time Twice => this.Multiply(((Number)2));
        public Time Lerp(Time b, Number t) => this.Multiply(t.FromOne).Add(b.Multiply(t));
        public Time Barycentric(Time v2, Time v3, Vector2D uv) => this.Add(v2.Subtract(this).Multiply(uv.X).Add(v3.Subtract(this).Multiply(uv.Y)));
        public Time Clamp(Time a, Time b) => this.Greater(a).Lesser(b);
        public Boolean Equals(Time b) => this.Compare(b).Equals(((Integer)0));
        public static Boolean operator ==(Time a, Time b) => a.Equals(b);
        public Boolean NotEquals(Time b) => this.Compare(b).NotEquals(((Integer)0));
        public static Boolean operator !=(Time a, Time b) => a.NotEquals(b);
        public Boolean LessThan(Time b) => this.Compare(b).LessThan(((Integer)0));
        public static Boolean operator <(Time a, Time b) => a.LessThan(b);
        public Boolean LessThanOrEquals(Time b) => this.Compare(b).LessThanOrEquals(((Integer)0));
        public static Boolean operator <=(Time a, Time b) => a.LessThanOrEquals(b);
        public Boolean GreaterThan(Time b) => this.Compare(b).GreaterThan(((Integer)0));
        public static Boolean operator >(Time a, Time b) => a.GreaterThan(b);
        public Boolean GreaterThanOrEquals(Time b) => this.Compare(b).GreaterThanOrEquals(((Integer)0));
        public static Boolean operator >=(Time a, Time b) => a.GreaterThanOrEquals(b);
        public Time Lesser(Time b) => this.LessThanOrEquals(b) ? this : b;
        public Time Greater(Time b) => this.GreaterThanOrEquals(b) ? this : b;
    }
    public readonly partial struct DateTime
    {
    }
    public readonly partial struct AnglePair
    {
        public Angle Size => this.Max.Subtract(this.Min);
        public Angle Lerp(Number amount) => this.Min.Lerp(this.Max, amount);
        public AnglePair Reverse => this.Max.Tuple2(this.Min);
        public Angle Center => this.Lerp(((Number)0.5));
        public Boolean Contains(Angle value) => value.Between(this.Min, this.Max);
        public Boolean Contains(AnglePair y) => this.Contains(y.Min).And(this.Contains(y.Max));
        public Boolean Overlaps(AnglePair y) => this.Contains(y.Min).Or(this.Contains(y.Max).Or(y.Contains(this.Min).Or(y.Contains(this.Max))));
        public Tuple2<AnglePair, AnglePair> SplitAt(Number t) => this.Left(t).Tuple2(this.Right(t));
        public Tuple2<AnglePair, AnglePair> Split => this.SplitAt(((Number)0.5));
        public AnglePair Left(Number t) => this.Min.Tuple2(this.Lerp(t));
        public AnglePair Right(Number t) => this.Lerp(t).Tuple2(this.Max);
        public AnglePair MoveTo(Angle v) => v.Tuple2(v.Add(this.Size));
        public AnglePair LeftHalf => this.Left(((Number)0.5));
        public AnglePair RightHalf => this.Right(((Number)0.5));
        public AnglePair Recenter(Angle c) => c.Subtract(this.Size.Half).Tuple2(c.Add(this.Size.Half));
        public AnglePair Clamp(AnglePair y) => this.Clamp(y.Min).Tuple2(this.Clamp(y.Max));
        public Angle Clamp(Angle value) => value.Clamp(this.Min, this.Max);
    }
    public readonly partial struct NumberInterval
    {
        public Number Size => this.Max.Subtract(this.Min);
        public Number Lerp(Number amount) => this.Min.Lerp(this.Max, amount);
        public NumberInterval Reverse => this.Max.Tuple2(this.Min);
        public Number Center => this.Lerp(((Number)0.5));
        public Boolean Contains(Number value) => value.Between(this.Min, this.Max);
        public Boolean Contains(NumberInterval y) => this.Contains(y.Min).And(this.Contains(y.Max));
        public Boolean Overlaps(NumberInterval y) => this.Contains(y.Min).Or(this.Contains(y.Max).Or(y.Contains(this.Min).Or(y.Contains(this.Max))));
        public Tuple2<NumberInterval, NumberInterval> SplitAt(Number t) => this.Left(t).Tuple2(this.Right(t));
        public Tuple2<NumberInterval, NumberInterval> Split => this.SplitAt(((Number)0.5));
        public NumberInterval Left(Number t) => this.Min.Tuple2(this.Lerp(t));
        public NumberInterval Right(Number t) => this.Lerp(t).Tuple2(this.Max);
        public NumberInterval MoveTo(Number v) => v.Tuple2(v.Add(this.Size));
        public NumberInterval LeftHalf => this.Left(((Number)0.5));
        public NumberInterval RightHalf => this.Right(((Number)0.5));
        public NumberInterval Recenter(Number c) => c.Subtract(this.Size.Half).Tuple2(c.Add(this.Size.Half));
        public NumberInterval Clamp(NumberInterval y) => this.Clamp(y.Min).Tuple2(this.Clamp(y.Max));
        public Number Clamp(Number value) => value.Clamp(this.Min, this.Max);
    }
    public readonly partial struct Vector2D
    {
        public static implicit operator Vector3D(Vector2D v) => v.X.Tuple3(v.Y, ((Integer)0));
        public Vector3D Vector3D => this.X.Tuple3(this.Y, ((Integer)0));
        public Integer Count => ((Integer)2);
        public Number At(Integer n) => n.Equals(((Integer)0)) ? this.X : this.Y;
        public Number this[Integer n] => At(n);
        public Number Cross(Vector2D b) => this.X.Multiply(b.Y).Subtract(this.Y.Multiply(b.X));
        public Number Length => this.Magnitude;
        public Number LengthSquared => this.MagnitudeSquared;
        public Number Sum => this.Reduce(((Number)0), (a, b) => a.Add(b));
        public Number SumSquares => this.Square.Sum;
        public Number MagnitudeSquared => this.SumSquares;
        public Number Magnitude => this.MagnitudeSquared.SquareRoot;
        public Number Dot(Vector2D v2) => this.Multiply(v2).Sum;
        public Number Average => this.Sum.Divide(this.Count);
        public Vector2D Normalize => this.MagnitudeSquared.GreaterThan(((Integer)0)) ? this.Divide(this.Magnitude) : this.Zero;
        public Vector2D Reflect(Vector2D normal) => this.Subtract(normal.Multiply(this.Dot(normal).Multiply(((Number)2))));
        public Vector2D Project(Vector2D other) => other.Multiply(this.Dot(other));
        public Number Distance(Vector2D b) => b.Subtract(this).Magnitude;
        public Number DistanceSquared(Vector2D b) => b.Subtract(this).Magnitude;
        public Angle Angle(Vector2D b) => this.Dot(b).Divide(this.Magnitude.Multiply(b.Magnitude)).Acos;
        public Vector2D PlusOne => this.Add(this.One);
        public Vector2D MinusOne => this.Subtract(this.One);
        public Vector2D FromOne => this.One.Subtract(this);
        public Number Component(Integer n) => this.Components.At(n);
        public Integer NumComponents => this.Components.Count;
        public Vector2D MapComponents(System.Func<Number, Number> f) => this.FromComponents(this.Components.Map(f));
        public Vector2D Zero => this.MapComponents((i) => ((Number)0));
        public Vector2D One => this.MapComponents((i) => ((Number)1));
        public Vector2D MinValue => this.MapComponents((x) => x.Constants.MinNumber);
        public Vector2D MaxValue => this.MapComponents((x) => x.Constants.MaxNumber);
        public Boolean AllComponents(System.Func<Number, Boolean> predicate) => this.Components.All(predicate);
        public Boolean AnyComponent(System.Func<Number, Boolean> predicate) => this.Components.Any(predicate);
        public Vector2D Half => this.Divide(((Number)2));
        public Vector2D Quarter => this.Divide(((Number)4));
        public Vector2D Tenth => this.Divide(((Number)10));
        public Vector2D Twice => this.Multiply(((Number)2));
        public Vector2D Lerp(Vector2D b, Number t) => this.Multiply(t.FromOne).Add(b.Multiply(t));
        public Vector2D Barycentric(Vector2D v2, Vector2D v3, Vector2D uv) => this.Add(v2.Subtract(this).Multiply(uv.X).Add(v3.Subtract(this).Multiply(uv.Y)));
        public Vector2D Pow2 => this.Multiply(this);
        public Vector2D Pow3 => this.Pow2.Multiply(this);
        public Vector2D Pow4 => this.Pow3.Multiply(this);
        public Vector2D Pow5 => this.Pow4.Multiply(this);
        public Vector2D Square => this.Pow2;
        public Vector2D Cube => this.Pow3;
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Number First => this.At(((Integer)0));
        public Number Last => this.At(this.Count.Subtract(((Integer)1)));
        public Number Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public Vector2D Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public Vector2D Subarray(Integer from, Integer count)
        {
            var _var230 = from;
            {
                var _var229 = this;
                return count.Map((i) => _var229.At(i.Add(_var230)));
            }
        }
        public Vector2D Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public Vector2D Take(Integer n) => this.Subarray(((Integer)0), n);
        public Vector2D Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public Vector2D SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public Vector2D Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Number, TAcc> f) => f(f(init, X), Y);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public Vector2D PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var233 = this;
            {
                var _var232 = this;
                {
                    var _var231 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var232.At(i)._var231(_var233.At(i.Add(((Integer)1)))));
                }
            }
        }
        public Vector2D PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var237 = this;
            {
                var _var236 = this;
                {
                    var _var235 = this;
                    {
                        var _var234 = f;
                        return this.Count.Map((i) => _var235.At(i)._var234(_var236.At(i.Add(((Integer)1).Modulo(_var237.Count)))));
                    }
                }
            }
        }
        public Vector2D Zip<T0, T1, TR>(Vector2D ys, System.Func<T0, T1, TR> f)
        {
            var _var240 = ys;
            {
                var _var239 = this;
                {
                    var _var238 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var239.At(i)._var238(_var240.At(i)));
                }
            }
        }
    }
    public readonly partial struct Vector3D
    {
        public static implicit operator Vector4D(Vector3D v) => v.X.Tuple4(v.Y, v.Z, ((Integer)0));
        public Vector4D Vector4D => this.X.Tuple4(this.Y, this.Z, ((Integer)0));
        public Vector2D To2D => this.X.Tuple2(this.Y);
        public Integer Count => ((Integer)3);
        public Number At(Integer n) => n.Equals(((Integer)0)) ? this.X : n.Equals(((Integer)1)) ? this.Y : this.Z;
        public Number this[Integer n] => At(n);
        public Vector3D Cross(Vector3D b) => this.Y.Multiply(b.Z).Subtract(this.Z.Multiply(b.Y)).Tuple3(this.Z.Multiply(b.X).Subtract(this.X.Multiply(b.Z)), this.X.Multiply(b.Y).Subtract(this.Y.Multiply(b.X)));
        public Number MixedProduct(Vector3D b, Vector3D c) => this.Cross(b).Dot(c);
        public Number Length => this.Magnitude;
        public Number LengthSquared => this.MagnitudeSquared;
        public Number Sum => this.Reduce(((Number)0), (a, b) => a.Add(b));
        public Number SumSquares => this.Square.Sum;
        public Number MagnitudeSquared => this.SumSquares;
        public Number Magnitude => this.MagnitudeSquared.SquareRoot;
        public Number Dot(Vector3D v2) => this.Multiply(v2).Sum;
        public Number Average => this.Sum.Divide(this.Count);
        public Vector3D Normalize => this.MagnitudeSquared.GreaterThan(((Integer)0)) ? this.Divide(this.Magnitude) : this.Zero;
        public Vector3D Reflect(Vector3D normal) => this.Subtract(normal.Multiply(this.Dot(normal).Multiply(((Number)2))));
        public Vector3D Project(Vector3D other) => other.Multiply(this.Dot(other));
        public Number Distance(Vector3D b) => b.Subtract(this).Magnitude;
        public Number DistanceSquared(Vector3D b) => b.Subtract(this).Magnitude;
        public Angle Angle(Vector3D b) => this.Dot(b).Divide(this.Magnitude.Multiply(b.Magnitude)).Acos;
        public Vector3D PlusOne => this.Add(this.One);
        public Vector3D MinusOne => this.Subtract(this.One);
        public Vector3D FromOne => this.One.Subtract(this);
        public Number Component(Integer n) => this.Components.At(n);
        public Integer NumComponents => this.Components.Count;
        public Vector3D MapComponents(System.Func<Number, Number> f) => this.FromComponents(this.Components.Map(f));
        public Vector3D Zero => this.MapComponents((i) => ((Number)0));
        public Vector3D One => this.MapComponents((i) => ((Number)1));
        public Vector3D MinValue => this.MapComponents((x) => x.Constants.MinNumber);
        public Vector3D MaxValue => this.MapComponents((x) => x.Constants.MaxNumber);
        public Boolean AllComponents(System.Func<Number, Boolean> predicate) => this.Components.All(predicate);
        public Boolean AnyComponent(System.Func<Number, Boolean> predicate) => this.Components.Any(predicate);
        public Vector3D Half => this.Divide(((Number)2));
        public Vector3D Quarter => this.Divide(((Number)4));
        public Vector3D Tenth => this.Divide(((Number)10));
        public Vector3D Twice => this.Multiply(((Number)2));
        public Vector3D Lerp(Vector3D b, Number t) => this.Multiply(t.FromOne).Add(b.Multiply(t));
        public Vector3D Barycentric(Vector3D v2, Vector3D v3, Vector2D uv) => this.Add(v2.Subtract(this).Multiply(uv.X).Add(v3.Subtract(this).Multiply(uv.Y)));
        public Vector3D Pow2 => this.Multiply(this);
        public Vector3D Pow3 => this.Pow2.Multiply(this);
        public Vector3D Pow4 => this.Pow3.Multiply(this);
        public Vector3D Pow5 => this.Pow4.Multiply(this);
        public Vector3D Square => this.Pow2;
        public Vector3D Cube => this.Pow3;
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Number First => this.At(((Integer)0));
        public Number Last => this.At(this.Count.Subtract(((Integer)1)));
        public Number Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public Vector3D Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public Vector3D Subarray(Integer from, Integer count)
        {
            var _var242 = from;
            {
                var _var241 = this;
                return count.Map((i) => _var241.At(i.Add(_var242)));
            }
        }
        public Vector3D Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public Vector3D Take(Integer n) => this.Subarray(((Integer)0), n);
        public Vector3D Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public Vector3D SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public Vector3D Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Number, TAcc> f) => f(f(f(init, X), Y), Z);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public Vector3D PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var245 = this;
            {
                var _var244 = this;
                {
                    var _var243 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var244.At(i)._var243(_var245.At(i.Add(((Integer)1)))));
                }
            }
        }
        public Vector3D PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var249 = this;
            {
                var _var248 = this;
                {
                    var _var247 = this;
                    {
                        var _var246 = f;
                        return this.Count.Map((i) => _var247.At(i)._var246(_var248.At(i.Add(((Integer)1).Modulo(_var249.Count)))));
                    }
                }
            }
        }
        public Vector3D Zip<T0, T1, TR>(Vector3D ys, System.Func<T0, T1, TR> f)
        {
            var _var252 = ys;
            {
                var _var251 = this;
                {
                    var _var250 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var251.At(i)._var250(_var252.At(i)));
                }
            }
        }
    }
    public readonly partial struct Vector4D
    {
        public Integer Count => ((Integer)4);
        public Number At(Integer n) => n.Equals(((Integer)0)) ? this.X : n.Equals(((Integer)1)) ? this.Y : n.Equals(((Integer)2)) ? this.Z : this.W;
        public Number this[Integer n] => At(n);
        public Number Length => this.Magnitude;
        public Number LengthSquared => this.MagnitudeSquared;
        public Number Sum => this.Reduce(((Number)0), (a, b) => a.Add(b));
        public Number SumSquares => this.Square.Sum;
        public Number MagnitudeSquared => this.SumSquares;
        public Number Magnitude => this.MagnitudeSquared.SquareRoot;
        public Number Dot(Vector4D v2) => this.Multiply(v2).Sum;
        public Number Average => this.Sum.Divide(this.Count);
        public Vector4D Normalize => this.MagnitudeSquared.GreaterThan(((Integer)0)) ? this.Divide(this.Magnitude) : this.Zero;
        public Vector4D Reflect(Vector4D normal) => this.Subtract(normal.Multiply(this.Dot(normal).Multiply(((Number)2))));
        public Vector4D Project(Vector4D other) => other.Multiply(this.Dot(other));
        public Number Distance(Vector4D b) => b.Subtract(this).Magnitude;
        public Number DistanceSquared(Vector4D b) => b.Subtract(this).Magnitude;
        public Angle Angle(Vector4D b) => this.Dot(b).Divide(this.Magnitude.Multiply(b.Magnitude)).Acos;
        public Vector4D PlusOne => this.Add(this.One);
        public Vector4D MinusOne => this.Subtract(this.One);
        public Vector4D FromOne => this.One.Subtract(this);
        public Number Component(Integer n) => this.Components.At(n);
        public Integer NumComponents => this.Components.Count;
        public Vector4D MapComponents(System.Func<Number, Number> f) => this.FromComponents(this.Components.Map(f));
        public Vector4D Zero => this.MapComponents((i) => ((Number)0));
        public Vector4D One => this.MapComponents((i) => ((Number)1));
        public Vector4D MinValue => this.MapComponents((x) => x.Constants.MinNumber);
        public Vector4D MaxValue => this.MapComponents((x) => x.Constants.MaxNumber);
        public Boolean AllComponents(System.Func<Number, Boolean> predicate) => this.Components.All(predicate);
        public Boolean AnyComponent(System.Func<Number, Boolean> predicate) => this.Components.Any(predicate);
        public Vector4D Half => this.Divide(((Number)2));
        public Vector4D Quarter => this.Divide(((Number)4));
        public Vector4D Tenth => this.Divide(((Number)10));
        public Vector4D Twice => this.Multiply(((Number)2));
        public Vector4D Lerp(Vector4D b, Number t) => this.Multiply(t.FromOne).Add(b.Multiply(t));
        public Vector4D Barycentric(Vector4D v2, Vector4D v3, Vector2D uv) => this.Add(v2.Subtract(this).Multiply(uv.X).Add(v3.Subtract(this).Multiply(uv.Y)));
        public Vector4D Pow2 => this.Multiply(this);
        public Vector4D Pow3 => this.Pow2.Multiply(this);
        public Vector4D Pow4 => this.Pow3.Multiply(this);
        public Vector4D Pow5 => this.Pow4.Multiply(this);
        public Vector4D Square => this.Pow2;
        public Vector4D Cube => this.Pow3;
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Number First => this.At(((Integer)0));
        public Number Last => this.At(this.Count.Subtract(((Integer)1)));
        public Number Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public Vector4D Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public Vector4D Subarray(Integer from, Integer count)
        {
            var _var254 = from;
            {
                var _var253 = this;
                return count.Map((i) => _var253.At(i.Add(_var254)));
            }
        }
        public Vector4D Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public Vector4D Take(Integer n) => this.Subarray(((Integer)0), n);
        public Vector4D Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public Vector4D SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public Vector4D Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Number, TAcc> f) => f(f(f(f(init, X), Y), Z), W);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public Vector4D PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var257 = this;
            {
                var _var256 = this;
                {
                    var _var255 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var256.At(i)._var255(_var257.At(i.Add(((Integer)1)))));
                }
            }
        }
        public Vector4D PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var261 = this;
            {
                var _var260 = this;
                {
                    var _var259 = this;
                    {
                        var _var258 = f;
                        return this.Count.Map((i) => _var259.At(i)._var258(_var260.At(i.Add(((Integer)1).Modulo(_var261.Count)))));
                    }
                }
            }
        }
        public Vector4D Zip<T0, T1, TR>(Vector4D ys, System.Func<T0, T1, TR> f)
        {
            var _var264 = ys;
            {
                var _var263 = this;
                {
                    var _var262 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var263.At(i)._var262(_var264.At(i)));
                }
            }
        }
    }
    public readonly partial struct Matrix3x3
    {
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Vector3D First => this.At(((Integer)0));
        public Vector3D Last => this.At(this.Count.Subtract(((Integer)1)));
        public Vector3D Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public Matrix3x3 Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public Matrix3x3 Subarray(Integer from, Integer count)
        {
            var _var266 = from;
            {
                var _var265 = this;
                return count.Map((i) => _var265.At(i.Add(_var266)));
            }
        }
        public Matrix3x3 Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public Matrix3x3 Take(Integer n) => this.Subarray(((Integer)0), n);
        public Matrix3x3 Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public Matrix3x3 SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public Matrix3x3 Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Vector3D, TAcc> f) => f(f(f(init, Column1), Column2), Column3);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public Matrix3x3 PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var269 = this;
            {
                var _var268 = this;
                {
                    var _var267 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var268.At(i)._var267(_var269.At(i.Add(((Integer)1)))));
                }
            }
        }
        public Matrix3x3 PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var273 = this;
            {
                var _var272 = this;
                {
                    var _var271 = this;
                    {
                        var _var270 = f;
                        return this.Count.Map((i) => _var271.At(i)._var270(_var272.At(i.Add(((Integer)1).Modulo(_var273.Count)))));
                    }
                }
            }
        }
        public Matrix3x3 Zip<T0, T1, TR>(Matrix3x3 ys, System.Func<T0, T1, TR> f)
        {
            var _var276 = ys;
            {
                var _var275 = this;
                {
                    var _var274 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var275.At(i)._var274(_var276.At(i)));
                }
            }
        }
    }
    public readonly partial struct Matrix4x4
    {
        public Number M11 => this.Column1.X;
        public Number M12 => this.Column2.X;
        public Number M13 => this.Column3.X;
        public Number M14 => this.Column4.X;
        public Number M21 => this.Column1.Y;
        public Number M22 => this.Column2.Y;
        public Number M23 => this.Column3.Y;
        public Number M24 => this.Column4.Y;
        public Number M31 => this.Column1.Z;
        public Number M32 => this.Column2.Z;
        public Number M33 => this.Column3.Z;
        public Number M34 => this.Column4.Z;
        public Number M41 => this.Column1.W;
        public Number M42 => this.Column2.W;
        public Number M43 => this.Column3.W;
        public Number M44 => this.Column4.W;
        public Vector3D Multiply(Vector3D v) => v.X.Multiply(this.M11).Add(v.Y.Multiply(this.M21).Add(v.Z.Multiply(this.M31).Add(this.M41))).Tuple3(v.X.Multiply(this.M12).Add(v.Y.Multiply(this.M22).Add(v.Z.Multiply(this.M32).Add(this.M42))), v.X.Multiply(this.M13).Add(v.Y.Multiply(this.M23).Add(v.Z.Multiply(this.M33).Add(this.M43))));
        public static Vector3D operator *(Matrix4x4 m, Vector3D v) => m.Multiply(v);
        public Boolean IsEmpty => this.Count.Equals(((Integer)0));
        public Vector4D First => this.At(((Integer)0));
        public Vector4D Last => this.At(this.Count.Subtract(((Integer)1)));
        public Vector4D Middle(Integer n) => this.At(this.Count.Divide(((Integer)2)));
        public Matrix4x4 Slice(Integer from, Integer to) => this.Subarray(from, to.Subtract(from));
        public Matrix4x4 Subarray(Integer from, Integer count)
        {
            var _var278 = from;
            {
                var _var277 = this;
                return count.Map((i) => _var277.At(i.Add(_var278)));
            }
        }
        public Matrix4x4 Skip(Integer n) => this.Subarray(n, this.Count.Subtract(n));
        public Matrix4x4 Take(Integer n) => this.Subarray(((Integer)0), n);
        public Matrix4x4 Drop(Integer n) => this.Take(this.Count.Subtract(n));
        public Matrix4x4 SkipDrop(Integer n1, Integer n2) => this.Skip(n1).Drop(n2);
        public Matrix4x4 Rest => this.Skip(((Integer)1));
        public TAcc Reduce<TAcc>(TAcc init, System.Func<TAcc, Vector4D, TAcc> f) => f(f(f(f(init, Column1), Column2), Column3), Column4);
        public Boolean All<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)true);
        }
        public Boolean Any<T0>(System.Func<T0, Boolean> f)
        {
            {
                var i = ((Integer)0);
                while (i.LessThan(this.Count))
                {
                    i = i.Add(((Integer)1));
                }

            }
            return ((Boolean)false);
        }
        public Matrix4x4 PairwiseMap<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var281 = this;
            {
                var _var280 = this;
                {
                    var _var279 = f;
                    return this.Count.Subtract(((Integer)1)).Map((i) => _var280.At(i)._var279(_var281.At(i.Add(((Integer)1)))));
                }
            }
        }
        public Matrix4x4 PairwiseMapModulo<T1, TR>(System.Func<T1, T1, TR> f)
        {
            var _var285 = this;
            {
                var _var284 = this;
                {
                    var _var283 = this;
                    {
                        var _var282 = f;
                        return this.Count.Map((i) => _var283.At(i)._var282(_var284.At(i.Add(((Integer)1).Modulo(_var285.Count)))));
                    }
                }
            }
        }
        public Matrix4x4 Zip<T0, T1, TR>(Matrix4x4 ys, System.Func<T0, T1, TR> f)
        {
            var _var288 = ys;
            {
                var _var287 = this;
                {
                    var _var286 = f;
                    return this.Count.Min(ys.Count).Map((i) => _var287.At(i)._var286(_var288.At(i)));
                }
            }
        }
    }
        public static class Intrinsics
    {
        public static TR Invoke<TR>(this Function0<TR> self) => self._function();
        public static TR Invoke<T0, TR>(this Function1<T0, TR> self, T0 arg) => self._function(arg);
        public static TR Invoke<T0, T1, TR>(this Function2<T0, T1, TR> self, T0 arg0, T1 arg1) => self._function(arg0, arg1);
        public static TR Invoke<T0, T1, T2, TR>(this Function3<T0, T1, T2, TR> self, T0 arg0, T1 arg1, T2 arg2) => self._function(arg0, arg1, arg2);
        public static TR Invoke<T0, T1, T2, T3, TR>(this Function4<T0, T1, T2, T3, TR> self, T0 arg0, T1 arg1, T2 arg2, T3 arg3) => self._function(arg0, arg1, arg2, arg3);

        public static T ChangePrecision<T>(this T self) => self;
        public static float ChangePrecision(this double self) => (float)self;
        public static string ChangePrecision(this string self) => self;

        public static Number MinNumber => float.MinValue;
        public static Number MaxNumber => float.MinValue;

        public static Number Cos(Angle x) => (float)System.Math.Cos(x.Radians);
        public static Number Sin(Angle x) => (float)System.Math.Sin(x.Radians);
        public static Number Tan(Angle x) => (float)System.Math.Tan(x.Radians);

        public static Number Ln(Number x) => (float)System.Math.Log(x.Value);
        public static Number Exp(Number x) => (float)System.Math.Exp(x.Value);

        public static Number Floor(Number x) => (float)System.Math.Floor(x.Value);
        public static Number Ceiling(Number x) => (float)System.Math.Ceiling(x.Value);
        public static Number Round(Number x) => (float)System.Math.Round(x.Value);
        public static Number Truncate(Number x) => (float)System.Math.Truncate(x.Value);

        public static Angle Acos(Number x) => new Angle((float)System.Math.Acos(x));
        public static Angle Asin(Number x) => new Angle((float)System.Math.Asin(x));
        public static Angle Atan(Number x) => new Angle((float)System.Math.Atan(x));

        public static Number Pow(Number x, Number y) => (float)System.Math.Pow(x, y);
        public static Number Log(Number x, Number y) => (float)System.Math.Log(x, y);
        public static Number NaturalLog(Number x) => (float)System.Math.Log(x);
        public static Number NaturalPower(Number x) => (float)System.Math.Pow(x, System.Math.E);

        public static Number Add(Number x, Number y) => x.Value + y.Value;
        public static Number Subtract(Number x, Number y) => x.Value - y.Value;
        public static Number Divide(Number x, Number y) => x.Value / y.Value;
        public static Number Multiply(Number x, Number y) => x.Value * y.Value;
        public static Number Modulo(Number x, Number y) => x.Value % y.Value;
        public static Number Negative(Number x) => -x.Value;

        public static Integer Add(Integer x, Integer y) => x.Value + y.Value;
        public static Integer Subtract(Integer x, Integer y) => x.Value - y.Value;
        public static Integer Divide(Integer x, Integer y) => x.Value / y.Value;
        public static Integer Multiply(Integer x, Integer y) => x.Value * y.Value;
        public static Integer Modulo(Integer x, Integer y) => x.Value % y.Value;
        public static Integer Negative(Integer x) => -x.Value;
        public static Integer Reciprocal(Integer x) => (int)(1.0 / (double)x.Value);

        public static Array<Integer> Range(Integer x) => new RangeStruct(x);

        public static Boolean And(Boolean x, Boolean y) => x.Value && y.Value;
        public static Boolean Or(Boolean x, Boolean y) => x.Value || y.Value;
        public static Boolean Not(Boolean x) => !x.Value;

        public static Number ToNumber(Integer x) => x.Value;

        public static string MakeString(string typeName, Array<String> fieldNames, Array<Dynamic> fieldValues)
        {
            var sb = new System.Text.StringBuilder();
            sb.Append($"{{ _type=\"{typeName}\" ");
            for (var i = 0; i < fieldNames.Count; i++)
                sb.Append(", ").Append(fieldNames.At(i).Value).Append(" = ").Append(fieldValues.At(i).Value);
            sb.Append(" }");
            return sb.ToString();
        }

        public static int CombineHashCodes(params object[] objects)
        {
            if (objects.Length == 0) return 0;
            var r = objects[0].GetHashCode();
            for (var i = 1; i < objects.Length; ++i)
                r = CombineHashCodes(r, objects[i].GetHashCode());
            return r;
        }

        public static (T0, T1) Tuple2<T0, T1>(this T0 item0, T1 item1)
            => (item0, item1);

        public static (T0, T1, T2) Tuple3<T0, T1, T2>(this T0 item0, T1 item1, T2 item2)
            => (item0, item1, item2);

        public static (T0, T1, T2, T3) Tuple4<T0, T1, T2, T3>(this T0 item0, T1 item1, T2 item2, T3 item3)
            => (item0, item1, item2, item3);

        public static Array<T> MakeArray<T>(params T[] args)
            => new PrimitiveArray<T>(args);

        public static int CombineHashCodes(int h1, int h2)
        {
            unchecked
            {
                var rol5 = ((uint)h1 << 5) | ((uint)h1 >> 27);
                return ((int)rol5 + h1) ^ h2;
            }
        }

        public static Array<T1> Map<T0, T1>(this Array<T0> self, System.Func<T0, T1> f)
            => new MappedArray<T0, T1>(self, f);

        public static TAcc Reduce<T, TAcc>(this Array<T> self, TAcc init, System.Func<TAcc, T, TAcc> f)
        {
            for (var i = 0; i < self.Count; ++i)
                init = f(init, self.At(i));
            return init;
        }        
    }

    public readonly struct PrimitiveArray<T> : Array<T>
    {
        private readonly T[] _data;
        public Integer Count => _data.Length;
        public T At(Integer n) => _data[n];
        public PrimitiveArray(T[] data) => _data = data;
        public static Array<T> Default = new PrimitiveArray<T>(System.Array.Empty<T>());
    }

    public readonly struct MappedArray<T0, T1> : Array<T1>
    {
        public System.Func<T0, T1> MapFunc { get; }
        public Array<T0> Original { get; }
        public Integer Count => Original.Count;
        public T1 At(Integer n) => MapFunc(Original.At(n));

        public MappedArray(Array<T0> input, System.Func<T0, T1> f)
        {
            Original = input;
            MapFunc = f;
        }
    }

    public readonly struct RangeStruct : Array<Integer>
    {
        public Integer Count { get; }
        public Integer At(Integer n) => n;
        public RangeStruct(Integer n) => Count = n;
    }

    public readonly partial struct String
    {
        public Integer Compare(String other) => Value.CompareTo(other.Value);
        public Character At(Integer n) => Value[n];
        public Integer Count => Value.Length;
    }

    public readonly partial struct Boolean
    {
        public static bool operator true(Boolean b) => b.Value;
        public static bool operator false(Boolean b) => !b.Value;
    }

    public readonly partial struct Number
    {
        public Number Zero => 0;
        public Number One => 1;
        public Number MinValue => float.MinValue;
        public Number MaxValue => float.MaxValue;
        public Integer Compare(Number other) => Value.CompareTo(other.Value);
        public Number Unlerp(Number a, Number b) => (float)(this - a) / (float)(b - a);
        public Number Component(int index) => Value;
    }

    public readonly partial struct Integer
    {
        public Integer Zero => 0;
        public Integer One => 1;
        public Integer MinValue => int.MinValue;
        public Integer MaxValue => int.MaxValue;
        public Number Magnitude => Value;
        public static implicit operator Number(Integer self) => self.Value;
        public Integer Compare(Integer other) => Value.CompareTo(other.Value);
        public Number Unlerp(Integer a, Integer b) => (float)(this - a) / (float)(b - a);
        public Number Component(int index) => Value;
    }

    public readonly partial struct Character
    {
        public Character Zero => (char)0;
        public Character One => (char)1;
        public Character MinValue => char.MinValue;
        public Character MaxValue => char.MaxValue;
        public Number Magnitude => Value;
        public static implicit operator Number(Character self) => self.Value;
        public Integer Compare(Character other) => Value.CompareTo(other.Value);
        public Number Unlerp(Character a, Character b) => (float)(this - a) / (float)(b - a);
        public Boolean Equals(Character x) => Value.Equals(x.Value);
        public Boolean NotEquals(Character x) => !Equals(x);
    }

    public readonly partial struct Dynamic
    {
        public readonly object Value;
        public Dynamic WithValue(object value) => new Dynamic(value);
        public Dynamic(object value) => (Value) = (value);
        public static Dynamic Default = new Dynamic();
        public static Dynamic New(object value) => new Dynamic(value);
        public String TypeName => "Dynamic";
        public Array<String> FieldNames => Intrinsics.MakeArray<String>("Value");
        public Array<Dynamic> FieldValues => Intrinsics.MakeArray<Dynamic>(new Dynamic(Value));
        public T As<T>() => (T)Value;
    }

    public readonly partial struct Function0<TR>
    {
        public readonly System.Func<TR> _function;
        public Function0(System.Func<TR> f) => _function = f;
        public static implicit operator Function0<TR>(System.Func<TR> f) => new Function0<TR>(f);
    }

    public readonly partial struct Function1<T0, TR>
    {
        public readonly System.Func<T0, TR> _function;
        public Function1(System.Func<T0, TR> f) => _function = f;
        public static implicit operator Function1<T0, TR>(System.Func<T0, TR> f) => new Function1<T0, TR>(f);
    }

    public readonly partial struct Function2<T0, T1, TR>
    {
        public readonly System.Func<T0, T1, TR> _function;
        public Function2(System.Func<T0, T1, TR> f) => _function = f;
        public static implicit operator Function2<T0, T1, TR>(System.Func<T0, T1, TR> f) => new Function2<T0, T1, TR>(f);
    }

    public readonly partial struct Function3<T0, T1, T2, TR>
    {
        public readonly System.Func<T0, T1, T2, TR> _function;
        public Function3(System.Func<T0, T1, T2, TR> f) => _function = f;
        public static implicit operator Function3<T0, T1, T2, TR>(System.Func<T0, T1, T2, TR> f) => new Function3<T0, T1, T2, TR>(f);
    }
    
    public readonly partial struct Function4<T0, T1, T2, T3, TR>
    {
        public readonly System.Func<T0, T1, T2, T3, TR> _function;
        public Function4(System.Func<T0, T1, T2, T3, TR> f) => _function = f;
        public static implicit operator Function4<T0, T1, T2, T3, TR>(System.Func<T0, T1, T2, T3, TR> f) => new Function4<T0, T1, T2, T3, TR>(f);
    }
}
