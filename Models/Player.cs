using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations; 

namespace MvcChess.Models { 
public class Player{
	public bool white; 
	public Board board;
	public List<Piece> Pieces; 
	public King king;   
	
	public Player(bool white, Board board){ 
		this.white = white; 
		this.board = board;

		this.Pieces = new List<Piece>(); 
		 
		for(int row = 0; row < 8; row++){ 
			for(int col = 0; col < 8; col++){ 
				if(this.board.board[row, col] != null && this.board.board[row, col].white == this.white){ 
					this.Pieces.Add(this.board.board[row, col]); 
				}
			} 
		}  	 
		if(this.white){ 
			this.king = this.board.kings[Convert.ToInt32(this.white)];
		}
		else{ 
			this.king = this.board.kings[Convert.ToInt32(!this.white)]; 
		}  
	}

	public virtual void move(Piece piece, int row, int col){
		if(this.board.board[row, col] != null){ 
			this.board.board[row, col].active = false; 
			this.board.board[row, col] = null; 
		}
		if(piece.label == 'R' && piece.row == 0 && piece.col == 7 || piece.label == 'R' && piece.row == 7 && piece.col == 7){ 
			this.board.kings[Convert.ToInt32(piece.white)].can_castle_king = "never"; 
		} 
		if(piece.label == 'R' && piece.row == 0 && piece.col == 0 || piece.label == 'R' && piece.row == 7 && piece.col == 0){ 
			this.board.kings[Convert.ToInt32(piece.white)].can_castle_queen = "never"; 
		} 
		if(piece.label == 'K' && piece.row == 0 && piece.col == 4 && row == 0 && col == 6){ 
			this.board.board[0, 5] = this.board.board[0, 7];  
			this.board.board[0, 7] = null; 
		} 
		if(piece.label == 'K' && piece.row == 0 && piece.col == 4 && row == 0 && col == 2){ 
			this.board.board[0, 3] = this.board.board[0, 0]; 
			this.board.board[0, 0] = null; 
		} 
		if(piece.label == 'K' && piece.row == 7 && piece.col == 4 && row == 7 && col == 6){ 
			this.board.board[7, 5] = this.board.board[7, 7]; 
			this.board.board[7, 7] = null; 
		} 
		if(piece.label == 'K' && piece.row == 7 && piece.col == 4 && row == 7 && col == 2){ 
			this.board.board[7, 3] = this.board.board[7, 0]; 
			this.board.board[7, 0] = null; 
		} 
		this.board.board[row, col] = piece; 
		this.board.board[piece.row, piece.col] = null; 
		piece.row = row; 
		piece.col = col;  
		piece.moves_made++;
		
		 
		if(piece.label == 'K'){ 
			this.board.kings[Convert.ToInt32(piece.white)] = (King) piece;
			//this.board.kings[Convert.ToInt32(piece.white)].row = piece.row; 
			//this.board.kings[Convert.ToInt32(piece.white)].col = piece.col; 
			this.board.kings[Convert.ToInt32(piece.white)].can_castle_king = "never"; 
			this.board.kings[Convert.ToInt32(piece.white)].can_castle_queen = "never";  
		}
	} 
}}   
