using System; 

using System.ComponentModel.DataAnnotations; 

namespace MvcChess.Models { 
public class Knight : Piece{ 
	
	public Knight(char label, int row, int col, bool white) : base(label, row, col, white){
		this.points = 3; 
        }


	public override Dynarray<Coordinate> moves(Board board){ 
		Dynarray<Coordinate> legal_moves = new Dynarray<Coordinate>();
		this.potential_captures = new Dynarray<Piece>();
		if(this.row + 2 < 8 && this.col + 1 < 8){
			if(board.board[this.row + 2, this.col + 1] == null){
				legal_moves.append(new Coordinate(this.row + 2, this.col + 1)); 
			} 
			  
			else if(board.board[this.row + 2, this.col + 1].white != this.white){ 
				this.potential_captures.append(board.board[this.row + 2, this.col + 1]); 
				legal_moves.append(new Coordinate(this.row + 2, this.col + 1)); 
			}	
		} 
 
		if(this.row + 2 < 8 && this.col - 1 >= 0){ 
			if(board.board[this.row + 2, this.col - 1] == null){ 
				legal_moves.append(new Coordinate(this.row + 2, this.col - 1)); 
			} 
			else if(board.board[this.row + 2, this.col - 1].white != this.white){ 
				this.potential_captures.append(board.board[this.row + 2, this.col - 1]); 
				if(board.board[this.row + 2, this.col - 1].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				} 
			}  
		} 
		
		if(this.row - 2 >= 0 && this.col + 1 < 8){
			if(board.board[this.row - 2, this.col + 1] == null){ 
				legal_moves.append(new Coordinate(this.row - 2, this.col + 1)); 
			} 
	
			else if(board.board[this.row - 2, this.col + 1].white != this.white){ 
				this.potential_captures.append(board.board[this.row - 2, this.col + 1]); 
				if(board.board[this.row - 2, this.col + 1].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				} 
				legal_moves.append(new Coordinate(this.row - 2, this.col + 1)); 
			} 
		}

		if(this.row - 2 >= 0 && this.col - 1 >= 0){ 
			if(board.board[this.row - 2, this.col - 1] == null){ 
				legal_moves.append(new Coordinate(this.row - 2, this.col - 1)); 
			} 
			else if(board.board[this.row - 2, this.col - 1].white != this.white){ 
				this.potential_captures.append(board.board[this.row - 2, this.col - 1]);
				if(board.board[this.row - 2, this.col - 1].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				} 
				legal_moves.append(new Coordinate(this.row - 2, this.col - 1)); 
			}

		}
		
		if(this.row - 1 >= 0 && this.col + 2 < 8){ 
			if(board.board[this.row - 1, this.col + 2] == null){ 
				legal_moves.append(new Coordinate(this.row - 1, this.col + 2)); 
			}
			else if(board.board[this.row - 1, this.col + 2].white != this.white){
				this.potential_captures.append(board.board[this.row - 1, this.col + 2]); 
				if(board.board[this.row - 1, this.col + 2].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				} 
			}
		}

		if(this.row - 1 >= 0 && this.col - 2 >= 0){
			if(board.board[this.row - 1, this.col - 2] == null){ 
				legal_moves.append(new Coordinate(this.row - 1, this.col - 2)); 
			}  
			else if(board.board[this.row - 1, this.col - 2].white != this.white){ 
				this.potential_captures.append(board.board[this.row - 1, this.col - 2]); 
				if(board.board[this.row - 1, this.col - 2].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				} 
				legal_moves.append(new Coordinate(this.row - 1, this.col - 2)); 
			}
		}

		if(this.row + 1 < 8 && this.col + 2 < 8){
			if(board.board[this.row + 1, this.col + 2] == null){ 
				legal_moves.append(new Coordinate(this.row + 1, this.col + 2)); 
			}  
			else if(board.board[this.row + 1, this.col + 2].white != this.white){
				this.potential_captures.append(board.board[this.row + 1, this.col + 2]);  
				if(board.board[this.row + 1, this.col + 2].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				}
				legal_moves.append(new Coordinate(this.row + 1, this.col + 2)); 
			}

		} 

		if(this.row + 1 < 8 && this.col - 2 >= 0){ 
			if(board.board[this.row + 1, this.col - 2] == null){ 
				legal_moves.append(new Coordinate(this.row + 1, this.col - 2)); 
			} 
			else if(board.board[this.row + 1, this.col - 2].white != this.white){ 
				this.potential_captures.append(board.board[this.row + 1, this.col - 2]); 
				if(board.board[this.row + 1, this.col - 2].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				} 
			 
				legal_moves.append(new Coordinate(this.row + 1, this.col - 2)); 
			}
		} 
		return legal_moves; 
	}  


}
}  
