using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs_nmcs {
    class LabsFactory {

        public static Lab getLab(Labs lab) {
            switch (lab) {
                case Labs.Eluler:
                    return new Lab6.Euler(1, 0, 0.9, 0.05, "2*[x]*[y]*[y]");
                case Labs.Milne:
                    return new Lab7.Milne(0, 5, 1, "[y]+3*[x]-Pow([x],2)");
                default:
                    throw new Exception("Not implemented");
            }
        }
    }
}
