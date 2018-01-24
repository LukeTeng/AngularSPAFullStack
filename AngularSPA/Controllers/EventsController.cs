using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AngularSPA.Entities;
using AngularSPA.Modules;
using AngularSPA.Services;

namespace AngularSPA.Controllers
{

    public class EventsController : ApiBaseController
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
            : base()
        {
            _eventService = eventService;
        }

        [HttpPost]
        public ApiResponse<EventData> Get([FromBody]EventEnqueryRqeuest request)
        {
            var result = _eventService.GetEventDataById(request.EventId);
            return new ApiResponse<EventData>(result);

        }

        [HttpPost]
        public ApiResponse<Invitation> SendInvitation([FromBody]SendInvitationRqeuest request)
        {
            var result = _eventService.SendInvitation(request.EventId, request.invitationId);
            if (result.result == true)
            {
                return new ApiResponse<Invitation>(result.invite);
            }
            else
            {
                //exception needs to be managed more accurately here ?????????????
                return new ApiResponse<Invitation>(new ErrorMsg { Code = Status.ServerError, Message = "Internal problem." });
            }
        }

    }
}