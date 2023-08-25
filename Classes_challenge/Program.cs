using System;

namespace Classes_challenge
{
    class Fighters
    {
        public string userName;// Player's name (There will be 2 players)

        public float basicDamage;// Basic Attack
        public float skillDamage;// Skill Attack

        private float maxHP;// Max HP

        public float currentHP;// HP - basicDamage, HP - skillDamage, or HP + amountHeal
        public float amountHeal;// The amount of the HP regained

        public bool skillXp;// Needed to use skill attack

        public static int Count = 1;
        public static int player1CountSkillXP = 3;
        public static int player2CountSkillXP = 3;

        public Fighters(string _userName) // Customize the variable here (float)
        {
            userName = _userName;
            basicDamage = 5;                    // Default is 5
            skillDamage = basicDamage + 17.5f;  // Default is basicDamage + 17.5f
            maxHP = 100;                        // Default is 100
            currentHP = maxHP;                  
            amountHeal = 20;                    // Default is 20
            skillXp = true;
        }
    }
    class Program
    {
        static void BasicAttack(string userName, string targetUserName, ref float targetCurrentHP, float basicDamage)
        {
            targetCurrentHP -= basicDamage;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n" + userName + " uses their basic attacks.");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(targetUserName + " dealt " + basicDamage + " pts of damage.");
            Console.ReadKey();
        }

        static void SkillAttack(string userName, string targetUserName, ref float targetCurrentHP, float skillDamage, float basicDamage, ref bool skillXP, ref int countSkillXP)
        {
            if(skillXP == true)
            {
                targetCurrentHP -= skillDamage;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n" + userName + " cast their almighty SKILL ATTACKS");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(targetUserName + " dealt a whooping " + skillDamage + " pts of damage.");
                countSkillXP = 0; //Bugfix
            }
            else
            {
                targetCurrentHP -= basicDamage;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + userName + " failed to cast their skill attack");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(targetUserName + " dealt " + basicDamage + " pts of damage.");
            }
            Console.ReadKey();
        }

