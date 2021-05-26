using System; 

using System.ComponentModel.DataAnnotations; 

namespace MvcChess.Models { 
public class King : Piece{ 
	public bool in_check; 	
	public King(char label, int row, int col, bool white) : base(label, row, col, white){
        	this.points = 1000;
		this.in_check = false;  
	}


	public override Dynarray<Coordinate> moves(Board board){ 
		Dynarray<Coordinate> legal_moves = new Dynarray<Coordinate>();
		this.potential_captures = new Dynarray<Piece>(); 
		if(this.row + 1 < 8){ 
			if(board.board[this.row + 1, this.col] == null){
				legal_moves.append(new Coordinate(this.row + 1, this.col));
			} 
			else if(board.board[this.row + 1, this.col].white != this.white){ 
				legal_moves.append(new Coordinate(this.row + 1, this.col)); 
				this.potential_captures.append(board.board[this.row + 1, this.col]); 
			} 
		}  
		if(this.row - 1 >=  0){ 
			if(board.board[this.row - 1, this.col] == null){
				legal_moves.append(new Coordinate(this.row - 1, this.col));
			} 
			else if(board.board[this.row - 1, this.col].white != this.white){ 
				legal_moves.append(new Coordinate(this.row - 1, this.col)); 
				this.potential_captures.append(board.board[this.row - 1, this.col]); 
			} 
		} 
		if(this.col + 1 < 8){ 
			if(board.board[this.row, this.col + 1] == null){ 
				legal_moves.append(new Coordinate(this.row, this.col + 1));
			} 
			else if(board.board[this.row, this.col + 1].white != this.white){ 
				legal_moves.append(new Coordinate(this.row, this.col + 1));
				this.potential_captures.append(board.board[this.row, this.col + 1]); 
			}
		} 
   
		if(this.col - 1 >= 0){ 
			if(board.board[this.row, this.col - 1] == null){ 
				
				legal_moves.append(new Coordinate(this.row, this.col - 1));
			} 
			else if(board.board[this.row, this.col - 1].white != this.white){ 
				legal_moves.append(new Coordinate(this.row, this.col - 1)); 
				this.potential_captures.append(board.board[this.row, this.col - 1]);
			} 
		}  
				
		if(this.row + 1 < 8 && this.col + 1 < 8){ 
			if(board.board[this.row + 1, this.col + 1] == null){ 
				
				legal_moves.append(new Coordinate(this.row + 1, this.col + 1)); 
			} 
			else if(board.board[this.row + 1, this.col + 1].white != this.white){ 
				legal_moves.append(new Coordinate(this.row + 1, this.col + 1)); 
				this.potential_captures.append(board.board[this.row + 1, this.col + 1]); 	
			}
		}	
		if(this.row + 1 < 8 && this.col - 1 >= 0){ 
			if(board.board[this.row + 1, this.col - 1] == null){
				legal_moves.append(new Coordinate(this.row + 1, this.col - 1)); 
			}
			else if(board.board[this.row + 1, this.col - 1].white != this.white){ 
				legal_moves.append(new Coordinate(this.row + 1, this.col - 1)); 
				this.potential_captures.append(board.board[this.row + 1, this.col - 1]); 
			} 
		}
			 
		
		
		if(this.row - 1 >= 0 && this.col + 1 < 8){
			if(board.board[this.row - 1, this.col + 1] == null){ 
				
				legal_moves.append(new Coordinate(this.row - 1, this.col + 1)); 
		 	}
			else if(board.board[this.row - 1, this.col + 1].white != this.white){ 
				legal_moves.append(new Coordinate(this.row - 1, this.col + 1)); 
				this.potential_captures.append(board.board[this.row - 1, this.col + 1]); 
			} 
		} 

		if(this.row - 1 >= 0 && this.col - 1 >= 0){ 
			if(board.board[this.row - 1, this.col - 1] == null){	
				legal_moves.append(new Coordinate(this.row - 1, this.col - 1));
			}
			else if(board.board[this.row - 1, this.col - 1].white != this.white){ 
				legal_moves.append(new Coordinate(this.row - 1, this.col - 1)); 
				this.potential_captures.append(board.board[this.row - 1, this.col - 1]); 
			} 
 
		}
 
		return legal_moves;  
	} 
} 
} 