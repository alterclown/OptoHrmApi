using System;
using System.Collections.Generic;

#nullable disable

namespace OptocoderHrmApi.Data.Entities
{
    public partial class EmployeeExpense
    {
        public int EmployeeExpenseId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime Date { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionNo { get; set; }
        public string Payee { get; set; }
        public string Category { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public byte[] Attachment { get; set; }
        public int EmployeeId { get; set; }
        public int ExpenseId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int PaymentMethodId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Expense Expense { get; set; }
        public virtual PaymentMethod PaymentMethodNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
