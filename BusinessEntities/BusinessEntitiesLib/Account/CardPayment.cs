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

public class CardPayment : PaymentMethod
{
	public virtual int CardNumber
	{
		get;
		set;
	}

	public virtual int CardType
	{
		get;
		set;
	}

	public virtual int TransactionNumber
	{
		get;
		set;
	}

	public virtual Bank IssuingBank
	{
		get;
		set;
	}

}
