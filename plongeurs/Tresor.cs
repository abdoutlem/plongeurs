using System;
using System.Collections.Generic;
using System.Text;

namespace plongeurs
{
    class Tresor
    {

        public int[] Xposition = new int[10];
        public int[] Yposition = new int[10];
        public int[] PointsTresors = new int[10]; 
        
       
        public void genererTresor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 10; i++)
            {
                
                Console.SetCursorPosition(50, this.GetYposition(i));
                Console.WriteLine("T");
                
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        public int GetXposition(int indice)
        {
            return Xposition[indice];
        }

        public void SetXposition(int indice, int XPosition)
        {
            Xposition[indice] = XPosition;
        }

        public int GetYposition(int indice)
        {
            return Yposition[indice];
        }

        public void SetYposition(int indice, int YPosition)
        {
            
            Yposition[indice] = YPosition; 
            
        }
    }
}
