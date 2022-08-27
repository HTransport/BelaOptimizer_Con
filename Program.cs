using System;
using BelaOptimizer_Con.Models;

namespace BelaOptimizer_Con
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cards = new string[]{ "H7","H8","H9","HX","HJ","HQ","HK","HA","D7","D8","D9","DX","DJ","DQ","DK","DA","C7","C8","C9","CX","CJ","CQ","CK","CA","S7","S8","S9","SX","SJ","SQ","SK","SA"};

            Player P1 = new() { Id = 1};
            Player P2 = new() { Id = 2};
            Player P3 = new() { Id = 3};
            Player P4 = new() { Id = 4};

            Random rnd;

            Game game = new();
            int dealer;


            while(!game.Ended())
            {
                rnd = new(DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);
                if (game.PreviousDealer is null)
                    dealer = rnd.Next(1, 5);

                else if (Convert.ToInt32(game.PreviousDealer) == 4)
                    dealer = 1;

                else
                    dealer = Convert.ToInt32(game.PreviousDealer) + 1;

                Game.Set set = game.NewSet(dealer);
                game.PreviousDealer = dealer.ToString();

                string[] deck = game.Shuffle(cards, rnd);

                game.DealFirst(dealer, deck, P1, P2, P3, P4);

                switch (dealer)
                {
                    case 1:
                        {
                            set.Trump = P2.DecideTrump();
                            if (set.Trump != "PASS")
                                break;
                            set.Trump = P3.DecideTrump();
                            if (set.Trump != "PASS")
                                break;
                            set.Trump = P4.DecideTrump();
                            if (set.Trump != "PASS")
                                break;
                            set.Trump = P1.DecideTrump(true);
                            break;
                        }
                    case 2:
                        {
                            set.Trump = P3.DecideTrump();
                            if (set.Trump != "PASS")
                                break;
                            set.Trump = P4.DecideTrump();
                            if (set.Trump != "PASS")
                                break;
                            set.Trump = P1.DecideTrump();
                            if (set.Trump != "PASS")
                                break;
                            set.Trump = P2.DecideTrump(true);
                            break;
                        }
                    case 3:
                        {
                            set.Trump = P4.DecideTrump();
                            if (set.Trump != "PASS")
                                break;
                            set.Trump = P1.DecideTrump();
                            if (set.Trump != "PASS")
                                break;
                            set.Trump = P2.DecideTrump();
                            if (set.Trump != "PASS")
                                break;
                            set.Trump = P3.DecideTrump(true);
                            break;
                        }
                    case 4:
                        {
                            set.Trump = P1.DecideTrump();
                            if (set.Trump != "PASS")
                                break;
                            set.Trump = P2.DecideTrump();
                            if (set.Trump != "PASS")
                                break;
                            set.Trump = P3.DecideTrump();
                            if (set.Trump != "PASS")
                                break;
                            set.Trump = P4.DecideTrump(true);
                            break;
                        }
                    default:
                        throw new NotImplementedException();
                }

                game.DealSecond(dealer, deck, P1, P2, P3, P4);

                Console.WriteLine(set.Trump);

                // zvanja

                string P1decs = P1.CheckDeclarations();
                string P2decs = P2.CheckDeclarations();
                string P3decs = P3.CheckDeclarations();
                string P4decs = P4.CheckDeclarations();

                // WORK IN PROGRESS
                // WORK IN PROGRESS
                // WORK IN PROGRESS
            }
        }
    }
}
