import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../../shared/services/http.service';
import { EventData, Invitation } from './event.d';

export enum Status {
    Initial = 10,
    Sending = 20,
    Sent = 30,
    Declined = 40,
    Confirmed = 50,
    Expired = 60,
    Others = 100
}

@Component({
    selector: 'counter',
    templateUrl: './bookevent.component.html'
})
export class BookEventComponent {

    constructor(private httpService: HttpService) {
    }

    private eventData: EventData;
    private timeOutSeconds_Start: number = 10;
    private timeOut_Invitation: number = 10;
    private timeOutSeconds_Intervals: number = 25;
    private sendInvFlag: boolean = false;
    private maxLoopCount = 100;
    private currentLoopNum = 0;

    ngOnInit() {
    }

    private async start() {
        this.eventData = await this.getEventData();
        if (this.eventData && this.eventData.eventId) {
            setTimeout(() => {
                this.sendInvFlag = true;
                this.sendInvitation();
            }, 1000 * this.timeOutSeconds_Start);

            setTimeout(() => {
                this.getEventData();
            }, 1000 * this.timeOutSeconds_Intervals);
        }
    }


    private async getEventData(): Promise<EventData> {
        const result = await this.httpService.post("/api/Events/Get", { eventId: 110 });
        //console.log('event data, ', result);
        return result;
    }

    private async sendInvitation() {
        let unsentInv = this.getUnsentInv();
        console.log('get unsend, ', unsentInv);
        if (unsentInv) {
            await this.apiSendInvitation(unsentInv);
            //total try protection ?????????
            setTimeout(() => {
                this.sendInvitation();
            }, 1000 * this.timeOut_Invitation);
        }
    }

    private getUnsentInv(): Invitation | null {
        let unsendInvs = this.eventData.invitations.filter(p => Number(p.status) === Status.Initial || Number(p.status) === Status.Others );
        if (unsendInvs && unsendInvs.length > 0) {
            return unsendInvs[0];
        }
        return null;
    }

    private async apiSendInvitation(inv: Invitation): Promise<void>{
        const result = await this.httpService.post("/api/Events/SendInvitation", { eventId: this.eventData.eventId, invitationId: inv.id });
        this.resetInvitation(result);
        console.log('event data, ', result, this.eventData);
    }

    private resetInvitation(inv: Invitation) {
        this.eventData.invitations.forEach((invItem, index) => {
            if (invItem.id === inv.id) {
                this.eventData.invitations.splice(index, 1, inv);
            }
        })
    }


    private getStatusString(status: Status): string {
        return Status[status];
    }

}
