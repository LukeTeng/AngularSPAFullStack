using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularSPA.Modules;

using AngularSPA.MockRepo;
using AngularSPA.Repo;

namespace AngularSPA.Services
{

    public interface IEventService
    {
        /// <summary>
        /// Get event data by eventId
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        EventData GetEventDataById(int eventId);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="invitationId"></param>
        /// <returns>
        ///   result: true: send successfully
        ///   invitaion: new invation data after sending
        /// </returns>
        (bool result, Invitation invite) SendInvitation(int eventId, int invitationId);
    }

    public class EventService : IEventService
    {
        private readonly IEventDataRepo _eventDataRepo;

        public EventService(IEventDataRepo eventRepo)
        {
            _eventDataRepo = eventRepo;
        }
        public EventData GetEventDataById(int eventId)
        {
            return _eventDataRepo.GetEventData(eventId);
        }


        public (bool result, Invitation invite) SendInvitation(int eventId, int invitationId)
        {
            return this._eventDataRepo.SendInvitation(eventId, invitationId);
        }
        //testing stub for front end, mock data would be generated here.





    }


}
