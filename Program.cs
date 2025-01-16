using System;
using System.Threading;

class Globals {
    public static bool isTeemoDone = false;
    public static bool isLambDone = false;
    public static int Time = 0;
    public static bool hasKey = false;
    public static bool hasAmulet = false;
}

class SpiritBonds
{
    static void Main()
    {
        Console.WriteLine("Welcome to Spirit Bonds!\nExplore the spirit realm, meet new friends, complete quests, gather rewards, and unlock new places!\n");
        string playerName = GetPlayerName();
        StartDialogue(playerName);

    }

    static string GetPlayerName()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("What do people call you?\n> ");
        string playerName = Console.ReadLine();

        return playerName;
    }

    static void StartDialogue(string playerName)
    {
        // Set name names and colors
        string name = "Fox";
        ConsoleColor color = ConsoleColor.Magenta;

        WorldChat($"You come upon a great tree in the middle of bloom. Something about it seems... soothing.");
        Chat(name, color, "Hello, stranger.");
        Chat(name, color, "Have you come here for the spirit petals?");
        // Display choices
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"[1] What's a spirit petal?");
        Console.WriteLine($"[2] The what what?");

        // Get player's choice
        int playerChoice = GetPlayerChoice(2);

        // Process player's choice
        switch (playerChoice)
        {
            case 1:
                SpiritPetalExplanation(playerName);
                break;
            case 2:
                SpiritPetalExplanation(playerName);
                break;
            default:
                break;
        }
    }



    static void SpiritPetalExplanation(string playerName)
    {
        string name = "Fox";
        ConsoleColor color = ConsoleColor.Magenta;
        Chat(name, color, "The tree is blooming with spirit blossoms.","You won't find one like it in your world.","Each petal is filled with the memories of the spirits.","They are highly prized by our kind.","Yet, we cannot take one ourselves.","Each must be gifted by human hands.","Experience many things,","and you might find one yourself.", "Then give the petal to a spirit you truly care about...","and they will return the favor with a gift you may keep forever.","Think of them as mementos of your time here, hee hee.", "...Well? Did you get all that?");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"[1] Yes.");
        Console.WriteLine($"[2] No.");

        int playerChoice = GetPlayerChoice(2);

        switch (playerChoice)
        {
            case 1:
                Chat(name, color, "Ah, well.");
                Chat(name, color, "And here I was, all ready to repeat myself.");
                Chat(name, color, "I wonder who you'll choose... hee hee...");
                WorldChat("You may now earn Spirit Petals by goals");
                WorldChat("Exchange them with spirits whose journeys you have completed, and they will reward you with gifts to enjoy");
                Thread.Sleep(300);
                SelectLocation(playerName, "Spirit Blossom Tree", "Suspicious Forest");
                break;
            case 2:
                SpiritPetalExplanation(playerName);
                break;
        }
    }

    static void SelectLocation(string playerName, params string[] titles)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"\nWhere do you want to go next? ({10-titles.Length} are locked!)");
        for (int i = 0; i < 10; i++)
        {
            if (i < titles.Length)
            {
                Console.WriteLine($"[{i+1}] {titles[i]}");
            } else {
                Console.WriteLine($"[{i+1}] ???");
            }
        }

        int choice = GetPlayerChoice(titles.Length);
        WorldChat("You began walking");
                for (int i = 0; i < 3; i++)
                {
                    WorldChat("...");
                    Thread.Sleep(450);
                }
        switch (choice)
        {
            case 1:
                SpiritBlossomTree(playerName);
                break;
            case 2:
                SuspiciousForest(playerName);
                break;
            case 3:
                LanternRiver(playerName);
                break;
            case 4:
                ThreshTemple(playerName);
                break;
            case 5:
                SpiritForest(playerName);
                break;
            case 6:
                AzakanaForest(playerName);
                break;
            case 7: 
                SwordGraveyard(playerName);
                break;
            case 8:
                GoldenTree(playerName);
                break;
            case 9:
                Beach(playerName);
                break;
            case 10:
                Gate(playerName);
                break;
        }
    }

    static void Gate(string playerName)
    {
        WorldChat("You stand upon an enormous blue gate that shines dimly.", "You feel a sense of home.");
        OpenGate(playerName);
    }

    static void OpenGate(string playerName)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("[1] [Open the gate]");
        Console.WriteLine("[2] [Walk away.]");
        int choice = GetPlayerChoice(2);

        if (choice == 1)
        {
            if (Globals.hasKey)
            {
                WorldChat("The Gate slowly opened before you.", "You can now leave the spirit realm.");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("[1] [Go home.]");
                Console.WriteLine("[2] [Walk away.]");

                int choice1 = GetPlayerChoice(2);

                if (choice1 == 1)
                {
                    WorldChat("Used Gate Key.");
                    WorldChat("A bright light flashed your eyes.", "You stepped into the light.");
                    Thread.Sleep(450);
                    WorldChat("!!!", "2");
                    WorldChat("You heard a Azakanaic scream from behind.", "It was a rampaging Azakana being pursued by Yone.", "It is running towards you.");
                    Chat("Yone", ConsoleColor.DarkMagenta, "Get out of the way!");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("[1] [Fear]");
                    Console.WriteLine("[2] [Fear]");
                    Console.WriteLine("[3] [Fear]");
                    Console.WriteLine("[4] [Fear]");
                    Console.WriteLine("[5] [Fear]");
                    int choice2 = GetPlayerChoice(5);

                    if (Globals.hasAmulet)
                    {
                        WorldChat("A dazzling light came from the amulet given by Lamb.", "The Azakana ran away screeching in pain.", "You crossed the gate.", "You came back to the mortal realm.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        WorldChat("Game Win!");
                        System.Environment.Exit(1);

                    } else {
                        WorldChat("The Azakana lounged at you with great force.", "Yone was too late.", "The Azakana clawed through your body and devoured you.", "You died.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        WorldChat("Game Over.");
                    }
                } else {
                    SelectLocation(playerName, "Spirit Blossom Tree", "Suspicious Forest", "Lantern-lit River", "Thresh Temple", "Spirit Forest", "Azakana Forest", "Sword Graveyard", "Tree of Peace", "Beach", "Mysterious Gate");
                }
            } else {
                WorldChat("It won't budge.", "The gate is locked.");
                OpenGate(playerName);
            }
        } else {
            SelectLocation(playerName, "Spirit Blossom Tree", "Suspicious Forest", "Lantern-lit River", "Thresh Temple", "Spirit Forest", "Azakana Forest", "Sword Graveyard", "Tree of Peace", "Beach", "Mysterious Gate");
        }
    }

    static void Beach(string playerName)
    {
        WorldChat("The ocean waves produce a soothing tone to the ears.", "You relax a bit.", "The sun is shining bright.", "There is no one else in the beach.", "You bask in the sunlight of the moment.", "You cannot hide anywhere here.");
        Relax(playerName);
    }

    static void Relax(string playerName)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("[1] [Relax.]");
        Console.WriteLine("[2] [Walk away.]");
        int choice = GetPlayerChoice(2);

        if (choice == 1)
        {
            WorldChat("You relaxed in the beach.");
            for (int i = 0; i < 5; i++)
            {
                WorldChat("...");
                Thread.Sleep(450);
            }
            WorldChat("A few hours have passed.");
            Relax(playerName);
        } else {
            SelectLocation(playerName, "Spirit Blossom Tree", "Suspicious Forest", "Lantern-lit River", "Thresh Temple", "Spirit Forest", "Azakana Forest", "Sword Graveyard", "Tree of Peace", "Beach", "Mysterious Gate");
        }
    }

    static void GoldenTree(string playerName)
    {
        string lamb = "Lamb";
        ConsoleColor lambColor = ConsoleColor.Cyan;
        string wolf = "Wolf";
        ConsoleColor wolfColor = ConsoleColor.Red;

        WorldChat("You stumble upon a golden tree that emanates a peaceful aura.", "You feel safe under its leaves.", "This seems like a good enough place to hide.");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("[1] [Sit under the golden tree.]");
        Console.WriteLine("[2] [Walk away.]");
        int choice = GetPlayerChoice(2);

        if (choice == 1)
        {
            WorldChat("You rested under the golden tree...");
            for (int i = 0; i < 5; i++)
            {
                WorldChat("...");
                Thread.Sleep(450);
            }
            WorldChat("You woke up from a thud.", "You look up and see an arrow right above your head.");
            Chat(lamb, lambColor, "Oh, hi there!");
            Chat(wolf, wolfColor, "LAMB FOUND THE HUMAN!", "LAMB IS GOOD AT FINDING.", "LAMB ALWAYS FINDS WOLF.", "WOLF CANNOT WIND HIDE AND SEEK, NO HE CANNOT");
            Chat(lamb, lambColor, "Huh, was that really your hiding spot?", "I thought you were taking a nap or something.", "I guess humans are just as bad at hide-and-seek as Wolf.");
            Chat(wolf, wolfColor, "WOLF WILL START LOSERS CLUB.", "VERY EXCLUSIVE. JUST YOU AND WOLF.");
            Chat(lamb, lambColor, "Hey, since you played with us, you can have this.");
            WorldChat("Acquired Azakana Amulet.");
            Globals.hasAmulet = true;
            SelectLocation(playerName, "Spirit Blossom Tree", "Suspicious Forest", "Lantern-lit River", "Thresh Temple", "Spirit Forest", "Azakana Forest", "Sword Graveyard", "Tree of Peace", "Beach", "Mysterious Gate");
        } else {
            SelectLocation(playerName, "Spirit Blossom Tree", "Suspicious Forest", "Lantern-lit River", "Thresh Temple", "Spirit Forest", "Azakana Forest", "Sword Graveyard", "Tree of Peace", "Beach", "Mysterious Gate");
        }
    }

    static void SwordGraveyard(string playerName)
    {
        string wolf = "Wolf";
        ConsoleColor wolfColor = ConsoleColor.Red;
        WorldChat("Thousands of warrior swords laid down in the battlefield.", "Their fight lasts longer than their life.", "You feel an ominous stare.", "You cannot hide anywhere here.");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("[1] [Pick up a sword.]");
        Console.WriteLine("[2] [Look around.]");
        Console.WriteLine("[3] [Run away.]");
        int choice = GetPlayerChoice(3);

        if (choice == 3)
        {
            SelectLocation(playerName, "Spirit Blossom Tree", "Suspicious Forest", "Lantern-lit River", "Thresh Temple", "Spirit Forest", "Azakana Forest", "Sword Graveyard", "Tree of Peace", "Beach", "Mysterious Gate");
        } else if (choice == 2) {
            WorldChat("Everything you can see are just swords buried and scattered to the ground over the horizon.");
        } else {
            WorldChat("You picked up a decent sword.", "It must've belonged to a great swordsman");
        }
        WorldChat("...");
        Thread.Sleep(450);
        WorldChat("You hear a growl behind you.", "You are being hunted.", "You can feel Wolf's murderous intent.", "Your body forces you to run away.", "It is hopeless.", "You call out for Lamb.", "Your lower body is missing.");
        Chat(wolf, wolfColor, "HA!", "I WIN!", "I FOUND HUMAN FIRST!", "HUMAN IS TASTY!", "GOOD HUNT!");
        WorldChat("Your consciousness fades away...");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Game Over.");
    }

    static void AzakanaForest(string playerName)
    {
        string yone = "Yone";
        ConsoleColor color = ConsoleColor.DarkBlue;
        WorldChat("Blood and fear fills the air", "You cannot hide anywhere here.", "You shouldn't have gone here.");
        
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("[1] [Look around.]");
        Console.WriteLine("[2] What's that awful smell?");
        Console.WriteLine("[3] [Run away.]");
        int choice = GetPlayerChoice(3);
        if (choice == 3)
        {
           SelectLocation(playerName, "Spirit Blossom Tree", "Suspicious Forest", "Lantern-lit River", "Thresh Temple", "Spirit Forest", "Azakana Forest", "Sword Graveyard", "Tree of Peace", "Beach", "Mysterious Gate");
        } else {
            WorldChat("You spotted a powerful Azakana Azakana.", "Your body is betraying your mind.", "You cannot move.");
            Chat(yone, color, "A human?!", "Get out of there!");
            WorldChat("The Azakana lounged at you with great force.", "Yone was too late.", "The Azakana clawed through your body and devoured you.", "You died.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Game Over.");
        }

        
    }

    static void SpiritBlossomTree(string playerName)
    {
        string ahri = "Ahri";
        ConsoleColor color = ConsoleColor.Magenta;
        WorldChat("You arrive in a serene place.", "Motes of light drift lazily through the trees.", "Everything is peaceful.", "You come upon a great tree in the middle of bloom. Something about it seems... soothing.");
        if (Globals.Time > 120)
        {
            Chat(ahri, color, "We meet again, strange human.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[1] Uhh.. Who are you again?");
            Console.WriteLine("[2] What do you mean by strange human?!");
            Console.WriteLine("[3] I'm sorry, but I have no idea who you are.");
            GetPlayerChoice(3);

            Chat(ahri, color, "It is me, the Fox who told you the ways of the Spirit Petals.", "It seems you have not gotten a single fucking petal, you imbecile.", "Can't even code a simple game currency smh my head, damn bro", "Here's the key to the gate, get out of here bitch.");
            WorldChat("Acquired Gate Key.");
            Globals.hasKey = true;
            SelectLocation(playerName, "Spirit Blossom Tree", "Suspicious Forest", "Lantern-lit River", "Thresh Temple", "Spirit Forest", "Azakana Forest", "Sword Graveyard", "Tree of Peace", "Beach", "Mysterious Gate");
            


        } else {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[1] The fox spirit is not here... I should come back later.");
            GetPlayerChoice(1);
            if (Globals.isTeemoDone)
            {
                SelectLocation(playerName, "Spirit Blossom Tree", "Suspicious Forest", "Lantern-lit River", "Thresh Temple", "Spirit Forest", "Azakana Forest", "Sword Graveyard", "Tree of Peace", "Beach", "Mysterious Gate");
            } else {
                SelectLocation(playerName, "Spirit Blossom Tree", "Suspicious Tree");
            }
            
        }
    }
    
    static void SpiritForest(string playerName)
    {
        if (Globals.isLambDone)
        {
            WorldChat("Lamb and Wolf are nowhere to be found.");
            SelectLocation(playerName, "Spirit Blossom Tree", "Suspicious Forest", "Lantern-lit River", "Thresh Temple", "Spirit Forest", "Azakana Forest", "Sword Graveyard", "Tree of Peace", "Beach", "Mysterious Gate");
        } else {
            string unknown = "???";
            string girl = "Girl";
            string lamb = "Lamb";
            ConsoleColor lambColor = ConsoleColor.Cyan;
            string wolf = "Wolf";
            ConsoleColor wolfColor = ConsoleColor.Red;

            WorldChat("You don’t remember how you made your way to this forest, but you feel like you belong here.");
            WorldChat("Maybe you should never leave...");
            Chat(unknown, wolfColor, "GRRRRRRRR...");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[1] Uh... hello?");
            Console.WriteLine("[2] That can't be good.");
            Console.WriteLine("[3] Oh boy! A new friend!");
            GetPlayerChoice(3);
            Chat(wolf, wolfColor, "GRRRRR.", "WOLF KNEW HE SMELLED SOMETHING TASTY.", "ARE YOU GOING TO RUN? PLEASE SAY YES.", "WOLF LOVES A GOOD CHASE. WOLF LOVES IT VERY MUCH.");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[1] Um... help?");
            Console.WriteLine("[2] There, ghost wolfie. Nice ghost wolfie");
            Console.WriteLine("[3] I have many regrets about the new friend thing!");
            GetPlayerChoice(3);

            Chat(girl, lambColor, "Ninety eight...");
            Thread.Sleep(500);
            Chat(girl, lambColor, "ninety nine...");
            Thread.Sleep(500);
            Chat(girl, lambColor, "one hundred!");
            Thread.Sleep(500);
            Chat(lamb, lambColor,  "Ready or not. here I come!", "ON!", "There you are, Wolf! I win, again! Woo hoo!", "That's four thousand three hundred and ninety six for me.", "And for you, zero");
            Thread.Sleep(500);
            Chat(wolf, wolfColor, "WOLF WAS DISTRACTED!", "LET WOLF PLAY AGAIN,", "HE WILL WIN THIS TIME.");
            Chat(lamb, lambColor, "Maaaaybe. Y'know.", "if you stop growling so much it'll take me longer to find you.", "Then you can finally beat me!");
            Chat(wolf, wolfColor, "‘WOLF WILL PRACTICE NOT GROWLING.", "HE WILL BE THE QUIETEST WOLF.");
            Chat(lamb, lambColor, "Hooray!", "And look, you found a human!", "Hello, human!", "What are you doing in the spirit realm?", "You've very pale and shaky for a human.");
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[1] Er, hello! Is this wolf your... friend?");
            Console.WriteLine("[2] I think that wolf wants to eat me.");
            Console.WriteLine("[3] Please tell your wolf friend to close his mouth.");
            GetPlayerChoice(3);

            Chat(lamb, lambColor, "Don't worry. Wolf only bites spirits.", "Bad spirits.");
            Chat(wolf, wolfColor, "WOLF BITES PEOPLE TOO.", "IT IS FUN FOR HIM.");
            Chat(lamb, lambColor, "Wolf, not right now.", "You're scaring the human!");
            Chat(wolf, wolfColor, "OOPS");
            Thread.Sleep(300);
            Chat(wolf, wolfColor, "WOLF IS SORRY.");
            Chat(lamb, lambColor, "You know, I'm getting kind of bored of winning hide and seek so much", "Would you play with me, non-spirit?");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[1] I love playing games with children and their monster friends in strange forests!");
            Console.WriteLine("[2] Only if Wolf promises not to eat me. I will destroy you at hide-and-seek, little lamb.");
            GetPlayerChoice(2);

            Chat(wolf, wolfColor, "WOLF DOESN'T THINK YOU CAN WIN.", "HIDE-AND-SEEK IS VERY HARD.");
            Chat(lamb, lambColor, "I'm sure you're a better hider than Wolf, right?", "I bet you'd know not to growl when you're hiding!");
            Chat(lamb, lambColor, "Right?");
            Thread.Sleep(600);
            Chat(lamb, lambColor, "Right?");
            Thread.Sleep(750);
            Chat(lamb, lambColor, "Okay, I'll start counting!", "One...");
            Thread.Sleep(750);
            Chat(lamb, lambColor, "Two...");
            Thread.Sleep(750);
            Chat(lamb, lambColor, "Three...");
            Thread.Sleep(750);
            WorldChat("You walk away as silently as possible to search for a creative hiding spot,");
            SelectLocation(playerName, "Spirit Blossom Tree", "Suspicious Forest", "Lantern-lit River", "Thresh Temple", "Spirit Forest", "Azakana Forest", "Sword Graveyard", "Tree of Peace", "Beach", "Mysterious Gate");
            Globals.isLambDone = false;
        }
    }
    static void LanternRiver(string playerName)
    {
        string name = "Teemo";
        ConsoleColor color = ConsoleColor.Green;
        Chat(name, color, "Wha—");
        Chat(name, color, "Why are you here?!");
        Chat(name, color, "Go sneak into Thresh's temple and get that lantern!");
        SelectLocation(playerName, "Spirit Blossom Tree", "Suspicious Forest", "Lantern-lit River", "Thresh Temple", "Spirit Forest");


    }

    static void ThreshTemple(string playername)
    {
        string name = "Thresh";
        ConsoleColor color = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Black;
        WorldChat("You crossed through the temple gate");
        WorldChat("!!!", "4");
        WorldChat("Absolute darkness blinded your eyes", "4");
        WorldChat("Anguished screams deafened your ears", "4");
        WorldChat("Hellish fire burned your skin", "4");
        Chat(name, color, "Death?");
        Chat(name, color, "No...");
        Thread.Sleep(450);
        Chat(name, color, "Nothing that simple.");
        WorldChat("Your spirit got trapped inside Thresh's lantern for eternity.", "4");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("[Game Over]");
    }

    static void SuspiciousForest(string playerName)
    {
        string name = "Teemo";
        ConsoleColor color = ConsoleColor.Green;
        if (Globals.isTeemoDone)
        {
            WorldChat("You arrived in a strange forest...");
            WorldChat("You feel gazes from the trees");
            WorldChat("An uneerie feeling surfaces on your skin");
            WorldChat("Something bad is about to happen...");
            Thread.Sleep(450);
            Chat(name, color, "Wha—");
                Chat(name, color, "Why are you here?!");
                Chat(name, color, "Go sneak into Thresh's temple and get that lantern!");
                SelectLocation(playerName, "Spirit Blossom Tree", "Suspicious Forest", "Lantern-lit River", "Thresh Temple", "Spirit Forest");
        } else {
            WorldChat("You arrived in a strange forest...");
            WorldChat("You have no idea how much time has passed, but you must've missed dinner. You're starving!");
            WorldChat("Luckily enough, you spotted Onigiri on the ground...");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[1] That's eerily convenient. [Eat the food.]\n[2] Poke the food with a stick.\n[3] Hello? Is this someone's food?");
            GetPlayerChoice(3);
            WorldChat("Somewhat warily, you begin to stuff your face.");
            Chat(name, color, "Tee-hee-hee!");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[1] Who's there?\n[2] What's so funny?");
            GetPlayerChoice(2);

            Chat(name, color, "How's the free meal?");
            WorldChat("You realize your mouth is full of leaves.");
            Chat(name, color, "Oh-ho! I'm sorry! It's just one of my little jokes!");
            Chat(name, color, "You should've seen your face!");
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[1] Who are you?");
            Console.WriteLine("[2] You made me eat leaves.");
            Console.WriteLine("[3] I'm sorry. Was that supposed to be funny?");
            int choice = GetPlayerChoice(3);

            switch (choice)
            {
                case 1:
                    Chat(name, color, "Just a spirit who likes to have fun! Sometimes at other spirits' expense.");
                    break;
                case 2:
                    Chat(name, color, "I can't help it—I have to play pranks on other spirits. It's what I do!");
                    break;
                case 3:
                    Chat(name, color, "I mean...");
                    Chat(name, color, "Well, yeah.");
                    break;

            }
            Chat(name, color, "Hey, you must not be from around here.");
            Chat(name, color, "Wait a minute...");
            Chat(name, color, "YOU'RE NOT A SPIRIT.");
            Chat(name, color, "And that means you can help me with something.");
            Chat(name, color, "It's a very serious matter. What do ya say? Can you help me?");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[1] Sure, why not?");
            Console.WriteLine("[2] Uhhhh...");
            Console.WriteLine("[3] Well, I really need to get back—");
            GetPlayerChoice(3);
            Chat(name, color, "Great! Follow me and we'll get started!");

            WorldChat("You and Teemo wandered around the forest.", "You can feel mischievous gazes upon you.");
                for (int i = 0; i < 3; i++)
                {
                    WorldChat("...");
                    Thread.Sleep(450);
                }

            WorldChat("Following Teemo's twists and turns through the woods leave you even more lost than when you started.");
            WorldChat("But you eventually arrive at an impressive gate overlooking the banks of a beautiful lantern-lit river.");
            Chat(name, color, "I'm sure glad you agreed to do this mission with me...");
            Chat(name, color, "Like I said, it's extremely serious and secret.");
            Chat(name, color, "Can I trust you with extremely serious secrets?");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[1] Yes, I'm great with serious secrets!");
            Console.WriteLine("[2] Depends on how juicy the secret is.");
            Console.WriteLine("[3] Definitely not. I blab to everyone.");
            GetPlayerChoice(3);
            Chat(name, color, "Hmmm. You don't sound very reliable.");
            Chat(name, color, "But you know what? Neither am I!");
            Chat(name, color, "Call me crazy, but I'm going to trust you with this super-secret serious mission.");
            Chat(name, color, "You ready? We're going to...");
            Chat(name, color, "PLAY A PRANK ON THRESH!");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[1] ...");
            GetPlayerChoice(1);
            Chat(name, color, "...");
            Thread.Sleep(300);
            Chat(name, color, "What?");
            Chat(name, color, "Wondering why I need you for this?");
            Chat(name, color, "Because you're a...");
            Chat(name, color, "a...");
            Chat(name, color, "What exactly are you?");
            Chat(name, color, "Where are you from anyway?");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[1] I'm a person. From the physical world. Duh.");
            Console.WriteLine("[2] What are you talking about? I'm a spirit, just like you! Duh!.");
            Console.WriteLine("[3] I... think I'm human. I can't remember much. ...Duh.");
            int choice1 = GetPlayerChoice(3);

            if (choice1 == 1)
            {
                Chat(name, color, "Oooh. I've never met anybody from Duh before!");
                Chat(name, color, "This is gonna be fun!");
            }
            else if (choice1 == 2)
            {
                Chat(name, color, "Hey...");
                Chat(name, color, "you're trying to fool me, aren't ya?");
                Chat(name, color, "You've got the heart of a trickster! I like it!");
                
            }
            else
            {
                Chat(name, color, "Aww, that's a shame.");
                Chat(name, color, "But you know what I do when I can't remember somethin'?");
                Chat(name, color, "I play pranks!");
                Chat(name, color, "They don't help me remember.");
                Chat(name, color, "But they make me happy while I forget!");
            }
            Chat(name, color, "Well, the important thing is that you're definitely not a spirit.");
            Chat(name, color, "And that means Thresh's magic won't work on you.");
            Chat(name, color, "Which means you can sneak into this temple and steal his lantern for me!");
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[1] I don't know. I don't really have time for pranks. I need to figure out how to get back home.");
            GetPlayerChoice(1);
            Chat(name, color, "What? Is Thresh too scary for you?");
            Chat(name, color, "Don't be that way! You do this, and I'll be your super-serious best friend.");
            Chat(name, color, "And maybe even send you back home.");
            Chat(name, color, "What do ya say?!");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[1] This is the dumbest idea I've ever heard. I'm out.");
            Console.WriteLine("[2] This is the dumbest idea I've ever heard. I'm in.");
            GetPlayerChoice(2);
            Chat(name, color, "Great! I'll wait here, and you go get that lantern!");
            Globals.isTeemoDone = true;
            SelectLocation(playerName, "Spirit Blossom Tree", "Suspicious Forest", "Lantern-lit River", "Thresh Temple", "Spirit Forest");
            }
    }


    static void Chat(string name, ConsoleColor color, params string[] messages)
    {
        foreach (string message in messages)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"[{name}]: {message}");
            Thread.Sleep(GetReadTime(message));
            Globals.Time += 1;
        }
    }

    static void WorldChat(params string[] messages)
    {
        foreach (string message in messages)
        {
            bool isNumeric = int.TryParse(message, out int color);
            if (isNumeric)
            {
                Console.ForegroundColor = (ConsoleColor) color;
                break;
            } else {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        foreach (string message in messages)
        {
            bool isNumeric = int.TryParse(message, out int color);
            if (!isNumeric)
            {
                Console.WriteLine($"[{message}]");
                Thread.Sleep(GetReadTime(message));
                Globals.Time += 1;
            }
        }
            
    }

    static int GetPlayerChoice(int optionsCount)
    {
        int choice;
        bool validChoice;

        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("> ");
            validChoice = int.TryParse(Console.ReadLine(), out choice);

            if (!validChoice || choice < 1 || choice > optionsCount)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice. Please try again.");
            }
        } while (!validChoice || choice < 1 || choice > optionsCount);

        return choice;
    }

    static int GetReadTime(string message)
    {
        return (message.Length * 35) + 50; 
    }
}
