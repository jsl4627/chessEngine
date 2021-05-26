using System; 

using System.ComponentModel.DataAnnotations; 

namespace MvcChess.Models { 
public class Rook : Piece{
	

	public Rook(char label, int row, int col, bool white) : base(label, row, col, white){
		this.points = 5; 	
       }
	public override Dynarray<Coordinate> moves(Board board){ 
		Dynarray<Coordinate> legal_moves = new Dynarray<Coordinate>(); 
		this.potential_captures = new Dynarray<Piece>(); 
		int start_column = this.col; 
		int current_column = this.col + 1; 
		while(current_column < 8 && board.board[this.row, current_column] == null){
			legal_moves.append(new Coordinate(this.row, current_column)); 
			current_column++; 
		}
		if(current_column < 8 && board.board[this.row, current_column].white != this.white){ 
			legal_moves.append(new Coordinate(this.row, current_column)); 
			this.potential_captures.append(board.board[this.row, current_column]); 
			if(board.board[this.row, current_column].label == 'K'){ 
				board.kings[Convert.ToInt32(!this.white)].in_check = true; 
			} 
		}   
		current_column = this.col - 1; 
		while(current_column >= 0 && board.board[this.row, current_column] == null){ 
			legal_moves.append(new Coordinate(this.row, current_column)); 
			current_column--; 
		} 
		if(current_column >= 0 && board.board[this.row, current_column].white != this.white){ 
			legal_moves.append(new Coordinate(this.row, current_column)); 
			this.potential_captures.append(board.board[this.row, current_column]);
			if(board.board[this.row, current_column].label == 'K'){ 
				board.kings[Convert.ToInt32(!this.white)].in_check = true; 
			}  
		}
		int start_row = this.row; 
		int current_row = this.row + 1; 
		while(current_row < 8 && board.board[current_row, this.col] == null){
 			legal_moves.append(new Coordinate(current_row, this.col)); 
			current_row++; 
		}
		if(current_row < 8 && board.board[current_row, this.col].white != this.white){ 
			legal_moves.append(new Coordinate(current_row, this.col)); 
			this.potential_captures.append(board.board[current_row, this.col]); 
			if(board.board[current_row, this.col].label == 'K'){
				board.kings[Convert.ToInt32(!this.white)].in_check = true; 
			} 
		} 
			 
		current_row= this.row - 1; 
		while(current_row >= 0 && board.board[current_row, this.col] == null){ 
			legal_moves.append(new Coordinate(current_row, this.col)); 
			current_row--; 
		} 
		if(current_row >= 0 && board.board[current_row, this.col].white != this.white){ 
			legal_moves.append(new Coordinate(current_row, this.col)); 
			this.potential_captures.append(board.board[current_row, this.col]);  
			if(board.board[current_row, this.col].label == 'K'){ 
				board.kings[Convert.ToInt32(!this.white)].in_check = true; 
			} 
		} 
		return legal_moves; 
	}  
	
}}  