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

Read more on our [Website](https://dappertutorial.net/dapper-transaction).

## Downloads

### Dapper.Transaction

[![nuget](https://img.shields.io/nuget/v/Dapper.Transaction?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Dapper.Transaction)
[![nuget](https://img.shields.io/nuget/dt/Dapper.Transaction?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Dapper.Transaction)

```
PM> NuGet\Install-Package Dapper.Transaction
```

```
> dotnet add package Dapper.Transaction
```

### Dapper.Transaction.StrongName

[![nuget](https://img.shields.io/nuget/v/Dapper.Transaction.StrongName?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Dapper.Transaction.StrongName)
[![nuget](https://img.shields.io/nuget/dt/Dapper.Transaction.StrongName?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Dapper.Transaction.StrongName)

## Sponsors

ZZZ Projects owns and maintains **Dapper.Transaction** as part of our [mission](https://zzzprojects.com/mission) to add value to the .NET community

Through [Dapper Plus](https://dapper-plus.net/?utm_source=zzzprojects&utm_medium=dappertransaction) and [Entity Framework Extensions](https://entityframework-extensions.net/?utm_source=zzzprojects&utm_medium=dappertransaction), we actively sponsor and help key open-source libraries grow.

[![Dapper Plus](https://raw.githubusercontent.com/zzzprojects/Dapper.Transaction/master/dapper-plus-sponsor.png)](https://dapper-plus.net/bulk-insert?utm_source=zzzprojects&utm_medium=dappertransaction)

[![Entity Framework Extensions](https://raw.githubusercontent.com/zzzprojects/Dapper.Transaction/master/entity-framework-extensions-sponsor.png)](https://entityframework-extensions.net/bulk-insert?utm_source=zzzprojects&utm_medium=dappertransaction)

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
