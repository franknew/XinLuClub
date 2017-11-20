import { Component } from '@angular/core';
import { Topic } from '../../../entities/topic';
import { ActivatedRoute } from '@angular/router';
import { ForumService } from '../../../services/forum.service';
import { NotifyModel } from '../../ajax/NotifyModel';

@Component({
    moduleId: 'activetopiclist',
    selector: 'activetopiclist',
    templateUrl: 'activetopiclist.component.html',
})
export class ActivetopiclistComponent {
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
        this.service.getActiveTopicList(this.pageSize, this.currentPageIndex, [success], []);
    }


    pageIndexChanged(index: number) {
        this.currentPageIndex = index;
        this.getTopicListByBoard();
    }
}
