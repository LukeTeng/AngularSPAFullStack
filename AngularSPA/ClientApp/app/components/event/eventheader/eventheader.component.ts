import { Component, OnInit, Input } from '@angular/core';
import { EventHeader } from '../event.d';

@Component({
    selector: 'event-header',
    templateUrl: './eventheader.component.html',
    styleUrls: ['./eventheader.component.css']
})
export class EventHeaderComponent {

    private eventHeader: EventHeader;

    constructor() {
    }

    @Input() progressNumber: number = 0; 
    @Input() totalNumber: number = 0; 

    get progressValue() {
        if (this.totalNumber > 0) {
            return Math.round(this.progressNumber / this.totalNumber);
        }

        //return 0;
        //in order to show progress bar
        return 50;
    }



    ngOnInit() {
        this.eventHeader = {
            createdTime: 'Fri, July 3, 2017 at 8:30am',
            startTime: 'Wed 11 Oct 2017',
            numberOfTeacher: 1,
            teacherCovered: 'Mrs.Jones',
            classCovered: 'L1',
            reasonForAbsense: 'No Reason'
        }
    }





}
