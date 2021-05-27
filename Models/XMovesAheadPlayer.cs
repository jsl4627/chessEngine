using System; 

using System.ComponentModel.DataAnnotations; 

namespace MvcChess.Models{ 
public class XMovesAheadPlayer : Player{ 
	public int depth;
	public class obj{ 
		public Board config; 
		public int score; 
		
		public obj(Board config, int score){ 
			this.config = config; 
			this.score = score; 
		} 	
	}  
	
	public XMovesAheadPlayer(bool white, Board board, int depth) : base(white, board){ 
		this.depth = depth;
	}
	

	  

	public double evaluate_config(Board config, bool white){ 
		// If this player is in checkmate, return -1.0. 
		// If the oppponent is in checkmate, return 1.0.
		// If the game is a draw, return 0.0. 
		int total_score = 0; 
		for(int i = 0; i < 8; i++){
			for(int j = 0; j < 8; j++){
				if(config.board[i, j] != null){ 
					if(config.board[i, j].white == white){ 
						total_score += config.board[i, j].points; 
					} 
					else{ 
						total_score -= config.board[i, j].points; 
					} 
				} 
			} 
		}
		return total_score / 100.0;   
	}
	public int times(int a, int b){ 
		if(b == 1000){
			return 0;  
		} 
		else{ 
			return a * b; 
		} 
	} 

	public int evaluate_config2(Board config, bool white){ 
		int[] board_vector = new int[64]; 
		int board_vector_index = 0; 
		for(int i = 0; i < 8; i++){ 
			for(int j = 0; j < 8; j++){ 
				if(config.board[i, j] == null){ 
					board_vector[board_vector_index] = 0; 
				} 
				else if(config.board[i, j].white == this.white){ 
					board_vector[board_vector_index] = config.board[i, j].points;
				} 
				
				else{ 
					board_vector[board_vector_index] = times(-1, config.board[i, j].points); 
				} 
				board_vector_index++; 
			}
		}
		// 1 1 1 1 1 1 1 1
		// 1 1 1 1 1 1 1 1 
		// 1 1 2 2 2 2 1 1 
		// 1 1 2 4 4 1 1 1  
		// 1 1 2 4 4 1 1 1 
		// 1 1 2 2 2 1 1 1 
		// 1 1 1 1 1 1 1 1 
		// 1 1 1 1 1 1 1 1 	
		int[] aux = new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 2, 4, 4, 2, 1, 1, 1, 1, 2, 4, 4, 2, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
		int total_score = 0; 
		for(int i = 0; i < 64; i++){ 
			total_score += times(aux[i], board_vector[i]);
		}  
		return total_score; 
	} 

	public int evaluate_config3(Board config, bool white, bool test){ 
		int[,] piece_matrix = new int[8, 8]; 
		int[,] position_matrix = new int[8, 8];
		for(int i = 0; i < 8; i++){ 
			for(int j = 0; j < 8; j++){ 
				if(config.board[i, j] == null){ 
					piece_matrix[i, j] = 0; 
				}
				else if(config.board[i, j].label == 'P'){ 
					piece_matrix[i, j] = 1 * (this.white == config.board[i, j].white?1:-1);
				} 
				else if(config.board[i, j].label == 'N'){ 
					piece_matrix[i, j] = 3 * (this.white == config.board[i, j].white?1:-1); 
				} 
				else if(config.board[i, j].label == 'B'){ 
					piece_matrix[i, j] = 3 * (this.white == config.board[i, j].white?1:-1);  
				} 
				else if(config.board[i, j].label == 'Q'){	
					piece_matrix[i, j] = 9 * (this.white == config.board[i, j].white?1:-1);  
				}
				else if(config.board[i, j].label == 'K'){ 
					piece_matrix[i, j] = 4 * (this.white == config.board[i, j].white?1:-1);  
				}
			}
		}  
		position_matrix[0, 0] = 10; 
		position_matrix[0, 1] = 5; 
		position_matrix[0, 2] = 5; 
		position_matrix[0, 3] = 30; 
		position_matrix[0, 4] = 30;
		position_matrix[0, 5] = 5; 
		position_matrix[0, 6] = 5; 
		position_matrix[0, 7] = 10; 
		for(int i = 0; i < 8; i++){ 
			position_matrix[1, i] = 10; 
		} 
		position_matrix[2, 0] = 5; 
		position_matrix[2, 1] = 5; 
		position_matrix[2, 2] = 20; 
		position_matrix[2, 3] = 25; 
		position_matrix[2, 4] = 25; 
		position_matrix[2, 5] = 20; 
		position_matrix[2, 6] = 5; 
		position_matrix[2, 7] = 5; 
		for(int i = 0; i < 8; i++){ 
			position_matrix[3, i] = position_matrix[2, i]; 
		} 
		for(int i = 7; i >=4; i -= 1){ 
			for(int j = 0; j < 8; j++){ 
				position_matrix[i, j] = position_matrix[7 - i, j]; 
			} 
		}  
		int score = 0; 
		for(int i = 0; i < 8; i++){ 
			for(int j = 0; j < 8; j++){ 
				score += position_matrix[i, j] * piece_matrix[i, j]; 
			} 
		} 
		Console.WriteLine(score); 
		return score; 
	} 
		


	public obj MiniMax(Board config, int depth, bool white){ 
		Dynarray<Board> successors = config.getSuccessors(white);
		if(depth == 0 || config.checkMate(white)){ 
			int score = evaluate_config3(config, white, true); 
			return new obj(config, score); 
		}
		else{
			if(this.white == white){ 
				int max_score = -1000000; 
				int max_index = 0;
				for(int i = 0; i < successors.size; i++){
					obj new_obj = this.MiniMax(successors.get(i), depth - 1, !white); 
					if(new_obj.score > max_score){ 
						max_score = new_obj.score; 
						max_index = i; 
					} 
				}	
				return new obj(successors.get(max_index), max_score); 
			} 
			else{ 
				int min_score = 1000000; 
				int min_index = 0;
				for(int i = 0; i < successors.size; i++){
					obj new_obj = this.MiniMax(successors.get(i), depth - 1, !white); 
					if(new_obj.score < min_score){ 
						min_score = new_obj.score; 
						min_index = i; 
					} 
				} 
				return new obj(successors.get(min_index), min_score); 
			}
			
		}
		
	} 
		 
	public override void move(Piece piece, int row, int col){
 		obj optimal_obj = this.MiniMax(this.board, this.depth, this.white);
		this.board.board = optimal_obj.config.board;
		this.board.kings = optimal_obj.config.kings; 
		this.board.kings[Convert.ToInt32(this.white)].in_check = false; 	
	} 

}
}  
