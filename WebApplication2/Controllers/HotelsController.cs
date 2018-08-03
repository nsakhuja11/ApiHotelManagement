using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;
namespace WebApplication1.Controllers
{
    public class HotelsController : ApiController
    {
        static int _idindex = 4;

        static List<Hotel> _hotelList = new List<Hotel>()
        {
            new Hotel(){Id=1,Name="Centrum",Address="Roorkee",RoomsAvailalbe=15,PINCode=247667},
            new Hotel(){Id=2,Name="Royal Palace",Address="Roorkee",RoomsAvailalbe=6,PINCode=247667},
            new Hotel(){Id=3,Name="Sagar Ratna",Address="Roorkee",RoomsAvailalbe=16,PINCode=247667}
        };
        [HttpGet]
        public Response GetAllHotels()
        {
            try
            {
                if (_hotelList == null)
                {
                    throw new Exception("Nothing to Display");
                }
                else
                {
                    return new Response()
                    {
                        Hotels = _hotelList,
                        Status = Status.Success,
                        StatusCode = 200,
                        StatusMessage = "Displayed Successfully"
                    };
                }
            }
            catch(Exception e)
            {
                return new Response()
                {
                    Hotels = null,
                    Status = Status.Failure,
                    StatusCode = 500,
                    StatusMessage = e.Message
                };
            }
        }

        [HttpGet]
        public Response GetHotelById(int id)
        {
            try
            {
                var requiredHotel = _hotelList.Find(x => x.Id == id);
                if (requiredHotel == null)
                {
                    throw new Exception("No Hotel Found");
                }
                else
                {
                    return new Response()
                    {
                        Hotels = new List<Hotel>(){
                        _hotelList.Find(x=> x.Id==id)
                    },
                        Status = Status.Success,
                        StatusCode = 200,
                        StatusMessage = "Displayed Successfully"
                    };
                }
            }
            catch (Exception e)
            {
                return new Response()
                {
                    Hotels = null,
                    Status = Status.Failure,
                    StatusCode = 404,
                    StatusMessage = e.Message
                };
            }
        }

        [HttpPut]
        public Response BookHotelRoom(int id,[FromBody] int bookingsRequired)
        {
            try
            {
                var requiredHotel = _hotelList.Find(x => x.Id == id);
                if (requiredHotel == null)
                {
                    throw new Exception("Hotel Not Found");
                }
                else if (requiredHotel != null && requiredHotel.RoomsAvailalbe > bookingsRequired)
                {
                    requiredHotel.RoomsAvailalbe = requiredHotel.RoomsAvailalbe - bookingsRequired;
                    return new Response
                    {
                        Status = Status.Success,
                        StatusCode = 200,
                        StatusMessage = "Room Booked Successfully"
                    };

                }
                else
                {
                    throw new Exception("Not Enough Rooms Available");
                }
            }
            catch(Exception e)
            {
                return new Response()
                {
                    Status=Status.Failure,
                    StatusCode=404,
                    StatusMessage=e.Message
                };
            }
        }

        [HttpPost]
        public Response AddNewHotel(Hotel newHotel)
        {
            try
            {
                if (newHotel == null)
                {
                    throw new Exception("No Hotel Found To Be Added");
                }
                else
                {
                    newHotel.Id = _idindex;
                    _idindex++;
                    _hotelList.Add(newHotel);
                    return new Response()
                    {
                        Status = Status.Success,
                        StatusCode = 200,
                        StatusMessage = "Hotel Added Successfully"
                    };
                }
            }
            catch(Exception e)
            {
                return new Response()
                {
                    Hotels = null,
                    Status=Status.Failure,
                    StatusCode=404,
                    StatusMessage=e.Message
                };
            }
        }

        [HttpDelete]
        public Response RemoveHotelById(int id)
        {
            try
            {
                var deletehotel = _hotelList.Find(x => x.Id == id);
                if (deletehotel == null)
                {
                    throw new Exception("No Hotel Found to Be Deleted");
                }
                else
                {
                    _hotelList.Remove(deletehotel);
                    return new Response()
                    {
                        Status = Status.Success,
                        StatusCode = 200,
                        StatusMessage = "Hotel Deleted Successfully"
                    };
                }
            }
            catch(Exception e)
            {
                return new Response()
                {
                    Hotels = null,
                    Status = Status.Failure,
                    StatusCode = 404,
                    StatusMessage = e.Message
                };
            }
        }
    }
}
