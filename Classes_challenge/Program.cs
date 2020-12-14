using System;

namespace Classes_challenge
{
    class Fighters
    {
        public string userName;// Player's name (There will be 2 players)

        public float basicDamage;// Basic Attack
        public float skillDamage;// Skill Attack

        private float maxHP;// Max HP

        public float currentHP;// HP - basicDamage or HP + amouontHeal
        public float amountHeal;// The amount of the HP regained

        public bool skillXp;// Needed to use skill attack

        public static int Count = 1;
        public static int player1CountSkillXP = 3;
        public static int player2CountSkillXP = 3;

        public Fighters(string _userName)
        {
            userName = _userName;
            basicDamage = 5;
            skillDamage = basicDamage + 17.5f;
            maxHP = 100;
            currentHP = maxHP;
            amountHeal = 20;
            skillXp = true;
        }
    }
    class Program
    {
        static void ACTIONp1 (int choice1, ref float _Player2CurrentHP, ref float _Player1CurrentHP, float _Player1BasicDamage, float _Player1SkillDamage, float _Player1AmountHeal, out bool _Player1SkillXP, string _Player2UserName, string _Player1UserName)
        {
            if (Fighters.player1CountSkillXP % 3 == 0)
            {
                _Player1SkillXP = true;
            }
            else{
                _Player1SkillXP = false;
            }
            switch(choice1)
            {
                case 1:// Basic Attack to Player 2
                    _Player2CurrentHP -= _Player1BasicDamage;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n" + _Player1UserName + " uses their basic attacks.");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(_Player2UserName + " dealt 5 pts of damage.");
                    Console.ReadKey();
                    break;
                case 2:// Skill Attack to Player 2
                    if(_Player1SkillXP == true || Fighters.player1CountSkillXP % 3 == 0)
                    {
                        _Player2CurrentHP -= _Player1SkillDamage;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n" + _Player1UserName + " cast their almighty SKILL ATTACKS");
                        Console.ReadKey();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(_Player2UserName + " dealt a whooping 22,5 pts of damage.");
                        Console.ReadKey();
                        _Player1SkillXP = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n" + _Player1UserName + " failed to cast their skill attack");
                        Console.ReadKey();

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(_Player2UserName + " dealt 5 pts of damage.");
                        Console.ReadKey();
                        _Player2CurrentHP -= _Player1BasicDamage;
                    }
                    break;
                case 3:// Heal
                    if(_Player1CurrentHP + _Player1AmountHeal >= 100){
                        float Player1ToMaxHP = 100 - _Player1CurrentHP;
                        _Player1CurrentHP = 100;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n" + _Player1UserName + " maxed out their HP by regaining " + Player1ToMaxHP + " pts of their HP.");
                        Console.ReadKey();
                    }else{
                        _Player1CurrentHP += _Player1AmountHeal;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(_Player1UserName + " regained 20 pts of their HP.");
                        Console.ReadKey();
                    }
                    break;
                case 4:// Rest
                    _Player1SkillXP = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n" + _Player1UserName + " is taking a rest.");
                    Console.ReadKey();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(_Player1UserName + " has now able to cast SKILL ATTACK for their next turn.");
                    Console.ReadKey();
                    Fighters.player1CountSkillXP = 3;
                    break;
            }
        }
        static void ACTIONp2 (int choice2, ref float _Player1CurrentHP, ref float _Player2CurrentHP, float _Player2BasicDamage, float _Player2SkillDamage, float _Player2AmountHeal, out bool _Player2SkillXP, string _Player1UserName, string _Player2UserName)
        {
            if (Fighters.player2CountSkillXP % 3 == 0)
            {
                _Player2SkillXP = true;
            }
            else{
                _Player2SkillXP = false;
            }
            switch(choice2)
            {
                case 1:// Basic Attack to Player 1
                    _Player1CurrentHP -= _Player2BasicDamage;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n" + _Player2UserName + " uses their basic attacks.");
                    Console.ReadKey();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(_Player1UserName + " dealt 5 pts of damage.");
                    Console.ReadKey();
                    break;
                case 2:// Skill Attack to Player 1
                    if(_Player2SkillXP == true)
                    {
                        _Player1CurrentHP -= _Player2SkillDamage;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n" + _Player2UserName + " cast their almighty SKILL ATTACKS");
                        Console.ReadKey();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(_Player1UserName + " dealt a whooping 22,5 pts of damage.");
                        Console.ReadKey();
                        _Player2SkillXP = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n" + _Player2UserName + " failed to cast their skill attack");
                        Console.ReadKey();

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(_Player1UserName + " dealt 5 pts of damage.");
                        Console.ReadKey();
                        _Player1CurrentHP -= _Player2BasicDamage;
                    }
                    break;
                case 3:// Heal
                    if(_Player2CurrentHP + _Player2AmountHeal >= 100){
                        float Player2ToMaxHP = 100 - _Player2CurrentHP;
                        _Player2CurrentHP = 100;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n" + _Player2UserName + " maxed out their HP by regaining " + Player2ToMaxHP + " pts of their HP.");
                        Console.ReadKey();
                    }else{
                        _Player2CurrentHP += _Player2AmountHeal;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(_Player2UserName + " regained 20 pts of their HP.");
                        Console.ReadKey();
                    }
                    break;
                case 4:// Rest
                    _Player2SkillXP = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n" + _Player2UserName + " is taking a rest.");
                    Console.ReadKey();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(_Player2UserName + " has now able to cast SKILL ATTACK for their next turn.");
                    Console.ReadKey();
                    Fighters.player2CountSkillXP = 3;
                    break;
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Turn-Based Combat lol";

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Give a Player 1 a name: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string p1 = Console.ReadLine();
            Fighters Player1 = new Fighters(p1);

            Console.ForegroundColor = ConsoleColor.Gray;
            
            Console.Write("Give a Player 2 a name: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string p2 = Console.ReadLine();
            Fighters Player2 = new Fighters(p2);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nINSTRUCTIONS:\n1. Each player starts from 100 pts of HP.\n2. Both player have their 4 action: Basic attack, Skill attack, Heal, and Rest.\n3. One of the player wins when he succeded to take down the other player.\n4. Skill attack has a cooldown for 3 turns for each player.\n5. Time duration depends lol.");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("~~~~~~~~~~~~(Game begins)~~~~~~~~~~~~");
            Console.ReadKey();

            while(Player1.currentHP > 1 && Player2.currentHP > 1)
                {
                    if (Fighters.Count % 2 != 0)// Player 1's turn
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nPlayer 1: " + Player1.userName);
                        Console.WriteLine("HP : " + Player1.currentHP);
                        if (Fighters.player1CountSkillXP % 3 == 0 || Player1.skillXp == true){
                            Console.WriteLine("Skill Attack: Ready!");
                            Console.WriteLine("\nACTION\n1. Use basic attack\n2. Use SKILL ATTACK\n3. Heal yourself \n4. Take a rest");
                        }
                        else
                        {
                            Console.WriteLine("Skill Attack: In a cooldown...");
                            Console.WriteLine("ACTION\n1. Use basic attack\n2. (Skill attack in cooldown. Basic attack will be used.)\n3. Heal yourself \n4. Take a rest");
                        }
                        Console.Write("Choose your action: ");

                        int choice1 = Convert.ToInt32(Console.ReadLine());
                        ACTIONp1(choice1, ref Player2.currentHP, ref Player1.currentHP, Player1.basicDamage, Player1.skillDamage, Player1.amountHeal, out Player1.skillXp, Player2.userName, Player1.userName);

                        if(choice1 != 4)
                        {
                            Fighters.player1CountSkillXP++;
                        }
                        Fighters.Count++;
                    }
                    else// Player 2's turn
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nPlayer 2: " + Player2.userName);
                        Console.WriteLine("HP : " + Player2.currentHP);
                        if (Fighters.player2CountSkillXP % 3 == 0 || Player2.skillXp == true){
                            Console.WriteLine("Skill Attack: Ready!");
                            Console.WriteLine("ACTION\n1. Use basic attack\n2. Use SKILL ATTACK\n3. Heal yourself \n4. Take a rest");
                        }
                        else{
                            Console.WriteLine("Skill Attack: In a cooldown...");
                            Console.WriteLine("\nACTION\n1. Use basic attack\n2. (Skill attack in cooldown. Basic attack will be used.)\n3. Heal yourself \n4. Take a rest");
                        }
                        Console.Write("Choose your action: ");

                        int choice2 = Convert.ToInt32(Console.ReadLine());
                        ACTIONp2(choice2, ref Player1.currentHP, ref Player2.currentHP, Player2.basicDamage, Player2.skillDamage, Player2.amountHeal, out Player2.skillXp, Player1.userName, Player2.userName);
                        
                        if(choice2 != 4)
                        {
                            Fighters.player2CountSkillXP++;
                        }
                        Fighters.Count++;
                    }
                }
            if (Player2.currentHP <= 0)// Player 1 wins
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n" + Player1.userName + " WINS THE GLORIOUS BATTLE!!!");
            }
            else if (Player1.currentHP <= 0)// Player 2 wins
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n" + Player2.userName + " WINS THE GLORIOUS BATTLE!!!");
            }
            Console.ReadKey();
        }
    }
}