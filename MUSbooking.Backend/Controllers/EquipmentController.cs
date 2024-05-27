using Microsoft.AspNetCore.Mvc;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.AddEquipmentRespons;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.GetEquipmentsListRequest;
using MUSbooking.Domain.Models.Requests.EquipmentRequests.UpdateEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentResponse;
using MUSbooking.Domain.Models.Responses.EquipmentResponses.GetEquipmentsListResponse;
using MUSbooking.Exceptions.Common.Exceptions;
using MUSbooking.Handlers.Abstract;

namespace MUSbooking.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentHandler _equipmentHandler;
        public EquipmentController(IEquipmentHandler equipmentHandler)
        {
            _equipmentHandler = equipmentHandler;
        }

        [HttpPost("getEquipmentsList")]
        public async Task<ActionResult<GetEquipmentsListResponse>> Get(GetEquipmentsListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _equipmentHandler.Get(request, cancellationToken));
            }
            catch (BadRequestException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (EntityNotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка получения списка оборудования");
            }
        }

        [HttpGet]
        public async Task<ActionResult<GetEquipmentResponse>> Get(int id, CancellationToken cancellationToken)
        {
            try 
            { 
                return Ok(await _equipmentHandler.Get(id, cancellationToken));
            }
            catch (BadRequestException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (EntityNotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при получении информации об оборудования");
            }
        }

        [HttpPost("addEquipment")]
        public async Task<ActionResult> Insert(AddEquipmentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _equipmentHandler.Insert(request, cancellationToken);
                return Ok();
            }
            catch (BadRequestException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (EntityNotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при добавлении оборудования");
            }
        }

        [HttpPut]
        public async Task<ActionResult<GetEquipmentResponse>> Update(UpdateEquipmentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _equipmentHandler.Update(request, cancellationToken));
            }
            catch (BadRequestException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (EntityNotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при обновлении оборудования");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _equipmentHandler.Delete(id, cancellationToken);
                return Ok();
            }
            catch (BadRequestException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (EntityNotFoundException exception)
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
