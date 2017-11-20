import { Component, Input, Output, OnChanges, SimpleChanges, OnInit } from '@angular/core';
import { BoardGroup } from '../../../entities/boardGroup';
import { NotifyModel } from '../../ajax/NotifyModel';
import { ForumService } from '../../../services/forum.service';
import { Topic } from '../../../entities/topic';

@Component({
    moduleId: "forumpage",
    selector: 'forumpage',
    templateUrl: 'forumpage.component.html',
})
export class forumpageComponent  {
    records: Topic[] = [];
    boards: BoardGroup[] = [];

    constructor(private service: ForumService) {

    }
    
    pageSize:number = 30;
    currentPageIndex: number = 1;
    recordCount: number = 25;
    selectedMenuID: string = "-1";
    loading: boolean = false;

    @Input()
    set Records(records: any[]) {
        this.records = records
    }

    @Input()
    set CurrentPageIndex(currentPageIndex: number) {
        this.currentPageIndex = currentPageIndex;
    }

    @Input()
    set RecordCount(recordCount: number) {
        this.recordCount = recordCount;
    }

    @Input()
    set SelectedMenuID(selectedMenuID: string) {
        this.selectedMenuID = selectedMenuID;
    }

    @Input()
    set Boards(boards: BoardGroup[]) {
        this.boards = boards;
    }

    @Input()
    set PageSize(pageSize: number) {
        this.pageSize = pageSize;
    }

    active(event) {
        let a = event;
    }

    getActiveTopicList(boardID: string) {
        this.loading = true;
        this.selectedMenuID = boardID;
        let success = new NotifyModel();
        success.args = [this];
        success.callback = (data, sender)=> {
            this.records = data.List;
            this.recordCount = data.RecordCount;
            this.loading = false;
        }
        let failed = new NotifyModel();
        failed.callback = (error, sender)=> {
            this.loading = false;
        }
        switch (boardID) {
            case "-1":
            this.service.getActiveTopicList(30, 1, [success], [failed]);
            break;
            default:
            this.service.getTopicListByBoard(boardID, 30, 1, [success], [failed]);
            break;
        }
    }
}
