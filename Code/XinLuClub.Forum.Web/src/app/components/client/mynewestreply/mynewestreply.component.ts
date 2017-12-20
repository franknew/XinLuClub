import { Component } from '@angular/core';
import { Reply } from '../../../entities/reply';
import { NotifyModel } from '../../ajax/NotifyModel';
import { ForumService } from '../../../services/forum.service';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { ClientService } from '../../../services/client.service';

@Component({
    moduleId: 'mynewestreply',
    selector: 'mynewestreply',
    templateUrl: 'mynewestreply.component.html',
})
export class MynewestreplyComponent implements OnInit {
    records: Reply[] = [];
    pageSize: number = 20;
    recordCount: number = 0;
    currentPageIndex: number = 1;
    replyID: string;
    toggleList: string[] = [];
    preText: string;
    showReplyPanelID: string;
    topicID: string;
    replyToName: string;
    replyToID: string;
    loading: boolean = false;
    loadingID: string;
    replyContent: string;

    constructor(private service: ForumService, 
        private route: ActivatedRoute,
        private client: ClientService,    
    ) {}
    
    ngOnInit(): void {
        this.refreshData();
    }

    pageIndexChanged(index: number) {
        this.currentPageIndex = index;
        this.refreshData();
    }

    refreshData() {
        // let topicID = this.route.paramMap.switchMap((params: ParamMap)=> {
        //     return params.getAll("id");
        // }).subscribe((id)=>{
        //     this.replyID = id;
        // });
        let success = new NotifyModel();
        success.callback = (data)=>
        {
            this.records = data.List;
            this.recordCount = data.RecordCount
        }

        this.service.getMyReplies(this.pageSize, this.currentPageIndex, [success]);
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

    replyTo() {
        this.loadingID = this.showReplyPanelID;
        let content = this.preText;
        let contentArray = content.split(':');
        if (contentArray.length > 1) content = contentArray[1];
        this.reply(content, this.showReplyPanelID);
    }


    reply(content: string, replyID: string) {
        let reply = new Reply();
        reply.Content = content;
        reply.ReplyID = replyID;
        reply.TopicID = this.topicID;
        reply.ReplyToName = this.replyToName;
        reply.ReplyToID = this.replyToID;
        reply.OwnerName = this.client.getUser().Name;
        reply.CreateTime = new Date();

        let success = new NotifyModel();
        success.callback = (data, sender)=> {
            reply.ID = data;
            if (reply.ReplyID == '0' || reply.ReplyID == null) this.records.push(reply);
            else {
                for (let r of this.records) {
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
}
