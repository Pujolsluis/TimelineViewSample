using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TimelineViewSample.Models;

namespace TimelineViewSample.Services
{
    public class DataService
    {
        public ObservableCollection<TimelineItem> _usersDataSource { get; set; } = new ObservableCollection<TimelineItem>()
        {
            new TimelineItem()
            {
                UserName = "Luis Pujols",
                Date = DateTime.Now.AddDays(-10),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
            },
            new TimelineItem()
            {
                UserName = "Charlin Agramonte",
                Date = DateTime.Now.AddDays(-9),
                Description = "Incididunt ut labore et dolore magna aliqua."
            },
            new TimelineItem()
            {
                UserName = "Luis Pujols",
                Date = DateTime.Now.AddDays(-9),
                Description = "Sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
            },
            new TimelineItem()
            {
                UserName = "Rendy Del Rosario",
                Date = DateTime.Now.AddDays(-7),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing, incididunt ut labore et dolore magna aliqua."
            },
            new TimelineItem()
            {
                UserName = "Luis Pujols",
                Date = DateTime.Now.AddDays(-6),
                Description = "Ipsum dolor sit amet, incididunt ut labore et dolore magna aliqua."
            },
            new TimelineItem()
            {
                UserName = "Pedro Guzman",
                Date = DateTime.Now.AddDays(-6),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
            },
            new TimelineItem()
            {
                UserName = "Leo Reyes",
                Date = DateTime.Now.AddDays(-5),
                Description = "Lorem ipsum dolor sit amet, consectetur incididunt ut labore et dolore magna aliqua."
            },
            new TimelineItem()
            {
                UserName = "Leyla Smith",
                Date = DateTime.Now,
                Description = "Dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
            },
            new TimelineItem()
            {
                UserName = "Aston Martin",
                Date = DateTime.Now,
                Description = "Adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
            }
        };

        public DataService()
        {
        }

        public async Task<IList<TimelineItem>> GetUsersAsync(int pageIndex, int pageSize)
        {
            await Task.Delay(2500);

            return _usersDataSource.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
    }
}
