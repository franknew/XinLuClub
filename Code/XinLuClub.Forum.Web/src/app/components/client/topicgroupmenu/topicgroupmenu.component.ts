import { Component, Input, EventEmitter, Output } from '@angular/core';
import { Topic } from '../../../entities/topic';
import { BoardGroup } from '../../../entities/boardGroup';

@Component({
    moduleId: "topicgroupmenu",
    selector: 'topicgroupmenu',
    templateUrl: 'topicgroupmenu.component.html',
})
export class TopicgroupmenuComponent {
    records: Array<BoardGroup> = [];
    selectedMenuID: string = "-1";

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
