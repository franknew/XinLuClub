import { Component } from '@angular/core';
import { Reply } from '../../../entities/reply';
import { ForumService } from '../../../services/forum.service';
import { ClientService } from '../../../services/client.service';
import { NotifyModel } from '../../ajax/NotifyModel';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { ActivatedRoute, ParamMap } from '@angular/router';

@Component({
    moduleId: module.id,
    selector: 'replydetaillist',
    templateUrl: 'replydetaillist.component.html',
})
export class ReplydetaillistComponent implements OnInit {

    records: Reply[] = [];
    preText: string;
    replyToUser: string;
    replyToID: string;
    replyToName: string;
    isShowenReplyPanel: boolean = false;
    loading: boolean = true;
    replyID: string;
    replyContent: string;

    constructor(private service: ForumService, 
        private client: ClientService,
        private route: ActivatedRoute,
    ) {}

    ngOnInit(): void {
        this.refreshData();
    }

    refreshData() {
        this.loading = true;
        let replyID = this.route.paramMap.switchMap((params: ParamMap)=> {
            return params.getAll("id");
        }).subscribe((id)=>{
            this.replyID = id;
        });
        
        let success = new NotifyModel();
        success.callback = (data)=> {
            this.records = [data];
            this.loading = false;
        }
        let failed = new NotifyModel();
        failed.callback = (error)=> {
            this.loading = false;
        }
        this.service.getReplyDetailList(this.replyID, [success], [failed]);
    }

    showReplyPanel(levelID: string, replyTo: string, replyToID: string, replyToName: string) {
        this.replyID = levelID;
        this.replyToUser = replyTo;
        this.isShowenReplyPanel = true;
        if (replyToID == null) this.preText = "";
        else this.preText = "回复 " + replyToName + ": "
        this.replyToID = replyToID;
        this.replyToName = replyToName;
    }

    replyTo() {
        this.loading = true;
        let content = this.preText;
        let contentArray = content.split(':');
        if (contentArray.length > 1) content = contentArray[1];
        this.reply(content, this.replyID);
    }

    reply(content: string, replyID: string) {
        let reply = new Reply();
        reply.Content = content;
        reply.ReplyID = replyID;
        reply.ReplyTo = this.replyToUser;
        reply.TopicID = this.records[0].TopicID;
        reply.ReplyToName = this.replyToName;
        reply.ReplyToID = this.replyToID;
        reply.OwnerName = this.client.getUser().Name;
        reply.CreateTime = new Date();

        let success = new NotifyModel();
        success.callback = (data, sender)=> {
            reply.ID = data;
            this.records[0].Children.push(reply);
            this.loading = false;
            this.replyContent = '';
            this.preText = '';
        }
        let failed = new NotifyModel();
        failed.callback = (error, sender)=> {
            this.loading = false;
        }

        this.service.addReply(reply, [success], [failed]);

    }
}
