using System;

public class GameSuite
{
	public static void Main()
	{
		bool running = true;
		while (running)
		{
			Console.WriteLine("--- Game Console ---");
			Console.WriteLine("1. Naughts and Crosses (PvP)");
			Console.WriteLine("2. Rock, Paper, Scissors (PvC)");
			Console.WriteLine("3. Turn Based Attack Game (PvC)");
			Console.WriteLine("4. Exit ");
			Console.Write("\nSelect an option: ");
			string choice = Console.ReadLine();
			switch (choice)
			{
				case "1":
					PlayNC();
					break;
				case "2":
					PlayRPS();
					break;
				case "3":
					PlayTRPG();
					break;
				case "4":
					Console.WriteLine("Thank You For Playing");
					running = false;
					break;
				default:
					Console.WriteLine("Invalid selection. Please Try Again");
					continue; 
			}
		}
	}
	
	static string[] grid = new string [9]
	{
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9"
		};
	
	static void PlayNC()
	{
	bool PlayAgain = true;
	string Answer = "";
	
	while (PlayAgain)
	{
		string[] grid = new string[9]
			{
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9"
			};
			bool Player1Turn = true;
			int numTurns = 0;
			while (!CheckVictory() && numTurns != 9) // While Not Victory and the number of turns not being 9 the game will run
			{
				PrintGrid();
				if (Player1Turn)
					Console.WriteLine("P1 Turn");
				else
					Console.WriteLine("P2 Turn");
				string choice = Console.ReadLine();
				if (grid.Contains(choice) && choice != "X" && choice != "O")
				{
					int gridIndex = Convert.ToInt32(choice) - 1;
					if (Player1Turn)
						grid[gridIndex] = "X";
					else
						grid[gridIndex] = "O";
					numTurns++;

					Player1Turn = !Player1Turn; // Alernates between Player 1's turn through self-negation
				}

			}

			if (CheckVictory())
				Console.WriteLine("Victory Achieved");
			else
				Console.WriteLine("Draw");
			bool CheckVictory() // 8 total TicTacToe Win Conditions (3 Rows + 3 Columns + 2 Diagonals)
			{
				bool row1 = grid[0] == grid[1] && grid[1] == grid[2]; // Checks to see if all grids in a row are the same
				bool row2 = grid[3] == grid[4] && grid[4] == grid[5];
				bool row3 = grid[6] == grid[7] && grid[7] == grid[8];
				bool column1 = grid[0] == grid[3] && grid[3] == grid[6]; // Checks to see if all grids in a column are the same 
				bool column2 = grid[1] == grid[4] && grid[4] == grid[7];
				bool column3 = grid[2] == grid[5] && grid[5] == grid[8];
				bool diagonal1 = grid[0] == grid[4] && grid[4] == grid[8]; // Checks to see if all grids in a diagonal are the same
				bool diagonal2 = grid[2] == grid[4] && grid[4] == grid[6];
				return row1 || row2 || row3 || column1 || column2 || column3 || diagonal1 || diagonal2;
			}

			PrintGrid();
			void PrintGrid()
			{
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						Console.Write(grid[i * 3 + j] + "|");
					}

					Console.WriteLine();
					Console.WriteLine("------");
				}
			}
		
			Console.WriteLine("Would You Like To Play Again. (Y/N)");
			Answer = Console.ReadLine();
			Answer = Answer.ToUpper();
		
