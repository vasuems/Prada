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

public class Address : BaseEntity
{
	public virtual Country Country
	{
		get;
		set;
	}

	public virtual State State
	{
		get;
		set;
	}

	public virtual City City
	{
		get;
		set;
	}

}
