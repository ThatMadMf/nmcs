﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace labs_nmcs.Lab1 {
  static class Segment1 {
    //public static double Segment(string f, double a, double b, double eps) {
    //  double x0 = a;
    //  double f0 = calcFunc(f, x0);
    //  double f00 = calcFunc(f, x0 + eps);
    //  double df0 = (f00 - f0) / eps;
    //  double xn = x0 - f0 / df0;
    //  do {
    //    x0 = xn;
    //    f0 = calcFunc(f, x0);
    //    f00 = calcFunc(f, x0 + eps);
    //    df0 = (f00 - f0) / eps;
    //    xn = x0 - f0 / df0;
    //    if (!isValid(xn)) {
    //      Segment(f, xn + eps, b, eps);
    //    }
    //  } while (Math.Abs(x0 - xn) > eps);
    //  return xn;
    //}
    public static double calcFunc(string f, double x) {
      Expression expression = new Expression(f);
      expression.Parameters["x"] = x;
      return (double)expression.Evaluate(); 
    }

    public static List<double> runNewton(string f, double a, double b, double eps) {
      List<double> solutions = new List<double>();
      for (double x0 = a; x0 <= b; x0 += eps) {
        double fx0 = calcFunc(f, x0);
        double fx1 = calcFunc(f, (x0 + eps));
        double dfx0 = (fx1 - fx0) / eps;
        double dfx1 = (calcFunc(f, (x0 + eps + eps)) - fx1) / eps;
        if (fx0 * fx1 < 0 && dfx0 * dfx1 > 0) {
          double xn = x0;
          if (Math.Abs(xn) < eps) {
            solutions.Add(Math.Round(x0, 2));
            continue;
          }
          int iteration = 0;
          while (!(Math.Abs(calcFunc(f, xn)) < eps || iteration < 10)) {
            xn = xn - (calcFunc(f, xn) / ((calcFunc(f, xn + eps) - calcFunc(f, xn)) / eps));
            iteration++;
          }
          solutions.Add(Math.Round(xn, 5));
        }
      }
      return solutions;
    }
  }
}