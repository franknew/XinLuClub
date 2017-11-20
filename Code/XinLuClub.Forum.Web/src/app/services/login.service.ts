import { CookieService } from 'angular2-cookie/core';
import { AjaxComponent } from '../components/ajax/ajax.component';
import { Component, Injectable } from '@angular/core';
import { NotifyModel } from '../components/ajax/NotifyModel';
import { LoginResult } from '../entities/loginResult';
import { HttpClient } from '@angular/common/http';
import { NzNotificationService } from 'ng-zorro-antd';
import { User } from '../entities/user';
import { ClientService } from './client.service';
import { ActivatedRoute } from '@angular/router/src/router_state';
import { Router } from '@angular/router/src/router';


@Component({
    template: ''
})
@Injectable()
export class LoginService {
    ajax: AjaxComponent;

    constructor(private http: HttpClient, private notify: NzNotificationService, private client: ClientService) {
        this.ajax = new AjaxComponent(http);
    }

    login(userName: string, password: string, success: NotifyModel[], failed: NotifyModel[]) {
        let url = "/api/Login/Login";
        this.ajax.DoGet(url, {userName: userName, password: password}, success, failed);
    }

    logout() {
        this.client.removeToken();
        this.client.RedirectToLogin();
    }
    
    getLoginFailedNotify(cookie: CookieService): NotifyModel {
       let loginFailed = new NotifyModel();
        loginFailed.args = [this];
        loginFailed.callback = (error, sender)=> {
            if (error.status == 401) this.logout();
            else {
                this.notify.error("发生错误", error.error);
            }
        }
        return loginFailed;
    }
}