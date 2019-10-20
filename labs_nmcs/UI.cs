using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labs_nmcs.Lab1;
using labs_nmcs.Lab2;

namespace labs_nmcs {
  static class UI {

    static public void lab1() {
      Console.WriteLine("Enter function");
      string expression = Console.ReadLine();
      Console.WriteLine("Enter borders");
      int leftBorder = Convert.ToInt32(Console.ReadLine());
      int rightBorder = Convert.ToInt32(Console.ReadLine());
      //(Pow(x,4)-1)/Pow(x,3)
      //1.5-Pow(x, 1-Cos(x))
      var res = Segment1.runNewton(expression, leftBorder, rightBorder, 0.01);
      if (res.Count == 0) {
        Console.WriteLine("There are no solutions on this segment");
      } else {
        foreach (var x in res) {
          Console.WriteLine("Solution: " + x);
          Console.WriteLine($"F({x}) = " + Segment1.calcFunc(expression, x));
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


      SimpleIteration simpleIteration = new SimpleIteration(input);
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
  }
}
