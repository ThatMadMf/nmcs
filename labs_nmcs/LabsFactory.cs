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
                    return new Lab6.Euler(1, 0, 0.9, 0.1, "2*[x]*[y]*[y]");
                default:
                    throw new Exception("Not implemented");
            }
        }
    }
}
