using System;

namespace LB_3._2
{
    public class LineSegment
    {
        private double _x;
        private double _y;

        // Свойства (полное тело — без автосвойств)
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        // Конструктор по умолчанию
        public LineSegment()
        {
            _x = 0;
            _y = 0;
        }

        // Конструктор с параметрами
        public LineSegment(double x, double y)
        {
            _x = x;
            _y = y;
        }

        // Конструктор копирования
        public LineSegment(LineSegment other)
        {
            _x = other._x;
            _y = other._y;
        }

        public override string ToString()
        {
            return "Отрезок: x = " + _x + ", y = " + _y;
        }

        // 6: метод проверки пересечения
        public bool IsIntersect(LineSegment other)
        {
            double a1 = Math.Min(_x, _y);
            double a2 = Math.Max(_x, _y);
            double b1 = Math.Min(other._x, other._y);
            double b2 = Math.Max(other._x, other._y);

            return Math.Max(a1, b1) <= Math.Min(a2, b2);
        }

        // 7: перегрузка операций

        public static double operator !(LineSegment s)
        {
            return Math.Abs(s._y - s._x);
        }

        public static LineSegment operator ++(LineSegment s)
        {
            return new LineSegment(s._x - 1, s._y + 1);
        }

        public static implicit operator int(LineSegment s)
        {
            return (int)s._x;
        }

        public static explicit operator double(LineSegment s)
        {
            return s._y;
        }

        public static LineSegment operator -(LineSegment s,
            int value)
        {
            return new LineSegment(s._x - value, s._y);
        }

        public static LineSegment operator -(int value,
            LineSegment s)
        {
            return new LineSegment(s._x, s._y - value);
        }

        public static bool operator <(LineSegment a,
            LineSegment b)
        {
            return a.IsIntersect(b);
        }

        public static bool operator >(LineSegment a,
            LineSegment b)
        {
            return b.IsIntersect(a);
        }
    }
}