        static void Heal(string userName, ref float currentHP, float amountHeal)
        {
            if(currentHP + amountHeal >= 100)
            {
                float toMaxHP = 100 - currentHP;
                currentHP = 100;
                if(toMaxHP == 0)
                    Skip(userName);
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n" + userName + " maxed out their HP by regaining " + toMaxHP + " pts of their HP.");
                    Console.ReadKey();
                }
            }
            else
            {
                currentHP += amountHeal;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n" + userName + " regained " + amountHeal + " pts of their HP.");
                Console.ReadKey();
            }
        }
        
        static void Rest(string userName, ref bool skillXP, ref int countSkillXP)
        {
            countSkillXP = 3;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n" + userName + " is taking a rest.");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(userName + " has now able to cast SKILL ATTACK for their next turn.");
            Console.ReadKey();
        }

        static void Skip(string userName)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n" + userName + " have decided to skip their turn. Very generous~~");
            Console.ReadKey();
        }

        static void ACTION(int choice, ref float targetCurrentHP, ref float currentHP, float basicDamage, float skillDamage, float amountHeal, bool skillXP, string targetUserName, string userName, ref int countSkillXP)
        {
            if(countSkillXP % 3 == 0)
                skillXP = true;
            else
                skillXP = false;
            //Debug
            //Console.WriteLine("DEBUG: " + skillXP + ", " + countSkillXP + " // Count: " + Fighters.Count);

            switch(choice)
            {
                case 1:// Basic Attack to Player 2
                    BasicAttack(userName, targetUserName, ref targetCurrentHP, basicDamage);
                    break;
                case 2:// Skill Attack to Player 2
                    SkillAttack(userName, targetUserName, ref targetCurrentHP, skillDamage, basicDamage, ref skillXP, ref countSkillXP);
                    break;
                case 3:// Heal for Player 1
                    Heal(userName, ref currentHP, amountHeal);
                    break;
                case 4:// Rest for Player 1
                    Rest(userName, ref skillXP, ref countSkillXP);
                    break;
                default:
                    Skip(userName);
                    break;
            }

            if(choice != 4)
            {
                countSkillXP++;
            }
            //Bugfix
            if(countSkillXP > 3)
            {
                countSkillXP = 3;
            }
            Fighters.Count++;
        }

        static void Main(string[] args)
        {
            Console.Title = "Turn-Based Combat lol";
            Play();
        }

        static void Instructions()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("INSTRUCTIONS:");
            Console.WriteLine("1) Each player starts from 100 pts of HP.");
            Console.WriteLine("2) Both player have 4 action: Basic attack, Skill attack, Heal, and Rest. Input a number ranging from 1 to 4 to choose your action. (Otherwise will result in skipping a turn)");
            Console.WriteLine("3) One of the player wins when they succeded to take down the other player.");
            Console.WriteLine("4) Skill attack has a cooldown of 3 turns for each player.");
            Console.WriteLine("5) Remember, number only. Other than integer input = GAME CRASH.");
            Console.WriteLine("6) Reset program: 2803");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Zefanya Pijar Manullang 2020 - 2023");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("~~~~~~~~~~~~(Game begins, press any key to continue)~~~~~~~~~~~~");
            Console.ReadKey();
        }

        static void Play()
        {
            while(true)
            {
                nullCheckP1Name:
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Give a Player 1 a name: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Fighters Player1 = new Fighters(Console.ReadLine()); //Input Player 1 name

                if(string.IsNullOrWhiteSpace(Player1.userName))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    goto nullCheckP1Name;
                }

                nullCheckP2Name:
                Console.ForegroundColor = ConsoleColor.Gray;                
                Console.Write("Give a Player 2 a name: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Fighters Player2 = new Fighters(Console.ReadLine()); //Input Player 2 name

                if(string.IsNullOrWhiteSpace(Player2.userName))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    goto nullCheckP2Name;
                }

                Instructions();

                while(Player1.currentHP > 0.1f && Player2.currentHP > 0.1f)
                {
                    if (Fighters.Count % 2 != 0)// Player 1's turn
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nPlayer 1: " + Player1.userName);
                        Console.WriteLine("HP : " + Player1.currentHP);
                        Menu(Fighters.player1CountSkillXP, Player1.currentHP);        
                        ACTION(Input(), ref Player2.currentHP, ref Player1.currentHP, Player1.basicDamage, Player1.skillDamage, Player1.amountHeal, Player1.skillXp, Player2.userName, Player1.userName, ref Fighters.player1CountSkillXP);
                    }
                    else// Player 2's turn
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nPlayer 2: " + Player2.userName);
                        Console.WriteLine("HP : " + Player2.currentHP);
                        Menu(Fighters.player2CountSkillXP, Player2.currentHP);
                        ACTION(Input(), ref Player1.currentHP, ref Player2.currentHP, Player2.basicDamage, Player2.skillDamage, Player2.amountHeal, Player2.skillXp, Player1.userName, Player2.userName, ref Fighters.player2CountSkillXP);
                    }
                }
                WinCheck(Player1.currentHP, Player2.currentHP, Player1.userName, Player2.userName);
            }
        }

        static void Menu(int countSkillXP, float currentHP)
        {
            Console.WriteLine(countSkillXP % 3 == 0 ? "Skill Attack: Ready!" : "Skill Attack: In a cooldown...");
            Console.WriteLine("ACTION");
            Console.WriteLine("1. Use basic attack");
            Console.WriteLine(countSkillXP % 3 == 0 ? "2. Use SKILL ATTACK" : "2. (Skill attack in cooldown, basic attack will be used.)");
            Console.WriteLine(currentHP != 100 ? "3. Heal yourself" : "3. (Already max HP, skipping a turn instead.)");
            Console.WriteLine("4. Take a rest");
        }

        static int Input()
        {
            nullCheckInput:
            Console.Write("Choose your action: ");
            string _choice = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(_choice))
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                goto nullCheckInput;
            }
            else
            {
                int choice = Convert.ToInt32(_choice);
                ForceReset(choice);
                return choice;
            }
        }

        static void WinCheck(float p1CurrentHP, float p2CurrentHP, string p1UserName, string p2UserName)
        {
            if(p1CurrentHP <= 0 || p2CurrentHP <= 0)
            {
                if (p2CurrentHP <= 0)// Player 1 wins
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n" + p1UserName + " WINS THE GLORIOUS BATTLE!!!");
                }
                else if (p1CurrentHP <= 0)// Player 2 wins
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n" + p2UserName + " WINS THE GLORIOUS BATTLE!!!");
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("(Game over, press any key to restart)");
                Console.ReadKey();
                Reset();
            }
        }

        static void Reset()
        {
            Fighters.Count = 1;
            Fighters.player1CountSkillXP = 3;
            Fighters.player2CountSkillXP = 3;
            Console.Clear();
        }

        static void ForceReset(int code)
        {
            if (code == 2803)
            {
                Reset();
                Play();
            }
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}