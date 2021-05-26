using System; 

using System.ComponentModel.DataAnnotations; 

namespace MvcChess.Models { 
public class Coordinate{ 
	public int row; 
	public int col; 
	
	public Coordinate(int row, int col){ 
		this.row = row; 
		this.col = col; 
	} 
	
	public override bool Equals(Object other){
		if(this.GetType().Equals(other.GetType())){ 
			Coordinate coord = (Coordinate) other;  
			return this.row == coord.row && this.col == coord.col; 
	  	} 
		return false; 
	}
	public override int GetHashCode(){ 
		return 1; 
	}

	public override String ToString(){ 
		String str = "(" + this.row.ToString() + ", " + this.col.ToString() + ")";  
		return str;
	}  
}}  
