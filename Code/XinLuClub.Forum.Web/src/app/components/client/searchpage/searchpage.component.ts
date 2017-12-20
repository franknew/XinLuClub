import { Component } from '@angular/core';
import { Topic } from '../../../entities/topic';
import { ForumService } from '../../../services/forum.service';
import { NotifyModel } from '../../ajax/NotifyModel';

@Component({
    moduleId: module.id,
    selector: 'searchpage',
    templateUrl: 'searchpage.component.html',
})
export class SearchpageComponent {
    searchContent: string;
    records: Topic[] = [];
    loading: boolean = false;
    
    constructor(private service: ForumService) {

    }

    search() {
        this.loading = true;
        let success = new NotifyModel();
        success.callback = (data)=> {
            this.records = data;
            this.loading = false;
        }

        let failed = new NotifyModel();
        failed.callback = (error)=> {
            this.loading = false;
        }
        this.service.search(this.searchContent, [success],[failed]);
    }
}
