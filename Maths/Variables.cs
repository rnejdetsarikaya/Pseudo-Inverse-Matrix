using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoInverse.Maths
{
   public class Variables
    {
        private static Variables instance = null;
        private Variables() {}

        public double det { get; set; }
        public double[,] A { get; set; }
        public double[,] ATranspose { get; set; }
        public double[,] Multiply { get; set; }
        public double[,] MultiplyInverse { get; set; }
        public double[,] PseudoInverse { get; set; }
        public string RowOrColumn { get; set; }
        public int Additions { get; set; }
        public int Multiplactions { get; set; }
        public int Loops { get; set; }


        public static Variables Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Variables();
                }
                return instance;
            }
            
        }

        

    }
}
