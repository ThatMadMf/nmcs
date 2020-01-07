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
      var res = expression.Evaluate();
      lastRes = (double)res;
      return (double) res;
    }

    public double[] run(string f1, string f2, double x0, double y0) {
      for (double x = x0, y = y0; ; x += eps, y+=eps) {
        double currentX = caclFunc(f1, x, y);
        double currentY = caclFunc(f2, x, y);
        if(shouldStop(f1, f2, currentX, currentY)) {
          break;
        }
      }
      return null;
    }

    private bool shouldStop(string f1, string f2, double x, double y) {
      if(caclFunc(f1, x, y) < eps && caclFunc(f2, x, y) < eps) {
        return true;
      }
      return false;
    }
  }
}
