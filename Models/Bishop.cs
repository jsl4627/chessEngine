using System; 

using System.ComponentModel.DataAnnotations; 
using System.Collections; 
using System.Collections.Generic; 
namespace MvcChess.Models { 
public class Bishop : Piece{ 
	
	public Bishop(char label, int row, int col, bool white) : base(label, row, col, white){
		this.points = 3; 
		this.potential_captures = null; 
        }

	public override List<Coordinate> moves(Board board){ 
		List<Coordinate> legal_moves = new List<Coordinate>(); 
		this.potential_captures = new List<Piece>(); 
		int start_row = this.row; 
		int start_col = this.col; 

		int current_row = start_row + 1; 
		int current_col = start_col + 1; 
		
		while(current_row < 8 && current_col < 8 && board.board[current_row, current_col] == null){ 
			legal_moves.Add(new Coordinate(current_row, current_col)); 
			current_row += 1; 
			current_col += 1; 
		} 
		if(current_row < 8 && current_col < 8 && board.board[current_row, current_col].white != this.white){ 
			legal_moves.Add(new Coordinate(current_row, current_col)); 
			this.potential_captures.Add(board.board[current_row, current_col]);
			if(board.board[current_row, current_col].label == 'K'){ 
				board.kings[Convert.ToInt32(!this.white)].in_check = true; 
			}  
		}

		current_row = start_row - 1; 
		current_col = start_col + 1; 

		while(current_row >= 0 && current_col < 8 && board.board[current_row, current_col] == null){ 
			legal_moves.Add(new Coordinate(current_row, current_col)); 
			current_row -= 1; 
			current_col += 1; 		
		}
		if(current_row >= 0 && current_col < 8 && board.board[current_row, current_col].white != this.white){ 
			legal_moves.Add(new Coordinate(current_row, current_col)); 
			this.potential_captures.Add(board.board[current_row, current_col]); 
			if(board.board[current_row, current_col].label == 'K'){ 
				board.kings[Convert.ToInt32(!this.white)].in_check = true; 
			} 
		} 
		 

		current_row = start_row + 1; 
		current_col = start_col - 1; 
		while(current_row < 8 && current_col >= 0 && board.board[current_row, current_col] == null){ 
			legal_moves.Add(new Coordinate(current_row, current_col)); 
			current_row += 1; 
			current_col -= 1; 
		} 

		if(current_row < 8 && current_col >= 0 && board.board[current_row, current_col].white != this.white){ 
			legal_moves.Add(new Coordinate(current_row, current_col)); 
			this.potential_captures.Add(board.board[current_row, current_col]);
			if(board.board[current_row, current_col].label == 'K'){ 
				board.kings[Convert.ToInt32(!this.white)].in_check = true; 
			} 
		} 
		
		current_row = start_row - 1; 
		current_col = start_col - 1; 
		while(current_row >= 0 && current_col >= 0 && board.board[current_row, current_col] == null){ 
			legal_moves.Add(new Coordinate(current_row, current_col)); 
			current_row -= 1; 
			current_col -= 1; 
		}
		if(current_row >= 0 && current_col >= 0 && board.board[current_row, current_col].white != this.white){ 
			legal_moves.Add(new Coordinate(current_row, current_col)); 
			this.potential_captures.Add(board.board[current_row, current_col]); 
			if(board.board[current_row, current_col].label == 'K'){ 
				board.kings[Convert.ToInt32(!this.white)].in_check = true; 
			} 
		} 
		return legal_moves; 
	} 
	

} 
} 
