using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogueJouetDll
{
    public class TrancheAge
    {
        private int code;
        private int ageMin;
        private int ageMax;

        public TrancheAge(int pCode, int pMax, int pMin)
        {
            code = pCode;
            ageMax = pMax;
            ageMin = pMin;
        }

        public int getCode()
        {
            return code;
        }
        public int getAgeMin()
        {
            return ageMin;
        }

        public int getAgeMax()
        {
            return ageMax;
        }

        public override string ToString()
        {
            return ageMin + " - " + ageMax;
        }
    }
}
