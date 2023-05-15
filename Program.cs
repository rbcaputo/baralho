using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_DesafioBaralho
{
		internal class Program
		{
				static void Main(string[] args)
				{
						Console.WriteLine("EMBARALHADOR, DISTRIBUIDOR E ORDENADOR DE CARTAS DE BARALHO\n");
						//52 CARDS DECK START
						List<string> newDeck = new List<string>() { "AdC", "2dC", "3dC", "4dC", "5dC", "6dC", "7dC", "8dC", "9dC", "10dC", "JdC", "QdC", "KdC",
																																																		"AdP", "2dP", "3dP", "4dP", "5dP", "6dP", "7dP", "8dP", "9dP", "10dP", "JdP", "QdP", "KdP",
																																																		"AdO", "2dO", "3dO", "4dO", "5dO", "6dO", "7dO", "8dO", "9dO", "10dO", "JdO", "QdO", "KdO",
																																																		"AdE", "2dE", "3dE", "4dE", "5dE", "6dE", "7dE", "8dE", "9dE", "10dE", "JdE", "QdE", "KdE" };
						//52 CARDS DECK END
						//GET NUMERICAL VALUES OF CARDS' FACE VALUES START
						int lttValue(string card)
						{
								string strValue = card.Substring(0, 1);
								switch (strValue)
								{
										case "A":
												return 1;
										case "J":
												return 11;
										case "Q":
												return 12;
										case "K":
												return 13;
										default:
												return int.Parse(strValue);
								}
						}
						//GET NUMERICAL VALUES OF CARDS' FACE VALUES END
						Random rnd = new Random();
						List<string> shfDeck = new List<string>();
						//SHUFFLE NEW DECK ALGORITHM START
						for (int i = newDeck.Count; i > 0; i--)
						{
								int cardPos = rnd.Next(i);
								string card = newDeck[cardPos];
								shfDeck.Add(card);
								newDeck.RemoveAt(cardPos);
						}
						//SHUFFLE NEW DECK ALGORITHM END
						int numPlayers = 13;
						int handSize = 4;
						List<string[]> playersHands = new List<string[]>();
						//ADD PLAYERS START
						for (int i = 0; i < numPlayers; i++)
						{
								string[] player = new string[handSize];
								playersHands.Add(player);
						}
						//ADD PLAYERS END
						//DEAL HAND OF FOUR CARDS AMONG THIRTEEN PLAYERS START
						for (int i = 0; i < shfDeck.Count; i++)
						{
								for (int j = 0; j < playersHands.Count; j++)
								{
										for (int k = 0; k < handSize; k++)
										{
												playersHands[j][k] = shfDeck[i];
												shfDeck.RemoveAt(i);
										}
								}
						}
						//DEAL HAND OF FOUR CARDS AMONG THIRTEEN PLAYERS END
						//SORT PLAYERS' HANDS ACCORDING TO CARDS VALUES START
						for (int i = 0; i < playersHands.Count; i++)
						{
								for (int j = 0; j < playersHands[i].Length; j++)
								{
										for (int k = j + 1; k < playersHands[i].Length; k++)
										{
												int val1 = lttValue(playersHands[i][j]);
												int val2 = lttValue(playersHands[i][k]);
												if (val1 > val2)
												{
														string valTemp = playersHands[i][j];
														playersHands[i][j] = playersHands[i][k];
														playersHands[i][k] = valTemp;
												}
										}
								}
						}
						//SORT PLAYERS' HANDS ACCORDING TO CARDS VALUES END
						//PRINT EACH PLAYER'S HAND ON SCREEN START
						for (int i = 0; i < playersHands.Count; i++)
						{
								Console.Write($"Cartas do Jogador {i + 1}: ");
								for (int j = 0; j < playersHands[i].Length; j++)
								{
										Console.Write($"{playersHands[i][j]} ");
								}
								Console.Write("\n\n");
						}
						//PRINT EACH PLAYER'S HAND ON SCREEN END
						Console.ReadKey();
				}
		}
}
