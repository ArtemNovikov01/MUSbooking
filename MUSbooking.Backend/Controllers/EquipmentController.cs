using Microsoft.AspNetCore.Mvc;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.AddEquipmentRespons;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.GetEquipmentsListRequest;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.UpdateEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse;
using MUSbooking.Validation.Abstract;

namespace MUSbooking.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentValidator _equipmentHandler;
        public EquipmentController(IEquipmentValidator equipmentHandler)
        {
            _equipmentHandler = equipmentHandler;
        }

        [HttpPost("getEquipmentsList")]
        public ActionResult<GetEquipmentsListResponse> Get(GetEquipmentsListRequest request)
        {
            try
            {
                return Ok(_equipmentHandler.Get(request));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        public ActionResult<GetEquipmentResponse> Get(int id)
        {
            try 
            { 
                return Ok(_equipmentHandler.Get(id));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("addEquipment")]
        public ActionResult Insert(AddEquipmentRequest request)
        {
            try
            {
                _equipmentHandler.Insert(request);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public ActionResult<GetEquipmentResponse> Update(UpdateEquipmentRequest request)
        {
            try
            {
                return Ok(_equipmentHandler.Update(request));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                _equipmentHandler.Delete(id);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
