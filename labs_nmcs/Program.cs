using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NCalc;
using labs_nmcs.Lab1;
using labs_nmcs.Lab2;
using System.Drawing;

namespace labs_nmcs {
  static class Program {

    [STAThread]
    static void Main(string[] args) {
      runLab5();
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

      gammas = new double[] { 3.5, 1 };
      alphas = new double[] { 1, 3.5 };
      b = new double[] { 5.1, -10.5 };
      betas = null;
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
      float[] x = new float[] { 0, 3, 6, 8, 10 };
      float[] y = new float[] { 5, 2, 0, 4, 6 };
      Lab4.CubicSpline spline = new Lab4.CubicSpline(x, y);
      float[] resX = new float[501];
      for (float i = 0; i <= 500; i++) {
        resX[(int)i] = (float)Math.Round(i * 0.02, 2);
      }
      float[] resY = spline.Eval(resX);
      List<Lab4.Point> points = new List<Lab4.Point>();
      for (int i = 0; i < resY.Length; i++) {
        points.Add(new Lab4.Point(resX[i], resY[i]));
      }
      Brush brush = new SolidBrush(Color.Red);
      Thread.Sleep(500);
      Thread thread = new Thread(thr => Lab4.FormDrawer.drawPoints(points.ToArray(), brush, lab4.field));
      thread.Start();
      Lab4.Point[] args = new Lab4.Point[x.Length];
      for (int i = 0; i < x.Length; i++) {
        args[i] = new Lab4.Point((int)x[i], (int)y[i]);
      }
      Brush blackBrush = new SolidBrush(Color.Black);
      Lab4.FormDrawer.drawPoints(args, blackBrush, lab4.field, 7);
    }

    static void runLab5() {
      string f = "7 + 2 * Pow([x], -2 / 3)";
      double res = Lab5.Lab5Class.integrateSimpson3_8(0, 60, 10, f);
      Console.WriteLine(res);
    }
  }
}
