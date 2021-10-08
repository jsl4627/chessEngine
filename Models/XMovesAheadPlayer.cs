using System;
using System.Collections;  
using System.Collections.Generic; 

using System.ComponentModel.DataAnnotations; 

namespace MvcChess.Models{ 
public class XMovesAheadPlayer : Player{ 
	public int depth;
	public int[] aux; 
	public class obj{ 
		public Board config; 
		public int score; 
		public Hashtable choiceTable; 
		public Stack<String> predicessors;
		public Hashtable gameTrees;  
		
		public obj(Board config, int score, Hashtable choiceTable, Stack<String> predicessors, Hashtable gameTrees){ 
			this.config = config; 
			this.score = score; 
			this.choiceTable = choiceTable;
			this.predicessors = predicessors;
			this.gameTrees = gameTrees;  
		} 	
	}  
	
	public XMovesAheadPlayer(bool white, Board board, int depth) : base(white, board){ 
		this.depth = depth;
		
		this.aux = new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 1, 1, 2, 4, 4, 2, 1, 1, 1, 1, 2, 4, 4, 2, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
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
		

	
	public int evaluate_config4(Board config){ 
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
		int total_score = 0; 
		for(int i = 0; i < 64; i++){ 
			total_score += times(this.aux[i], board_vector[i]);
		}  
		return total_score; 
	}
 
	public int evaluate_config5(Board config, bool white){ 
		int[] board_vector = new int[64];
		int[,] position_matrix = new int[8, 8];
		int[] position_vector = new int[64];  
		position_matrix[0, 0] = 8; 
		position_matrix[0, 1] = 8; 
		position_matrix[0, 2] = 8; 
		position_matrix[0, 3] = 8; 
		position_matrix[0, 4] = 8; 
		position_matrix[0, 5] = 8; 
		position_matrix[0, 6] = 8; 
		position_matrix[0, 7] = 8;
		
		position_matrix[1, 0] = 8;  
		position_matrix[1, 1] = 8; 
		position_matrix[1, 2] = 8; 
		position_matrix[1, 3] = 8; 
		position_matrix[1, 4] = 8; 
		position_matrix[1, 5] = 8; 
		position_matrix[1, 6] = 8; 
		position_matrix[1, 7] = 8;

		 
		position_matrix[2, 0] = 8;  
		position_matrix[2, 1] = 12; 
		position_matrix[2, 2] = 12; 
		position_matrix[2, 3] = 18; 
		position_matrix[2, 4] = 18; 
		position_matrix[2, 5] = 12; 
		position_matrix[2, 6] = 12; 
		position_matrix[2, 7] = 8;

		 
		position_matrix[3, 0] = 8;  
		position_matrix[3, 1] = 12; 
		position_matrix[3, 2] = 12; 
		position_matrix[3, 3] = 27; 
		position_matrix[3, 4] = 27; 
		position_matrix[3, 5] = 12; 
		position_matrix[3, 6] = 12; 
		position_matrix[3, 7] = 8;

		 
		position_matrix[4, 0] = 8;  
		position_matrix[4, 1] = 12; 
		position_matrix[4, 2] = 12; 
		position_matrix[4, 3] = 27; 
		position_matrix[4, 4] = 27; 
		position_matrix[4, 5] = 12; 
		position_matrix[4, 6] = 12; 
		position_matrix[4, 7] = 8; 

		
		position_matrix[5, 0] = 8;  
		position_matrix[5, 1] = 12; 
		position_matrix[5, 2] = 12; 
		position_matrix[5, 3] = 18; 
		position_matrix[5, 4] = 18; 
		position_matrix[5, 5] = 12; 
		position_matrix[5, 6] = 12; 
		position_matrix[5, 7] = 8;

		
		position_matrix[6, 0] = 8;  
		position_matrix[6, 1] = 8; 
		position_matrix[6, 2] = 8; 
		position_matrix[6, 3] = 8; 
		position_matrix[6, 4] = 8; 
		position_matrix[6, 5] = 8; 
		position_matrix[6, 6] = 8; 
		position_matrix[6, 7] = 8;

		
		position_matrix[7, 0] = 8;  
		position_matrix[7, 1] = 8; 
		position_matrix[7, 2] = 8; 
		position_matrix[7, 3] = 8; 
		position_matrix[7, 4] = 8; 
		position_matrix[7, 5] = 8; 
		position_matrix[7, 6] = 8; 
		position_matrix[7, 7] = 8;
		int board_vector_index = 0; 
		for(int i = 0; i < 8; i++){ 
			for(int j = 0; j < 8; j++){
				if(config.board[i, j] == null){ 
					board_vector[board_vector_index] = 0; 
				} 
				else if(config.board[i, j].white == white){ 
					board_vector[board_vector_index] = config.board[i, j].points;
			 
				} 
				
				else{ 
					board_vector[board_vector_index] = times(-1, config.board[i, j].points); 
				 
				} 
				position_vector[board_vector_index] = position_matrix[i, j]; 
				board_vector_index++; 
			}
		}
		// 8 8 8 8 8 8 8 8
		// 8 8 8 8 8 8 8 8 
		// 8 12 12 18 18 12 12 8 
		// 8 12 12 27 27 12 12 8  
		// 8 12 12 27 27 12 12 8 
		// 8 12 12 18 18 12 12 8 
		// 8 8 8 8 8 8 8 8 
		// 8 8 8 8 8 8 8 8 	
		int total_score = 0; 
		for(int i = 0; i < 64; i++){ 
			total_score += times(position_vector[i], board_vector[i]);
		}  
		return total_score; 
	}
	public int head_count(Board config, bool white){
		int headCount = 0; 
		for(int i = 0; i < 8; i++){ 
			for(int j = 0; j < 8; j++){ 
				if(config.board[i, j] != null && config.board[i, j].white == white){ 
					headCount += config.board[i, j].points; 
				} 
			} 
		} 
		return headCount; 
	}
	public List<Board> prune_successors(List<Board> successors, bool white, Board config){ 
		List<Board> pruned_successors = new List<Board>();
		int config_body_count = head_count(config, !white); 
		bool free_piece = false;  
		for(int i = 0; i < successors.Count; i++){
			bool pruned = false;  
			Board current_successor = successors[i]; 
			// check if the rook pawn or knight pawn was moved
			if(current_successor.board[3, 0] != null || current_successor.board[3, 1] != null || current_successor.board[3, 6] != null || current_successor.board[3, 7] != null){
				pruned = true; 
			} 
			if(current_successor.board[4, 0] != null || current_successor.board[4, 1] != null || current_successor.board[4, 6] != null || current_successor.board[4, 7] != null){ 
				pruned = true;  
			} 
			// check if there is a piece on the rim 
			if(current_successor.board[2, 0] != null || current_successor.board[2, 7] != null || current_successor.board[5, 0] != null || current_successor.board[5, 7] != null){ 
				pruned = true; 
			} 
			// prune if the white king is not on E1 
			//if(current_successor.board[0, 4] == null && config.kings[1].in_check == false && config.board[0, 4] != null && config.board[0, 4].label == 'K'){ 
			//	pruned = true; 
			//} 
			// prune if the black king is not on E8 
			//if(current_successor.board[7, 4] == null && config.kings[0].in_check == false && config.board[7, 4] != null && config.board[7, 4].label == 'K'){ 
			//	pruned = true; 
			//}
			// prune if the white rooks are not on the first row
			//int num_rooks_on_first_row = 0;  
			//for(int col = 0; col < 8; col++){
			//	if(current_successor.board[0, col] != null && current_successor.board[0, col].label == 'R'){ 
			//		num_rooks_on_first_row++; 
			//	} 
			//} 
			//if(num_rooks_on_first_row != 2){ 
			//	pruned = true; 
			//}
			// prune if the black rooks are not on the eighth row
			//int num_rooks_on_eighth_row = 0;  
			//for(int col = 0; col < 8; col++){ 
			//	if(current_successor.board[7, col] != null && current_successor.board[7, col].label == 'R'){ 
			//		  num_rooks_on_eighth_row++; 
			//	} 
			//} 
			//if(num_rooks_on_eighth_row != 2){ 
			//	pruned = true; 
			//} 
			// prune if a queen can be captured in other successors but not in the current one 
			//bool free_piece_successor = head_count(successors.get(i), !white) - config_body_count <= -9; 
			//if(free_piece_successor){ 
				//free_piece = true; 
			//} 
			//else if(free_piece){ 
			//	pruned = true; 
			//} 
				
			
	
			if(!pruned){ 
				pruned_successors.Add(current_successor); 
			} 
		} 
		return pruned_successors; 
	}
	public int material_evaluation(Board config, bool white){
		int score = 0; 
		for(int i = 0; i < 8; i++){ 
			for(int j = 0; j < 8; j++){ 
				if(config.board[i, j] != null && config.board[i, j].label != 'K'){ 
					if(config.board[i, j].white == white){ 
						score += config.board[i, j].points;
					} 
					else{ 
						score -= config.board[i, j].points;  
					} 
				} 
			} 
		} 
		return score; 
	} 
 

	public obj MiniMax(Board config, int depth, bool white, Hashtable choiceTable, Hashtable gameTree, Stack<String> predicessors, int alpha, int beta, int R, bool null_move, bool cut){ 
		predicessors.Push(config.ToString()); 
		List<Board> successors = config.getSuccessors(white);
		if(depth == 0 || config.checkMate(white)){ 
			int score = evaluate_config5(config, white); 
			if(!null_move && !cut){
				choiceTable.Add(config.ToString(), score);  
			} 
			Stack<String> GameTree = new Stack<String>(new Stack<String>(predicessors));
			gameTree.Add(config.ToString(), gameTree);  
			predicessors.Pop(); 
			return new obj(config, score, choiceTable, predicessors, gameTree); 
		}
		else{
			if(this.white == white){ 
				int max_score = -1000; 
				int max_index = -1;
				obj new_obj = null;
				//null move pruning  
				//if(!null_move && max_score > -1000 && depth > 2 && !cut){ 
				//	new_obj = this.MiniMax(config, 2, !white, choiceTable, max_score, beta, R - 1, true, false);
				//}
				//if(new_obj != null && new_obj.score > beta){ 
				//	return new obj(config, beta, choiceTable); 
				//}
				///////////////////////
	
				// multi-cut pruning 
				//if(!cut){ 
					//int M = 6 <= successors.size?6:successors.size; 
					//int C = 3;
					//int c = 0;  
					//if(depth >= 2 && !null_move && !cut && max_score > -1000){ 
						//for(int k = 0; k < M; k++){ 
							//new_obj = this.MiniMax(successors.get(k), 1, !white, choiceTable, predicessors, max_score, beta, R, null_move, true);  
							//if(new_obj.score >= beta){
								//c++;
								//if(c == C){ 
									//return new obj(config, beta, choiceTable); 
								//} 
							//} 
						//}
					//} 
			 
								
				//}
				// TODO: Test ProbCut Pruning.
				//double T = 1.5; 
				//int DP = 2; 
				//int D = 4;
				//if(depth == D){  
					//int bound = Convert.ToInt32(T * alpha + beta); 
					//new_obj = MiniMax(config, DP, !white, choiceTable, alpha, bound, R, false, false); 
					//if(new_obj != null && new_obj.score >= bound){ 
						//return null; 
					//} 
				//}  	
				//////////////////////	
				 
				//successors = prune_successors(successors, this.white, config); 
				for(int i = 0; i < successors.Count; i++){
					if(!predicessors.Contains(successors[i].ToString())){ 
						new_obj = null;

						if(choiceTable.ContainsKey(successors[i].ToString())){ 
							new_obj = new obj(successors[i], (int) choiceTable[successors[i].ToString()], choiceTable, predicessors, gameTree); 
						}	 
						else{
															 
							new_obj = this.MiniMax(successors[i], depth - 1, !white, choiceTable, gameTree, predicessors, max_score, beta, R, null_move, cut);
						}
						if(new_obj != null){ 
							choiceTable = new_obj.choiceTable; 
							predicessors = new_obj.predicessors; 	
							if(new_obj.score > max_score){ 
								max_score = new_obj.score; 
								max_index = i; 
							}
							if(new_obj.score >= beta){ 
								predicessors.Pop();  
								return new obj(config, beta, choiceTable, predicessors, gameTree); 
							}
						}	
					}		 
				}
				if(max_index > -1){
					predicessors.Pop(); 
					return new obj(successors[max_index], max_score, choiceTable, predicessors, gameTree); 
				} 
				else{ 
					predicessors.Pop(); 
					return null; 
				} 
			} 
			else{ 
				int min_score = 1000; 
				int min_index = -1;
				//successors = prune_successors(successors, !this.white, config); 
				for(int i = 0; i < successors.Count; i++){
					if(!predicessors.Contains(successors[i].ToString())){
						obj new_obj = null; 
						if(choiceTable.ContainsKey(successors[i].ToString())){ 
							new_obj = new obj(successors[i], (int) choiceTable[successors[i].ToString()], choiceTable, predicessors, gameTree); 
						} 
						else{ 
							new_obj = this.MiniMax(successors[i], depth - 1, !white, choiceTable, gameTree, predicessors, alpha, min_score, R, null_move, cut); 
						}
						if(new_obj != null){ 
							choiceTable = new_obj.choiceTable; 
							predicessors = new_obj.predicessors; 
					
						
							if(new_obj.score < min_score){ 
								min_score = new_obj.score; 
								min_index = i; 
							} 
							if(new_obj.score <= alpha){
								predicessors.Pop(); 
								return new obj(config, alpha, choiceTable, predicessors, gameTree); 
							}
						}
					} 	 
				}
				if(min_index > -1){ 	
					predicessors.Pop(); 
					return new obj(successors[min_index], min_score, choiceTable, predicessors, gameTree); 
				} 
				else{
					predicessors.Pop();  
					return null; 
				} 
			}
			
		}
		
	} 
		 
	public override void move(Piece piece, int row, int col){
 		obj optimal_obj = this.MiniMax(this.board, this.depth, this.white, new Hashtable(), new Hashtable(), new Stack<String>(), -1000, 1000, 1, false, false);
		this.board.board = optimal_obj.config.board;
		this.board.kings = optimal_obj.config.kings; 
		this.board.kings[Convert.ToInt32(this.white)].in_check = false; 	
	} 

}
}  
