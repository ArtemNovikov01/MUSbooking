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
            return Ok(_equipmentHandler.Get(request));
        }

        [HttpGet]
        public ActionResult<GetEquipmentResponse> Get(int id)
        {
            return Ok(_equipmentHandler.Get(id));
        }

        [HttpPost("addEquipment")]
        public ActionResult Insert(AddEquipmentRequest request)
        {
            _equipmentHandler.Insert(request);
            return Ok();
        }

        [HttpPut]
        public ActionResult<GetEquipmentResponse> Update(UpdateEquipmentRequest request)
        {
            return Ok(_equipmentHandler.Update(request));
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _equipmentHandler.Delete(id);
            return Ok();
        }
    }
}
