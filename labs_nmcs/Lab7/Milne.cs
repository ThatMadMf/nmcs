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

        public Milne(double t0, double tk, double y0, string f) {
            this.t0 = t0;
            this.tk = tk;
            this.y0 = y0;
            this.f = f;
        }

        public void run() {
            double step = (0.45 / Math.Abs(caclFunc(f, t0, y0)));
            var res = solve(step, false);
            return;
        }

        private List<double> solve(double step, bool doubleStep) {
            List<double> results = new List<double>();
            List<double> accurateRes = new List<double>();
            results.Add(y0);
            double h = step;
            if (doubleStep) {
                h *= 2;
            }
            for(double i = t0 + h; i <= tk; i += h) {
                accurateRes.Add(caclT(i));
                int previous = results.Count - 1;
                if(i < 4) {
                    results.Add(results[previous] + h * caclFunc(f, i-h, results[previous]));
                } else {
                    double p = results[previous - 3] + (4 * h) / 3 * (
                        2 * caclFunc(f, i - h * 3, results[previous - 2]) -
                        caclFunc(f, i - h * 2, results[previous - 1]) +
                        2 * caclFunc(f, i - h, results[previous])
                        );
                    results.Add(results[previous - 1] + h / 3 * (
                        caclFunc(f, i - h * 2, results[previous - 1]) +
                        4 * caclFunc(f, i - h, results[previous]) +
                        caclFunc(f, i, p)
                        ));
                }
            }

            return results;
        }

        private List<double> solveWithManage(double step, bool doubleStep) {
            double h = step;
            if (doubleStep) {
                h *= 2;
            }
            return null;
        }

        private double caclFunc(string f, double x, double y) {
            Expression expression = new Expression(f);
            expression.Parameters["x"] = x;
            expression.Parameters["y"] = y;
            return Math.Round((double)expression.Evaluate(), 3);
        }

        private double caclT(double t) {
            string func = "-Exp([t])+Pow([t], 2)-[t]*2+2";
            Expression expression = new Expression(func);
            expression.Parameters["t"] = t;
            return Math.Round((double)expression.Evaluate(), 3);
        }
    }
}
