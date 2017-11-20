import { Component } from '@angular/core';
import { BaseEntity } from './baseEntity';

@Component({
    template: ''
})
export class BoardGroup extends BaseEntity {
    Name: string;
    Description: string;
    Enabled: number = 1;
}