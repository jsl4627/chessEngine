using System; 

using System.ComponentModel.DataAnnotations; 

namespace MvcChess.Models { 
public class Dynarray<T>{ 
	public int size; 
	public int capacity; 
	public T[] array; 
	
	public Dynarray(){
		this.size = 0; 
		this.capacity = 40;
		this.array = new T[this.capacity];  
	} 
	public void resize(){
		this.capacity = 2 * this.capacity; 
		T[] new_array = new T[this.capacity]; 
		for(int i = 0; i < this.size; i++){ 
			new_array[i] = this.array[i]; 
		}  
		this.array = new_array; 
	} 

	public void append(T value){
		if(this.size == this.capacity){ 
			this.resize(); 
		} 
		this.array[this.size] = value; 
		this.size++;  	
	}  
	
	public T get(int index){ 
		return this.array[index]; 
	}

	public bool contains(T value){ 
		for(int i = 0; i < this.size; i++){ 
			if(this.array[i].Equals(value)){ 
				return true; 
			} 
		} 
		return false; 
	}
	public void print_contents(){
		for(int i = 0; i < this.size; i++){ 
			Console.WriteLine(this.array[i].ToString()); 
		} 
	}  

	public override String ToString(){ 
		String arr = ""; 
		for(int i = 0; i < this.size; i++){ 
			arr += this.array[i].ToString() + " "; 
		} 
		return arr;
	}  
	  
}}  
