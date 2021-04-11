using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using OptocoderHrmApi.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IEmployeePayrollRepository
    {
        Task<ICollection<Payroll>> GetPayrollList();
        Task<Payroll> GetPayroll(int id);
        Task<Payroll> CreateNewPayroll(Payroll payroll);

        Task<string> DeletePayroll(int id);
        Task<string> UpdatePayroll(int id, Payroll payroll);
    }

    public class EmployeePayrollRepository : IEmployeePayrollRepository
    {
        private readonly DataContext _context;

        public EmployeePayrollRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Payroll> CreateNewPayroll(Payroll payroll)
        {
            try
            {
                _context.Payrolls.Add(payroll);
                await _context.SaveChangesAsync();
                return payroll;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeletePayroll(int id)
        {
            try
            {
                var response = await _context.Payrolls.FindAsync(id);
                _context.Payrolls.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Payroll> GetPayroll(int id)
        {
            try
            {
                var res = await _context.Payrolls.FirstOrDefaultAsync(m => m.PayrollId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Payroll>> GetPayrollList()
        {
            try
            {
                var response = from c in _context.Payrolls
                               orderby c.PayrollId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdatePayroll(int id, Payroll payroll)
        {
            try
            {
                var res = await _context.Payrolls.FirstOrDefaultAsync(m => m.PayrollId == id);
                res.Month = payroll.Month;
                res.Year = payroll.Year;
                res.TotalPresent = payroll.TotalPresent;
                res.TotalAbsent = payroll.TotalAbsent;
                res.LeaveDays = payroll.LeaveDays;
                res.Deduction = payroll.Deduction;
                res.LeaveStatus = payroll.LeaveStatus;
                res.FestivalAdvance = payroll.FestivalAdvance;
                res.HousingLoan = payroll.HousingLoan;
                res.VehicleLoan = payroll.VehicleLoan;
                res.OtherLoan = payroll.OtherLoan;
                res.LossOfPay = payroll.LossOfPay;
                res.Tds = payroll.Tds;
                res.ProfessionalFees = payroll.ProfessionalFees;
                res.OtherDeductions = payroll.OtherDeductions;
                res.TotalEarnings = payroll.TotalEarnings;
                res.OtherPay = payroll.OtherPay;
                res.BasicSalary = payroll.BasicSalary;
                res.SalaryPerDay = payroll.SalaryPerDay;
                res.Pay = payroll.Pay;
                res.Earnings = payroll.Earnings;
                res.Deductions = payroll.Deductions;
                res.NetPay = payroll.NetPay;
                _context.Update(res);
                await _context.SaveChangesAsync();
                return "Updated Record";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
