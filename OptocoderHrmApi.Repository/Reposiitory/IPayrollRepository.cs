using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OptocoderHrmApi.Repository.Reposiitory
{
    public interface IPayrollRepository
    {
        Task<List<Payroll>> GetPayrollList();
        Task<Payroll> GetPayroll(int id);
        Task<Payroll> CreateNewPayroll(Payroll payroll);
        Task<string> DeletePayroll(int id);
        Task<string> UpdatePayroll(int id, Payroll payroll);
    }

    public class PayrollRepository : IPayrollRepository
    {
        private readonly DataContext _context;

        public PayrollRepository(DataContext context)
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
                var res = await _context.Payrolls.FindAsync(id);
                _context.Payrolls.Remove(res);
                await _context.SaveChangesAsync();
                return "Deleted Successfully";
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
                var res = await _context.Payrolls.FirstOrDefaultAsync(x => x.PayrollId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Payroll>> GetPayrollList()
        {
            try
            {
                var res = from c in _context.Payrolls
                          orderby c.PayrollId descending
                          select c;
                return await res.ToListAsync();
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
                var response = await _context.Payrolls.FirstOrDefaultAsync(m => m.PayrollId == id);
                response.EmployeeId = payroll.EmployeeId;
                response.Month = payroll.Month;
                response.Year = payroll.Year;
                response.TotalPresent = payroll.TotalPresent;
                response.TotalAbsent = payroll.TotalAbsent;
                response.LeaveDays = payroll.LeaveDays;
                response.Deduction = payroll.Deduction;
                response.LeaveStatus = payroll.LeaveStatus;
                response.FestivalAdvance = payroll.FestivalAdvance;
                response.HousingLoan = payroll.HousingLoan;
                response.VehicleLoan = payroll.VehicleLoan;
                response.OtherLoan = payroll.OtherLoan;
                response.LossOfPay = payroll.LossOfPay;
                response.Tds = payroll.Tds;
                response.ProfessionalFees = payroll.ProfessionalFees;
                response.OtherDeductions = payroll.OtherDeductions;
                response.TotalEarnings = payroll.TotalEarnings;
                response.OtherPay = payroll.OtherPay;
                response.BasicSalary = payroll.BasicSalary;
                response.SalaryPerDay = payroll.SalaryPerDay;
                response.Pay = payroll.Pay;
                response.Earnings = payroll.Earnings;
                response.Deductions = payroll.Deductions;
                response.NetPay = payroll.NetPay;
                response.CompanyId = payroll.CompanyId;
                response.UserId = payroll.UserId;
                _context.Payrolls.Update(response);
                await _context.SaveChangesAsync();
                return "Updated SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
