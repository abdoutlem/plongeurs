using System;
using System.Collections.Generic;

namespace plongeurs
{
    class Program
    {
        
        

        static void Main(string[] args)
        {
            
            int jeu = 1;
            int tour = 1;
            int c = 0;
            int k = 0;
            int d = 0;

            string Gagnant = "Personne";
            string nomPlongeur1;
            string nomPlongeur2;


            Console.SetWindowSize(200,50);
            //Console.SetBufferSize(150,150);

            //Fenetre de lancement
            while (c == 0)
            {
                Cave init = new Cave(20,100,10);
                if (k==0)
                {
                    
                    for (int i = 0; i < init.profondeur; i++)
                    {
                        Console.SetCursorPosition(4, i + 3);
                        Console.WriteLine("||");
                        
                    }

                    for (int i = 0; i < init.largeur; i++)
                    {
                        Console.SetCursorPosition(i + 6, init.profondeur + 2);
                        Console.WriteLine("_");
                    }

                    for (int i = 0; i < init.profondeur; i++)
                    {
                        Console.SetCursorPosition(4 + init.largeur, i + 3);
                        Console.WriteLine("||");

                    }

                    Console.ForegroundColor = ConsoleColor.DarkMagenta; 
                    Console.SetCursorPosition(42, 4);
                    Console.WriteLine("Bienvenue dans DIVING DUEL ! ");
                    Console.SetCursorPosition(48, 8);
                    Console.WriteLine("Régles du jeu : ");
                    Console.SetCursorPosition(8, 10);
                    Console.WriteLine("Bienvenue dans  Diving Duel . Il s'agit d'un jeu de stratégie en multijoueur 1 VS 1. \n \tChaque joueur est un plongeur et est représenté par le signe  % , il peut plonger \n \ten profondeur, remonter à la surface et s'emparer des si convoités Trésors.Chaque trésor\n \t rapporte un nombre de points qui dépend de sa profondeur, mais attention pour valider \n \tce Trésor il faut le remonter intégralement en surface. La stratégie réside dans le fait\n \t que l'oxygène disponible au cours de la partie est partagé entre les 2 plongeurs, si \n \tvous êtes sous l'eau et n'avait plus d'énergie vous êtes morts / Normal, on est pas \n \tdes poissons ! / Quand l'oxygène est épuisé, la partie s'achève, le joueur avec le score\n \t le plus élevé gagne.");
                    Console.SetCursorPosition(39, 20);
                    Console.WriteLine("Appuyer sur entree pour commencer");
                    Console.ForegroundColor = ConsoleColor.White;

                    k++;
                }

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    c++; 
                }
                

            }


            Cave scene = new Cave(20,100,10); // Profondeur conseillee = 20 et largeur conseillee = 100 
            Oxygene ox = new Oxygene();
            Plongeur plongeur1 = new Plongeur("joueur1",1);
            Plongeur plongeur2 = new Plongeur("joueur2",2);
            Tresor tres = new Tresor(); 



            // Initialisation de l'emplacement des tresors aleatoirement 
            Random rd = new Random(); 
            for(int i = 0; i< 10; i++)
            {
                tres.SetYposition(i,rd.Next(5,20));
            }

            Console.Clear();

            Console.WriteLine(" Veuillez saisir le nom du joueur 1");
            nomPlongeur1 = Console.ReadLine();


            
            // Verification de la bonne entree du prenom
            while (string.IsNullOrEmpty(nomPlongeur1))
            {
                Console.WriteLine("Le champs ne peut pas etre vide, essayez encore");
                nomPlongeur1 = Console.ReadLine();
            }

            Console.WriteLine("Veuillez saisir le nom du joueur 2");
            nomPlongeur2 = Console.ReadLine();

            while (string.IsNullOrEmpty(nomPlongeur2))
            {
                Console.WriteLine("Le champs ne peut pas etre vide, essayez encore");
                nomPlongeur2 = Console.ReadLine();
            }

           

            Console.Clear();

