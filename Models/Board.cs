using System; 

using System.ComponentModel.DataAnnotations; 

namespace MvcChess.Models{ 
public class Board{ 
	public Piece[,] board; 
	public bool checkmate; 
	public bool stalemate;
	public King[] kings;  
	public Board(){
		this.checkmate = false;
		this.stalemate = false;  
		this.board = new Piece[8,8]; 
		for(int i = 0; i < 8; i++){ 
			for(int j = 0; j < 8; j++){
				this.board[i, j] = null; 				
			} 
		} 
		for(int col = 0; col < 8; col++){ 
			this.board[1, col] = new Piece('P', 1, col, true); 
			this.board[6, col] = new Piece('P', 6, col, false); 
		} 
		this.board[0, 0] = new Rook('R', 0, 0, true);
		this.board[0, 1] = new Knight('N', 0, 1, true); 
		this.board[0, 2] = new Bishop('B', 0, 2, true); 
		this.board[0, 3] = new Queen('Q', 0, 3, true); 
		this.board[0, 4] = new King('K', 0, 4, true); 
		this.board[0, 5] = new Bishop('B', 0, 5, true); 
		this.board[0, 6] = new Knight('N', 0, 6, true); 
		this.board[0, 7] = new Rook('R', 0, 7, true);  
		
		this.board[7, 0] = new Rook('R', 7, 0, false);
		this.board[7, 1] = new Knight('N', 7, 1, false); 
		this.board[7, 2] = new Bishop('B', 7, 2, false); 
		this.board[7, 3] = new Queen('Q', 7, 3, false); 
		this.board[7, 4] = new King('K', 7, 4, false); 
		this.board[7, 5] = new Bishop('B', 7, 5, false); 
		this.board[7, 6] = new Knight('N', 7, 6, false); 
		this.board[7, 7] = new Rook('R', 7, 7, false);
		
		this.kings = new King[2]; 
		this.kings[0] = (King) this.board[7, 4]; 
		this.kings[1] = (King) this.board[0, 4]; 

		for(int i = 0; i < 8; i++){ 
			for(int j = 0; j < 8; j++){ 
				if(this.board[i, j] != null){ 
					Dynarray<Coordinate> Moves = this.board[i, j].moves(this);
				} 
			} 
		}

	}

	public Board(Board other){
		this.board = new Piece[8,8];
		this.kings = new King[2];  
		for(int i = 0; i < 8; i++){ 
			for(int j = 0; j < 8; j++){ 
				if(other.board[i, j] == null){ 
					this.board[i, j] = null; 
				} 
				else if(other.board[i, j].label == 'P'){ 
					this.board[i, j] = new Piece(other.board[i, j].label, other.board[i, j].row, other.board[i, j].col, other.board[i, j].white); 
				} 
				else if(other.board[i, j].label == 'R'){ 
					this.board[i, j] = new Rook(other.board[i, j].label, other.board[i, j].row, other.board[i, j].col, other.board[i, j].white); 
				} 
				else if(other.board[i, j].label == 'N'){ 
					this.board[i, j] = new Knight(other.board[i, j].label, other.board[i, j].row, other.board[i, j].col, other.board[i, j].white); 
				} 
				else if(other.board[i, j].label == 'B'){ 
					this.board[i, j] = new Bishop(other.board[i, j].label, other.board[i, j].row, other.board[i, j].col, other.board[i, j].white); 
				} 
				else if(other.board[i, j].label == 'Q'){ 
					this.board[i, j] = new Queen(other.board[i, j].label, other.board[i, j].row, other.board[i, j].col, other.board[i, j].white); 
				} 
				else if(other.board[i, j].label == 'K'){ 
					this.board[i, j] = new King(other.board[i, j].label, other.board[i, j].row, other.board[i, j].col, other.board[i, j].white); 
					this.kings[Convert.ToInt32(other.board[i, j].white)] = (King) this.board[i, j]; 
				} 
			} 
		}
	}  

