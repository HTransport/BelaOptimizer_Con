using System;

namespace BelaOptimizer_Con.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string[] Hand { get; set; }

        public Player()
        {
            Hand = new string[8];
        }

        public string DecideTrump()
        {
            // Player Algo

            int treshold = 17;
            int H = 0, C = 0, D = 0, S = 0;
            int J = 12;
            int IX = 8;
            int A = 6;
            int X = 4, b = 2;

            bool h = false, c = false, d = false, s = false;

            foreach (string card in Hand)
            {
                if (card is null)
                    continue;
                if(card[1] == 'J')
                {
                    switch (card[0])
                    {
                        case 'H': H += J; break;
                        case 'C': C += J; break;
                        case 'D': D += J; break;
                        case 'S': S += J; break;
                    }
                }
                if (card[1] == '9')
                {
                    switch (card[0])
                    {
                        case 'H': H += IX; break;
                        case 'C': C += IX; break;
                        case 'D': D += IX; break;
                        case 'S': S += IX; break;
                    }
                }
                if (card[1] == 'A')
                {
                    switch (card[0])
                    {
                        case 'H': H += A; h = true; break;
                        case 'C': C += A; c = true; break;
                        case 'D': D += A; d = true; break;
                        case 'S': S += A; s = true; break;
                    }
                }
                if (card[1] == 'X')
                {
                    switch (card[0])
                    {
                        case 'H': H += X; break;
                        case 'C': C += X; break;
                        case 'D': D += X; break;
                        case 'S': S += X; break;
                    }
                }
                if (card[1] == 'K' || card[1] == 'Q' || card[1] == '8' || card[1] == '7')
                {
                    switch (card[0])
                    {
                        case 'H': H += b; break;
                        case 'C': C += b; break;
                        case 'D': D += b; break;
                        case 'S': S += b; break;
                    }
                }
            }

            if (H > treshold)
                if (c || d || s)
                    return "H";

            if (C > treshold)
                if (h || d || s)
                    return "C";

            if (D > treshold)
                if (c || h || s)
                    return "D";

            if (S > treshold)
                if (c || d || h)
                    return "S";

            if (H >= treshold + 1)
                return "H";

            if (C >= treshold + 1)
                return "C";

            if (D >= treshold + 1)
                return "D";

            if (S >= treshold + 1)
                return "S";

            return "PASS";
        }
        public string DecideTrump(bool i)
        {
            int H = 0, C = 0, D = 0, S = 0;

            foreach (string card in Hand)
            {
                if (card is null)
                    continue;
                if (card[1] == 'J')
                {
                    switch (card[0])
                    {
                        case 'H': H += 5; break;
                        case 'C': C += 5; break;
                        case 'D': D += 5; break;
                        case 'S': S += 5; break;
                    }
                }
                if (card[1] == '9')
                {
                    switch (card[0])
                    {
                        case 'H': H += 4; break;
                        case 'C': C += 4; break;
                        case 'D': D += 4; break;
                        case 'S': S += 4; break;
                    }
                }
                if (card[1] == 'A')
                {
                    switch (card[0])
                    {
                        case 'H': H += 3; break;
                        case 'C': C += 3; break;
                        case 'D': D += 3; break;
                        case 'S': S += 3; break;
                    }
                }
                if (card[1] == 'X')
                {
                    switch (card[0])
                    {
                        case 'H': H += 1; break;
                        case 'C': C += 1; break;
                        case 'D': D += 1; break;
                        case 'S': S += 1; break;
                    }
                }
                if (card[1] == 'K' || card[1] == 'Q' || card[1] == '8' || card[1] == '7')
                {
                    switch (card[0])
                    {
                        case 'H': H += 1; break;
                        case 'C': C += 1; break;
                        case 'D': D += 1; break;
                        case 'S': S += 1; break;
                    }
                }
            }

            if (H >= C && H >= D && H >= S)
                return "H";

            if (C >= H && C >= D && C >= S)
                return "C";

            if (D >= H && D >= C && D >= S)
                return "D";

            if (S >= H && S >= C && S >= D)
                return "S";

            Random rnd = new(DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);

            string symbols = "HCDS";

            return symbols[rnd.Next(0, 4)].ToString();
        }
        public string CheckDeclarations()
        {
            int J = 0, IX = 0, A = 0, X = 0, K = 0, Q = 0,  H = 0, C = 0, D = 0, S = 0;
            byte h = 0, c = 0, d = 0, s = 0;
            bool hbool = false, cbool = false, dbool = false, sbool = false;
            foreach (string card in Hand)
            {
                switch (card[0])
                {
                    case 'H': H++; hbool = true; break;
                    case 'C': C++; cbool = true; break;
                    case 'D': D++; dbool = true; break;
                    case 'S': S++; sbool = true; break;
                }
                switch (card[1])
                {
                    case 'J': 
                        J++;
                        if (hbool)
                            h += 16;
                        if (cbool)
                            c += 16;
                        if (dbool)
                            d += 16;
                        if (sbool)
                            s += 16;
                        break;
                    case '9': 
                        IX++;
                        if (hbool)
                            h += 4;
                        if (cbool)
                            c += 4;
                        if (dbool)
                            d += 4;
                        if (sbool)
                            s += 4;
                        break;
                    case 'A': 
                        A++;
                        if (hbool)
                            h += 128;
                        if (cbool)
                            c += 128;
                        if (dbool)
                            d += 128;
                        if (sbool)
                            s += 128;
                        break;
                    case 'X': 
                        X++;
                        if (hbool)
                            h += 8;
                        if (cbool)
                            c += 8;
                        if (dbool)
                            d += 8;
                        if (sbool)
                            s += 8;
                        break;
                    case 'K': 
                        K++;
                        if (hbool)
                            h += 64;
                        if (cbool)
                            c += 64;
                        if (dbool)
                            d += 64;
                        if (sbool)
                            s += 64;
                        break;
                    case 'Q': 
                        Q++;
                        if (hbool)
                            h += 32;
                        if (cbool)
                            c += 32;
                        if (dbool)
                            d += 32;
                        if (sbool)
                            s += 32;
                        break;
                    case '8':
                        if (hbool)
                            h += 2;
                        if (cbool)
                            c += 2;
                        if (dbool)
                            d += 2;
                        if (sbool)
                            s += 2;
                        break;
                    case '7':
                        if (hbool)
                            h += 1;
                        if (cbool)
                            c += 1;
                        if (dbool)
                            d += 1;
                        if (sbool)
                            s += 1;
                        break;
                    default: break;
                }
                hbool = cbool = dbool = sbool = false;
            }
            string returnString = "";

            if (CombinationGot(c, 255) || CombinationGot(d, 255) || CombinationGot(s, 255))
                return "BELOTE";

            if (J == 4)
                returnString += "200J";

            if (IX == 4)
                returnString += "1509";

            if (A == 4)
                returnString += "100A";

            if (X == 4)
                returnString += "100X";

            if (K == 4)
                returnString += "100K";

            if (Q == 4)
                returnString += "100Q";

            if (Q == 0 && IX == 0)
            {
                returnString += "_0";
                return returnString;
            }

            // 100A
            if(h - 248 == 0 || h - 248 == 1 || h - 248 == 2 || h - 248 == 4)
            {
                returnString += "_100A";
                returnString = Check20s(h, c, d, s, returnString, "h");
                returnString += "_0";
                return returnString;
            }
            else if (CombinationGot(c, 248))
            {
                returnString += "_100A";
                returnString = Check20s(h, c, d, s, returnString, "c");
                returnString += "_0";
                return returnString;
            }
            else if (CombinationGot(d, 248))
            {
                returnString += "_100A";
                returnString = Check20s(h, c, d, s, returnString, "d");
                returnString += "_0";
                return returnString;
            }
            else if (CombinationGot(s, 248))
            {
                returnString += "_100A";
                returnString = Check20s(h, c, d, s, returnString, "s");
                returnString += "_0";
                return returnString;
            }
            // 100K
            else if (CombinationGot(h, 124))
            {
                returnString += "_100K";
                returnString = Check20s(h, c, d, s, returnString, "h");
                returnString += "_0";
                return returnString;
            }
            else if (CombinationGot(c, 124))
            {
                returnString += "_100K";
                returnString = Check20s(h, c, d, s, returnString, "c");
                returnString += "_0";
                return returnString;
            }
            else if (CombinationGot(d, 124))
            {
                returnString += "_100K";
                returnString = Check20s(h, c, d, s, returnString, "d");
                returnString += "_0";
                return returnString;
            }
            else if (CombinationGot(s, 124))
            {
                returnString += "_100K";
                returnString = Check20s(h, c, d, s, returnString, "s");
                returnString += "_0";
                return returnString;
            }
            // 100Q
            else if (CombinationGot(h, 62))
            {
                returnString += "_100Q";
                returnString = Check20s(h, c, d, s, returnString, "h");
                returnString += "_0";
                return returnString;
            }
            else if (CombinationGot(c, 62))
            {
                returnString += "_100Q";
                returnString = Check20s(h, c, d, s, returnString, "c");
                returnString += "_0";
                return returnString;
            }
            else if (CombinationGot(d, 62))
            {
                returnString += "_100Q";
                returnString = Check20s(h, c, d, s, returnString, "d");
                returnString += "_0";
                return returnString;
            }
            else if (CombinationGot(s, 62))
            {
                returnString += "_100Q";
                returnString = Check20s(h, c, d, s, returnString, "s");
                returnString += "_0";
                return returnString;
            }
            // 100J
            else if (CombinationGot(h, 31))
            {
                returnString += "_100J";
                returnString = Check20s(h, c, d, s, returnString, "h");
                returnString += "_0";
                return returnString;
            }
            else if (CombinationGot(c, 31))
            {
                returnString += "_100J";
                returnString = Check20s(h, c, d, s, returnString, "c");
                returnString += "_0";
                return returnString;
            }
            else if (CombinationGot(d, 31))
            {
                returnString += "_100J";
                returnString = Check20s(h, c, d, s, returnString, "d");
                returnString += "_0";
                return returnString;
            }
            else if (CombinationGot(s, 31))
            {
                returnString += "_100J";
                returnString = Check20s(h, c, d, s, returnString, "s");
                returnString += "_0";
                return returnString;
            }
            // 50s

            RM1 rm = Check50s(h, c, d, s, returnString);

            returnString = rm.RS;

            if (rm.Ended)
                return returnString;

            // 20s

            rm = Check20s(h, c, d, s, returnString);

            returnString = rm.RS;

            if (rm.Ended)
                return returnString;

            returnString += "_0";
            return returnString;
        }
        private RM1 Check50s(byte h, byte c, byte d, byte s, string rs)
        {
            if (CombinationGot(h, 240))
            {
                rs += "_50A";
                rs = Check50s(h, c, d, s, rs, "h");
                rs = Check20s(h, c, d, s, rs, "h");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(c, 240))
            {
                rs += "_50A";
                rs = Check50s(h, c, d, s, rs, "c");
                rs = Check20s(h, c, d, s, rs, "c");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(d, 240))
            {
                rs += "_50A";
                rs = Check50s(h, c, d, s, rs, "d");
                rs = Check20s(h, c, d, s, rs, "d");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(s, 240))
            {
                rs += "_50A";
                rs = Check50s(h, c, d, s, rs, "s");
                rs = Check20s(h, c, d, s, rs, "s");
                return new(rs + "_0", true);
            }
            if (CombinationGot(h, 120))
            {
                rs += "_50K";
                rs = Check50s(h, c, d, s, rs, "h");
                rs = Check20s(h, c, d, s, rs, "h");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(c, 120))
            {
                rs += "_50K";
                rs = Check50s(h, c, d, s, rs, "c");
                rs = Check20s(h, c, d, s, rs, "c");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(d, 120))
            {
                rs += "_50K";
                rs = Check50s(h, c, d, s, rs, "d");
                rs = Check20s(h, c, d, s, rs, "d");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(s, 120))
            {
                rs += "_50K";
                rs = Check50s(h, c, d, s, rs, "s");
                rs = Check20s(h, c, d, s, rs, "s");
                return new(rs + "_0", true);
            }
            if (CombinationGot(h, 60))
            {
                rs += "_50Q";
                rs = Check50s(h, c, d, s, rs, "h");
                rs = Check20s(h, c, d, s, rs, "h");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(c, 60))
            {
                rs += "_50Q";
                rs = Check50s(h, c, d, s, rs, "c");
                rs = Check20s(h, c, d, s, rs, "c");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(d, 60))
            {
                rs += "_50Q";
                rs = Check50s(h, c, d, s, rs, "d");
                rs = Check20s(h, c, d, s, rs, "d");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(s, 60))
            {
                rs += "_50Q";
                rs = Check50s(h, c, d, s, rs, "s");
                rs = Check20s(h, c, d, s, rs, "s");
                return new(rs + "_0", true);
            }
            if (CombinationGot(h, 30))
            {
                rs += "_50J";
                rs = Check50s(h, c, d, s, rs, "h");
                rs = Check20s(h, c, d, s, rs, "h");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(c, 30))
            {
                rs += "_50J";
                rs = Check50s(h, c, d, s, rs, "c");
                rs = Check20s(h, c, d, s, rs, "c");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(d, 30))
            {
                rs += "_50J";
                rs = Check50s(h, c, d, s, rs, "d");
                rs = Check20s(h, c, d, s, rs, "d");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(s, 30))
            {
                rs += "_50J";
                rs = Check50s(h, c, d, s, rs, "s");
                rs = Check20s(h, c, d, s, rs, "s");
                return new(rs + "_0", true);
            }
            if (CombinationGot(h, 15))
            {
                rs += "_50X";
                rs = Check50s(h, c, d, s, rs, "h");
                rs = Check20s(h, c, d, s, rs, "h");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(c, 15))
            {
                rs += "_50X";
                rs = Check50s(h, c, d, s, rs, "c");
                rs = Check20s(h, c, d, s, rs, "c");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(d, 15))
            {
                rs += "_50X";
                rs = Check50s(h, c, d, s, rs, "d");
                rs = Check20s(h, c, d, s, rs, "d");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(s, 15))
            {
                rs += "_50X";
                rs = Check50s(h, c, d, s, rs, "s");
                rs = Check20s(h, c, d, s, rs, "s");
                return new(rs + "_0", true);
            }
            return new(rs, false);
        }
        private string Check50s(byte h, byte c, byte d, byte s, string rs, string suit)
        {
            switch (suit)
            {
                case "h":
                    if (CombinationGot(c, 240) || CombinationGot(d, 240) || CombinationGot(s, 240))
                    {
                        rs += "_50A";
                        return rs;
                    }

                    if (CombinationGot(c, 120) || CombinationGot(d, 120) || CombinationGot(s, 120))
                    {
                        rs += "_50K";
                        return rs;
                    }

                    if (CombinationGot(c, 60) || CombinationGot(d, 60) || CombinationGot(s, 60))
                    {
                        rs += "_50Q";
                        return rs;
                    }

                    if (CombinationGot(c, 30) || CombinationGot(d, 30) || CombinationGot(s, 30))
                    {
                        rs += "_50J";
                        return rs;
                    }

                    if (CombinationGot(c, 15) || CombinationGot(d, 15) || CombinationGot(s, 15))
                    {
                        rs += "_50X";
                        return rs;
                    }
                    break;
                case "c":
                    if (CombinationGot(h, 240) || CombinationGot(d, 240) || CombinationGot(s, 240))
                    {
                        rs += "_50A";
                        return rs;
                    }

                    if (CombinationGot(h, 120) || CombinationGot(d, 120) || CombinationGot(s, 120))
                    {
                        rs += "_50K";
                        return rs;
                    }

                    if (CombinationGot(h, 60) || CombinationGot(d, 60) || CombinationGot(s, 60))
                    {
                        rs += "_50Q";
                        return rs;
                    }

                    if (CombinationGot(h, 30) || CombinationGot(d, 30) || CombinationGot(s, 30))
                    {
                        rs += "_50J";
                        return rs;
                    }

                    if (CombinationGot(h, 15) || CombinationGot(d, 15) || CombinationGot(s, 15))
                    {
                        rs += "_50X";
                        return rs;
                    }
                    break;
                case "d":
                    if (CombinationGot(h, 240) || CombinationGot(c, 240) || CombinationGot(s, 240))
                    {
                        rs += "_50A";
                        return rs;
                    }

                    if (CombinationGot(h, 120) || CombinationGot(c, 120) || CombinationGot(s, 120))
                    {
                        rs += "_50K";
                        return rs;
                    }

                    if (CombinationGot(h, 60) || CombinationGot(c, 60) || CombinationGot(s, 60))
                    {
                        rs += "_50Q";
                        return rs;
                    }

                    if (CombinationGot(h, 30) || CombinationGot(c, 30) || CombinationGot(s, 30))
                    {
                        rs += "_50J";
                        return rs;
                    }

                    if (CombinationGot(h, 15) || CombinationGot(c, 15) || CombinationGot(s, 15))
                    {
                        rs += "_50X";
                        return rs;
                    }
                    break;
                case "s":
                    if (CombinationGot(h, 240) || CombinationGot(d, 240) || CombinationGot(c, 240))
                    {
                        rs += "_50A";
                        return rs;
                    }

                    if (CombinationGot(h, 120) || CombinationGot(d, 120) || CombinationGot(c, 120))
                    {
                        rs += "_50K";
                        return rs;
                    }

                    if (CombinationGot(h, 60) || CombinationGot(d, 60) || CombinationGot(c, 60))
                    {
                        rs += "_50Q";
                        return rs;
                    }

                    if (CombinationGot(h, 30) || CombinationGot(d, 30) || CombinationGot(c, 30))
                    {
                        rs += "_50J";
                        return rs;
                    }

                    if (CombinationGot(h, 15) || CombinationGot(d, 15) || CombinationGot(c, 15))
                    {
                        rs += "_50X";
                        return rs;
                    }
                    break;
            }
            return rs;
        }
        private RM1 Check20s(byte h, byte c, byte d, byte s, string rs)
        {
            if (CombinationGot(c, 238) || CombinationGot(d, 238) || CombinationGot(s, 238))
            {
                rs += "_20A_20X";
                return new(rs + "_0", true);
            }
            else if (CombinationGot(c, 231) || CombinationGot(d, 231) || CombinationGot(s, 231))
            {
                rs += "_20A_209";
                return new(rs + "_0", true);
            }
            else if (CombinationGot(c, 119) || CombinationGot(d, 119) || CombinationGot(s, 119))
            {
                rs += "_20K_209";
                return new(rs + "_0", true);
            }

            if (CombinationGot(h, 224))
            {
                rs += "_20A";
                rs = Check20s(h, c, d, s, rs, "h");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(c, 224))
            {
                rs += "_20A";
                rs = Check20s(h, c, d, s, rs, "c");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(d, 224))
            {
                rs += "_20A";
                rs = Check20s(h, c, d, s, rs, "d");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(s, 224))
            {
                rs += "_20A";
                rs = Check20s(h, c, d, s, rs, "s");
                return new(rs + "_0", true);
            }
            if (CombinationGot(h, 112))
            {
                rs += "_20K";
                rs = Check20s(h, c, d, s, rs, "h");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(c, 112))
            {
                rs += "_20K";
                rs = Check20s(h, c, d, s, rs, "c");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(d, 112))
            {
                rs += "_20K";
                rs = Check20s(h, c, d, s, rs, "d");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(s, 112))
            {
                rs += "_20K";
                rs = Check20s(h, c, d, s, rs, "s");
                return new(rs + "_0", true);
            }
            if (CombinationGot(h, 56))
            {
                rs += "_20Q";
                rs = Check20s(h, c, d, s, rs, "h");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(c, 56))
            {
                rs += "_20Q";
                rs = Check20s(h, c, d, s, rs, "c");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(d, 56))
            {
                rs += "_20Q";
                rs = Check20s(h, c, d, s, rs, "d");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(s, 56))
            {
                rs += "_20Q";
                rs = Check20s(h, c, d, s, rs, "s");
                return new(rs + "_0", true);
            }
            if (CombinationGot(h, 28))
            {
                rs += "_20J";
                rs = Check20s(h, c, d, s, rs, "h");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(c, 28))
            {
                rs += "_20J";
                rs = Check20s(h, c, d, s, rs, "c");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(d, 28))
            {
                rs += "_20J";
                rs = Check20s(h, c, d, s, rs, "d");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(s, 28))
            {
                rs += "_20J";
                rs = Check20s(h, c, d, s, rs, "s");
                return new(rs + "_0", true);
            }

            if (CombinationGot(h, 14))
            {
                rs += "_20X";
                rs = Check20s(h, c, d, s, rs, "h");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(c, 14))
            {
                rs += "_20X";
                rs = Check20s(h, c, d, s, rs, "c");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(d, 14))
            {
                rs += "_20X";
                rs = Check20s(h, c, d, s, rs, "d");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(s, 14))
            {
                rs += "_20X";
                rs = Check20s(h, c, d, s, rs, "s");
                return new(rs + "_0", true);
            }

            if (CombinationGot(h, 7))
            {
                rs += "_209";
                rs = Check20s(h, c, d, s, rs, "h");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(c, 7))
            {
                rs += "_209";
                rs = Check20s(h, c, d, s, rs, "c");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(d, 7))
            {
                rs += "_209";
                rs = Check20s(h, c, d, s, rs, "d");
                return new(rs + "_0", true);
            }
            else if (CombinationGot(s, 7))
            {
                rs += "_209";
                rs = Check20s(h, c, d, s, rs, "s");
                return new(rs + "_0", true);
            }

            return new(rs, false);
        }
        private string Check20s(byte h, byte c, byte d, byte s, string rs, string suit)
        {
            switch (suit)
            {
                case "h":
                    if (CombinationGot(c, 224) || CombinationGot(d, 224) || CombinationGot(s, 224))
                        {
                        rs += "_20A";
                        return rs;
                    }

                    if (CombinationGot(c, 112) || CombinationGot(d, 112) || CombinationGot(s, 112))
                        {
                        rs += "_20K";
                        return rs;
                    }

                    if ( CombinationGot(c, 56) || CombinationGot(d, 56) || CombinationGot(s, 56))
                        {
                        rs += "_20Q";
                        return rs;
                    }

                    if (CombinationGot(c, 28) || CombinationGot(d, 28) || CombinationGot(s, 28))
                        {
                        rs += "_20J";
                        return rs;
                    }

                    if (CombinationGot(c, 14) || CombinationGot(d, 14) || CombinationGot(s, 14))
                        {
                        rs += "_20X";
                        return rs;
                    }

                    if (CombinationGot(c, 7) || CombinationGot(d, 7) || CombinationGot(s, 7))
                        {
                        rs += "_20IX";
                        return rs;
                    }
                    break;
                case "c":
                    if (CombinationGot(h, 224) || CombinationGot(d, 224) || CombinationGot(s, 224))
                        {
                        rs += "_20A";
                        return rs;
                    }

                    if (CombinationGot(h, 112) || CombinationGot(d, 112) || CombinationGot(s, 112))
                        {
                        rs += "_20K";
                        return rs;
                    }

                    if (CombinationGot(h, 56) || CombinationGot(d, 56) || CombinationGot(s, 56))
                        {
                        rs += "_20Q";
                        return rs;
                    }

                    if (CombinationGot(h, 28) || CombinationGot(d, 28) || CombinationGot(s, 28))
                        {
                        rs += "_20J";
                        return rs;
                    }

                    if (CombinationGot(h, 14) || CombinationGot(d, 14) || CombinationGot(s, 14))
                        {
                        rs += "_20X";
                        return rs;
                    }

                    if (CombinationGot(h, 7) || CombinationGot(d, 7) || CombinationGot(s, 7))
                        {
                        rs += "_209";
                        return rs;
                    }
                    break;
                case "d":
                    if (CombinationGot(h, 224) || CombinationGot(c, 224) || CombinationGot(s, 224))
                        {
                        rs += "_20A";
                        return rs;
                    }

                    if (CombinationGot(h, 112) || CombinationGot(c, 112) || CombinationGot(s, 112))
                        {
                        rs += "_20K";
                        return rs;
                    }

                    if (CombinationGot(h, 56) || CombinationGot(c, 56) || CombinationGot(s, 56))
                        {
                        rs += "_20Q";
                        return rs;
                    }

                    if (CombinationGot(h, 28) || CombinationGot(c, 28) || CombinationGot(s, 28))
                        {
                        rs += "_20J";
                        return rs;
                    }

                    if (CombinationGot(h, 14) || CombinationGot(c, 14) || CombinationGot(s, 14))
                        {
                        rs += "_20X";
                        return rs;
                    }

                    if (CombinationGot(h, 7) || CombinationGot(c, 7) || CombinationGot(s, 7))
                        {
                        rs += "_209";
                        return rs;
                    }
                    break;
                case "s":
                    if (CombinationGot(h, 224) || CombinationGot(c, 224) || CombinationGot(d, 224))
                    {
                        rs += "_20A";
                        return rs;
                    }
                        

                    if (CombinationGot(h, 112) || CombinationGot(c, 112) || CombinationGot(d, 112))
                    {
                        rs += "_20K";
                        return rs;
                    }
                       

                    if (CombinationGot(h, 56) || CombinationGot(c, 56) || CombinationGot(d, 56))
                    {
                        rs += "_20Q";
                        return rs;
                    }

                    if (CombinationGot(h, 28) || CombinationGot(c, 28) || CombinationGot(d, 28))
                    {
                        rs += "_20J";
                        return rs;
                    }

                    if (CombinationGot(h, 14) || CombinationGot(c, 14) || CombinationGot(d, 14))
                    {
                        rs += "_20X";
                        return rs;
                    }

                    if (CombinationGot(h, 7) || CombinationGot(c, 7) || CombinationGot(d, 7))
                    {
                        rs += "_209";
                        return rs;
                    }
                    break;
            }
            
            return rs;
        }

        private bool CombinationGot(byte b, byte target)
        {
            if (b == target)
                return true;
            byte _target = (byte)(255 - target);
            bool[] _targetBits = new bool[8];
            bool[] bBits = new bool[8];
            int temp = _target;
            for (int i = 7; i >= 0; i--)
            {
                temp -= (int)Math.Pow(2, i);
                if (temp >= 0)
                    _targetBits[i] = true;
                else
                {
                    temp += (int)Math.Pow(2, i);
                    _targetBits[i] = false;
                }
            }

            temp = b;
            for (int i = 7; i >= 0; i--)
            {
                temp -= (int)Math.Pow(2, i);
                if (temp >= 0)
                    bBits[i] = true;
                else
                {
                    temp += (int)Math.Pow(2, i);
                    bBits[i] = false;
                }
            }
            b = 0;
            for (int i = 0; i < 8; i++)
            {
                if (bBits[i] == _targetBits[i])
                    bBits[i] = false;
                if (bBits[i])
                    b += (byte)Math.Pow(2, i);
            }
            if (b == target)
                return true;
            return false;
        }
    }
}
