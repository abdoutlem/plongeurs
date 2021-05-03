using System;
using System.Collections.Generic;
using System.Text;

namespace plongeurs
{
    class Oxygene
    {
        int reserve = 100;
        int reserveMax; 

        public int GetReserve()
        {
            return this.reserve; 
        }

        public void SetReserve(int Reserve)
        {
            this.reserve = Reserve;
        }


    }
}
