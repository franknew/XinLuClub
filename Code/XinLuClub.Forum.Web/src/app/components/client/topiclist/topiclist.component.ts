import { Component, Input, EventEmitter, Output, OnInit } from '@angular/core';
import { Topic } from '../../../entities/topic';
import { DatePipe } from '@angular/common'
import { User } from '../../../entities/user';
import { ClientService } from '../../../services/client.service';

@Component({
    moduleId: "topiclist",
    selector: 'topiclist',
    templateUrl: 'topiclist.component.html',
    styles: [`
    .navbar-nav li:hover{
        display: block;
        background: green;
        padding: 10px;

    }
    `],
})
export class TopiclistComponent implements OnInit {
    pageSize = 20;
    recordCount = 0;
    currentPageIndex = 1;
    loading: boolean = false;
    records: Array<any> = [];
    searchContent: string;
    displayPagination: boolean = true;
    displayRefresh: boolean = true;

    constructor(private datePipe: DatePipe, private client: ClientService){
        
    }
    ngOnInit(): void {
    }

    @Input()
    set Records(records: any[]) {
      // tslint:disable-next-line:curly
      if (records == null) records = [];
      this.records = records;
    }
    @Input()
    set RecordCount(recordCount: number) {
        this.recordCount = recordCount;
    }
    @Input()
    set CurrentPageIndex(currentPageIndex: number) {
        this.currentPageIndex = currentPageIndex;
    }

    @Input()
    set PageSize(pageSize: number) {
        this.pageSize = pageSize;
    }
    @Input()
    set Loading(loading: boolean) {
        this.loading = loading;
    }
    @Input()
    set DisplayPagination(displayPagination: boolean) {
        this.displayPagination = displayPagination;
    }
    @Input()
    set DisplayRefresh(displayRefresh: boolean) {
        this.displayRefresh = displayRefresh;
    }

    @Output() PageIndexChanged = new EventEmitter<number>();
    @Output() Search = new EventEmitter<string>();
    @Output() OnRefresh = new EventEmitter<string>();

    pageIndexChanged(index: number) {
        this.PageIndexChanged.emit(index);
    }

    doSearch($event) {
        this.Search.emit(this.searchContent);
    }

    refresh($event) {
        this.OnRefresh.emit('');
    }
}
