using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace GeronimoHBS.Models
{
    public class TimetableViewModel
    {
        public Location CurrentLocation { get; set; }

        public List<Timetable> Monday { get; set; }
        public List<Timetable> Tuesday { get; set; }
        public List<Timetable> Wednesday { get; set; }
        public List<Timetable> Thursday { get; set; }
        public List<Timetable> Friday { get; set; }
        public List<Timetable> Saturday { get; set; }
        public List<Timetable> Sunday { get; set; }
    }

}