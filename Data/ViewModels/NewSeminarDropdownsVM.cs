using DIKESE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIKESE.Data.ViewModels
{
    public class NewSeminarDropdownsVM
    {
        public NewSeminarDropdownsVM()
        {
            Sponsors = new List<Sponsor>();
            Rooms = new List<Room>();
            Speakers = new List<Speaker>();
        }

        public List<Sponsor> Sponsors { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Speaker> Speakers { get; set; }
    }
}