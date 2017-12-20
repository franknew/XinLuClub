
import { NgModule } from '@angular/core';
import { AjaxComponent } from './ajax.component';
import { NotifyModel } from './NotifyModel';


@NgModule({
    declarations: [
        AjaxComponent,
        NotifyModel,
    ],
    imports: [
        AjaxComponent,
    ],
    providers: [
    ],
    bootstrap: []
  })
  export class AjaxModule { }