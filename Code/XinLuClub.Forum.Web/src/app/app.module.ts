import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RoutingModule } from './routing.module';
import { QuillEditorModule } from 'ng2-quill-editor';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgZorroAntdModule, NzFormItemDirective } from 'ng-zorro-antd';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NotfoundComponent } from './components/notfound/notfound.component';
import { ForumService } from './services/forum.service';
import { CookieService } from 'angular2-cookie/services/cookies.service';
import { HeadBannerComponent } from './components/head-banner/head-banner.component';
import { IndexComponent } from './components/client/index/index.component';
import { forumpageComponent } from './components/client/forumpage/forumpage.component';
import { Reply } from './entities/reply';
import { User } from './entities/user';
import { Token } from './entities/token';
import { Topic } from './entities/topic';
import { TopicgroupmenuComponent } from './components/client/topicgroupmenu/topicgroupmenu.component';
import { TopiclistComponent } from './components/client/topiclist/topiclist.component';
import { BoardtopiclistComponent } from './components/client/boardtopiclist/boardtopiclist.component';
import { LoginService }  from './services/login.service';
import { LoginpageComponent } from './components/loginpage/loginpage.component';
import { PublishtopicComponent } from './components/client/publishtopic/publishtopic.component';
import { DatePipe } from '@angular/common';
import { NewesttopiclistComponent } from './components/client/newesttopiclist/newesttopiclist.component';
import { ActivetopiclistComponent } from './components/client/activetopiclist/activetopiclist.component';
import { TopicdetailComponent } from './components/client/topicdetail/topicdetail.component';
import { ClientService } from './services/client.service';
import { AdminpageComponent } from './components/admin/adminpage/adminpage.component';
import { UserComponent } from './components/admin/user/user.component';
import { BoardgroupComponent } from './components/admin/boardgroup/boardgroup.component';
import { AdminbannerComponent } from './components/admin/adminbanner/adminbanner.component';
import { ChangemypasswordComponent } from './components/client/changemypassword/changemypassword.component';
import { ChangepasswordComponent } from './components/admin/changepassword/changepassword.component';
import { MyprofileComponent } from './components/myprofile/myprofile.component';
import { BaseEntity } from './entities/baseEntity';
import { BoardGroup } from './entities/boardGroup';
import { NotifyModel } from './components/ajax/NotifyModel';
import { AjaxComponent } from './components/ajax/ajax.component';
import { LoginResult } from './entities/loginResult';
import { Timer } from './components/timer/timer.component';
import { TopicGroup } from './entities/topicGroup';
import { SearchpageComponent } from './components/client/searchpage/searchpage.component';
import { MytopicsComponent } from './components/client/mytopics/mytopics.component';
import { MynewestreplyComponent } from './components/client/mynewestreply/mynewestreply.component';
import { ReplydetaillistComponent } from './components/client/replydetaillist/replydetaillist.component';

@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    HeadBannerComponent,
    forumpageComponent,
    TopicgroupmenuComponent,
    TopiclistComponent,
    BoardtopiclistComponent,
    LoginpageComponent,
    PublishtopicComponent,
    MyprofileComponent,
    NewesttopiclistComponent,
    ActivetopiclistComponent,
    TopicdetailComponent,
    AdminpageComponent,
    BoardgroupComponent,
    UserComponent,
    AdminbannerComponent,
    ChangemypasswordComponent,
    ChangepasswordComponent,
    NotfoundComponent,
    BaseEntity,
    BoardGroup,
    User,
    Topic,
    Reply,
    NotifyModel,
    AjaxComponent,
    Token,
    LoginResult,
    Timer,
    ClientService,
    LoginService,
    ForumService,
    TopicGroup,
    TopicdetailComponent,
    SearchpageComponent,
    MytopicsComponent,
    MynewestreplyComponent,
    ReplydetaillistComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    RoutingModule,
    HttpClientModule,
    NgZorroAntdModule.forRoot(),
    QuillEditorModule,
    ReactiveFormsModule,
  ],
  providers: [
    CookieService, 
    ForumService, 
    LoginService,
    DatePipe,
    ClientService,
    NzFormItemDirective,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
