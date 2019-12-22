using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flee;
using NCalc;
using labs_nmcs.Lab1;
using labs_nmcs.Lab2;

namespace labs_nmcs {
  class Program {
    static void Main(string[] args) {
      Lab1.SimpleIteration simpleIteration = new Lab1.SimpleIteration();
      var res = simpleIteration.runSimpleIteration(0, 10, 0.01, "Sin(x) - Log10(x)");
      Console.WriteLine(res);
      LU_Decomposition lU = new LU_Decomposition();
      double[] gammas = new double[] { 1, 4, 1, 4, 2, 7 };
      double[] alphas = new double[] { 2, -2, -1, 7, -5, -3, -3 };
      double[] betas = new double[] { 0.5, 6, 3, 2, 1, 2 };
      double[] b = new double[] { 8, 6, 3, -2, 4, 7, -0.5 };
      var resLU = lU.calculate_LU(gammas, alphas, betas, b);
      Console.WriteLine(resLU);
    }
  }
}
