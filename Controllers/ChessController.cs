using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Http;
using System;  
using System.Text.Encodings.Web;
using System.IO; 
using System.Collections; 
using System.Web; 
using MvcChess.Models;

namespace MvcChess.Controllers{
	public class ChessController : Controller{

		
		// /Chess/Game 
		public IActionResult Game(int moves_ahead = 1){  		
			string[] lines = System.IO.File.ReadAllLines("Write_Board_Pieces.txt"); 
			
			string[] colors = System.IO.File.ReadAllLines("Write_Board_Colors.txt"); 
			Piece[,] board_array = new Piece[8, 8];
			King[] kings = new King[2];  
			for(int i = 0; i < 8; i++){ 
				char[] pieces_line = lines[i].Replace(" ", String.Empty).ToCharArray(); 
				char[] colors_line = colors[i].Replace(" ", String.Empty).ToCharArray();
				for(int j = 0; j < 8; j++){ 
					if(pieces_line[j] == '.'){ 
						board_array[i, j] = null; 
					}
					else{
						bool white = colors_line[j] == 'W';  
						if(pieces_line[j] == 'P'){ 
							board_array[i, j] = new Piece('P', i, j, white);
						}
						else if(pieces_line[j] == 'R'){ 
							board_array[i, j] = new Rook('R', i, j, white); 
						} 
						else if(pieces_line[j] == 'N'){ 
							board_array[i, j] = new Knight('N', i, j, white); 
						} 
						else if(pieces_line[j] == 'B'){ 
							board_array[i, j] = new Bishop('B', i, j, white); 
						} 
						else if(pieces_line[j] == 'Q'){ 
							board_array[i, j] = new Queen('Q', i, j, white); 
						} 
						else{
							board_array[i, j] = new King('K', i, j, white); 
							kings[Convert.ToInt32(white)] =  (King) board_array[i, j];
						}  
										
					}
				}
				
			}
			Board board = new Board(); 
			board.board = board_array; 
			board.kings = kings; 
			board.checkmate = false; 
			board.stalemate = false;
			for(int i = 0; i < 8; i++){ 
				for(int j = 0; j < 8; j++){ 
					if(board.board[i, j] != null){ 
						Dynarray<Coordinate> moves = board.board[i, j].moves(board); 
					} 
				} 
			} 	
			StreamWriter file = new("Write_Board_Pieces.txt");
			file.Write(board.ToString());
			file.Flush();  
			file.Close(); 

			file = new("Write_Board_Colors.txt"); 
			file.Write(board.BoardColors()); 
			file.Flush(); 
			file.Close();
			 
			Player Player1 = new Player(true, board); 
			XMovesAheadPlayer Player2 = new XMovesAheadPlayer(false, board, moves_ahead); 
			Game game = new Game(Player1, Player2); 

			return View(game); 
		} 	

		//
		// GET: /Chess/Board/
		public IActionResult Board(){
			return View(new Board()); 
		}


		// 
		// GET: /Chess/Start  
		public IActionResult Start(){ 
			Board GameBoard = new Board(); 
			Player Player1 = new Player(true, GameBoard); 
			int moves_ahead = 1; 
			Player Player2 = new XMovesAheadPlayer(false, GameBoard, moves_ahead); 
			Game game = new Game(Player1, Player2);
			ViewData["Game"] = game;
			
			
			// Write the pieces array to a file 
			StreamWriter file = new("Write_Board_Pieces.txt");
			file.Write(GameBoard.ToString());
			file.Flush();  
			file.Close(); 

			file = new("Write_Board_Colors.txt"); 
			file.Write(GameBoard.BoardColors()); 
			file.Flush(); 
			file.Close(); 


			return RedirectToAction("Game");  
		}  
		
		//
		// GET: /Chess/Welcome/  
		public IActionResult Welcome(string name, int numTimes = 1){
			ViewData["Message"] = "Hello " + name; 
			ViewData["NumTimes"] = numTimes;
			return View();  
		}

