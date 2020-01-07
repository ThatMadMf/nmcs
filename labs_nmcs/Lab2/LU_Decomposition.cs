using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs_nmcs.Lab2 {
  class LU_Decomposition {

    public double[] calculate_LU(double[] gammas, double[] alphas, double[] betas, double[] b) {

      double[] lVector = new double[b.Length];
      double[] uVector = new double[betas.Length];
      double[] yVector = new double[b.Length];
      double[] xVector = new double[b.Length];

      for (int k = 0; k < b.Length; k++) {
        if (k == 0) {
          lVector[k] = alphas[k];
          yVector[k] = b[k] / lVector[k];
        } else {
          lVector[k] = alphas[k] - betas[k - 1] * uVector[k - 1];
          yVector[k] = (b[k] - betas[k - 1] * yVector[k - 1]) / lVector[k];
        }
        if (k != betas.Length) {
          uVector[k] = gammas[k] / lVector[k];
        }
      }

      for (int k = b.Length - 1; k >= 0; k--) {
        if (k == b.Length - 1) {
          xVector[k] = yVector[k];
        } else {
          xVector[k] = yVector[k] - uVector[k] * xVector[k + 1];
        }
      }

      return xVector;
    }
  }
}
