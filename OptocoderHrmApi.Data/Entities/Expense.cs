using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class Expense
    {
        public Expense()
        {
            EmployeeExpenses = new HashSet<EmployeeExpense>();
        }

        public int ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<EmployeeExpense> EmployeeExpenses { get; set; }
    }
}
