using DomainLayer.Dtos;
using System.Collections.Generic;

namespace Elite_Hotel.Controllers
{
    public class ViewModel
    {
        public List<CategoryDto> Categories { get; set; }
        public List<ServicecatDto> Servicecats { get; set; }
        public List<HotelDto> hotels { get; set; }
    }
}