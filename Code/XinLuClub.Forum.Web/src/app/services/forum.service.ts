import { Reply } from '../entities/reply';
import { LoginService } from './login.service';
import { Component, Injectable } from '@angular/core';
import { AjaxComponent } from '../components/ajax/ajax.component';
import { NotifyModel } from '../components/ajax/NotifyModel';
import { HttpClient } from '@angular/common/http';
import { CookieService } from 'angular2-cookie/services/cookies.service';
import { Router, Routes, ActivatedRoute } from '@angular/router';
import { Topic } from '../entities/topic';
import { ClientService } from './client.service';
import { User } from '../entities/user';
import { BoardGroup } from '../entities/boardGroup';


@Component({
    template: ''
})
@Injectable()
export class ForumService {
    ajax: AjaxComponent;

    constructor(
        private http: HttpClient, 
        private cookie: CookieService, 
        private router: Router, 
        private loginService: LoginService,
        private client: ClientService,
    ) {
        this.ajax = new AjaxComponent(this.http);
        this.checkLogin();
    }

    checkLogin() {
        let token = this.client.getToken();
        if (token == null || token == '') this.client.RedirectToLogin();
    }

    publishTopic(topic: Topic, success: NotifyModel[], failed: NotifyModel[] = []) {
        let url = "/api/Topic/AddTopic"
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        topic["token"] = this.client.getToken();
        this.ajax.DoPost(url, topic , success, failed);
    }

    getIndexPage(success: NotifyModel[], failed: NotifyModel[] = []) {
        let url = "/api/Index/Index";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoGet(url, {}, success, failed);
    }

    getActiveTopicList(pageSize: number, currentPageIndex: number, success: NotifyModel[], failed: NotifyModel[] = []) {
        let url = "/api/Topic/GetActiveTopicList";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoGet(url, {pageSize: pageSize, currentPageIndex: currentPageIndex}, success, failed);
    }

    getNewestTopicList(pageSize: number, currentPageIndex: number, success: NotifyModel[], failed: NotifyModel[] = []) {
        let url = "/api/Topic/GetNewestTopicList";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoGet(url, {pageSize: pageSize, currentPageIndex: currentPageIndex}, success, failed);
    }

    getTopicListByBoard(boardID: string, pageSize: number, currentPageIndex: number, success: NotifyModel[], failed: NotifyModel[] = []) {
        let url = "/api/Topic/GetTopicListByBoard";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoGet(url, {pageSize: pageSize, currentPageIndex: currentPageIndex, boardID: boardID,}, success, failed);
    }

    addTopic(topic: Topic, success: NotifyModel[], failed: NotifyModel[]= []) {
        let url = "/api/Topic/AddTopic";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoPost(url, topic, success, failed);
    }

    getTopicDetail(topicID: string, pageSize: number, currentPageIndex: number,success: NotifyModel[], failed: NotifyModel[]= [])
    {
        let url = "/api/Topic/GetTopicDetail";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoGet(url, {topicID: topicID, pageSize: pageSize, currentPageIndex: currentPageIndex}, success, failed);
    }

    addReply(reply: Reply, success: NotifyModel[], failed: NotifyModel[]= []) {
        let url = "/api/Topic/AddReply";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoPost(url, reply, success, failed);
    }

    changeMyPassword(oldPassword: string, newPassword: string, success: NotifyModel[], failed: NotifyModel[] = []) {
        let url = "/api/Index/ChangeMyPassword";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoGet(url, {oldPassword: oldPassword, newPassword: newPassword}, success, failed);
    }

    updateMe(user: User, success: NotifyModel[], failed: NotifyModel[] = []) {
        let url = "/api/Index/UpdateMe";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoPost(url, user, success, failed);
    }

    getUserList(name: string, mobile: string, pageSize: number, currentPageIndex, success: NotifyModel[], failed: NotifyModel[] = []) {
        let url = "/api/Admin/GetUserList";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoPost(url, {Name: name, Mobile: mobile, PageSize: pageSize, CurrentIndex: currentPageIndex }, success, failed);
    }

    resetPassword(userID: string, password: string, success:NotifyModel[], failed: NotifyModel[] = []) {
        let url = "/api/Admin/ResetPassword";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoGet(url, {password: password, userID: userID }, success, failed);
    }

    addUser(user: User, success: NotifyModel[], failed: NotifyModel[] = []) {
        let url = "/api/Admin/AddUser";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoPost(url, user, success, failed);
    }

    updateUser(user: User, success: NotifyModel[], failed: NotifyModel[] = []) {
        let url = "/api/Admin/UpdateUser";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoPost(url, user, success, failed);
    }

    deleteUser(userID: string, success: NotifyModel[], failed: NotifyModel[] = []) {
        let url = "/api/Admin/DeleteUser";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoGet(url, {userID: userID}, success, failed);
    }

    addBoard(board: BoardGroup, success: NotifyModel[], failed: NotifyModel[] = []) {
        let url = "/api/Admin/AddBoard";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoPost(url, board, success, failed);
    }

    updateBoard(board: BoardGroup, success: NotifyModel[], failed: NotifyModel[] = []) {
        let url = "/api/Admin/UpdateBoard";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoPost(url, board, success, failed);
    }

    deleteBoard(boardID: string, success: NotifyModel[], failed: NotifyModel[] = []) {
        let url = "/api/Admin/DeleteBoard";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoPost(url, {boardID: boardID}, success, failed);
    }

    getBoardGroupList(success: NotifyModel[], failed: NotifyModel[] = []) {
        let url = "/api/Admin/GetBoardGroupList";
        failed.push(this.loginService.getLoginFailedNotify(this.cookie));
        this.ajax.DoGet(url, {}, success, failed);
    }
}
