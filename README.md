## Library Powered By

This library is powered by [Dapper Plus](https://dapper-plus.net/)

<a href="https://dapper-plus.net/">
<kbd>
<img src="https://zzzprojects.github.io/images/logo/dapper-plus-add.png" alt="Dapper Plus" />
</kbd>
</a>

---

## What's Dapper Transaction?
Dapper Transaction is exactly like Dapper but extend the IDbTransaction interface instead and use Dapper under the hood.

It's a simple library to make it easier to work with a transaction.

Everything Dapper support, Dapper Transaction support it as well.

```csharp
using (var connection = new SqlConnection(FiddleHelper.GetConnectionStringSqlServerW3Schools()))
{
	connection.Open();
	
	using (var transaction = connection.BeginTransaction())
	{
		// Dapper
		var affectedRows1 = connection.Execute(sql, new {CustomerName = "Mark"}, transaction: transaction);
		
		// Dapper Transaction
		var affectedRows2 = transaction.Execute(sql, new {CustomerName = "Mark"});

		transaction.Commit();
	}
}
```

## Method Supported

- Execute
- ExecuteAsync
- ExecuteReader
- ExecuteReaderAsync
- ExecuteScalar
- ExecuteScalarAsync
- Query
- QueryAsync
- QueryFirst
- QueryFirstAsync
- QueryFirstOrDefault
- QueryFirstOrDefaultAsync
- QuerySingle
- QuerySingleAsync
- QuerySingleOrDefault
- QuerySingleOrDefaultAsync
- QueryMultiple
- QueryMultipleAsync

## Useful links

- [Website](https://dappertutorial.net/transaction)
- [Nugget Dapper Transaction](https://www.nuget.org/packages/Dapper.Transaction/)
- [Nugget Dapper Transaction StrongName](https://www.nuget.org/packages/Dapper.Transaction.StrongName/)

## Contribute

The best way to contribute is by **spreading the word** about the library:

 - Blog it
 - Comment it
 - Star it
 - Share it
 
A **HUGE THANKS** for your help.

## More Projects

- Projects:
   - [EntityFramework Extensions](https://entityframework-extensions.net/)
   - [Dapper Plus](https://dapper-plus.net/)
   - [C# Eval Expression](https://eval-expression.net/)
- Learn Websites
   - [Learn EF Core](https://www.learnentityframeworkcore.com/)
   - [Learn Dapper](https://www.learndapper.com/)
- Online Tools:
   - [.NET Fiddle](https://dotnetfiddle.net/)
   - [SQL Fiddle](https://sqlfiddle.com/)
   - [ZZZ Code AI](https://zzzcode.ai/)
- and much more!

To view all our free and paid projects, visit our website [ZZZ Projects](https://zzzprojects.com/).
