using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AngularSPA.Modules;

namespace AngularSPA.Repo
{

    public interface IEventDataRepo
    {
        void GenerateEvent();

        EventData GetEventData(int eventId);
        (bool result, Invitation invitation) SendInvitation(int eventId, int invitationId);

    }

}
