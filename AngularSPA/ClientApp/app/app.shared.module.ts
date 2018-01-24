import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { TopNavMenuComponent } from './components/navmenu/topnavmenu/topnavmenu.component';
import { HomeComponent } from './components/home/home.component';
import { BookEventComponent } from './components/event/bookevent/bookevent.component';
import { HttpService } from './shared/services/http.service';


@NgModule({
    declarations: [
        AppComponent,
        TopNavMenuComponent,
        HomeComponent,
        BookEventComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'book-event', component: BookEventComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        HttpService
    ]
    
})
export class AppModuleShared {
}
