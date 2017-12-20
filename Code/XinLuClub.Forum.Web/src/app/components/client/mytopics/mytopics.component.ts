import { Component, OnInit } from '@angular/core';
import { Topic } from '../../../entities/topic';
import { ForumService } from '../../../services/forum.service';
import { NotifyModel } from '../../ajax/NotifyModel';

@Component({
    moduleId: 'mytopics',
    selector: 'mytopics',
    templateUrl: 'mytopics.component.html',
})
export class MytopicsComponent implements OnInit {
    records: Topic[] = [];
    pageSize: number = 20;
    currentPageIndex: number = 1;
    recordCount: number = 0;
    loading: boolean = false;

    constructor(private service: ForumService) {}

    ngOnInit(): void {
        this.getMyTopicList();
    }

    pageIndexChanged(index: number) {
        this.currentPageIndex = index;
    }

    refreshData() {
        this.currentPageIndex = 1;
        this.getMyTopicList();
    }

    getMyTopicList() {
        this.loading = false;
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
        this.service.getMyTopicList(this.pageSize, this.currentPageIndex, [success], [failed]);
    }
}
