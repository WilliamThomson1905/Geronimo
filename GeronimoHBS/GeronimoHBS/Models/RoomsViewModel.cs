using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace GeronimoHBS.Models
{
    public class RoomsViewModel
    {
        public Location CurrentLocation { get; set; }
        public int Guests { get; set; }
        public int RoomsCount { get; set; }
        public List<RoomType> RoomTypes { get; set; }

    }

}