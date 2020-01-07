using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labs_nmcs.Lab4 {
  public partial class Field : Form {

    private double xBeginning;
    private double xLast;
    private double yBeginning;
    private double yLast;
    private double xStep;
    private double yStep;
    private Graphics graphics;

    public Field(double x0, double y0, double xn, double yn, int pointsNum) {
      InitializeComponent();
      xBeginning = x0;
      yBeginning = y0;
      xLast = xn;
      yLast = yn;
      xStep = (xLast - xBeginning) / pointsNum;
      yStep = (yLast - yBeginning) / pointsNum;
      Size = new Size(pointsNum, pointsNum + 200);
      graphics = this.CreateGraphics();
    }

    public void drawPoint(Point point, Brush brush) {
      Point p = makeCoordinate(point);
      graphics.FillRectangle(brush, (float)p.X, (float)p.Y, 3, 3);
    }

    private Point makeCoordinate(Point point) {
      int x = Convert.ToInt32((point.X - xBeginning) / xStep);
      int y = Size.Height - 100 - Convert.ToInt32((point.Y - yBeginning) / yStep);
      return new Point(x, y);
    }
  }
}
