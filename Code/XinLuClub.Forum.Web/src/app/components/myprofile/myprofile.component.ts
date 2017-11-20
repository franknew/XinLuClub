import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ForumService } from '../../services/forum.service';
import { User } from '../../entities/user';
import { ClientService } from '../../services/client.service';
import { BoardGroup } from '../../entities/boardGroup';
import { NotifyModel } from '../ajax/NotifyModel';

@Component({
    moduleId: 'myprofile',
    selector: 'myprofile',
    templateUrl: 'myprofile.component.html',
})
export class MyprofileComponent implements OnInit {
    loading: boolean = false;
    isOpen: boolean = false;
    validateForm: FormGroup;
    user: User;
    
    constructor(private fb: FormBuilder, private service: ForumService, private client: ClientService) {
    }

    ngOnInit(): void {
        this.validateForm = this.fb.group({
            realName: [ ],
            weixin: [ ],
            mobile: [ ],
            identitycode: [ ],
            gender: [ ],
        });
        this.user = this.client.getUser();
    }
    
    showDialog() {
        this.isOpen = true;
    }

    save() {
        for (const key in this.validateForm.controls) {
          this.validateForm.controls[ key ].markAsDirty();
        }
        if (!this.validateForm.valid) return;
        this.loading = true;
        let success = new NotifyModel();
        success.callback = (data)=> {
            if (data) {
                this.loading = false;
                this.isOpen = false;
                this.client.saveUser(this.user);
            }
        }
        let failed = new NotifyModel();
        failed.callback = (error)=> {
            this.loading = false;
        }
        this.service.updateMe(this.user, [success], []);
    }

    close() {
        this.isOpen = false;
    }

    getFormControl(name: string) {
        return this.validateForm.controls[ name ];
    }
}
