using Microsoft.AspNetCore.Mvc;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.AddEquipmentRespons;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.GetEquipmentsListRequest;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.UpdateEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse;
using MUSbooking.Exceptions.Common.Exceptions;
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
            catch (BadRequestException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка получения списка оборудования");
            }
        }

        [HttpGet]
        public ActionResult<GetEquipmentResponse> Get(int id)
        {
            try 
            { 
                return Ok(_equipmentHandler.Get(id));
            }
            catch (BadRequestException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при получении информации об оборудования");
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
            catch (BadRequestException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при добавлении оборудования");
            }
        }

        [HttpPut]
        public ActionResult<GetEquipmentResponse> Update(UpdateEquipmentRequest request)
        {
            try
            {
                return Ok(_equipmentHandler.Update(request));
            }
            catch (BadRequestException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при обновлении оборудования");
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
            catch (BadRequestException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при удалении оборудования");
            }
        }
    }
}
