using System; 
using System.Collections; 
using System.Collections.Generic; 

using System.ComponentModel.DataAnnotations; 

namespace MvcChess.Models{
 
public class Game{ 
	public Board GameBoard; 
	public Player Player1; 
	public Player Player2; 

	public Game(Player Player1, Player Player2){ 
		this.Player1 = Player1; 
		this.Player2 = Player2;  
		this.GameBoard = Player1.board;
		for(int i = 0; i < 8; i++){ 
			for(int j = 0; j < 8; j++){ 
				if(this.GameBoard.board[i, j] != null){
					this.GameBoard.board[i, j].potential_captures = new List<Piece>();  
					this.GameBoard.board[i, j].moves(GameBoard); 
				} 
			} 
		}  
	}

	public bool tie(Player on_move){
		int num_pieces = 0; 
		for(int row = 0; row < 8; row++){
			for(int col = 8; col < 8; col++){ 
				if(this.GameBoard.board[row, col] != null){ 
					num_pieces++; 
				} 
			} 
		} 
		if(num_pieces == 2){ 
			return true; 
		} 

		if(!this.check(on_move)){ 
			List<Board> successors = this.GameBoard.getSuccessors(on_move.white); 
			for(int i = 0; i < successors.Count; i++){ 
				Player virtual_player1 = new Player(on_move.white, successors[i]); 
				Player virtual_player2 = new Player(!on_move.white, successors[i]); 
				Game virtual_game = new Game(virtual_player1, virtual_player2); 
				Player virtual_on_move = virtual_player1; 
				if(on_move == this.Player2){
					virtual_on_move = virtual_player2; 
				} 
				if(virtual_game.check(virtual_on_move)){
					return true;
				}
			}
		}
		return true; 	 
	}
	public void promote(){
		for(int i = 0; i < 8; i++){ 
			if(this.GameBoard.board[0, i] != null && this.GameBoard.board[0, i].label == 'P'){ 
				this.GameBoard.board[0, i] = new Queen('Q', 0, i, false); 
				List<Coordinate> Moves = this.GameBoard.board[0, i].moves(this.GameBoard); 
			}
			if(this.GameBoard.board[7, i] != null && this.GameBoard.board[0, i].label == 'P'){  
				this.GameBoard.board[7, i] = new Queen('Q', 7, i, true); 
				List<Coordinate> Moves = this.GameBoard.board[7, i].moves(this.GameBoard); 
			} 
		}  
	} 

	public bool check(Player on_move){
		Player last_move = this.Player1; 
		if(on_move == Player1){ 
			last_move = this.Player2; 
		} 
		
		for(int i = 0; i < last_move.Pieces.Count; i++){
			if(last_move.Pieces[i].active == true){
				List<Coordinate> Moves = last_move.Pieces[i].moves(last_move.board);
				for(int j = 0; j < last_move.Pieces[i].potential_captures.Count; j++){
					if(last_move.Pieces[i].potential_captures[j].label == 'K'){
						return true; 
					} 
				} 
			} 
		}
		return false; 
	} 

	public bool checkMate(Player on_move){ 
		if(this.check(on_move)){
			List<Board> successors = this.GameBoard.getSuccessors(on_move.white); 
			for(int i = 0; i < successors.Count; i++){ 
				Player virtual_player1 = new Player(on_move.white, successors[i]);
				Player virtual_player2 = new Player(!on_move.white, successors[i]); 
				Game virtual_game = new Game(virtual_player1, virtual_player2);  
				Player virtual_on_move = virtual_player1; 
				if(!virtual_game.check(virtual_on_move)){
					return false;
				}
			}
			return true;
		}
		return false; 	 
	}

	public void Promotion(Player on_move){ 
		Player just_moved = this.Player1; 
		if(on_move == this.Player1){
			just_moved = this.Player2; 
		} 
		for(int i = 0; i < just_moved.Pieces.Count; i++){ 
			Piece current_piece = just_moved.Pieces[i]; 
			if(current_piece.label == 'P'){ 
				if(current_piece.row == 0 || current_piece.col == 7){
					this.GameBoard.board[current_piece.row, current_piece.col] = new Queen('Q', current_piece.row, current_piece.col, current_piece.white); 
					this.GameBoard.board[current_piece.row, current_piece.col].moves(this.GameBoard); 
					just_moved.Pieces[i] = this.GameBoard.board[current_piece.row, current_piece.col]; 
				} 
			} 
		} 
	}
		  
	
}
}  
