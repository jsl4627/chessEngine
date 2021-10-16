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
		if(board.kings[1].can_castle_king != "never"){ 
			if(this.row == 0 && this.col == 5 || this.row == 0 && this.col == 6){ 
				board.kings[1].can_castle_king = "no";
			} 
		} 
		if(board.kings[1].can_castle_queen != "never"){ 
			if(this.row == 0 && this.col == 1 || this.row == 0 && this.col == 2 || this.row == 0 && this.col == 3){ 
				board.kings[1].can_castle_queen = "no"; 
			} 
		} 
		if(board.kings[0].can_castle_king != "never"){ 
			if(this.row == 7 && this.col == 5 || this.row == 7 && this.col == 6){ 
				board.kings[0].can_castle_king = "no"; 
			} 
		} 
		if(board.kings[0].can_castle_queen != "never"){ 
			if(this.row == 7 && this.col == 1 || this.row == 7 && this.col == 2 || this.row == 7 && this.col == 3){ 
				board.kings[0].can_castle_queen = "no"; 
			} 
		}  
		List<Coordinate> legal_moves = new List<Coordinate>(); 
		this.potential_captures = new List<Piece>(); 
		int start_row = this.row; 
		int start_col = this.col; 

		int current_row = start_row + 1; 
		int current_col = start_col + 1; 	
		while(current_row < 8 && current_col < 8 && board.board[current_row, current_col] == null){ 
			legal_moves.Add(new Coordinate(current_row, current_col));
			// !!!The following line is to test if the king referenced below is set to an instance of an object.!!!
			string test = board.kings[Convert.ToInt32(!this.white)].can_castle_queen; 
			if(this.white == true && board.kings[0].can_castle_king == "yes"){ 
				if(current_row == 7 && current_col == 5 || current_row == 7 && current_col == 6){ 
					board.kings[0].can_castle_king = "no"; 
				} 
			} 
			if(this.white == true && board.kings[0].can_castle_queen == "yes"){ 
				if(current_row == 7 && current_col == 3 || current_row == 7 && current_col == 2 || current_row == 7 && current_col == 1){
					board.kings[0].can_castle_queen = "no"; 
				} 
			} 
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
			if(this.white == false && board.kings[Convert.ToInt32(!this.white)].can_castle_king == "yes"){ 
				if(current_row == 0 && current_col == 5 || current_row == 0 && current_col == 6){ 
					board.kings[Convert.ToInt32(!this.white)].can_castle_king = "no"; 
				} 
			} 
			if(this.white == false && board.kings[Convert.ToInt32(!this.white)].can_castle_queen == "yes"){ 
				if(current_row == 0 && current_col == 3 || current_row == 0 && current_col == 2 || current_row == 0 && current_col == 1){ 
					board.kings[Convert.ToInt32(!this.white)].can_castle_queen = "no"; 
				} 
			} 
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
			 
			if(this.white == true && board.kings[Convert.ToInt32(!this.white)].can_castle_king == "yes"){ 
				if(current_row == 7 && current_col == 5 || current_row == 7 && current_col == 6){ 
					board.kings[Convert.ToInt32(!this.white)].can_castle_king = "no"; 
				} 
			} 
			if(this.white == true && board.kings[Convert.ToInt32(!this.white)].can_castle_queen == "yes"){ 
				if(current_row == 7 && current_col == 3 || current_row == 7 && current_col == 2 || current_row == 7 && current_col == 1){
					board.kings[Convert.ToInt32(!this.white)].can_castle_queen = "no"; 
				} 
			} 
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
			
			if(this.white == false && board.kings[Convert.ToInt32(!this.white)].can_castle_king == "yes"){ 
				if(current_row == 0 && current_col == 5 || current_row == 0 && current_col == 6){ 
					board.kings[Convert.ToInt32(!this.white)].can_castle_king = "no"; 
				} 
			} 
			if(this.white == false && board.kings[Convert.ToInt32(!this.white)].can_castle_queen == "yes"){ 
				if(current_row == 0 && current_col == 3 || current_row == 0 && current_col == 2 || current_row == 0 && current_col == 1){ 
					board.kings[Convert.ToInt32(!this.white)].can_castle_queen = "no"; 
				} 
			} 
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
