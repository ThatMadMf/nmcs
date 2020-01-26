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
            LabsFactory.getLab(Labs.Eluler).run();
            Console.ReadKey();
        }

        static void runLab2() {
            LU_Decomposition lU = new LU_Decomposition();
            double[] gammas = new double[] { 1, 4, 1, 4, 2, 7 };
            double[] alphas = new double[] { 2, -2, -1, 7, -5, -3, -3 };
            double[] betas = new double[] { 0.5, 6, 3, 2, 1, 2 };
            double[] b = new double[] { 8, 6, 3, -2, 4, 7, -0.5 };

            var resLU = lU.calculate_LU(gammas, alphas, betas, b);

            for (int i = 0; i < resLU.Length; i++) {
                Console.WriteLine("X" + i + ":" + resLU[i]);
            }
            for (int i = 0; i < resLU.Length; i++) {
                if (i == 0) {
                    Console.WriteLine("Check of equation Num" + i + "\t:" + (double)(alphas[i] * resLU[i] + gammas[i] * resLU[i + 1]));
                } else if (i == resLU.Length - 1) {
                    Console.WriteLine("Check of equation Num" + i + "\t:" + (double)(alphas[i] * resLU[i] + betas[i - 1] * resLU[i - 1]));
                } else {
                    Console.WriteLine("Check of equation Num" + i + "\t:" + (double)(betas[i - 1] * resLU[i - 1] + alphas[i] * resLU[i] + gammas[i] * resLU[i + 1]));
                }
            }
        }

        static void runLab3() {
            Lab3.SimpleIteration lab3 = new Lab3.SimpleIteration();
            string function1 = "Pow([x],2)-3.5*[x]*[y]+3*Pow([y],3)";
            string function2 = "3*[x]-8*Pow([x],3)*Pow([y],2)-4.7*[y]";
            double x = 10;
            double y = -5;
            double[] res = lab3.run(function1, function2, x, y);
            Console.WriteLine("x: " + res[0] + "\ty: " + res[1]);
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
            for (int i = 0; i < resX.Length; i++) {
                Console.WriteLine("x: " + resX[i] + "\ty:" + resY[i]);
            }
            List<Lab4.Point> points = new List<Lab4.Point>();
            for (int i = 0; i < resY.Length; i++) {
                points.Add(new Lab4.Point(resX[i], resY[i]));
            }
            Brush brush = new SolidBrush(Color.Red);
            Lab4.FormDrawer.drawPoints(points.ToArray(), brush, lab4.field);
            Lab4.Point[] args = new Lab4.Point[x.Length];
            for (int i = 0; i < x.Length; i++) {
                args[i] = new Lab4.Point((int)x[i], (int)y[i]);
            }
            Brush blackBrush = new SolidBrush(Color.Black);
            Lab4.FormDrawer.drawPoints(args, blackBrush, lab4.field, 7);
        }

        static void runLab5() {
            string f = "Pow([x], 2/3) + 2";
            string f38 = "7 + 2 * Pow([x], -2 / 3)";
            double res = Lab5.Lab5Class.integrateSimpson(0, 60, f);
            double res38 = Lab5.Lab5Class.integrateSimpson3_8(0, 60, f38);
            Console.WriteLine(res);
            Console.WriteLine(res38);
        }
    }
}
