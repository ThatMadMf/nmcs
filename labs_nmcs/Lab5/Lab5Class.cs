using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace labs_nmcs.Lab5 {
  static class Lab5Class {
    public static double calcFunc(string f, double x) {
      Expression expression = new Expression(f);
      expression.Parameters["x"] = x;
      double evaluate = (double)expression.Evaluate();
      if (double.IsInfinity(evaluate) || double.IsNaN(evaluate)) {
        return 0;
      }
      return Math.Round(evaluate, 2);
    }

    public static double integrateSimpson3_8(double a, double b, string f) {
      int m = 20;
      int n = (3 - 1) * m;
      double h = Math.Abs(b - a) / n ;
      double s = calcFunc(f, a) + calcFunc(f, b);
      for (int i = 1; i < n; i++) {
        if (i % 3 == 0) {
          s += Math.Round(2 * calcFunc(f, a + i * h), 2);
        } else {
          s += Math.Round(3 * calcFunc(f, a + i * h), 2);
        }
      }
      return Math.Round(s * h * 3 / 8, 2);
    }

    public static double integrateSimpson(double a, double b, string f) {
      int m = 20;
      int n = (4 - 1) * m;
      double h = Math.Abs(b - a) / n;
      double s = calcFunc(f, a) + calcFunc(f, b);
      for (int i = 1; i < n; i++) {
        if (i % 2 == 0) {
          s += Math.Round(2 * calcFunc(f, a + i * h), 2);
        } else {
          s += Math.Round(4 * calcFunc(f, a + i * h), 2);
        }
      }
      return Math.Round(s * h / 3, 2);
    }
  }
}
