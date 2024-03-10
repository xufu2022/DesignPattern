﻿namespace State;

public class GoldState : BankAccountState
{
    public GoldState(decimal balance, BankAccount bankAccount)
    {
        Balance = balance;
        BankAccount = bankAccount;
    }

    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, depositing " +
            $"{amount} + 10% bonus: {amount / 10}");
        Balance += amount + (amount / 10);
    }

    public override void Withdraw(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, withdrawing {amount} from {Balance}");
        // change state to overdrawn when withdrawing results in less than zero
        Balance -= amount;
        if (Balance < 1000 && Balance >= 0)
        {
            // change state to regular
            BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
        }
        else if (Balance < 0)
        {
            // change state to overdrawn
            BankAccount.BankAccountState = new OverdrawnState(Balance, BankAccount);
        }
    }
}

/// <summary>
/// ConcreteState
/// </summary>
public class RegularState : BankAccountState
{
    public RegularState(decimal balance, BankAccount bankAccount)
    {
        Balance = balance;
        BankAccount = bankAccount;
    }

    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, depositing {amount}");
        Balance += amount;
        if (Balance >= 1000)
        {
            // change state to gold
            BankAccount.BankAccountState = new GoldState(Balance, BankAccount);
        }
    }

    public override void Withdraw(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, withdrawing {amount} from {Balance}");
        // change state to overdrawn when withdrawing results in less than zero
        Balance -= amount;
        if (Balance < 0)
        {
            // change state to overdrawn
            BankAccount.BankAccountState = new OverdrawnState(Balance, BankAccount);
        }
    }
}

/// <summary>
/// ConcreteState
/// </summary>
public class OverdrawnState : BankAccountState
{
    public OverdrawnState(decimal balance, BankAccount bankAccount)
    {
        Balance = balance;
        BankAccount = bankAccount;
    }

    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, depositing {amount}");
        Balance += amount;
        if (Balance >= 0)
        {
            // change state to regular
            BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
        }
    }

    public override void Withdraw(decimal amount)
    {
        // cannot withdraw
        Console.WriteLine($"In {GetType()}, cannot withdraw, balance {Balance}");
    }
}
