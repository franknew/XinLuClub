import { Component, OnInit } from '@angular/core';
import { Topic } from '../../../entities/topic';
import { Reply } from '../../../entities/reply';
import { ForumService } from '../../../services/forum.service';
import { CookieService } from 'angular2-cookie/core';
import { Router, Routes, ParamMap, ActivatedRoute } from '@angular/router';
import { NotifyModel } from '../../ajax/NotifyModel';
import { ClientService } from '../../../services/client.service';
import { PublishtopicComponent } from '../publishtopic/publishtopic.component';
import { User } from '../../../entities/user';

@Component({
    moduleId: 'topicdetail',
    selector: 'topicdetail',
    templateUrl: 'topicdetail.component.html',
})
export class TopicdetailComponent implements OnInit {
    topic: Topic = new Topic();
    replies: Reply[] = [];
    recordCount: number = 0;
    pageSize: number = 30;
    currentPageIndex: number = 1;
    loading: boolean = false;
    showReplyPanelID: string;
    topicID: string;
    replyContent: string;
    preText: string;
    replyToID: string;
    replyToName: string;
    loadingID: string;
    toggleList: string[] = [];
    displayDelete: boolean = false;
    me: User;
    deleteLoading: boolean = false;
    replyToUser: string;

    editorOptions = {
        placeholder: "请输入你要回复的信息",
        height: 500,
      };

    constructor(private service: ForumService, 
        private route: ActivatedRoute,
        private client: ClientService,
        private router: Router,
    ) {

    }
    
    ngOnInit(): void {
        this.refreshData();
        this.me = this.client.getUser();
    }

    replyOwner() {
        this.loading = true;
        this.reply(this.replyContent, '0');
    }
    
    replyTo() {
        this.loadingID = this.showReplyPanelID;
        let content = this.preText;
        let contentArray = content.split(':');
        if (contentArray.length > 1) content = contentArray[1];
        this.reply(content, this.showReplyPanelID);
    }

    showReplyPanel(levelID: string, replyToUser: string, replyToID: string, replyToName: string) {
        this.showReplyPanelID = levelID;
        if (replyToID == null) this.preText = "";
        else this.preText = "回复 " + replyToName + ": "
        this.replyToID = replyToID;
        this.replyToUser = replyToUser;
        this.replyToName = replyToName;
    }

    reply(content: string, replyID: string) {
        let reply = new Reply();
        reply.Content = content;
        reply.ReplyID = replyID;
        reply.TopicID = this.topicID;
        reply.ReplyToName = this.replyToName;
        reply.ReplyToID = this.replyToID;
        reply.ReplyTo = this.replyToUser;
        reply.OwnerName = this.client.getUser().Name;
        reply.CreateTime = new Date();

        let success = new NotifyModel();
        success.callback = (data, sender)=> {
            reply.ID = data;
            if (reply.ReplyID == '0' || reply.ReplyID == null) this.replies.push(reply);
            else {
                for (let r of this.replies) {
                    if (r.ID == reply.ReplyID) {
                        r.Children.push(reply);
                        break;
                    }
                }
            }
            this.togleHide(true, this.showReplyPanelID);
            this.showReplyPanelID = null;
            this.loadingID = null;
            this.loading = false;
            this.replyContent = '';
            this.preText = '';
        }
        let failed = new NotifyModel();
        failed.callback = (error, sender)=> {
            this.loading = false;
            this.loadingID = null;
        }

        this.service.addReply(reply, [success], [failed]);

    }

    refreshData() {
        this.loading = true;
        this.topicID = "";
        let topicID = this.route.paramMap.switchMap((params: ParamMap)=> {
            return params.get("id");
        }).subscribe((id)=>{
            this.topicID += id;
        });
        let success = new NotifyModel();
        success.callback = (data, sender)=> {
            this.topic = data.Topic;
            this.replies = data.Replies.List;
            this.recordCount = data.Replies.RecordCount;
            this.loading = false;
        }
        this.service.getTopicDetail(this.topicID, this.pageSize, this.currentPageIndex, [success], []);
    }

    togleHide(toggle: boolean, toggleID: string) {
        if (!toggle) {
            this.toggleList.push(toggleID);
        }
        else {
            var i = 0;
            for (let t of this.toggleList) {
                if (t == toggleID) {
                    this.toggleList.splice(i, 1);
                    break;
                }
                i++;
            }
        }
    }

    containsToggle(toggleID: string): boolean {
        for (let t of this.toggleList) {
            if (t == toggleID) return true;
        }
        return false;
    }

    pageIndexChanged(index: number) {
        this.currentPageIndex = index;
        this.refreshData();
    }
    
    toggleDelete(show: boolean) {
        this.displayDelete = show;
    }

    delete() {
        this.deleteLoading = true;
        let success = new NotifyModel();
        success.callback = (data)=> {
            this.deleteLoading = false;
            this.displayDelete = false;
            this.router.navigate(["/index"]);
        }
        let failed = new NotifyModel();
        failed.callback = (error)=> {
            this.deleteLoading = false;
        }
        this.service.deleteTopic(this.topic.ID, [success], [failed]);
    }
}
