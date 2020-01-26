using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace labs_nmcs.Lab1 {
  class SimpleIteration {

    public static double calcFunc(string f, double x) {
      Expression expression = new Expression(f);
      expression.Parameters["x"] = x;
      return (double)expression.Evaluate();
    }

    public double runSimpleIteration(int a, int b, double eps, string f) {
  
      throw new Exception("There is no solution in the segment");
    }

  }
}
