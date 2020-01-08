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
      return evaluate;
    }

    public static double integrateSimpson3_8(double a, double b, int n, string f) {
      double h = (b - a) / n;
      double s = calcFunc(f, a) + calcFunc(f, b);
      for (int i = 1; i < n; i++) {
        if (i % 3 == 0) {
          s += 2 * calcFunc(f, a + i * h);
        } else {
          s += 3 * calcFunc(f, a + i * h);
        }
      }
      return s * 3 / 8 * h;
    }
  }
}
