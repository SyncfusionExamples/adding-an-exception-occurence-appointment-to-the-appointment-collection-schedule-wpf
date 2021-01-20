using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace WpfScheduler
{
    public class SchedulerViewModel
    {
        public ScheduleAppointmentCollection scheduleAppointmentCollection { get; set; } = new ScheduleAppointmentCollection();
        public SchedulerViewModel()
        {
            var scheduleAppointment = new ScheduleAppointment
            {
                Id = 1,
                Subject = "Daily scrum meeting",
                StartTime = new DateTime(2020, 12, 13, 11, 0, 0),
                EndTime = new DateTime(2020, 12, 13, 12, 0, 0),
                AppointmentBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00BFFF")),
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=10"
            };
            scheduleAppointmentCollection.Add(scheduleAppointment);

            DateTime changedExceptionDate = scheduleAppointment.StartTime.AddDays(3).Date;
            scheduleAppointment.RecurrenceExceptionDates = new ObservableCollection<DateTime>()
            {
               changedExceptionDate,
            };

            var exceptionAppointment = new ScheduleAppointment()
            {
                Id = 2,
                Subject = "Scrum meeting - Changed Occurrence",
                StartTime = new DateTime(changedExceptionDate.Year, changedExceptionDate.Month, changedExceptionDate.Day, 13, 0, 0),
                EndTime = new DateTime(changedExceptionDate.Year, changedExceptionDate.Month, changedExceptionDate.Day, 14, 0, 0),
                AppointmentBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF1493")),
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                RecurrenceId = 1
            };
            scheduleAppointmentCollection.Add(exceptionAppointment);
        }
    }
}
