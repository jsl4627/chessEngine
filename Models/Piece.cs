using System; 

 
using System.ComponentModel.DataAnnotations; 

namespace MvcChess.Models { 
public class Piece{ 
	public char label; 
	public int row; 
	public int col; 
	public bool white; 
	public Dynarray<Piece> potential_captures;
	public bool active; 
	public int moves_made; 
	public int points; 

	public Piece(char label, int row, int col, bool white){ 
		this.label = label; 
		this.row = row; 
		this.col = col; 
		this.white = white; 
		this.potential_captures = new Dynarray<Piece>();
		this.active = true;
		this.moves_made = 0;
		this.points = 1;     
	}
	
	public Piece(Piece other){ 
		this.label = other.label; 
		this.row = other.row; 
		this.col = other.col; 
		this.white = other.white;  
		this.potential_captures = other.potential_captures; 
		this.active = other.active; 
		this.moves_made = other.moves_made; 
		this.points = other.points; 
	}

	public bool check(Board board, Piece king){
		 
		for(int i = 0; i < 8; i++){ 
			for(int j = 0; j < 8; j++){
				if(board.board[i, j] != null && board.board[i, j].white != king.white){ 
					Dynarray<Coordinate> Moves = board.board[i, j].moves(board); 
					for(int k = 0; k < board.board[i, j].potential_captures.size; k++){ 
						if(board.board[i, j].potential_captures.get(k).label == 'K' && board.board[i, j].potential_captures.get(k).white == king.white){ 
							return true; 
						} 
					} 
				} 
			} 
		}
		return false; 
	} 
	
	public Dynarray<Coordinate> remove_checks(Board board, King king, Dynarray<Coordinate> potential_moves){ 
		//TODO: Remove all moves that leaves that team's king in check.
		Dynarray<Coordinate> legal_moves = new Dynarray<Coordinate>(); 
		for(int i = 0; i < potential_moves.size; i++){ 
			Board copy = new Board(board); 
			King king_copy = copy.kings[Convert.ToInt32(king.white)]; 
			Piece copy_piece = copy.board[this.row, this.col]; 
			copy.board[potential_moves.get(i).row, potential_moves.get(i).col] = copy_piece; 
			copy.board[copy_piece.row, copy_piece.col] = null; 
			copy_piece.row = potential_moves.get(i).row; 
			copy_piece.col = potential_moves.get(i).col; 
			if(copy_piece.label == 'K'){ 
				king_copy.row = copy_piece.row; 
				king_copy.col = copy_piece.col; 
			}		
			try{ 
				bool c = king_copy.in_check; 	 
			} 
			catch(NullReferenceException e){ 
				Console.WriteLine(copy); 
			} 
			if(!king_copy.in_check){
				if(copy.board[2, 5] != null && copy.board[2, 5].label == 'B' && copy.board[2, 5].white == false){ 
					if(copy.board[1, 4] != null && copy.board[1, 4].label == 'K' && copy.board[1, 4].white == true && king.white == true){ 
						Console.WriteLine("This is a check dumbass"); 
						Console.WriteLine(copy); 
						Console.WriteLine(king_copy.in_check); 
						Console.WriteLine("----------"); 
					} 
				}
				 
				legal_moves.append(potential_moves.get(i)); 	
			} 
		} 
		return legal_moves; 

	}  

	public override String ToString(){
		return this.label.ToString(); 
	}

	public virtual Dynarray<Coordinate> moves(Board board){
		this.potential_captures = new Dynarray<Piece>(); 
		Dynarray<Coordinate> legal_moves = new Dynarray<Coordinate>(); 
		//TODO: Pawns are the only piece whose direction depends on its color. The code still needs to consider this. 
		if(this.white){   
			if(this.row + 1 < 8 && board.board[this.row + 1, this.col] == null){ 
				legal_moves.append(new Coordinate(this.row + 1, this.col)); 
			} 
			if(this.row + 1 < 8 && this.col + 1 < 8 && board.board[this.row + 1, this.col + 1] != null && board.board[this.row + 1, this.col + 1].white != this.white){ 
				legal_moves.append(new Coordinate(this.row + 1, this.col + 1)); 
				this.potential_captures.append(board.board[this.row + 1, this.col + 1]); 
				if(board.board[this.row + 1, this.col + 1].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				}
			}
		 
			if(this.row + 1 < 8 && this.col - 1 >= 0 && board.board[this.row + 1, this.col - 1] != null && board.board[this.row + 1, this.col - 1].white != this.white){ 
				legal_moves.append(new Coordinate(this.row + 1, this.col - 1)); 
				this.potential_captures.append(board.board[this.row + 1, this.col - 1]); 
				if(board.board[this.row + 1, this.col - 1].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				}
			}
			if(this.row == 1){
				if(board.board[3, this.col] == null){ 
					legal_moves.append(new Coordinate(this.row + 2, this.col)); 
				} 
			} 
		} 
		else{ 
			if(this.row - 1 >= 0 && board.board[this.row - 1, this.col] == null){ 
				legal_moves.append(new Coordinate(this.row - 1, this.col)); 
			} 
			if(this.row - 1 >= 0 && this.col + 1 < 8 && board.board[this.row - 1, this.col + 1] != null && board.board[this.row - 1, this.col + 1].white != this.white){ 
				legal_moves.append(new Coordinate(this.row - 1, this.col + 1)); 
				this.potential_captures.append(board.board[this.row - 1, this.col + 1]); 
				if(board.board[this.row - 1, this.col + 1].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				} 
			} 
			if(this.row - 1 >= 0 && this.col - 1 >= 0 && board.board[this.row - 1, this.col - 1] != null && board.board[this.row - 1, this.col - 1].white != this.white){ 
				legal_moves.append(new Coordinate(this.row - 1, this.col - 1)); 
				this.potential_captures.append(board.board[this.row - 1, this.col - 1]); 
				if(board.board[this.row - 1, this.col - 1].label == 'K'){ 
					board.kings[Convert.ToInt32(!this.white)].in_check = true; 
				} 
			} 
			if(this.row == 6){
				if(board.board[4, this.col] == null){
					legal_moves.append(new Coordinate(this.row - 2, this.col));
				} 
			} 
		}   
		return legal_moves; 
	} 
	   
}} 
