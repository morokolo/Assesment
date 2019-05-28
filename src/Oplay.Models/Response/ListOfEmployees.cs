using System;
using Newtonsoft.Json;

namespace Oplay.Models.Response
{
    public class ListOfEmployees
    {
        public int personId { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public DateTime birthDate { get; set; }

        //public string DOB { get; set; }

        //public DateTime _date;
        //public DateTime birthDate
        //{
        //    get
        //    {
        //        return this._date;
        //    }
        //    set
        //    {
        //        this._date = value;

        //        this.DOB = _date.DayOfWeek + ", " + _date.Day + " " + _date.ToString("MMMM") + " " + _date.Year;
        //    }
        //}
    }
}
