﻿using DAL.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ReportRepository
    {
        private RCBTimerDBContext context;

        public ReportRepository()
        {
            context = new RCBTimerDBContext();
        }

        public IList<WorkdaysReportDTO> GetWorkdaysByDate(DateTime beginTime,  DateTime endTime, int employeeId)
        {
            if (employeeId > 0)
                return context.Workday.Where(w => w.BeginningTime >= beginTime &&
                                              w.BeginningTime <= endTime && w.EmployeeId == employeeId)
                                  .Select(w => new WorkdaysReportDTO
                                  {
                                      Id = w.Id,
                                      EmployeeInfo = w.Employee.FirstName + " " + w.Employee.LastName,
                                      BeginningTime = w.BeginningTime,
                                      BreakBeginningTime = w.BreakBeginningTime,
                                      BreakEndTime = w.BreakEndTime,
                                      EndTime = w.EndTime,
                                      Comments = w.Comments,
                                      EmployeeComments = w.CommentsfromEmployee
                                  }).ToList();
            else
                return context.Workday.Where(w => w.BeginningTime >= beginTime &&
                                              w.BeginningTime <= endTime)
                                  .Select(w => new WorkdaysReportDTO
                                  {
                                      Id = w.Id,
                                      EmployeeInfo = w.Employee.FirstName + " " + w.Employee.LastName,
                                      BeginningTime = w.BeginningTime,
                                      BreakBeginningTime = w.BreakBeginningTime,
                                      BreakEndTime = w.BreakEndTime,
                                      EndTime = w.EndTime,
                                      Comments = w.Comments
                                  }).ToList();
        }
    }
}
