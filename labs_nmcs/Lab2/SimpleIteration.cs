using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs_nmcs.Lab2 {
  class SimpleIteration {

    private List<double[]> resultsTable;
    private List<double[]> differences;
    private double[][] odds;
    private static double eps = 0.01;

    public SimpleIteration(double[][] input) {
      resultsTable = new List<double[]>();
      differences = new List<double[]>();

      odds = new double[input.Length][];
      addOdds(input);
      run(input);
    }

    private void run(double[][] input) {
      if (isOptimized()) {
        Console.WriteLine("SOLE is optimized");
        simpleIteraion();
        showSolution(input);
      } else {
        Console.WriteLine("SOLE is not optimized \n Performing optimization...");
        performOptimization(input);
        addOdds(input);
        if (isOptimized()) {
          Console.WriteLine("SOLE is now opitmized \n Performing calculation...");
          simpleIteraion();
          showSolution(input);
        } else {
          throw new Exception("SOLE cannot be optimized.");
        }
      }
    }

    private void showSolution(double[][] input) {
      for (int i = 0; i < resultsTable[0].Length; i++) {
        Console.Write($"x{ i + 1} = {resultsTable[resultsTable.Count - 1][i]}; ");
      }
      Console.WriteLine("Solution check: ");
      for (int i = 0; i < resultsTable[0].Length; i++) {
        Console.WriteLine("\t Result is " + checkEquation(input[i]));
      }
    }

    private double checkEquation(double[] input) {
      double sum = 0; 
      for (int i = 0; i < resultsTable[0].Length; i++) {
        Console.Write(input[i] + "*" + resultsTable[resultsTable.Count - 1][i]);
        if(i != resultsTable[0].Length - 1) {
          Console.Write(" + ");
        }
        sum += input[i] * resultsTable[resultsTable.Count - 1][i];
      }
      Console.Write(" = " + input[input.Length - 1]);
      return sum;
    }

    public void showResult() {
      int count = 0;
      foreach (var line in resultsTable) {
        Console.WriteLine("Iteration " + count);
        foreach (var x in line) {
          Console.Write(x + "\t");
        }
        Console.WriteLine();
        count++;
      }
    }

    public void showDifferences() {
      int count = 0;
      foreach (var line in differences) {
        Console.WriteLine("Iteration " + count);
        foreach (var e in line) {
          Console.Write(e + "\t");
        }
        Console.WriteLine();
        count++;
      }
    }

    private void simpleIteraion() {
      int counter = 0;

      while (counter <= 100 && !checkEpsilon()) {
        performIteration(resultsTable[resultsTable.Count - 1]);
        counter++;
      }
    }

    private bool checkEpsilon() {
      if (resultsTable.Count < 2) {
        return false;
      }
      bool result = true;
      double[] currentIteration = new double[resultsTable[0].Length];
      for (int i = 0; i < resultsTable[0].Length; i++) {
        double current = resultsTable[resultsTable.Count - 1][i];
        double previous = resultsTable[resultsTable.Count - 2][i];
        currentIteration[i] = Math.Abs(current - previous);
        if (currentIteration[i] > eps) {
          result = false;
        }
        currentIteration[i] = Math.Round(currentIteration[i], 3);
      }
      differences.Add(currentIteration);
      return result;
    }

    private void addOdds(double[][] input) {
      double[] current = new double[input[0].Length - 1];

      for (int i = 0; i < input[0].Length - 1; i++) {
        odds[i] = calculateOdds(input[i], i);
        current[i] = odds[i][i];
      }

      resultsTable.Add(current);
      differences.Add(current);
    }

    private double[] calculateOdds(double[] input, int index) {
      double[] odds = new double[input.Length - 1];

      for (int j = 0; j < input.Length - 1; j++) {
        if (j == index) {
          odds[j] = Math.Round(input[input.Length - 1] / input[j], 3);
        } else {
          odds[j] = Math.Round(input[j] / input[index], 3);
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
        currentIteration[i] = Math.Round(currentIteration[i], 3);
      }
      resultsTable.Add(currentIteration);
    }

    private bool isOptimized() {
      for (int i = 0; i < odds[0].Length; i++) {
        double sum = 0;
        for (int j = 0; j < odds[0].Length; j++) {
          if (i != j) {
            sum += odds[i][j];
          }
        }
        if (sum >= 2) {
          return false;
        }
      }
      return true;
    }

    private void performOptimization(double[][] input) {
      for (int i = 0; i < input[0].Length - 1; i++) {
        double max = input[i][i];
        int maxIndex = i;
        for (int j = i + 1; j < input[0].Length - 1; j++) {
          if (input[i][j] > max) {
            max = input[i][j];
            maxIndex = j;
          }
        }
        if (maxIndex != i) {
          for (int j = 0; j < input.Length; j++) {
            var temp = input[j][i];
            input[j][i] = input[j][maxIndex];
            input[j][maxIndex] = temp;
          }
        }
      }
    }
  }
}
