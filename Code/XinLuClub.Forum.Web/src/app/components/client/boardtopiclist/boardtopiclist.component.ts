import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Component, OnInit, OnChanges, SimpleChanges, AfterViewInit } from '@angular/core';
import 'rxjs/add/operator/switchMap';
import { NotifyModel } from '../../ajax/NotifyModel';
import { ForumService } from '../../../services/forum.service';
import { BoardGroup } from '../../../entities/boardGroup';
import { Topic } from '../../../entities/topic';
import { Timer } from '../../timer/timer.component';

@Component({
    moduleId: "boardtopiclist",
    selector: 'boardtopiclist',
    templateUrl: 'boardtopiclist.component.html',
})
export class BoardtopiclistComponent implements OnInit, OnChanges,  AfterViewInit {
    ngAfterViewInit(): void {
        let a = 1;
    }
    ngOnChanges(changes: SimpleChanges): void {
        for (let propName in changes) {
            let changedProp = changes[propName];
        }
    }
    records: Topic[] =  [];
    currentPageIndex: number = 1;
    recordCount: number = 0;
    pageSize: number = 30;
    boardID: string;
    boards: BoardGroup[] = [];
    loading: boolean = false;
    timer: Timer = new Timer();
    needLoad: boolean = false;

    constructor(private route: ActivatedRoute, private service: ForumService) {
    }

    public ngOnInit(): void {
        let notify = new NotifyModel();
        notify.callback = ()=> {
            let id = this.route.paramMap.switchMap((params: ParamMap)=> {
                let id = params.getAll('id');
                return id;
            }).subscribe((id)=>{
                if (id != null && this.boardID != id) {
                    this.boardID = id;
                    this.needLoad = true;
                }
                if (this.needLoad) {
                    this.needLoad = false;
                    this.getTopicListByBoard();
                }
            });
        };
        this.timer.Start(notify);
    }

    getTopicListByBoard() {
        this.loading = true;
        let success = new NotifyModel();
        success.args = [this];
        success.callback = (data, sender)=> {
            this.needLoad = false;
            this.records = data.List;
            this.recordCount = data.RecordCount;
            this.loading = false;
        }
        let failed = new NotifyModel();
        failed.callback = (error)=> {
            this.needLoad = false;
            this.loading = false;
            
        }
        this.service.getTopicListByBoard(this.boardID, this.pageSize, this.currentPageIndex, [success], [failed]);
    }

    pageIndexChanged(index: number) {
        this.currentPageIndex = index;
        this.getTopicListByBoard();
    }
}
