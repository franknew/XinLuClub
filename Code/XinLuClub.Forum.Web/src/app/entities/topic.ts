import { Component } from '@angular/core';
import { BaseEntity } from './baseEntity';

@Component({
    template: ''
})
export class Topic extends BaseEntity {
    Name: string;
    Content: string;
    ReplyCount: number;
    BoardGroupID: string;
    OwnerID: string;
    OwnerName: string;
}