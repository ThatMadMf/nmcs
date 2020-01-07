using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labs_nmcs.Lab1;
using labs_nmcs.Lab2;
using labs_nmcs.Lab5;

namespace labs_nmcs {
  static class UI {

    static public void lab1() {
      int leftBorder = -10;
      int rightBorder = 10;
      string expression = "1.5-Pow(x, 1-Cos(x))";
      //1.5-Pow(x, 1-Cos(x))
      var res = TangentMethod.runNewton(expression, leftBorder, rightBorder, 0.01);
      if (res.Count == 0) {
        Console.WriteLine("There are no solutions on this segment");
      } else {
        foreach (var x in res) {
          Console.WriteLine("Solution: " + x);
          Console.WriteLine($"F({x}) = " + TangentMethod.calcFunc(expression, x));
        }
      }
      Console.ReadKey();
    }

    static public void lab2() {
      double[][] input = new double[][] {
        new double[]{ 4, 7, 4, 17 },
        new double[]{ 1, 2, 6, 12 },
        new double[]{ 9, 5, 3, 14 } };

      double[][] input2 = new double[][] {
         new double[] { -2, 1, 1, 15 },
        new double[]{ 1, -2, 1, 10 },
        new double[]{ -1, 3, -6, 12 } };


      Lab2.SimpleIteration simpleIteration = new Lab2.SimpleIteration(input);
      while (true) {
        Console.WriteLine("1 - Show results table \n2 - Show infelicity table");
        string key = Console.ReadLine();
        switch (key) {
          case "1": {
              simpleIteration.showResult();
              break;
            }
          case "2": {
              simpleIteration.showDifferences();
              break;
            }
          default: {
              Console.WriteLine("wrong key");
              break;
            }
        }
      }
    }

    static public void lab5() {
      Lab5Class runTest = new Lab5Class();

      var result = runTest.calcualteArea(0, 60, "7 + 2 * Pow(Pow([x],(2/3)), -1)");
      Console.WriteLine("Result area is " + result);
      Console.ReadKey();
    }
  }
}
