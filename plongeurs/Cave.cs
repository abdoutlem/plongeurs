using System;
using System.Collections.Generic;
using System.Text;

namespace plongeurs
{
    class Cave
    {
        public int profondeur;
        public int largeur;
        public int niveaux;
        public int nbreTresors = 10;
        

        public Cave(int Profondeur, int Largeur, int Niveaux)
        {
            profondeur = Profondeur;
            largeur = Largeur;
            niveaux = Niveaux;
        }

        public void dessinerLaCave()
        {

            

            for (int i = 0; i < profondeur; i++)
            {
                Console.SetCursorPosition(4, i+3);
                Console.WriteLine("||");
                
            }
            
            for (int i = 0; i < largeur; i++)
            {
                
                Console.SetCursorPosition(i+6, profondeur + 2);
                Console.WriteLine("_");
            }


            for (int i = 0; i < profondeur; i++)
            {
                Console.SetCursorPosition(4 + largeur, i + 3);
                Console.WriteLine("||");

            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = 0; i<profondeur-2; i++)
            {
                Console.SetCursorPosition(6, i + 4);
                Console.WriteLine("#################################################################################################");
            }

            Console.SetCursorPosition(6,4);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void dessinerNiveaux()
        {

            int nbreNiveaux = 5; 

            for (int i = 0; i < largeur; i++)
            {
                Console.SetCursorPosition(i + 6, 7);
                Console.WriteLine("_");
            }
        }

        

        public int GetNbreTresors()
        {
            return this.nbreTresors;
        }

        public void SetNbreTresors(int NbreTresors)
        {
            this.nbreTresors = NbreTresors;

        }
    }
}
