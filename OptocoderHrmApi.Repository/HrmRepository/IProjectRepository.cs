﻿using Microsoft.EntityFrameworkCore;
using OptocoderHrmApi.Data.DbContexts;
using OptocoderHrmApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace OptocoderHrmApi.Repository.HrmRepository
{
    public interface IProjectRepository
    {
        Task<ICollection<Project>> GetProjectList();
        Task<Project> GetProject(int id);
        Task<Project> CreateNewProject(Project project);

        Task<string> DeleteProject(int id);
        Task<string> UpdateProject(int id, Project project);
    }

    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;

        public ProjectRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Project> CreateNewProject(Project project)
        {
            try
            {
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
                return project;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteProject(int id)
        {
            try
            {
                var response = await _context.Projects.FindAsync(id);
                _context.Projects.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Project> GetProject(int id)
        {
            try
            {
                var res = await _context.Projects.FirstOrDefaultAsync(m => m.ProjectId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Project>> GetProjectList()
        {
            try
            {
                var response = from c in _context.Projects
                               orderby c.ProjectId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateProject(int id, Project project)
        {
            try
            {
                var res = await _context.Projects.FirstOrDefaultAsync(m => m.ProjectId == id);
                res.ProjectName = project.ProjectName;
                res.Client = project.Client;
                res.Details = project.Details;
                res.Status = project.Status;
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