		//POST: /Chess/OpponentMove/ 
		public IActionResult OpponentMove(int moves_ahead = 3){ 
			
			string[] lines = System.IO.File.ReadAllLines("Write_Board_Pieces.txt"); 
			
			string[] colors = System.IO.File.ReadAllLines("Write_Board_Colors.txt"); 
		
			Piece[,] board_array = new Piece[8, 8];
			King[] kings = new King[2];  
			for(int i = 0; i < 8; i++){ 
				char[] pieces_line = lines[i].Replace(" ", String.Empty).ToCharArray(); 
				char[] colors_line = colors[i].Replace(" ", String.Empty).ToCharArray();
				for(int j = 0; j < 8; j++){ 
					if(pieces_line[j] == '.'){ 
						board_array[i, j] = null; 
					}
					else{
						bool white = colors_line[j] == 'W';  
						if(pieces_line[j] == 'P'){ 
							board_array[i, j] = new Piece('P', i, j, white);
						}
						else if(pieces_line[j] == 'R'){ 
							board_array[i, j] = new Rook('R', i, j, white); 
						} 
						else if(pieces_line[j] == 'N'){ 
							board_array[i, j] = new Knight('N', i, j, white); 
						} 
						else if(pieces_line[j] == 'B'){ 
							board_array[i, j] = new Bishop('B', i, j, white); 
						} 
						else if(pieces_line[j] == 'Q'){ 
							board_array[i, j] = new Queen('Q', i, j, white); 
						} 
						else{
							board_array[i, j] = new King('K', i, j, white); 
							kings[Convert.ToInt32(white)] =  (King) board_array[i, j];
						}  
										
					}
				}
				
			}
			Board board = new Board(); 
			board.board = board_array; 
			board.kings = kings; 
			board.checkmate = false; 
			board.stalemate = false;  
			for(int i = 0; i < 8; i++){ 
				for(int j = 0; j < 8; j++){
					if(board.board[i, j] != null){  
						Dynarray<Coordinate> moves = board.board[i, j].moves(board); 
					} 
				} 
			} 	 

			Player Player1 = new Player(true, board); 
			XMovesAheadPlayer Player2 = new XMovesAheadPlayer(false, board, moves_ahead); 		
			
			Game game = new Game(Player1, Player2);  
					
			game.Player2.move(null, 0, 0); 
		
			ViewData["Game"] = game;

					
			StreamWriter file = new("Write_Board_Pieces.txt");
			file.Write(game.GameBoard.ToString());
			file.Flush();  
			file.Close(); 

			file = new("Write_Board_Colors.txt"); 
			file.Write(game.GameBoard.BoardColors()); 
			file.Flush(); 
			file.Close(); 

			return RedirectToAction("Game"); 

		} 	
		// 
		// POST: /Chess/Move/?start_row = & start_col = & end_row = & end_col =   
		public IActionResult Move(string start_row, string start_col, string end_row, string end_col, int moves_ahead = 1){
			string[] lines = System.IO.File.ReadAllLines("Write_Board_Pieces.txt"); 
			
			string[] colors = System.IO.File.ReadAllLines("Write_Board_Colors.txt"); 
		
			Piece[,] board_array = new Piece[8, 8];
			King[] kings = new King[2];  
			for(int i = 0; i < 8; i++){ 
				char[] pieces_line = lines[i].Replace(" ", String.Empty).ToCharArray(); 
				char[] colors_line = colors[i].Replace(" ", String.Empty).ToCharArray();
				for(int j = 0; j < 8; j++){ 
					if(pieces_line[j] == '.'){ 
						board_array[i, j] = null; 
					}
					else{
						bool white = colors_line[j] == 'W';  
						if(pieces_line[j] == 'P'){ 
							board_array[i, j] = new Piece('P', i, j, white);
						}
						else if(pieces_line[j] == 'R'){ 
							board_array[i, j] = new Rook('R', i, j, white); 
						} 
						else if(pieces_line[j] == 'N'){ 
							board_array[i, j] = new Knight('N', i, j, white); 
						} 
						else if(pieces_line[j] == 'B'){ 
							board_array[i, j] = new Bishop('B', i, j, white); 
						} 
						else if(pieces_line[j] == 'Q'){ 
							board_array[i, j] = new Queen('Q', i, j, white); 
						} 
						else{
							board_array[i, j] = new King('K', i, j, white); 
							kings[Convert.ToInt32(white)] =  (King) board_array[i, j];
						}  
										
					}
				}
				
			}
			Board board = new Board(); 
			board.board = board_array; 
			board.kings = kings; 
			board.checkmate = false; 
			board.stalemate = false;  
			for(int i = 0; i < 8; i++){ 
				for(int j = 0; j < 8; j++){ 
					if(board.board[i, j] != null){ 	
						Dynarray<Coordinate> moves = board.board[i, j].moves(board); 
					} 
				} 
			} 
 
			Player Player1 = new Player(true, board); 
			XMovesAheadPlayer Player2 = new XMovesAheadPlayer(false, board, moves_ahead); 		
			Game game = new Game(Player1, Player2);  
			game.Player1.move(game.GameBoard.board[Convert.ToInt32(start_row), Convert.ToInt32(start_col)], Convert.ToInt32(end_row), Convert.ToInt32(end_col)); 
			ViewData["Game"] = game;

					
			StreamWriter file = new("Write_Board_Pieces.txt");
			file.Write(game.GameBoard.ToString());
			file.Flush();  
			file.Close(); 

			file = new("Write_Board_Colors.txt"); 
			file.Write(game.GameBoard.BoardColors()); 
			file.Flush(); 
			file.Close(); 

			return RedirectToAction("Game"); 
			
		}   
	} 
} 
