using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace labs_nmcs.Lab4 {
  class Polinom {

    public Field field;

    public void run() {
      Point[] points = new Point[5];
      points[0] = new Point(0, 5);
      points[1] = new Point(3, 2);
      points[2] = new Point(6, 0);
      points[3] = new Point(8, 4);
      points[4] = new Point(10, 6);

      double minValue = 2000;
      double maxValue = -2000;
      foreach (Point point in points) {
        if (point.X < minValue) {
          minValue = point.X;
        }
        if (point.X > maxValue) {
          maxValue = point.X;
        }
      }
      int numberOfPoints = 500;
      double step = (maxValue - minValue) / numberOfPoints;
      double minY = 2000;
      double maxY = -2000;
      List<Point> results = new List<Point>();
      for (double i = minValue; i <= maxValue; i = Math.Round(step + i, 3)) {
        double currentY = Math.Round(L_BI_MI(points, i), 2);
        if (currentY >= maxY) {
          maxY = currentY;
        }
        if (currentY < minY) {
          minY = currentY;
        }
        Console.WriteLine("x: " + i + "\ty:" + currentY);
        results.Add(new Point(i, currentY));
      }
      Console.WriteLine("\n\n");
      Console.WriteLine(minY + "\t" + maxY);
      field = new Field(minValue, minY, maxValue, maxY, numberOfPoints);
      field.Show();
      Brush brush = new SolidBrush(Color.Blue);
      FormDrawer.drawPoints(results.ToArray(), brush, field);
    }

    private double L_BI_MI(Point[] points, double x) {
      int n = points.Length;
      double r = 0, ra, rb;
      for (int i = 0; i < n; i++) {
        ra = rb = 1;
        for (int j = 0; j < n; j++)
          if (i != j) {
            ra *= x - points[j].X;
            rb *= points[i].X - points[j].X;
          }
        r += ra * points[i].Y / rb;
      }
      return r;
    }
  }
}
