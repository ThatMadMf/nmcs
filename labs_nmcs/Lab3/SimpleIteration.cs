using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace labs_nmcs.Lab3 {
  class SimpleIteration {

    private double eps = 0.01;
    private double lastRes;

    private double caclFunc(string f, double x, double y) {
      Expression expression = new Expression(f);
      expression.Parameters["x"] = x;
      expression.Parameters["y"] = y;
      return (double)expression.Evaluate();
    }

    public double[] run(string f1, string f2, double x0, double y0) {
      double currentX = x0;
      double currentY = y0;
      while (true) {
        double tempX = currentX;
        double tempY = currentY;
        currentX = Math.Round(caclFunc(f1, tempX, tempY), 3);
        currentY = Math.Round(caclFunc(f2, tempX, tempY), 3);
        if (shouldStop(tempX, tempY, currentX, currentY)) {
          return new double[] { currentX, currentY };
        }
      }
    }

    private bool shouldStop(double xn, double yn, double xn1, double yn1) {
      if (Math.Abs(xn1 - xn) + Math.Abs(yn1 - yn) <= eps || Math.Abs(yn1 - yn) <= eps) {
        return true;
      }
      return false;
    }
  }
}
