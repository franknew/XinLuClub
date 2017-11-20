import { ForumService } from '../../../services/forum.service';
import { NzModalService, NzModalSubject } from 'ng-zorro-antd';
import { Component, EventEmitter, Input, TemplateRef, ViewChild } from '@angular/core';
import { Topic } from '../../../entities/topic';
import { NotifyModel } from '../../ajax/NotifyModel';
import { BoardGroup } from '../../../entities/boardGroup';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';

@Component({
    moduleId: 'publishtopic',
    selector: 'publishtopic',
    templateUrl: 'publishtopic.component.html',
    styleUrls: ['publishtopic.component.scss'],
})
export class PublishtopicComponent {
    boardID: string;
    topicTitle: string;
    topicContent: string;
    modal: NzModalSubject;
    boards: BoardGroup[] = [];
    saveLoading: boolean = false;
    showError: boolean = false;
    errorMessage: string;
    validateForm: FormGroup;
    editorOptions = {
        placeholder: "请输入你要发布的信息",
        height: 500,
      };

      defaultModules = {
        toolbar: [
          ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
    
          ['clean'],                                         // remove formatting button
    
          ['link', 'image', 'video']                         // link and image, video
        ]
    }
    @ViewChild("title") 
    title: TemplateRef<any>;
    @ViewChild("footer")
    footer: TemplateRef<any>; 
    @ViewChild("content")
    content: TemplateRef<any>; 

    constructor(private modalService: NzModalService, private service: ForumService, private fb: FormBuilder) {
        this.validateForm = this.fb.group({
            boardID: [ '-1', [ this.validateBoard ] ],
            topicTitle: [ null, [ Validators.required ] ],
            topicContent: [ null, [ Validators.required ] ],
        });
    }

    validateBoard = (control: FormControl): { [s: string]: boolean } => {
        if (!control.value) {
            return { required: true };
        }
        else if (control.value == '-1') {
            return { required: true, error: true };
        }
    }

    validate() {
        for (const key in this.validateForm.controls) {
            this.validateForm.controls[ key ].markAsDirty();
        }
        return this.validateForm.valid;
    }
    
    publish() {
        if (!this.validate()) return;

        this.saveLoading = true;
        let topic = new Topic();
        topic.Content = this.topicContent;
        topic.Name = this.topicTitle;
        topic.BoardGroupID = this.boardID;
        let success = new NotifyModel();
        success.args = [this];
        success.callback = (data, sender)=> {
            this.saveLoading = false;
            this.close();
        };
        let failed = new NotifyModel();
        failed.callback = (error, sender)=> {
            this.errorMessage = error.error;
            this.saveLoading = false;
        }
        this.service.addTopic(topic, [success], [failed]);
    }

    open() {
        this.modal = this.modalService.open({
            title       : this.title,
            content     : this.content,
            footer      : this.footer,
            maskClosable: false,
            width       : 800,
            wrapClassName: "vertical-center-modal",
            zIndex      :101,
          });
    }

    close() {
        this.modal.destroy('onOk');
        this.modal = null;
    }

    @Input()
    set SelectedMenuID(boardID: string) {
        this.boardID = boardID;
    }
    @Input()
    set Boards(boards: any[]) {
        if (boards == null) boards = [];
        this.boards = boards;
    }

    getFormControl(name) {
        return this.validateForm.controls[name];
    }
}