            while (jeu == 1)
            {
                


                //Dessin des element cles du jeu (Joueurs, Cave et tresors)
                Console.Clear();

                scene.dessinerLaCave();
                tres.genererTresor();

                plongeur1.apparition();
                plongeur2.apparition();





                //Quand les limites sont atteintes
                
                if (plongeur1.GetYPosition()<3) //Ne pas autoriser les joueurs a depasser le cadre du jeu
                {
                    plongeur1.SetYPosition(2);
                    
                }
                else if (plongeur1.GetYPosition()>20)
                {
                    plongeur1.SetYPosition(20);
                }
                if (plongeur2.GetYPosition() < 3) //Ne pas autoriser les joueurs a depasser le cadre du jeu
                {
                    plongeur2.SetYPosition(2);
                    
                }
                else if (plongeur2.GetYPosition() > 20)
                {
                    plongeur2.SetYPosition(20);
                }

                //si les joueurs sont toujours sous l'eau mais sans oxygene
                if(plongeur1.GetYPosition() > 4 && ox.GetReserve() < 1)
                {
                    plongeur1.SetScore(0);
                }
                if (plongeur2.GetYPosition() > 4 && ox.GetReserve() < 1)
                {
                    plongeur2.SetScore(0);
                }

                // Pour deposer les tresors en possession
                if (plongeur1.GetYPosition() == 4 && tour == 1)
                {
                    plongeur1.SetTresorsValides(plongeur1.GetTresorsEnPossession() + plongeur1.GetTresorsValides());
                    plongeur1.SetTresorsEnPossession(0);

                    plongeur1.SetScore(plongeur1.GetScorePossible() + plongeur1.GetScore());
                    plongeur1.SetScorePossible(0);

                    
                }

                if (plongeur2.GetYPosition() == 4 && tour == 2)
                {
                    plongeur2.SetTresorsValides(plongeur2.GetTresorsEnPossession() + plongeur2.GetTresorsValides());
                    plongeur2.SetTresorsEnPossession(0);

                    plongeur2.SetScore(plongeur2.GetScorePossible() + plongeur2.GetScore());
                    plongeur2.SetScorePossible(0);
                }

                if (ox.GetReserve() < 1)
                {
                    if (plongeur1.GetScore() > plongeur2.GetScore())
                    {
                        Gagnant = nomPlongeur1;
                    }
                    else if (plongeur1.GetScore() < plongeur2.GetScore())
                    {
                        Gagnant = nomPlongeur2;
                    }
                    else
                    {
                        Gagnant = "Personne"; 
                    }

                    jeu = 0; 
                }




                //Partie presentation des informations essentiels au jeu (Score, tresors, oxygene, consignes...)
                Console.SetCursorPosition(45, 25);
                Console.WriteLine("Niveau d'Oxygene : ");
                Console.SetCursorPosition(5, 26);
                for (int i = 0; i < ox.GetReserve(); i++)
                {
                    Console.Write("#");
                }
                Console.Write("\t");
                Console.WriteLine(ox.GetReserve());


                Console.SetCursorPosition(10, 30);
                Console.Write("Score plongeur 1 : ");
                Console.Write(plongeur1.GetScore());

                Console.SetCursorPosition(70, 30);
                Console.Write("Score plongeur 2 : ");
                Console.Write(plongeur2.GetScore());

                Console.SetCursorPosition(10, 32);
                Console.WriteLine("Plongeur 1 : ");
                Console.SetCursorPosition(10, 33);
                Console.Write("Tresors en possesion : ");
                Console.WriteLine(plongeur1.GetTresorsEnPossession());
                Console.SetCursorPosition(10, 34);
                Console.Write("Tresors valides : ");
                Console.WriteLine(plongeur1.GetTresorsValides());

                Console.SetCursorPosition(70, 32);
                Console.WriteLine("Plongeur 2 : ");
                Console.SetCursorPosition(70, 33);
                Console.Write("Tresors en possesion : ");
                Console.WriteLine(plongeur2.GetTresorsEnPossession());
                Console.SetCursorPosition(70, 34);
                Console.Write("Tresors valides : ");
                Console.WriteLine(plongeur2.GetTresorsValides());

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(43,36);
                Console.Write("Au tour de ");
                if (tour == 1)
                {
                    Console.WriteLine(nomPlongeur1);
                }
                else
                {
                    Console.WriteLine(nomPlongeur2);
                }
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(110,10);
                Console.Write("▲ : ");
                Console.WriteLine("Monter");
                Console.SetCursorPosition(110, 12);
                Console.Write("▼ : ");
                Console.WriteLine("Descendre (plonger)");
                Console.SetCursorPosition(110, 14);
                Console.Write("P : ");
                Console.WriteLine("Prendre un trésor (uniquement quand le plongeur est au même niveau )");



                //Lecture de la touche --> Actions possible 1.Descendre 2.Monter 3.Prendre le tresor
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.DownArrow:
                        if (tour == 1)
                        {
                            
                            plongeur1.descendre();
                            tour = 2;
                            ox.SetReserve(ox.GetReserve() - (plongeur1.GetTresorsEnPossession() * 2 + 1));
                        }
                        else
                        {
                            
                            plongeur2.descendre();
                            tour = 1;
                            ox.SetReserve(ox.GetReserve() - (plongeur2.GetTresorsEnPossession()*2 + 1));
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (tour == 1)
                        {
                            
                            plongeur1.monter();
                            tour = 2;
                            ox.SetReserve(ox.GetReserve() - (plongeur1.GetTresorsEnPossession() * 2 + 1));
                                    
                        }
                        else
                        {
                           
                            plongeur2.monter();
                            tour = 1;
                            ox.SetReserve(ox.GetReserve() - (plongeur2.GetTresorsEnPossession() * 2 + 1));
                        }
                        break;


                    case ConsoleKey.P:
                        for (int i = 0; i < 10; i++)
                        {
                            if (plongeur1.GetYPosition() == tres.GetYposition(i) && tour == 1)
                            {
                                plongeur1.prendre(tres, i);
                                plongeur1.SetTresorsEnPossession(plongeur1.GetTresorsEnPossession() + 1);
                                plongeur1.SetScorePossible(plongeur1.GetYPosition()*plongeur1.GetTresorsEnPossession());
                                tour = 2; 
                                break;
                            }
                            else if (plongeur2.GetYPosition() == tres.GetYposition(i) && tour == 2)
                            {
                                plongeur2.prendre(tres, i);
                                plongeur2.SetTresorsEnPossession(plongeur2.GetTresorsEnPossession() + 1);
                                plongeur2.SetScorePossible(plongeur2.GetYPosition() * plongeur2.GetTresorsEnPossession());
                                tour = 1; 
                                break;
                            }
                        }
                        break;

                }

            
            
                
                


            }

            while (true)
            {
                 
                if (d == 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(100,20);
                    Console.Write("Le joueur ");
                    Console.Write(Gagnant);
                    Console.WriteLine("a gagne !!!!!!!!!!!!!!!!");
                    d++;
                }
                
            }
            









        }
    }
}
