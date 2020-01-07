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
  static class Program {

    [STAThread]
    static void Main(string[] args) {
      runLab4();
      
      Console.ReadKey();
    }

    static void runLab1() {
      Lab1.SimpleIteration simpleIteration = new Lab1.SimpleIteration();
      var res = simpleIteration.runSimpleIteration(0, 10, 0.01, "Sin(x) - Log10(x)");
      Console.WriteLine("Evaluate with found solution = " + Lab1.SimpleIteration.calcFunc("Sin(x) - Log10(x)", res));
      Console.WriteLine(res);
    }

    static void runLab2() {
      LU_Decomposition lU = new LU_Decomposition();
      double[] gammas = new double[] { 1, 4, 1, 4, 2, 7 };
      double[] alphas = new double[] { 2, -2, -1, 7, -5, -3, -3 };
      double[] betas = new double[] { 0.5, 6, 3, 2, 1, 2 };
      double[] b = new double[] { 8, 6, 3, -2, 4, 7, -0.5 };
      var resLU = lU.calculate_LU(gammas, alphas, betas, b);
      int i = 1;
      foreach (var v in resLU) {
        Console.WriteLine("X" + i + ":" + v);
        i++;
      }
    }

    static void runLab3() {
      Lab3.SimpleIteration lab3 = new Lab3.SimpleIteration();
      string function1 = "Pow([x],2)-3.5*[x]*[y]+3*Pow([y],3)";
      string function2 = "3*[x]-8*Pow([x],3)*Pow([y],2)-4.7*[y])";
      double x = 1.5;
      double y = 0.1;
      Console.WriteLine(lab3.run(function1, function2, x, y));
    }

    static void runLab4() {
      Lab4.Polinom lab4 = new Lab4.Polinom();
      lab4.run();
    }
  }
}
