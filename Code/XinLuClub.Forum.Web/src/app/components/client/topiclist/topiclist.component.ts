import { Component, Input, EventEmitter, Output } from '@angular/core';
import { Topic } from '../../../entities/topic';
import { DatePipe } from '@angular/common'

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
export class TopiclistComponent {
    pageSize = 20;
    recordCount = 0;
    currentPageIndex = 1;
    loading: boolean = false;
    records: Array<any> = [];
    searchContent: string;

    constructor(private datePipe: DatePipe){
        
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
