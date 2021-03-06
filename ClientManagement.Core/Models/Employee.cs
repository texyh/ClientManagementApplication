﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Exceptions;

namespace ClientManagement.Core.Models
{
    public class Employee
    {
        public Employee()
        {
            Projects = new List<Project>();
        }
        public Guid Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public Gender Gender { get; set; }
        public Guid ProjectId { get; set; }
        public string ApplicationUserId { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public void AssignProject(Project project)
        {
            var cantAssignProject = CantAssignProject(project);
            if (cantAssignProject)
               throw new ProjectExistException();

            Projects.Add(project);
        }

        public int NumberOfProjects()
        {
            return Projects.Count;
        }

        public bool CantAssignProject(Project project)
        {
            return Projects.Contains(project);    
        }

        public void RemoveProject(Project projectEntity)
        {
            var project = Projects.Contains(projectEntity);
            if (project)
            {
                Projects.Remove(projectEntity);
            }
            else
            {
                throw new InvalidOperationException("Project not found");
            }
        }

        public ICollection<Project> GetProjects()
        {
            return Projects;
        }
    }
}
