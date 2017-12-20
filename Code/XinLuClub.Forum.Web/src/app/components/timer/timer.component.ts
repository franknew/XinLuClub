import { Component } from '@angular/core';
import { NotifyModel } from '../ajax/NotifyModel';

@Component({
    moduleId: 'timer',
    selector: 'timer',
    template: '',
})
export class Timer {
    id: string;
    interval: number = 1000;
    private stopped: boolean = false;
    notify: NotifyModel;

    constructor(id: string, notify: NotifyModel, interval: number = 100) {
        this.id = id;
        this.notify = notify;
        this.interval = interval;
    }

    Start() {
        this.stopped = false;
        setTimeout(()=> {
            if (!this.stopped) {
                if (this.notify != null) this.notify.Notify([]);
                this.Start();
            }
        }, this.interval);
    }

    Stop() {
        this.stopped = true;
    }
}