			if (Answer == "Y") 
			{
				PlayAgain = true;
				Console.WriteLine("Game Restarting");
				continue;
			}
			else if (Answer == "N")
			{
				PlayAgain = false;
				Console.WriteLine("Returning to Console Interface");
				break;
			}
			else 
			{
				Console.WriteLine("Invalid Choice, Try Again!");
			}
	}
}
	enum Choice {Rock, Paper, Scissors} //Represents all posible Choices (Enum) 
	
	static void PlayRPS()
	{
		int playerScore = 0;
		int computerScore = 0;
		Random random = new Random(); //Initalises a Random Object Once
		string Answer;
		
		bool PlayAgain = true;
		while (PlayAgain)
		{
			Answer = "";
			
			while (playerScore < 3 && computerScore < 3) //Continue Game until someone reaches 3 wins. 
			{
				Console.WriteLine($"\nScore: Player {playerScore} | Computer {computerScore}");
				Console.WriteLine("Choose R for Rock, P for Paper or S for Scissors");
				string playerInput = Console.ReadLine().ToUpper(); //Input is read and converted to Capital Letter
				
				if (playerInput != "R" && playerInput != "P" && playerInput != "S")
				{
					Console.WriteLine("This input is Invalid. Please Try Again with a valid input");
					continue; //prompts again while skipping the rest of the loop 
				}
				
				Choice playerChoice = (playerInput == "R") ? Choice.Rock: (playerInput == "P") ? Choice.Paper : Choice.Scissors;
				
				Choice computerChoice = (Choice)random.Next(0,3);
				
				Console.WriteLine($"\nPlayer chose: {playerChoice}");
				Console.WriteLine($"Computer chose: {computerChoice}");
				
				//Determine Winner
				if (playerChoice == computerChoice) 
				{
					Console.WriteLine("It's a Draw!");
				}
				else if ((playerChoice == Choice.Rock && computerChoice == Choice.Scissors) || //--> || (or statment) Checks A, B and C, Stops the second a statement is true.
						 (playerChoice == Choice.Scissors && computerChoice == Choice.Paper) ||
						 (playerChoice == Choice.Paper && computerChoice == Choice.Rock))
				{
					Console.WriteLine("Player Wins this round!");
					playerScore++;
				}
				else
				{
					Console.WriteLine("Computer wins this round!");
					computerScore++;
				}
			}
			if (playerScore == 3) 
			{
			Console.WriteLine("\n**The Player Wins the Game!");
			}
		
			if (computerScore == 3)
			{
			Console.WriteLine("\n**The Computer Wins the Game!");
			}
			
			Console.WriteLine("Would You Like To Play Again. (Y/N)");
			Answer = Console.ReadLine();
			Answer = Answer.ToUpper();
		
			if (Answer == "Y") 
			{
				PlayAgain = true;
				Console.WriteLine("Game Restarting");
				continue;
			}
			else if (Answer == "N")
			{
				PlayAgain = false;
				Console.WriteLine("Returning to Console Interface");
				break;
			}
			else 
			{
				Console.WriteLine("Invalid Choice, Try Again!");
			}
		
		}
	}
		
	public static void PlayTRPG()
		{
			int playerHP = 30;
			int enemyHP = 20;
			
			int Pattack = 5;
			int Eattack = 7;
			int Hamount = 5;
			int EHamount = 7;
			
			double missChanceAttack = 0.20;
			double missChanceHeal = 0.15;
	
			Random random = new Random ();
			bool PlayAgain = true;
			string Answer = "";
		
		while (PlayAgain) 
		{	
			while (playerHP > 0 && enemyHP > 0) 
			{
				Console.WriteLine("---Player Turn---");
				Console.WriteLine("Press 'a' to attack and 'h' to heal");
				string choice = Console.ReadLine(); 
				
				if (choice == "a")
				{
					double roll = random.NextDouble(); // gives number between 0.0 and 1.0
					
					if (roll < missChanceAttack)
					{
						Console.WriteLine("Your Attack Missed");
					}
					else 
					{
					int damage = random.Next(Pattack - 2, Pattack + 3);
					enemyHP -= damage; 
					Console.WriteLine("Player Dealt" + " " + damage + " damage");
					}
				}
				else
				{
					double roll = random.NextDouble();
					
					if ((roll < missChanceHeal) || 
						(playerHP == 30))
					{
						Console.WriteLine("Healing Failed!");
					}
					else 
					{
					int heal = random.Next(Hamount - 2, Hamount + 1);
					playerHP += heal;
					Console.WriteLine("Player Healed" + " " + heal + " health");
					}
				}
				if (enemyHP > 0)
				{
					Console.WriteLine("---Enemy Turn---");
					Console.WriteLine("Player HP - " + playerHP + ". Enemy HP - " + enemyHP);
					int enemyChoice = random.Next(0,2);
					
					if (enemyChoice == 0)
					{
						double roll = random.NextDouble();
						
						if (roll < missChanceAttack)
						{
							Console.WriteLine("The Enemies Attack Missed");
						}
						else 
						{
						int enemyattack = random.Next(Eattack -3, Eattack + 2);
						playerHP -= enemyattack;
						Console.WriteLine("Enemy Deals" + " " + enemyattack + " damage");
						}
					}
					
					if (enemyChoice == 1) 
					{
						double roll = random.NextDouble();
						
						if ((roll < missChanceHeal) ||
							(enemyHP == 20))
						{
							Console.WriteLine("The Enemy Failed to Heal"); 
						}
						else 
						{
							int enemyheal = random.Next(EHamount -2, EHamount + 3);
							enemyHP += enemyheal;
							Console.WriteLine("The Enemy Healed" + " " + enemyheal + " Health");
						}
					}
				}			
			}
			if (playerHP > 0 && enemyHP < 0) 
			{
				Console.WriteLine("Victory Achieved");
			}
			else 
			{
				Console.WriteLine("You Have Perished");
			}
		
			Console.WriteLine("Would You Like To Play Again. (Y/N)");
			Answer = Console.ReadLine();
			Answer = Answer.ToUpper();
		
			if (Answer == "Y") 
			{
				PlayAgain = true;
				Console.WriteLine("Game Restarting");
				continue;
			}
			else if (Answer == "N")
			{
				PlayAgain = false;
				Console.WriteLine("Returning to Console Interface");
				break;
			}
			else 
			{
				Console.WriteLine("Invalid Choice, Try Again!");
			}
		}
	}
}
