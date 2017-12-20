import { Component, Input, EventEmitter, Output } from '@angular/core';
import { Topic } from '../../../entities/topic';
import { BoardGroup } from '../../../entities/boardGroup';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { setTimeout } from 'timers';
import { ForumService } from '../../../services/forum.service';
import { NotifyModel } from '../../ajax/NotifyModel';
import { Timer } from '../../timer/timer.component';
import { TimerPool } from '../../timer/timerPool.component';

@Component({
    moduleId: "topicgroupmenu",
    selector: 'topicgroupmenu',
    templateUrl: 'topicgroupmenu.component.html',
})
export class TopicgroupmenuComponent implements OnInit {
    records: Array<BoardGroup> = [];
    selectedMenuID: string = "-1";
    replyCount: number = 0;

    constructor(private service: ForumService) {}

    ngOnInit(): void {
        let nofity = new NotifyModel();
        nofity.callback = ()=> {
            this.getMyUnreadReplyCount();
        }
        let timer = new Timer("topicgroupmenu", nofity, 10000);
        TimerPool.register(timer);
        timer.Start();
    }

    getMyUnreadReplyCount() {
        let success = new NotifyModel();
        success.callback = (data)=> {
            if (data == null) data = 0;
            this.replyCount = data;
        }
        this.service.getMyUnreadReplyCount([success]);

    }

    @Input()
    set SelectedMenuID(selectedMenuID: string) {
        this.selectedMenuID = selectedMenuID;
    }
    @Input()
    set Records(records: BoardGroup[]) {
        this.records = records;
    }

    @Output() OnMenuClick = new EventEmitter<string>(); 

    menuClick(id: string) {
        if (this.OnMenuClick != null) this.OnMenuClick.emit(id);
    }
}
