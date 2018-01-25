import { Component } from '@angular/core';

@Component({
    selector: 'top-nav-menu',
    templateUrl: './topnavmenu.component.html',
    styleUrls: ['./topnavmenu.component.css']
})
export class TopNavMenuComponent {


    private userData: any = {
        userAvatarLink: '/images/avatars/avatar1.png',
        userName: 'Frances Howell',
        school: 'Brisbane Catholic School'
    }
    
}
