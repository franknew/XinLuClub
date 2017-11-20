import { LoginService } from '../../services/login.service';
import { Component, Input, OnInit } from '@angular/core';
import { NgModule } from '@angular/core';
import { CookieService } from 'angular2-cookie/services/cookies.service';
import { ForumService } from '../../services/forum.service';
import { Router } from '@angular/router';
import { BoardGroup } from '../../entities/boardGroup';
import { ClientService } from '../../services/client.service';

@Component({
    moduleId: 'headerBanner',
    // tslint:disable-next-line:component-selector
    selector: 'head-banner',
    templateUrl: 'head-banner.component.html',
})
export class HeadBannerComponent implements OnInit {
    boards: BoardGroup[] = [];
    selectedMenuID: string;
    isAdmin: number = 0;

    constructor(private cookie: CookieService, private service: LoginService, private router: Router, private client: ClientService) {   
    }
    
    ngOnInit(): void {
        let user = this.client.getUser();
        this.isAdmin = user.IsAdmin;
    }

    logout() {
        this.service.logout();
    }

    gotoAdmin() {
        this.router.navigate(['/admin'])
    }

    @Input()
    set Boards(boards: BoardGroup[]) {
        this.boards = boards;
    }
    @Input()
    set SelectedMenuID(selectedMenuID: string) {
        this.selectedMenuID = selectedMenuID;
    }

    gotoForum() {
        this.router.navigate(["/index"]);
    }
}
