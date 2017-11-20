import { Component, OnInit } from '@angular/core';
import { BoardGroup } from '../../../entities/boardGroup';
import { ForumService } from '../../../services/forum.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EditModeEnum } from '../../../entities/editModeEnum';
import { NotifyModel } from '../../ajax/NotifyModel';

@Component({
    moduleId: module.id,
    selector: 'boardgroup',
    templateUrl: 'boardgroup.component.html',
})
export class BoardgroupComponent implements OnInit {
    records: BoardGroup[] = [];
    displayDelete: boolean = false;
    displayEdit: boolean = false;
    deleteLoading: boolean = false;
    editLoading: boolean = false;
    validateForm: FormGroup;

    name: string;
    description: string;
    enabled: number = 1;
    editMode: EditModeEnum = EditModeEnum.None;
    selectedBoard: BoardGroup;
    loading: boolean = false;

    constructor(private service: ForumService, private fb: FormBuilder) {

    }

    ngOnInit(): void {
        this.validateForm = this.fb.group({
            name: [ null, [ Validators.required ] ],
            description: [ ],
            enabled: [],
        });
        this.getList();
    }

    getList() {
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
        this.service.getBoardGroupList([success], [failed]);
    }

    delete() {
        this.deleteLoading = true;
        let success = new NotifyModel();
        success.callback = (data)=> {
            let i = 0
            for (let b of this.records) {
                if (b.ID == this.selectedBoard.ID) {
                    this.records.splice(i, 1);
                    break;
                }
                i++;
            }
            this.displayDelete = false;
            this.deleteLoading = false;
        }

        let failed = new NotifyModel();
        failed.callback = (error)=> {
            this.deleteLoading = false;
        }
        this.service.deleteBoard(this.selectedBoard.ID, [success], [failed]);
    }

    add(board:BoardGroup, failed: NotifyModel) {
        let success = new NotifyModel();
        success.callback = (data)=> {
            board.ID = data;
            this.records.push(board);
            this.editLoading = false;
            this.displayEdit = false;
        }
        this.service.addBoard(board, [success], [failed]);
    }

    update(board:BoardGroup, failed: NotifyModel) {
        let success = new NotifyModel();
        success.callback = (data)=> {
            this.editLoading = false;
            this.displayEdit = false;
        }
        this.service.updateBoard(board, [success], [failed]);
    }

    toggleDelete(open: boolean, board: BoardGroup = null) {
        this.displayDelete = true;
        this.selectedBoard = board;

    }

    assignFrom(board: BoardGroup) {
        if (board == null) board = new BoardGroup();
        this.name = board.Name;
        this.description = board.Description;
        this.enabled = board.Enabled;
    }

    assignTo(board: BoardGroup): BoardGroup {
        board.Name = this.name;
        board.Enabled = this.enabled;
        board.Description = this.description;
        return board;
    }

    toggleEdit(open: boolean, board: BoardGroup = null) {
        if (!open) this.editMode = EditModeEnum.None;
        else {
            if (board == null) this.editMode = EditModeEnum.Add;
            else this.editMode = EditModeEnum.Update;
        }
        if (board == null) board = new BoardGroup();
        this.selectedBoard = board;
        this.assignFrom(this.selectedBoard);
        this.displayEdit = open;
    }
    
    save() {

        for (const key in this.validateForm.controls) {
            this.validateForm.controls[ key ].markAsDirty();
          }
        if (!this.validateForm.valid) return;

        this.editLoading = true;
        let board = this.assignTo(this.selectedBoard);
        let failed = new NotifyModel();
        failed.callback = (error)=> {
            this.editLoading = false;
        }
        switch (this.editMode) {
            case EditModeEnum.Add:
            this.add(board, failed);
            break;
            case EditModeEnum.Update:
            this.update(board, failed);
            break;
        }
    }

    getFormControl(name) {
        return this.validateForm.controls[ name ];
    }
}
