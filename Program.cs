﻿// See https://aka.ms/new-console-template for more information
using Microsoft.Data.Sqlite;
// using System;


// Console.WriteLine("Hello, World!");
// Console.Read();

// static string connectionString = @"Data Source=habit-Tracker.db";


string connectionString = @"Data Source=habit-Tracker.db";

using(var connection = new SqliteConnection(connectionString)){
    connection.Open();
    var tableCmd = connection.CreateCommand();
    tableCmd.CommandText = 
        @"CREATE TABLE IF NOT EXISTS drinking_water (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Date TEXT,
            Quantity INTEGER
            )";

    tableCmd.ExecuteNonQuery();

    connection.Close();
}

void GetUserInput()
{
    Console.Clear();
    bool closeApp = false;
    while(closeApp == false)
    {
        Console.WriteLine("\n\n MAIN MENU");
        Console.WriteLine("\nWhat would you like to do? ");
        Console.WriteLine("\nType 0 to Close Application. ");
        Console.WriteLine("Type 1 to View All Records. ");
        Console.WriteLine("Type 2 to Insert Record. ");
        Console.WriteLine("Type 3 to Delete Record");
        Console.WriteLine("Type 4 to Update Record");
        Console.WriteLine("----------------------------------------\n");
        
        
        string command = Console.ReadLine();

        switch (command)
        {
            case "0":
                Console.WriteLine("\nGoodBye\n");
                closeApp = true;
                break;
            // case 1:
            //     GetAllRecords();
            //     break;
            case "2":
                Insert();
                break;
            // case 3:
            //     Delete();
            //     break;
            // case 4:
            //     Update();
            //     break;
            // default:
            //     Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4. \n");
            //     break;
        }
    }
}

void Insert()
{
    string date = GetDateInput();
    int quantity = GetNumberInput("\n\nPlease insert number of glasses or other measur of your choice (no decimals allowed)\n\n");

    using(var connection = new SqliteConnection(connectionString))
    {
    connection.Open();
    var tableCmd = connection.CreateCommand();
    tableCmd.CommandText = 
        $"INSERT INTO drinking_water(date, quantity) VALUES('{date}', '{quantity}'";

    tableCmd.ExecuteNonQuery();

    connection.Close();
}

}

string GetDateInput()
{
    Console.WriteLine("\n\nPlease insert the date: (Format: dd-mm-yy). Type 0 to return main menu ");

    string dateInput = Console.ReadLine();

    if (dateInput == "0") GetUserInput();
    return dateInput;
}

int GetNumberInput(string message)
{
    Console.WriteLine(message);

    string numberInput = Console.ReadLine();

    if (numberInput == "0") GetUserInput();

    int finalInput = Convert.ToInt32(numberInput);
    return finalInput;
}

