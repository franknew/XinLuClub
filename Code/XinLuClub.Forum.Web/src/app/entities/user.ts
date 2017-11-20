import { Component } from '@angular/core';
import { BaseEntity } from './baseEntity';
import { BoardGroup } from './boardGroup';

@Component({
    template: ''
})
export class User extends BaseEntity {
    Name: string;
    Gender: number = 1;
    IdentityCode: string;
    Mobile: string;
    Enabled: number = 1;
    IsAdmin: number = 0;
    RealName: string;
    WeiXin: string;
    Boards: BoardGroup[] = [];
}