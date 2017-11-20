import { Reply } from '../entities/reply';
import { LoginService } from './login.service';
import { Component, Injectable } from '@angular/core';
import { AjaxComponent } from '../components/ajax/ajax.component';
import { NotifyModel } from '../components/ajax/NotifyModel';
import { HttpClient } from '@angular/common/http';
import { CookieService } from 'angular2-cookie/services/cookies.service';
import { Router, Routes, ActivatedRoute } from '@angular/router';
import { Topic } from '../entities/topic';
import { User } from '../entities/user';


@Component({
    template: ''
})
@Injectable()
export class ClientService {
    tokenKey = '__xinluclub_form_token';
    userKey = '__xinluclbu_form_user';

    constructor(private cookie: CookieService, private router: Router) {

    }

    saveToken(token: string) {
        this.cookie.put(this.tokenKey, token);
    }

    removeToken() {
        this.cookie.remove(this.tokenKey);
    }

    getToken(): string {
        return this.cookie.get(this.tokenKey);
        // return null;
    }

    saveUser(user: User) {
        this.cookie.put(this.userKey, JSON.stringify(user));
    }

    getUser(): User {
        let json = this.cookie.get(this.userKey);
        if (json == null) return null;
        let user = JSON.parse(json);
        return user;
        // return null;
    }
    
    RedirectToLogin() {
        this.router.navigate(['/login']);
    }
}