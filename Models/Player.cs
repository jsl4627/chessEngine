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
		this.board.board[row, col] = piece; 
		this.board.board[piece.row, piece.col] = null; 
		piece.row = row; 
		piece.col = col;  
		piece.moves_made++; 
		if(piece.label == 'K'){ 
			this.board.kings[Convert.ToInt32(piece.white)] = (King) piece; 
		}
	} 
}}   
