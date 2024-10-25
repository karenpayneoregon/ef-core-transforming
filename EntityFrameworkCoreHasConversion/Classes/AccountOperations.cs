﻿
using System;
using System.Linq;
using HasConversion.Data;
using HasConversion.Models;
using Newtonsoft.Json;
using Spectre.Console;

namespace HasConversion.Classes;

public class AccountOperations
{
    /// <summary>
    /// Mock-up an <see cref="Account"/>
    /// </summary>
    public static Account IncomingAccount()
    {
        Account account = new()
        {
            UserName = "jackwilliams",
            Active = true,
            CreatedDate = new DateTime(1999, 7, 22),
            Email = "will@comcast.com",
            Roles = new[]
            {
                "User", "Admin"
            }
        };

        return JsonConvert.DeserializeObject<Account>(JsonConvert.SerializeObject(account, Formatting.Indented))!;

    }
    public static void ViewAccounts()
    {
        using var context = new AccountContext();
        var accountList = context.Account.ToList();

        var table = CreateViewTable();

        foreach (var account in accountList)
        {

            if (account.Id.IsEven())
            {
                table.AddRow($"[bold yellow on green]{account.Id}[/]", $"[bold yellow on green]{account.UserName}[/]");
            }
            else
            {
                table.AddRow($"{account.Id}", account.UserName);
            }

            foreach (var role in account.Roles)
            {
                table.AddRow("", role.PadLeft(10));
            }

            table.AddEmptyRow();

        }

        AnsiConsole.Write(table);

        var admins = accountList.Where(account => account.Roles.Contains("Admin")).ToList();


    }
    private static void NewAccountRecord()
    {
        using var context = new AccountContext();

        var account = IncomingAccount();
        context.Add(account);
        context.SaveChanges();
        Console.WriteLine($"Id for new account {account.Id}");
    }

    private static Table CreateViewTable()
    {
        return new Table()
            .Border(TableBorder.Square)
            .BorderColor(Color.Grey100)
            .Title("[yellow][B]Accounts[/][/]")
            .AddColumn(new TableColumn("[u]Id[/]"))
            .AddColumn(new TableColumn("[u]Name and roles[/]"));
    }

}