﻿namespace Vistor
{
    /// <summary>
    /// ConcreteElement
    /// </summary>
    public class Customer : IElement
    {
        public decimal AmountOrdered { get; private set; }
        public decimal Discount { get; set; }
        public string Name { get; private set; }

        public Customer(string name, decimal amountOrdered)
        {
            Name = name;
            AmountOrdered = amountOrdered;
        }

        public void Accept(IVisitor visitor)
        {
            // visitor.VisitCustomer(this);
            visitor.Visit(this);
            Console.WriteLine($"Visited {nameof(Customer)} {Name}, " +
                $"discount given: {Discount}");
        }
    }

    /// <summary>
    /// ConcreteElement
    /// </summary>
    public class Employee : IElement
    {
        public int YearsEmployed { get; private set; }
        public decimal Discount { get; set; }
        public string Name { get; private set; }

        public Employee(string name, int yearsEmployed)
        {
            Name = name;
            YearsEmployed = yearsEmployed;
        }

        public void Accept(IVisitor visitor)
        {
            // visitor.VisitEmployee(this);
            visitor.Visit(this);
            Console.WriteLine($"Visited {nameof(Employee)} " +
                $"{Name}, discount given: {Discount}");
        }
    }

    ///// <summary>
    ///// Visitor
    ///// </summary>
    //public interface IVisitor
    //{
    //    void VisitCustomer(Customer customer);
    //    void VisitEmployee(Employee employee);
    //}

    /// <summary>
    /// Visitor (alternative)
    /// </summary>
    public interface IVisitor
    {
        void Visit(IElement element);
    }


    /// <summary>
    /// Element
    /// </summary>
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    /// <summary>
    /// ConcreteVisitor
    /// </summary>
    public class DiscountVisitor : IVisitor
    {
        public decimal TotalDiscountGiven { get; set; }

        public void Visit(IElement element)
        {
            if (element is Customer)
            {
                VisitCustomer((Customer)element);
            }
            else if (element is Employee)
            {
                VisitEmployee((Employee)element);
            }
        }

        private void VisitCustomer(Customer customer)
        {
            // percentage of total amount
            var discount = customer.AmountOrdered / 10;
            // set it on the customer
            customer.Discount = discount;
            // add it to the total amount
            TotalDiscountGiven += discount;
        }

        private void VisitEmployee(Employee employee)
        {
            // fixed value depending on the amount of years employed
            var discount = employee.YearsEmployed < 10 ? 100 : 200;
            // set it on the employee
            employee.Discount = discount;
            // add it to the total amount
            TotalDiscountGiven += discount;
        }
    }

    /// <summary>
    /// ObjectStructure
    /// </summary>
    public class Container
    {
        public List<Employee> Employees { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();

        public void Accept(IVisitor visitor)
        {
            foreach (var employee in Employees)
            {
                employee.Accept(visitor);
            }
            foreach (var customer in Customers)
            {
                customer.Accept(visitor);
            }
        }
    }



//    Console.Title = "Visitor";

//// create container & add concrete elements
//    var container = new Container();

//    container.Customers.Add(new Customer("Sophie", 500));
//    container.Customers.Add(new Customer("Karen", 1000));
//    container.Customers.Add(new Customer("Sven", 800));
//    container.Employees.Add(new Employee("Kevin", 18));
//    container.Employees.Add(new Employee("Tom", 5));

//// create visitor
//    DiscountVisitor discountVisitor = new();

//    // pass it through
//    container.Accept(discountVisitor);

//// write out gathered amount
//    Console.WriteLine($"Total discount: {discountVisitor.TotalDiscountGiven}");

//    Console.ReadKey();
}