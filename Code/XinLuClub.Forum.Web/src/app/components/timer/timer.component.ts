import { Component } from '@angular/core';
import { NotifyModel } from '../ajax/NotifyModel';

@Component({
    moduleId: 'timer',
    selector: 'timer',
    template: '',
})
export class Timer {
    interval: number = 100;
    Start(notify: NotifyModel) {
        setTimeout(()=> {
            if (notify != null) notify.Notify([]);
            this.Start(notify);
        }, this.interval);
    }
}
