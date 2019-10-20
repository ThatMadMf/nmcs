using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs_nmcs.Lab2 {
  class SimpleIteration {

    private List<double[]> resultsTable;
    private double[][] odds;
    private static double eps = 0.001;

    public SimpleIteration(double[][] input) {
      resultsTable = new List<double[]>();
      odds = new double[input.Length][];
      double[] current = new double[input[0].Length - 1];

      for (int i = 0; i < input[0].Length - 1; i++) {
        odds[i] = calculateOdds(input[i], i);
        current[i] = odds[i][i];
      }

      resultsTable.Add(current);
      simpleIteraion();
      Console.WriteLine(resultsTable);
    }

    private void simpleIteraion() {
      int counter = 0;

      while(counter <= 100 && !checkEpsilon()) {
        performIteration(resultsTable[resultsTable.Count - 1]);
        counter++;
      }
    }

    private bool checkEpsilon() {
      if(resultsTable.Count < 2) {
        return false;
      }
      for(int i = 0; i < resultsTable[0].Length; i++) {
        double current = resultsTable[resultsTable.Count - 1][i];
        double previous = resultsTable[resultsTable.Count - 2][i];
        if (Math.Abs(current - previous) > eps) {
          return false;
        }
      }
      return true;
    }

    private double[] calculateOdds(double[] input, int index) {
      double[] odds = new double[input.Length - 1];

      for (int j = 0; j < input.Length - 1; j++) {
        if (j == index) {
          odds[j] =input[input.Length - 1] / input[j];
        } else {
          odds[j] = input[j] / input[index];
        }
      }
      return odds;
    }

    private void performIteration(double[] input) {
      double[] currentIteration = new double[input.Length];

      for (int i = 0; i < currentIteration.Length; i++) {
          currentIteration[i] = 0;
        for (int j = 0; j < currentIteration.Length; j++) {
          if (i == j) {
            currentIteration[i] += odds[i][j];
          } else {
            currentIteration[i] -= input[j] * odds[i][j];
          }
        }
        currentIteration[i] = currentIteration[i];
      }
      resultsTable.Add(currentIteration);
    }
  }
}
