using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AngularSPA.Modules;
using AngularSPA.Repo;

namespace AngularSPA.MockRepo
{

    public class MockEventDataRepo : IEventDataRepo
    {
        public static List<EventData> eventDataList = new List<EventData>();
        private static int roundCounter = 5;

        public MockEventDataRepo()
        {
            GenerateEvent();
        }

        public void GenerateEvent()
        {
            var eventData = new EventData
            {
                EventId = 110,
                CreateTime = DateTime.UtcNow,
                Invitations = new List<Invitation>()
                {
                    new Invitation()
                    {
                        Id = 2000,
                        Name = "Cynthia Sims",
                        Email = "test1@test.com",
                        Mobile = "0403887667",
                        Content = "An invitation to you",
                        Status = InvitationStatus.Initial,
                        CreateTime = DateTime.UtcNow
                    },
                    new Invitation()
                    {
                        Id = 2001,
                        Name = "Nancy Myers",
                        Email = "test2@test.com",
                        Mobile = "0403887668",
                        Content = "An invitation to you",
                        Status = InvitationStatus.Initial,
                        CreateTime = DateTime.UtcNow
                    },
                    new Invitation()
                    {
                        Id = 2002,
                        Name = "Melissa Young",
                        Email = "test3@test.com",
                        Mobile = "0403887669",
                        Content = "An invitation to you",
                        Status = InvitationStatus.Initial,
                        CreateTime = DateTime.UtcNow
                    },
                    new Invitation()
                    {
                        Id = 2003,
                        Name = "Judith Davis",
                        Email = "test4@test.com",
                        Mobile = "0403887690",
                        Content = "An invitation to you",
                        Status = InvitationStatus.Initial,
                        CreateTime = DateTime.UtcNow
                    },
                    new Invitation()
                    {
                        Id = 2004,
                        Name = "Cynthia Morals",
                        Email = "test5@test.com",
                        Mobile = "0403887691",
                        Content = "An invitation to you",
                        Status = InvitationStatus.Initial,
                        CreateTime = DateTime.UtcNow
                    }
                }
            };
            eventDataList.Add(eventData);
        }


        // simplified operation without checking the eventId
        public EventData GetEventData(int eventId)
        {
            return eventDataList.FirstOrDefault(p => p.EventId == eventId);
        }


        /*
        public EventData GetEventData(int eventId, int scannedCounter = 0)
        {
            var counter = scannedCounter % roundCounter;
            switch (counter)
            {
                case 0:
                    return eventData;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    eventData.Invitations[counter].RequestSentTime = DateTime.UtcNow;
                    eventData.Invitations[counter].Status = InvitationStatus.Sent;
                    return eventData;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    eventData.Invitations[counter % eventData.Invitations.Count].ResponseTime = DateTime.UtcNow;
                    eventData.Invitations[counter % eventData.Invitations.Count].Status = InvitationStatus.Confirmed;
                    return eventData;

                case 11:
                case 12:
                    eventData.Invitations[counter % eventData.Invitations.Count].Status = InvitationStatus.Declined;
                    return eventData;

                default:
                    return eventData;

            }
           
        } */


        public (bool result, Invitation invitation) SendInvitation(int eventId, int invitationId)
        {
            var eventData = GetEventData(eventId);
            if (eventData == null)
            {
                return (false, null);
            }
            else 
            {
                var target = eventData.Invitations?.FirstOrDefault(p => p.Id == invitationId);
                if (target != null)
                {
                    target.Status = InvitationStatus.Sent;
                    target.RequestSentTime = DateTime.UtcNow;

                    // to be simple, just change the invitation status of the previous invitation.
                    // for test purpose only. just to show the changed response status
                    if(invitationId % 2 == 0)
                    {
                        ChangeInvitationStatus(eventId, invitationId - 1, InvitationStatus.Confirmed);
                    }
                    else
                    {
                        ChangeInvitationStatus(eventId, invitationId - 1, InvitationStatus.Declined);
                    }

                    return (true, target);
                }
                else
                {
                    return (false, target);
                }
            }
        }







        public (bool result, EventData eventData) ChangeInvitationStatus(int eventId, int invitationId, InvitationStatus targetStatus)
        {
            var eventData = GetEventData(eventId);
            if (eventData == null)
            {
                return (false, null);
            }

            var target = eventData.Invitations?.FirstOrDefault(p => p.Id == invitationId);
            if (target != null)
            {
                target.Status = targetStatus;
                if(targetStatus == InvitationStatus.Confirmed || targetStatus == InvitationStatus.Declined)
                {
                    target.ResponseTime = DateTime.UtcNow;
                }
                return (true, eventData);
            }
            else
            {
                return (false, eventData);
            }
        }

    }




}
