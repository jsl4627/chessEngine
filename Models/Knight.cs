using System; 
using System.Collections; 
using System.Collections.Generic; 

using System.ComponentModel.DataAnnotations; 

namespace MvcChess.Models { 
public class Knight : Piece{ 
	
	public Knight(char label, int row, int col, bool white) : base(label, row, col, white){
		this.points = 3; 
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
		if(this.row + 2 < 8 && this.col + 1 < 8){
			if(board.board[this.row + 2, this.col + 1] == null){
				legal_moves.Add(new Coordinate(this.row + 2, this.col + 1)); 
			} 
			  
			else if(board.board[this.row + 2, this.col + 1].white != this.white){ 
				this.potential_captures.Add(board.board[this.row + 2, this.col + 1]); 
				legal_moves.Add(new Coordinate(this.row + 2, this.col + 1)); 
			}	
		} 
 
		if(this.row + 2 < 8 && this.col - 1 >= 0){ 
			if(board.board[this.row + 2, this.col - 1] == null){ 
				legal_moves.Add(new Coordinate(this.row + 2, this.col - 1)); 
			} 
			else if(board.board[this.row + 2, this.col - 1].white != this.white){ 
				this.potential_captures.Add(board.board[this.row + 2, this.col - 1]); 
				if(board.board[this.row + 2, this.col - 1].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				} 
			}  
		} 
		
		if(this.row - 2 >= 0 && this.col + 1 < 8){
			if(board.board[this.row - 2, this.col + 1] == null){ 
				legal_moves.Add(new Coordinate(this.row - 2, this.col + 1)); 
			} 
	
			else if(board.board[this.row - 2, this.col + 1].white != this.white){ 
				this.potential_captures.Add(board.board[this.row - 2, this.col + 1]); 
				if(board.board[this.row - 2, this.col + 1].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				} 
				legal_moves.Add(new Coordinate(this.row - 2, this.col + 1)); 
			} 
		}

		if(this.row - 2 >= 0 && this.col - 1 >= 0){ 
			if(board.board[this.row - 2, this.col - 1] == null){ 
				legal_moves.Add(new Coordinate(this.row - 2, this.col - 1)); 
			} 
			else if(board.board[this.row - 2, this.col - 1].white != this.white){ 
				this.potential_captures.Add(board.board[this.row - 2, this.col - 1]);
				if(board.board[this.row - 2, this.col - 1].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				} 
				legal_moves.Add(new Coordinate(this.row - 2, this.col - 1)); 
			}

		}
		
		if(this.row - 1 >= 0 && this.col + 2 < 8){ 
			if(board.board[this.row - 1, this.col + 2] == null){ 
				legal_moves.Add(new Coordinate(this.row - 1, this.col + 2)); 
			}
			else if(board.board[this.row - 1, this.col + 2].white != this.white){
				this.potential_captures.Add(board.board[this.row - 1, this.col + 2]); 
				if(board.board[this.row - 1, this.col + 2].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				} 
			}
		}

		if(this.row - 1 >= 0 && this.col - 2 >= 0){
			if(board.board[this.row - 1, this.col - 2] == null){ 
				legal_moves.Add(new Coordinate(this.row - 1, this.col - 2)); 
			}  
			else if(board.board[this.row - 1, this.col - 2].white != this.white){ 
				this.potential_captures.Add(board.board[this.row - 1, this.col - 2]); 
				if(board.board[this.row - 1, this.col - 2].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				} 
				legal_moves.Add(new Coordinate(this.row - 1, this.col - 2)); 
			}
		}

		if(this.row + 1 < 8 && this.col + 2 < 8){
			if(board.board[this.row + 1, this.col + 2] == null){ 
				legal_moves.Add(new Coordinate(this.row + 1, this.col + 2)); 
			}  
			else if(board.board[this.row + 1, this.col + 2].white != this.white){
				this.potential_captures.Add(board.board[this.row + 1, this.col + 2]);  
				if(board.board[this.row + 1, this.col + 2].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				}
				legal_moves.Add(new Coordinate(this.row + 1, this.col + 2)); 
			}

		} 

		if(this.row + 1 < 8 && this.col - 2 >= 0){ 
			if(board.board[this.row + 1, this.col - 2] == null){ 
				legal_moves.Add(new Coordinate(this.row + 1, this.col - 2)); 
			} 
			else if(board.board[this.row + 1, this.col - 2].white != this.white){ 
				this.potential_captures.Add(board.board[this.row + 1, this.col - 2]); 
				if(board.board[this.row + 1, this.col - 2].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				} 
			 
				legal_moves.Add(new Coordinate(this.row + 1, this.col - 2)); 
			}
		} 
		return legal_moves; 
	}  


}
}  
