﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AccountTransaction
{
	public virtual DateTime TransactionDate
	{
		get;
		set;
	}

	public virtual AccountTransactionDetails ToCashPostingDetails
	{
		get;
		set;
	}

	public virtual AccountTransactionDetails FromCashPostingDetails
	{
		get;
		set;
	}

}
