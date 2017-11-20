import { Component } from '@angular/core';
import { CookieService } from 'angular2-cookie/services';
import { LoginService } from '../../../services/login.service';
import { Router } from '@angular/router';

@Component({
    moduleId: 'adminbanner',
    selector: 'adminbanner',
    templateUrl: 'adminbanner.component.html',
})
export class AdminbannerComponent {

    constructor(private cookie: CookieService, private service: LoginService, private router: Router) {
        
    }
        
    logout() {
        this.service.logout();
    }

    gotoForum() {
        this.router.navigate(["/index"]);
    }
}
