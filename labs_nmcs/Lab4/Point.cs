using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs_nmcs.Lab4 {
  public class Point {
    private double x;
    private double y;

    public double X => x;
    public double Y => y;

    public Point(double x, double y) {
      this.x = x;
      this.y = y;
    }
  }
}
