import { Component, OnInit } from '@angular/core';
import { User } from '../../../entities/user';
import { ForumService } from '../../../services/forum.service';
import { NotifyModel } from '../../ajax/NotifyModel';
import { BoardGroup } from '../../../entities/boardGroup';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { EditModeEnum } from '../../../entities/editModeEnum';

@Component({
    moduleId: module.id,
    selector: 'user',
    templateUrl: 'user.component.html',
})
export class UserComponent implements OnInit {
    records: User[] = [];
    boards: BoardGroup[] = [];
    pageSize: number = 30;
    currentPageIndex: number = 1;
    recordCount: number = 0;
    loading: boolean = false;
    resetPasswordLoading: boolean = false;
    deleteUserLoading: boolean = false;
    editUserLoading: boolean = false;
    saveUserLoading: boolean =  false;
    displayResetPassword: boolean = false;
    displayDelete: boolean = false;
    displayEditUser: boolean = false;
    password: string;
    selectedUser: User;
    validateForm: FormGroup;
    editUser: User = new User();
    searchName: string;
    searchMobile: string;

    name: string;
    mobile: string;
    userBoards: string[] = [];
    realName: string;
    gender: number = 1;
    identityCode: string;
    weixin: string;
    enabled: number = 1;
    isAdmin: number = 0;
    
    editMode: EditModeEnum = EditModeEnum.None;

    constructor(private service: ForumService, private fb: FormBuilder) {
        
    }

    ngOnInit(): void {

        this.validateForm = this.fb.group({
            name: [ null, [ Validators.required ] ],
            realName: [ null ],
            weixin: [ null ],
            mobile: [null ],
            identitycode: [null ],
            gender: [true ],
            enabled: [true],
            boards: [ null, [this.validateBoard]],
            isAdmin: [false ],
        });


        this.getUserList();
        this.getBoardList();
    }

    validateBoard = (control: FormControl): { [s: string]: boolean } => {
        if (!control.value) {
            return {required: true}
        }
        else if (control.value.length == 0) {
            return {required: true}
        }
    }

    toggleEditUser(open: boolean, user: User = null) {
        if (!open) this.editMode = EditModeEnum.None;
        else {
            if (user == null) this.editMode = EditModeEnum.Add;
            else this.editMode = EditModeEnum.Update;
        }
        if (user == null) user = new User();
        this.selectedUser = user;
        this.assignFromUser(user);
        this.displayEditUser = open;
        this.editUser = user;
    }

    assignFromUser(user: User) {
        this.name = user.Name;
        this.realName = user.RealName;
        this.gender = user.Gender;
        this.mobile = user.Mobile;
        this.weixin = user.WeiXin;
        this.enabled = user.Enabled;
        this.identityCode = user.IdentityCode;
        this.isAdmin = user.IsAdmin;
        this.userBoards = [];
        for (let b of user.Boards) {
            this.userBoards.push(b.ID);
        }
    }

    assignToUser(user: User): User {
        if (user == null) user = new User();
        user.Name = this.name;
        user.Enabled = this.enabled;
        user.RealName = this.realName;
        user.Gender = this.gender;
        user.Mobile = this.mobile;
        user.WeiXin = this.weixin;
        user.IsAdmin = this.isAdmin;
        user.IdentityCode = this.identityCode;
        user.Boards = [];
        if (this.userBoards == null) this.userBoards = [];
        for (let b of this.userBoards) {
            let board = new BoardGroup();
            board.ID = b;
            user.Boards.push(board);
        }
        return user;
    }

    saveUser() {

        for (const key in this.validateForm.controls) {
            this.validateForm.controls[ key ].markAsDirty();
          }
        if (!this.validateForm.valid) return;

        this.saveUserLoading = true;
        let user = this.assignToUser(this.selectedUser);
        let failed = new NotifyModel();
        failed.callback = (error)=> {
            this.saveUserLoading = true;
        }
        switch (this.editMode) {
            case EditModeEnum.Add:
            this.addUser(user, failed);
            break;
            case EditModeEnum.Update:
            this.updateUser(user, failed);
            break;
        }
    }

    addUser(user: User, failed: NotifyModel) {
        
        let success = new NotifyModel();
        success.callback = (data)=> {
            user.ID = data;
            this.records.push(user);
            this.saveUserLoading = true;
            this.displayEditUser = false;
        }
        this.service.addUser(user, [success], [failed]);
    }

    updateUser(user: User, failed: NotifyModel) {

        let success = new NotifyModel();
        success.callback = (data)=> {
            this.saveUserLoading = true;
            this.displayEditUser = false;
        }
        this.service.updateUser(user, [success], [failed]);
    }

    toggleDeleteUser(open: boolean, user: User = null) {
        this.selectedUser = user;
        this.displayDelete = open;
    }

    deleteUser() {
        this.deleteUserLoading = true;
        let success = new NotifyModel();
        success.callback = (data)=> {
            let i = 0
            for (let b of this.records) {
                if (b.ID == this.selectedUser.ID) {
                    this.records.splice(i, 1);
                    break;
                }
                i++;
            }
            this.deleteUserLoading = false;
            this.displayDelete = false;
        }
        let failed = new NotifyModel();
        failed.callback = (data)=> {
            this.deleteUserLoading = false;
        }
        this.service.deleteUser(this.selectedUser.ID, [success], [failed]);
    }

    toggleResetPassword(open: boolean, user: User = null) {
        this.selectedUser = user;
        this.password = null;
        this.displayResetPassword = open;
    }

    savePassword() {
        this.resetPasswordLoading = true;
        let success = new NotifyModel();
        success.callback = (data)=> {
            this.password = null;
            this.resetPasswordLoading = false;
            this.displayResetPassword = false;
        };
        let failed = new NotifyModel();
        failed.callback = (data)=> {
            this.resetPasswordLoading = false;
        };
        this.service.resetPassword(this.selectedUser.ID, this.password, [success], [failed]);
    }

    pageIndexChanged(index: number) {
        this.currentPageIndex = index;
        this.getUserList();
    }

    getUserList() {
        this.loading = true;
        let success = new NotifyModel();
        success.callback = (data)=> {
            this.records = data.List;
            this.recordCount = data.RecordCount;
            this.loading = false;
        }
        let failed = new NotifyModel();
        failed.callback = (error)=> {
            this.loading = false;
        }
        this.service.getUserList(this.name, this.mobile, this.pageSize, this.currentPageIndex, [success], [failed]);
    }

    getBoardList() {
        let success = new NotifyModel();
        success.callback = (data)=> {
            this.boards = data;
        }
        this.service.getBoardGroupList([success]);
    }

    getFormControl(name) {
        return this.validateForm.controls[ name ];
    }
}
