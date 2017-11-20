import { Component, OnInit } from '@angular/core';
import { Topic } from '../../../entities/topic';
import { BoardGroup } from '../../../entities/boardGroup';
import { ActivatedRoute } from '@angular/router';
import { ForumService } from '../../../services/forum.service';
import { NotifyModel } from '../../ajax/NotifyModel';

@Component({
    moduleId: 'newesttopiclist',
    selector: 'newesttopiclist',
    templateUrl: 'newesttopiclist.component.html',
})
export class NewesttopiclistComponent implements OnInit {
    records: Topic[] =  [];
    currentPageIndex: number = 1;
    recordCount: number = 0;
    pageSize: number = 30;
    boardID: string;
    loading: boolean = false;

    constructor(private route: ActivatedRoute, private service: ForumService) {
    }

    public ngOnInit(): void {
        this.getTopicListByBoard();
    }

    getTopicListByBoard() {
        this.loading = true;
        let success = new NotifyModel();
        success.args = [this];
        success.callback = (data, sender)=> {
            this.records = data.List;
            this.recordCount = data.RecordCount;
            this.loading = false;
        }
        this.service.getNewestTopicList(this.pageSize, this.currentPageIndex, [success], []);
    }
}
