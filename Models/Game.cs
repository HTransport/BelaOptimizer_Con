using System;

namespace BelaOptimizer_Con.Models
{
    public class Game
    {
        public int We { get; set; }
        public int Thy { get; set; }
        public string PreviousDealer { get; set; }

        public Game()
        {
            We = 0;
            Thy = 0;
        }

        public bool Ended()
        {
            if (We < 1001)
                if (Thy < 1001)
                    return false;

            return true;
        }

        public string Winner()
        {
            if (We >= 1001)
                if (Thy == We)
                    return "DRAW";

            if (We >= 1001)
                if (Thy > We)
                    return "THY";

            if (We >= 1001)
                if (Thy < We)
                    return "WE";

            if (Thy >= 1001)
                return "THY";

            return "NONE";
        }

        public string[] Shuffle(string[] cards, Random rnd)
        {
            string[] deck = new string[32];
            foreach (string x in cards)
            {
                int y = rnd.Next(0, 32);

                while (deck[y] is not null)
                {
                    y = rnd.Next(0, 32);
                }
                deck[y] = x;
            }
            return deck;
        }

        public void DealFirst(int dealer, string[] deck, Player P1, Player P2, Player P3, Player P4)
        {
            int start;
            int deckState = 0;

            if (dealer == 4)
                start = 1;
            else
                start = dealer + 1;

            for (int i = start; ;)
            {
                for (int j = 0; j < 6; j++)
                {
                    switch (i)
                    {
                        case 1: P1.Hand[j] = deck[j + deckState]; break;
                        case 2: P2.Hand[j] = deck[j + deckState]; break;
                        case 3: P3.Hand[j] = deck[j + deckState]; break;
                        case 4: P4.Hand[j] = deck[j + deckState]; break;

                        default:
                            throw new NotImplementedException();
                    }
                }
                deckState += 6;

                if (deckState == 24)
                    return;

                if (i == 4)
                    i = 1;
                else
                    i++;
            }
        }



        public void DealSecond(int dealer, string[] deck, Player P1, Player P2, Player P3, Player P4)
        {
            int start;
            int deckState = 24;

            if (dealer == 4)
                start = 1;
            else
                start = dealer + 1;

            for (int i = start; ;)
            {
                for (int j = 0; j < 2; j++)
                {
                    switch (i)
                    {
                        case 1: P1.Hand[j + 6] = deck[j + deckState]; break;
                        case 2: P2.Hand[j + 6] = deck[j + deckState]; break;
                        case 3: P3.Hand[j + 6] = deck[j + deckState]; break;
                        case 4: P4.Hand[j + 6] = deck[j + deckState]; break;

                        default:
                            throw new NotImplementedException();
                    }
                }
                deckState += 2;

                if (deckState == 32)
                    return;

                if (i == 4)
                    i = 1;
                else
                    i++;
            }
        }

        public Set NewSet(int Id)
        {
            return new(Id);
        }

        public class Set
        {
            public int Points { get; set; }
            public int We { get; set; }
            public int Thy { get; set; }
            public int DeclarationsWe { get; set; }
            public int DeclarationsThy { get; set; }
            public string Trump { get; set; }
            public int DealerId { get; set; }

            public Set(int Id)
            {
                DealerId = Id;
                DeclarationsWe = 0;
                DeclarationsThy = 0;
                Points = 162;
                We = 0;
                Thy = 0;
            }
        }
    }
}
