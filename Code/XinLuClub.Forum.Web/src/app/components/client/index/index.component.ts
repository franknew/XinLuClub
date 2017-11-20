import { Component, TemplateRef, OnInit } from '@angular/core';
import { ForumService } from '../../../services/forum.service';
import { NotifyModel } from '../../ajax/NotifyModel';
import { BoardGroup } from '../../../entities/boardGroup';

@Component({
    moduleId: "index",
    selector: 'index',
    templateUrl: "index.component.html"
})
export class IndexComponent implements OnInit {
    constructor(private service: ForumService){
        //this.service.checkLogin();
    }

    ngOnInit(): void {
        this.initPage();
    }

    records: any[] =  [];
    boards: BoardGroup[] = [];
    recordCount: number = 0;
    currentPageIndex: number = 1;
    
    initPage() {
        let success = new NotifyModel();
        success.args = [this];
        success.callback = (data, sender)=> {
            this.records = data.NewestTopics.List;
            this.recordCount = data.NewestTopics.RecordCount;
            this.boards = data.BoardGroups;
        };
        this.service.getIndexPage([success], []);
    }
}
