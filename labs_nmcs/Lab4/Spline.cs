using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs_nmcs.Lab4 {
  class Spline {

    public void run() {
      Point[] points = new Point[5];
      points[0] = new Point(0, 5);
      points[1] = new Point(3, 2);
      points[2] = new Point(6, 0);
      points[3] = new Point(8, 4);
      points[4] = new Point(10, 6);

      Point[] test = new Point[4];
      test[0] = new Point(0, 0);
      test[1] = new Point(1, 0.5);
      test[2] = new Point(2, 2);
      test[3] = new Point(3, 1.5);

      double[] h = findH(test);
      double[] d = findD(test, h);
      double[] u = findU(d);
      var temp = makeSystem(h, d, u, 0.2, -1);
      var l = 5;
    }

    private double[] findH(Point[] points) {
      double[] res = new double[points.Length - 1];

      for (int i = 0; i < res.Length; i++) {
        res[i] = Math.Round(points[i + 1].X - points[i].X, 2);
      }
      return res;
    }

    private double[] findD(Point[] points, double[] h) {
      double[] res = new double[points.Length - 1];

      for (int i = 0; i < res.Length; i++) {
        res[i] = Math.Round((points[i + 1].Y - points[i].Y) / h[i], 2);
      }
      return res;
    }

    private double[] findU(double[] d) {
      double[] res = new double[d.Length - 1];
      for (int i = 0; i < res.Length; i++) {
        res[i] = Math.Round(6 * (d[i + 1] - d[i]), 2);
      }
      return res;
    }

    private double[][] makeSystem(double[] h, double[] d, double[] u, double x0, double xn) {
      double[][] res = new double[h.Length][];
      for (int i = 0; i < res.Length; i++) {
        res[i] = new double[h.Length - 1];
      }

      for (int i = 1; i < res.Length - 1; i++) {
        if (i == 1) {
          for (int j = 0; j < res[i].Length; j++) {
            if (j == i - 1) {
              res[j][i] = Math.Round(1.5 * h[i - 1] + 2 * h[i], 2);
            } else {
              res[j][i - 1] = h[i];
            }
          }
          res[res[i].Length - 1][i] = u[i] * (d[i - 1] - x0);
        } else if (i == res.Length - 2) {
          for (int j = 0; j < res[i].Length - 1; j++) {
            if (j == i - 1) {
              res[j][i] = Math.Round(2 * h[i - 1] + 1.5 * h[i]);
            } else {
              res[j][i] = h[i];
            }
          }
          res[res[i].Length - 1][i] = u[i] - 3 * (xn - d[i]);
        } else {
          for (int j = 0; j < res[i].Length - 1; j++) {
            if(i == j) {
              res[j][i] = Math.Round(2 * (h[i - 1] + h[i]));
            }
            res[j][i] = h[j];
          }
        }
      }
      return res;
    }
  }
}
