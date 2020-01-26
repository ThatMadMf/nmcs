using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace labs_nmcs.Lab6 {
    class Euler : Lab {

        private double y0;
        private double t0;
        private double tk;
        private double h;
        private string f;
       

        private LinkedList<double> results;

        public Euler(double y0, double t0, double tk, double h, string f) {
            this.y0 = y0;
            this.t0 = t0;
            this.tk = tk;
            this.h = h;
            this.f = f;
            results = new LinkedList<double>();
            results.AddFirst(y0);
        }

        public void run() {
            double i = t0;
            foreach(var v in solve()) {
                Console.WriteLine("x = " + i + "\ty= " + v + "\t\t" + caclT(i));
                i += h;
            }
        }

        private List<double> solve() {
            for (double i = t0; i < tk; i = Math.Round(i + h, 1)) {
                if (results.Count < 2) {
                    results.AddLast(results.Last.Value + h * caclFunc(f, i, results.Last.Value));
                } else {
                    results.AddLast(results.Last.Previous.Value + 2 * h * caclFunc(f, i, results.Last.Value));
                }
            }
            return results.ToList();
        }

        private double caclFunc(string f, double x, double y) {
            Expression expression = new Expression(f);
            expression.Parameters["x"] = x;
            expression.Parameters["y"] = y;
            return Math.Round((double)expression.Evaluate(), 3);
        }

        private double caclT(double t) {
            string func = "1/(1-([t]*[t]))";
            Expression expression = new Expression(func);
            expression.Parameters["t"] = t;
            return Math.Round((double)expression.Evaluate(), 3);

        }

    }
}
