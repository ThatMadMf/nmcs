using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace labs_nmcs.Lab7 {
    class Milne : Lab {

        private double t0;
        private double tk;
        private double y0;
        private string f;
        private List<double> accurateRes;

        public Milne(double t0, double tk, double y0, string f) {
            this.t0 = t0;
            this.tk = tk;
            this.y0 = y0;
            this.f = f;
            accurateRes = new List<double>();
        }

        public void run() {
            double step = (0.45 / Math.Abs(caclFunc(f, t0, y0)));
            var res = solve(step, false);
            var resManaged = solveWithManage(step, false);
            var resD = solve(step, true);
            var resManagedD = solveWithManage(step, true);
            Console.WriteLine("t \t\t RESULT \t\t ACCURATE RESULT");
            for(int i = 0; i < res.Count; i++) {
                Console.WriteLine($"x = {String.Format("{0:0.00}", i*step)}\ty={String.Format("{0:00.000}", res[i])}" +
                    $"\ty2={String.Format("{0:0.000}", resManaged[i])}\t{caclT(i*step)}");
            }
        }

        private List<double> solve(double step, bool doubleStep) {
            List<double> results = new List<double>();
            results.Add(y0);
            double h = step;
            if (doubleStep) {
                h *= 2;
            }
            for (double i = t0 + h; i <= tk; i += h) {
                accurateRes.Add(caclT(i));
                int previous = results.Count - 1;
                if (results.Count < 4) {
                    results.Add(accurateRes[results.Count - 1]);
                } else {
                    double p0 = caclFunc(f, i - h * 3, results[previous - 2]);
                    double p1 = caclFunc(f, i - h * 2, results[previous - 1]);
                    double p2 = caclFunc(f, i - h, results[previous]);
                    double p = caclFunc(f, i, results[previous - 3] + 4 * h / 3 * (2 * p2 - p1 + 2 * p0));
                    results.Add(results[previous - 1] + h / 3 * (p1 + 4 * p2 + p));
                }
            }

            return results;
        }

        private List<double> solveWithManage(double step, bool doubleStep) {
            List<double> results = new List<double>();
            results.Add(y0);
            double h = step;
            if (doubleStep) {
                h *= 2;
            }
            double pPrevious = int.MaxValue;
            for (double i = t0 + h; i <= tk; i += h) {
                int previous = results.Count - 1;
                if (results.Count < 4) {
                    results.Add(accurateRes[results.Count - 1]);
                } else {
                    double p0 = caclFunc(f, i - h * 3, results[previous - 2]);
                    double p1 = caclFunc(f, i - h * 2, results[previous - 1]);
                    double p2 = caclFunc(f, i - h, results[previous]);
                    double p = caclFunc(f, i, results[previous - 3] + 4 * h / 3 * (2 * p2 - p1 + 2 * p0));
                    if (pPrevious != int.MaxValue) {
                        double m = caclFunc(f, i, p + 28 * (results[previous] - pPrevious) / 29);
                        results.Add(results[previous - 1] + h / 3 * (p1 + 4 * p2 + m));
                    } else {
                        results.Add(results[previous - 1] + h / 3 * (p1 + 4 * p2 + p));
                    }
                    pPrevious = p;
                }
            }
            return results;
        }

        private double caclFunc(string f, double x, double y) {
            Expression expression = new Expression(f);
            expression.Parameters["x"] = x;
            expression.Parameters["y"] = y;
            return Math.Round((double)expression.Evaluate(), 3);
        }

        private double caclT(double t) {
            string func = "2*Exp([t])+Pow([t],2)-[t]-1";
            Expression expression = new Expression(func);
            expression.Parameters["t"] = t;
            return Math.Round((double)expression.Evaluate(), 3);
        }
    }
}
