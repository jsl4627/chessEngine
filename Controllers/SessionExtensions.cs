
using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Http;
using System;  
using System.Text.Encodings.Web;
using System.IO; 
using System.Collections; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.Runtime.Serialization; 
using System.Web; 
using System.Text.Json; 
public static class SessionExtensions{ 
	public static void Set<T>(this ISession session, string key, T value){ 
		session.SetString(key, JsonSerializer.Serialize(value)); 
	} 
	public static T Get<T>(this ISession session, string key){ 
		var value = session.GetString(key); 
		return value == null ? default : JsonSerializer.Deserialize<T>(value); 
	}
}
