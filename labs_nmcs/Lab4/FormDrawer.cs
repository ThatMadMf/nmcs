using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace labs_nmcs.Lab4 {
  static class FormDrawer {

    public static void drawPoints(Point[] points, Brush brush, Field field) {
      foreach (Point point in points) {
        field.drawPoint(point, brush);
      }
    }

    public static void drawPoints(Point[] points, Brush brush, Field field, int size) {
      foreach (Point point in points) {
        field.drawPoint(point, brush, size);
      }
    }
  }
}
