import { LoginService } from '../../services/login.service';
import { Router } from '@angular/router';
import { CookieService } from 'angular2-cookie/core';
import { NzModalService, NzModalSubject } from 'ng-zorro-antd';
import { Component, TemplateRef, ViewChild } from '@angular/core';
import { User } from '../../entities/user';
import { NotifyModel } from '../ajax/NotifyModel';
import { ClientService } from '../../services/client.service';

@Component({
    moduleId: 'loginpage',
    selector: 'loginpage',
    templateUrl: 'loginpage.component.html',
})
export class LoginpageComponent {
    modal: NzModalSubject;
    userName: string;
    password: string;
    user: User;
    errorMessage: string;
    loginLoading: boolean = false;
    
    @ViewChild("title") 
    title: TemplateRef<any>;
    @ViewChild("footer")
    footer: TemplateRef<any>; 
    @ViewChild("content")
    content: TemplateRef<any>; 

    constructor(
        private modalService: NzModalService, 
        private router: Router,
        private service: LoginService,
        private client: ClientService
    ) {
    }

    ngAfterViewInit(): void {
        setTimeout(()=>{
            this.openDialog();
        }, 100);
    }

    openDialog() {

        this.modal = this.modalService.open({
            title       : this.title,
            content     : this.content,
            footer      : this.footer,
            maskClosable: false,
            closable    : false,
            wrapClassName: "vertical-center-modal",
          });
    }

    login() {
        this.loginLoading = true;
        this.errorMessage = null;
        let success = new NotifyModel();
        success.args = [this];
        success.callback = (data, sender)=> {
            this.client.saveToken(data.Token.AccessToken);
            this.client.saveUser(data.User);
            this.user = data.User;
            this.loginLoading = false;
            this.closeDialog();
            if (this.user.IsAdmin) this.router.navigate(['/admin']);
            else this.router.navigate(['/index']); 
        };
        let failed = new NotifyModel();
        failed.args = [this];
        failed.callback = (error, sender)=> {
            this.errorMessage = error.error;
            this.loginLoading = false;
        }
        this.service.login(this.userName, this.password, [success], [failed]);
    }

    closeDialog() {
        this.modal.destroy('onOk');
        this.modal = null;
    }

    keyPress(event: KeyboardEvent) {
        if (event.keyCode == 13) {
            this.login();
        }
    }
}
