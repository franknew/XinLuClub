import { Component } from '@angular/core';
import { BaseEntity } from './baseEntity';

@Component({
    template: ''
})
export class Token extends BaseEntity {
    AccessToken: string;
    ExpiredTime: Date;
}