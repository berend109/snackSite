using System.Data;
using Dapper;
using snackSite.Models;

namespace snackSite.Repositories;

public class BudgetRepository
{
	private static IDbConnection GetConnection()
	{
		return new DbUtils().GetDbConnection();
	}
	
	public static int UpdateBudget(decimal budget)
	{
		using var connection = GetConnection();
		
		const string sql = @"UPDATE Gebruiker SET Budget = @Budget";
		
		var parameters = new { Budget = budget };
		
		int updatedBudget = connection.Execute(sql, parameters);
		return updatedBudget;
	}
}
