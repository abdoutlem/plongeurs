using System;
using System.Collections.Generic;
using System.Text;

namespace plongeurs
{
    class Plongeur
    {
        public String nom;
        public int score = 0 ;
        public int scorePossible = 0; 
        public int oxygene = 20;
        public int Yposition = 2;
        public int numeroJoueur;
        public int tresorsEnPossesion = 0;
        public int tresorsValides = 0;

   

        public Plongeur(String Nom, int NumeroJoueur)
        {
            nom = Nom;
            numeroJoueur = NumeroJoueur;
        }


        public void prendre(Tresor tresor,int indice)
        {
            
            tresor.SetYposition(indice,30);
          
            
        }

        public void apparition()
        {
            if (this.numeroJoueur == 1)
            {
                Console.SetCursorPosition(20,this.Yposition);
                Console.WriteLine("%");
            }
            if (this.numeroJoueur == 2)
            {
                Console.SetCursorPosition(80, this.Yposition);
                Console.WriteLine("%");
            }

        }

        public void descendre()
        {
            this.Yposition = Yposition + 1;
        }

        public void monter()
        {
            this.Yposition = Yposition - 1;
        }

        public int GetYPosition()
        {
            return this.Yposition;
        }

        public void SetYPosition(int YPosition)
        {
            this.Yposition = YPosition;
        }

        public int GetScore()
        {
            return this.score;
        }

        public void SetScore(int Score)
        {
            this.score = Score; 
        }

        public int GetScorePossible()
        {
            return this.scorePossible;
        }

        public void SetScorePossible(int score)
        {
            this.scorePossible = score;
        }

        public int GetTresorsEnPossession()
        {
            return this.tresorsEnPossesion;
        }

        public void SetTresorsEnPossession(int Possession)
        {
            this.tresorsEnPossesion = Possession;
        }

        public int GetTresorsValides()
        {
            return this.tresorsValides;
        }

        public void SetTresorsValides(int TresValides)
        {
            this.tresorsValides = TresValides;
        }

    }
}
