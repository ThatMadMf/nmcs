using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace labs_nmcs.Lab5 {
  class Lab5Class {
    public static double calcFunc(string f, double x) {
      Expression expression = new Expression(f);
      expression.Parameters["x"] = x;
      return (double)expression.Evaluate();
    }

    public double calcualteArea(int lowerBound, int upperBound, string function) {
      const int amoutOfSegments = 10;
      double segmentLength = (double)(upperBound - lowerBound) / (amoutOfSegments - 1);
      double[] unknowns = initialiseUnknowns(segmentLength, 4);
      double[] subAreas = new double[unknowns.Length];

      for (int i = 0; i < subAreas.Length; i++) {
        if (Double.IsInfinity(calcFunc(function, unknowns[i]))) {
          subAreas[i] = 7;
        } else {
          subAreas[i] = calcFunc(function, unknowns[i]);
        }
        Console.WriteLine($"Segment number {i + 1} has area {subAreas[i]}");
      }

      return simpson3_8Formula(segmentLength, subAreas);
    }

    private double[] initialiseUnknowns(double distance, int lenght) {
      double[] result = new double[lenght];
      double x = 0;
      for (int i = 0; i < lenght; i++) {
        result[i] = x;
        x += distance;
      }
      return result;
    }

    private double simpson3_8Formula(double h, double[] f) {
      return (3 * h / 8) * (f[0] + 3 * f[1] + 3 * f[2] + 3 * f[3]);
    }
  }
}
