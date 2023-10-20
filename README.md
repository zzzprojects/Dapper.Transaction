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

Want to help us? Your donation directly helps us maintain and grow ZZZ Free Projects. 

We can't thank you enough for your support 🙏.

👍 [One-time donation](https://zzzprojects.com/contribute)

❤️ [Become a sponsor](https://github.com/sponsors/zzzprojects) 

### Why should I contribute to this free & open-source library?
We all love free and open-source libraries! But there is a catch... nothing is free in this world.

We NEED your help. Last year alone, we spent over **3000 hours** maintaining all our open source libraries.

Contributions allow us to spend more of our time on: Bug Fix, Development, Documentation, and Support.

### How much should I contribute?
Any amount is much appreciated. All our free libraries together have more than **100 million** downloads.

If everyone could contribute a tiny amount, it would help us make the .NET community a better place to code!

Another great free way to contribute is  **spreading the word** about the library.

A **HUGE THANKS** for your help!

## More Projects

- [EntityFramework Extensions](https://entityframework-extensions.net/)
- [Dapper Plus](https://dapper-plus.net/)
- [C# Eval Expression](https://eval-expression.net/)
- and much more! 

To view all our free and paid projects, visit our [website](https://zzzprojects.com/).
