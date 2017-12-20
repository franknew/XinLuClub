import { Component } from '@angular/core';
import { NotifyModel } from '../ajax/NotifyModel';
import { Timer } from './timer.component';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
    moduleId: 'timerpool',
    selector: 'timerpool',
    template: '',
})
export class TimerPool {
    private static pool: Timer[] = [];

    public static start() {
        for (let t of TimerPool.pool) {
            t.Start()
        }
    }

    public static stop() {
        for (let t of TimerPool.pool) {
            t.Stop()
        }
    }

    public static register(timer: Timer) {
        let hasTimer = false;
        for (let t of TimerPool.pool) {
            if (t.id == timer.id) {
                hasTimer = true;
                break;
            }
        }
        if (!hasTimer) TimerPool.pool.push(timer);
    }
}