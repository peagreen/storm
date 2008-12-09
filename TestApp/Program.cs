﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Storm;
using TestApp.Classes;

namespace TestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Work\\Storm\\Testing\\StormTest.mdb");
				Storm.DataBinders.OleDbDataBinder binder = new Storm.DataBinders.OleDbDataBinder(conn);
				StormMapper.RegisterDataBinder("oledbBinder", binder);
				Bicycle bicycle = new Bicycle();
				bicycle.Name = "The Diablo";
				StormMapper.Load(bicycle);
				Console.WriteLine("----------");
				Console.WriteLine("Bicycle");
				Console.WriteLine("----------");
				Console.WriteLine("Name:  " + bicycle.Name);
				Console.WriteLine("Frame: " + bicycle.Frame);
				Console.WriteLine("Fork:  " + bicycle.Fork);
				Console.WriteLine("----------");
				StormMapper.Cleanup();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}
		}
	}
}
