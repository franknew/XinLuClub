import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ForumService } from '../../../services/forum.service';
import { NotifyModel } from '../../ajax/NotifyModel';

@Component({
    moduleId: 'changemypassword',
    selector: 'changemypassword',
    templateUrl: 'changemypassword.component.html',
})
export class ChangemypasswordComponent implements OnInit {
    oldPassword: string;
    newPassword: string;
    confirmPasssword: string;
    validateForm: FormGroup;
    isOpen: boolean = false;
    loading: boolean = false;

    constructor(private fb: FormBuilder, private service: ForumService) {
    }

    checkConfirmPassword = (control: FormControl): { [s: string]: boolean } => {
        if (!control.value) {
            return { required: true };
        }
        else if (control.value !== this.validateForm.controls["newPassword"].value) {
            return { confirm: true, error: true }
        }
    }
    submitForm($event, value) {
        $event.preventDefault();
        for (const i in this.validateForm.controls) {
            this.validateForm.controls[ i ].markAsDirty();
        }
    }

    ngOnInit(): void {
        this.validateForm = this.fb.group({
            oldPassword         : [ null, [ Validators.required ] ],
            newPassword         : [ null, [ Validators.required ] ],
            confirmPassword     : [ null, [ Validators.required, this.checkConfirmPassword ] 
        ],
        });
    }
    showDialog() {
        this.isOpen = true;
    }

    close() {
        this.oldPassword = null;
        this.newPassword = null;
        this.confirmPasssword = null;
        this.isOpen = false;
    }

    changeMyPassword() {
        for (const i in this.validateForm.controls) {
            this.validateForm.controls[ i ].markAsDirty();
        }
        if (this.validateForm.valid) {
            this.loading = true;
            let success = new NotifyModel();
            success.callback = (data, sender)=> {
                if (data) {
                    this.oldPassword = null;
                    this.newPassword = null;
                    this.confirmPasssword = null;
                    this.loading = false;
                    this.isOpen = false;
                }
            }
            let failed = new NotifyModel();
            failed.callback = (error)=> {
                this.loading = false;
            }
            this.service.changeMyPassword(this.oldPassword, this.newPassword, [success], [failed]);
        }
    
    }

    getFormControl(name: string) {
        return this.validateForm.controls[ name ];
    }
}
