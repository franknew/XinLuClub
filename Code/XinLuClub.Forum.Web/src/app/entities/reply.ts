import { Component } from '@angular/core';
import { User } from './user';
import { Topic } from './topic';
import { BaseEntity } from './baseEntity';

@Component({
    template: ''
})
export class Reply extends BaseEntity {
    Content: string;
    ReplyToName: string;
    OwnerName: string;
    CreateTime: Date;
    Children: Reply[] = [];
    TopicID: string;
    ReplyToID: string;
    ReplyTo: string;
    ReplyID: string;

}