	public Dynarray<Board> getSuccessors(bool white){ 
		Dynarray<Board> successors = new Dynarray<Board>();
		for(int i = 0; i < 8; i++){ 
			for(int j = 0; j < 8; j++){ 
				if(this.board[i, j] != null){ 
					if(this.board[i, j].white == white){
						Piece current_piece = this.board[i, j];  
						Dynarray<Coordinate> legal_moves = current_piece.moves(this);
						for(int k = 0; k < legal_moves.size; k++){
							Board copy = new Board(this);
					
							try{ 
								bool is_king_in_check = copy.kings[Convert.ToInt32(white)].in_check; 
							} 
							catch(NullReferenceException e){ 
								Console.WriteLine(copy); 
							}
							try{  
								copy.kings[Convert.ToInt32(white)].in_check = false; 
							} 
							catch(NullReferenceException e){
								copy.kings[Convert.ToInt32(white)].in_check = false;  
							} 
							Piece copy_piece = copy.board[i, j];  
							Coordinate current_move = legal_moves.get(k); 
							copy.board[current_move.row, current_move.col] = copy_piece; 
							copy.board[copy_piece.row, copy_piece.col] = null; 
							copy_piece.row = current_move.row; 
							copy_piece.col = current_move.col; 
							copy_piece.moves_made++;
							if(this.kings[Convert.ToInt32(!white)].row == copy_piece.row && this.kings[Convert.ToInt32(!white)].col == copy_piece.col){ 
								copy.kings[Convert.ToInt32(!white)] = null; 
							} 
							if(copy_piece.label == 'K'){
								copy.kings[Convert.ToInt32(white)].row = copy_piece.row;
								copy.kings[Convert.ToInt32(white)].col = copy_piece.col;	
							}
							for(int a = 0; a < 8; a++){ 
								for(int b = 0; b < 8; b++){ 
									if(copy.board[a, b] != null){ 
										Dynarray<Coordinate> Moves = copy.board[a, b].moves(copy); 
									} 
								} 
							}
							if(!copy.kings[Convert.ToInt32(white)].in_check && copy.kings != null && copy.kings[Convert.ToInt32(white)] != null && copy.kings[Convert.ToInt32(!white)] != null){ 
								successors.append(copy);  
							}
						}
					} 
				}
			}
		}
		return successors; 
	}
	public bool checkMate(bool white){ 
		if(this.check(white)){ 
			Dynarray<Board> Successors = this.getSuccessors(white);	
			for(int i = 0; i < Successors.size; i++){ 
				if(!Successors.get(i).check(white)){ 
					return false; 
				} 
			} 
			return true; 
		} 
		return false; 
	} 
	
	public bool check(bool white){ 
		return this.kings[Convert.ToInt32(white)].in_check; 
	} 

	public String BoardColors(){ 
		String boardColors = ""; 
		for(int row = 0; row < 8; row++){ 
			for(int col = 0; col < 8; col++){ 
				if(this.board[row, col] == null){ 
					boardColors += "."; 
				} 
				else if(this.board[row, col].white){
					boardColors += "W"; 
				} 
				else{ 
					boardColors += "B";  
				} 
			}
			boardColors += "\n";
		} 
		return boardColors; 	
	}  
			 

	public override String ToString(){
		String boardString = ""; 
		for(int row = 0; row < 8; row++){ 
			for(int col = 0; col < 8; col++){ 
				if(this.board[row, col] == null){ 
					boardString += "."; 
				} 
				else{
					if(this.board[row, col].white){ 
						if(this.board[row, col].label == 'K' && this.kings[1].in_check){
							boardString += 'X'; 
						} 
						else{ 
							boardString += this.board[row, col].ToString(); 
						} 
					}
					else{ 
						if(this.board[row, col].label == 'K' && this.kings[0].in_check){ 
							boardString += 'x'; 
						} 
						else{ 
							boardString += Char.ToLower(this.board[row, col].label).ToString(); 
						} 
					} 
				} 
			} 
			boardString += "\n"; 
		} 
		return boardString; 

	}
}  
}
  
